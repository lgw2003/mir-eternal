using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Maps;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer.Templates
{
    /// <summary>
    /// 技能实例
    /// </summary>
    public class SkillInstance
    {
        public 游戏技能 技能模板;
        public SkillData 技能数据;
        public MapObject 技能来源;
        public byte 动作编号;
        public byte 分段编号;
        public MapInstance 释放地图;
        public MapObject 技能目标;
        public Point 技能锚点;
        public Point 释放位置;
        public DateTime 释放时间;
        public SkillInstance 父类技能;
        public bool 目标错位;
        public Dictionary<int, 命中详情> 命中列表;
        public int 飞行耗时;
        public int 攻速缩减;
        public bool 经验增加;
        public DateTime 处理计时;
        public DateTime 预约时间;
        public SortedDictionary<int, SkillTask> 节点列表;

        public int 来源编号 => 技能来源.ObjectId;
        public byte 分组编号 => 技能模板.技能分组编号;
        public byte 铭文编号 => 技能模板.自身铭文编号;
        public ushort 技能编号 => 技能模板.自身技能编号;
        public byte 技能等级
        {
            get
            {
                if (技能模板.绑定等级编号 == 0) return 0;

                if (技能来源 is PlayerObject playerObj && playerObj.MainSkills表.TryGetValue(技能模板.绑定等级编号, out var skillData))
                    return skillData.SkillLevel.V;

                if (技能来源 is TrapObject trapObj && trapObj.TrapSource is PlayerObject playerObj2 && playerObj2.MainSkills表.TryGetValue(技能模板.绑定等级编号, out var skillData2))
                    return skillData2.SkillLevel.V;

                return 0;
            }
        }
        public bool 检查计数 => 技能模板.检查技能计数;

        public bool 是否开关技能 { get; }

        public SkillInstance(MapObject 技能来源, 游戏技能 技能模板, SkillData 技能数据, byte 动作编号, MapInstance 释放地图, Point 释放位置, MapObject 技能目标,
            Point 技能锚点, SkillInstance 父类技能, Dictionary<int, 命中详情> 命中列表 = null, bool 目标错位 = false)
        {
            this.技能来源 = 技能来源;
            this.技能模板 = 技能模板;
            this.技能数据 = 技能数据;
            this.动作编号 = 动作编号;
            this.释放地图 = 释放地图;
            this.释放位置 = 释放位置;
            this.技能目标 = 技能目标;
            this.技能锚点 = 技能锚点;
            this.父类技能 = 父类技能;
            释放时间 = MainProcess.CurrentTime;
            this.目标错位 = 目标错位;
            this.命中列表 = (命中列表 ?? new Dictionary<int, 命中详情>());
            节点列表 = new SortedDictionary<int, SkillTask>(技能模板.节点列表);

            if (技能数据 != null && 技能数据.铭文模板.开关技能列表.Count > 0 && 游戏技能.DataSheet.TryGetValue(技能数据.铭文模板.开关技能列表[0], out 游戏技能 switchSkill) && 技能模板 != switchSkill)
            {
                var switchReleaseSkill = switchSkill.节点列表
                    .Select(x => x.Value)
                    .OfType<B_01_技能释放通知>()
                    .FirstOrDefault();

                if (switchReleaseSkill != null)
                {
                    是否开关技能 = true;
                    this.技能来源.Coolings[技能编号 | 16777216] = 释放时间.AddMilliseconds(switchReleaseSkill.自身冷却时间);
                    this.技能来源.Coolings[switchSkill.绑定等级编号 | 16777216] = 释放时间.AddMilliseconds(switchReleaseSkill.自身冷却时间);
                    if (this.技能来源 is PlayerObject playerObj)
                    {
                        playerObj.ActiveConnection.发送封包(new 同步技能计数
                        {
                            SkillId = switchSkill.绑定等级编号,
                            SkillCount = this.技能数据.RemainingTimeLeft.V,
                            技能冷却 = switchReleaseSkill.自身冷却时间
                        });
                    }
                }
            }

            if (节点列表.Count != 0)
            {
                this.技能来源.SkillTasks.Add(this);
                预约时间 = 释放时间.AddMilliseconds(飞行耗时 + 节点列表.First().Key);
            }
        }

        public void 任务处理()
        {
            if ((预约时间 - 处理计时).TotalMilliseconds > 5.0 && MainProcess.CurrentTime < 预约时间)
                return;

            var keyValuePair = 节点列表.First();
            节点列表.Remove(keyValuePair.Key);

            SkillTask task = keyValuePair.Value;
            处理计时 = 预约时间;

            if (task != null)
            {
                if (task is A_00_触发子类技能 a_00)
                {
                    if (游戏技能.DataSheet.TryGetValue(a_00.触发技能名字, out 游戏技能 skill))
                    {

                        bool flag = true;

                        if (a_00.计算触发概率)
                        {
                            flag = !a_00.计算幸运概率
                                ? ComputingClass.CheckProbability(a_00.技能触发概率 + ((a_00.增加概率Buff == 0 || !技能来源.Buffs.ContainsKey(a_00.增加概率Buff)) ? 0f : a_00.Buff增加系数))
                                : ComputingClass.CheckProbability(ComputingClass.计算幸运(技能来源[GameObjectStats.幸运]));
                        }

                        if (flag && a_00.验证自身Buff)
                        {
                            if (!技能来源.Buffs.ContainsKey(a_00.自身Buff编号))
                                flag = false;
                            else if (a_00.触发成功移除)
                                技能来源.移除Buff时处理(a_00.自身Buff编号);
                        }

                        if (flag && a_00.验证铭文技能 && 技能来源 is PlayerObject playerObj)
                        {
                            int num = a_00.所需铭文编号 / 10;
                            int num2 = a_00.所需铭文编号 % 10;
                            flag = playerObj.MainSkills表.TryGetValue((ushort)num, out var v)
                                && ((!a_00.同组铭文无效) ? (num2 == 0 || num2 == v.Id) : (num2 == v.Id));
                        }

                        if (flag)
                        {
                            switch (a_00.技能触发方式)
                            {
                                case SkillTriggerMethod.原点位置绝对触发:
                                    new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, 释放位置, 技能目标, 释放位置, this);
                                    break;
                                case SkillTriggerMethod.锚点位置绝对触发:
                                    new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, 释放位置, 技能目标, 技能锚点, this);
                                    break;
                                case SkillTriggerMethod.刺杀位置绝对触发:
                                    new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, 释放位置, 技能目标, ComputingClass.GetFrontPosition(释放位置, 技能锚点, 2), this);
                                    break;
                                case SkillTriggerMethod.目标命中绝对触发:
                                    foreach (var item in 命中列表)
                                        if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                            _ = new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, (父类技能 == null) ? 释放位置 : 技能锚点, item.Value.Object, item.Value.Object.CurrentPosition, this);
                                    break;
                                case SkillTriggerMethod.怪物死亡绝对触发:
                                    foreach (var item in 命中列表)
                                        if (item.Value.Object is MonsterObject && (item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            _ = new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, 释放位置, null, item.Value.Object.CurrentPosition, this);
                                    break;
                                case SkillTriggerMethod.怪物死亡换位触发:
                                    foreach (var item in 命中列表)
                                        if (item.Value.Object is MonsterObject && (item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            _ = new SkillInstance(技能来源, skill, null, item.Value.Object.ActionId++, 释放地图, item.Value.Object.CurrentPosition, item.Value.Object, item.Value.Object.CurrentPosition, this, 目标错位: true);
                                    break;
                                case SkillTriggerMethod.怪物命中绝对触发:
                                    foreach (var item in 命中列表)
                                        if (item.Value.Object is MonsterObject && (item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            _ = new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, 释放位置, null, 技能锚点, this);
                                    break;
                                case SkillTriggerMethod.无目标锚点位触发:
                                    if (命中列表.Count == 0 || 命中列表.Values.FirstOrDefault((命中详情 O) => O.Feedback != SkillHitFeedback.丢失) == null)
                                        _ = new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, 释放位置, null, 技能锚点, this);
                                    break;
                                case SkillTriggerMethod.目标位置绝对触发:
                                    foreach (var item in 命中列表)
                                        _ = new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, 释放位置, item.Value.Object, item.Value.Object.CurrentPosition, this);
                                    break;
                                case SkillTriggerMethod.正手反手随机触发:
                                    if (ComputingClass.CheckProbability(0.5f) && 游戏技能.DataSheet.TryGetValue(a_00.反手技能名字, out var value3))
                                        _ = new SkillInstance(技能来源, value3, 技能数据, 动作编号, 释放地图, 释放位置, null, 技能锚点, this);
                                    else
                                        _ = new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, 释放位置, null, 技能锚点, this);
                                    break;
                                case SkillTriggerMethod.目标死亡绝对触发:
                                    foreach (var item in 命中列表)
                                        if ((item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, 释放位置, null, item.Value.Object.CurrentPosition, this);
                                    break;
                                case SkillTriggerMethod.目标闪避绝对触发:
                                    foreach (var item in 命中列表)
                                        if ((item.Value.Feedback & SkillHitFeedback.Miss) != 0)
                                            new SkillInstance(技能来源, skill, 技能数据, 动作编号, 释放地图, 释放位置, null, item.Value.Object.CurrentPosition, this);
                                    break;
                            }
                        }
                    }
                }
                else if (task is A_01_触发对象Buff a_01)
                {
                    bool flag2 = false;
                    if (a_01.角色自身添加)
                    {
                        bool flag3 = true;
                        if (!ComputingClass.CheckProbability(a_01.Buff触发概率))
                            flag3 = false;

                        if (flag3 && a_01.验证铭文技能 && 技能来源 is PlayerObject PlayerObject2)
                        {
                            int num3 = (int)(a_01.所需铭文编号 / 10);
                            int num4 = (int)(a_01.所需铭文编号 % 10);
                            flag3 = PlayerObject2.MainSkills表.TryGetValue((ushort)num3, out SkillData skill) && a_01.同组铭文无效
                                ? num4 == (int)skill.Id
                                : skill != null && (num4 == 0 || num4 == (int)skill.Id);

                        }
                        if (flag3 && a_01.验证自身Buff)
                        {
                            if (!技能来源.Buffs.ContainsKey(a_01.自身Buff编号))
                                flag3 = false;
                            else
                            {
                                if (a_01.触发成功移除)
                                    技能来源.移除Buff时处理(a_01.自身Buff编号);
                                if (a_01.移除伴生Buff)
                                    技能来源.移除Buff时处理(a_01.移除伴生编号);
                            }
                        }

                        if (flag3 && a_01.验证分组Buff && 技能来源.Buffs.Values.FirstOrDefault((BuffData O) => O.Buff分组 == a_01.Buff分组编号) == null)
                            flag3 = false;

                        if (flag3 && a_01.验证目标Buff && 命中列表.Values.FirstOrDefault((命中详情 O) => (O.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (O.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常 && O.Object.Buffs.TryGetValue(a_01.目标Buff编号, out BuffData BuffData2) && BuffData2.当前层数.V >= a_01.所需Buff层数) == null)
                            flag3 = false;

                        if (flag3 && a_01.验证目标类型 && 命中列表.Values.FirstOrDefault((命中详情 O) => (O.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (O.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常 && O.Object.IsSpecificType(技能来源, a_01.所需目标类型)) == null)
                            flag3 = false;

                        if (flag3)
                        {
                            技能来源.OnAddBuff(a_01.触发Buff编号, 技能来源);
                            if (a_01.伴生Buff编号 > 0)
                                技能来源.OnAddBuff(a_01.伴生Buff编号, 技能来源);
                            flag2 = true;
                        }
                    }
                    else
                    {
                        bool flag4 = true;
                        if (a_01.验证自身Buff)
                        {
                            if (!技能来源.Buffs.ContainsKey(a_01.自身Buff编号))
                                flag4 = false;
                            else
                            {
                                if (a_01.触发成功移除)
                                    技能来源.移除Buff时处理(a_01.自身Buff编号);
                                if (a_01.移除伴生Buff)
                                    技能来源.移除Buff时处理(a_01.移除伴生编号);
                            }
                        }

                        if (flag4 && a_01.验证分组Buff && 技能来源.Buffs.Values.FirstOrDefault((BuffData O) => O.Buff分组 == a_01.Buff分组编号) == null)
                            flag4 = false;

                        if (flag4 && a_01.验证铭文技能 && 技能来源 is PlayerObject PlayerObject3)
                        {
                            int num5 = a_01.所需铭文编号 / 10;
                            int num6 = a_01.所需铭文编号 % 10;

                            flag4 = PlayerObject3.MainSkills表.TryGetValue((ushort)num5, out SkillData SkillData4) && a_01.同组铭文无效
                                ? (num6 == (int)SkillData4.Id)
                                : SkillData4 != null && (num6 == 0 || num6 == (int)SkillData4.Id);
                        }

                        if (flag4)
                        {
                            foreach (var item in 命中列表)
                            {
                                bool flag5 = true;

                                if ((item.Value.Feedback & (SkillHitFeedback.Miss | SkillHitFeedback.丢失)) != SkillHitFeedback.正常)
                                    flag5 = false;

                                if (flag5 && !ComputingClass.CheckProbability(a_01.Buff触发概率))
                                    flag5 = false;

                                if (flag5 && a_01.验证目标类型 && !item.Value.Object.IsSpecificType(技能来源, a_01.所需目标类型))
                                    flag5 = false;

                                if (flag5 && a_01.验证目标Buff)
                                    flag5 = (item.Value.Object.Buffs.TryGetValue(a_01.目标Buff编号, out BuffData buffData) && buffData.当前层数.V >= a_01.所需Buff层数);

                                if (flag5)
                                {
                                    item.Value.Object.OnAddBuff(a_01.触发Buff编号, 技能来源);
                                    if (a_01.伴生Buff编号 > 0) item.Value.Object.OnAddBuff(a_01.伴生Buff编号, 技能来源);
                                    flag2 = true;
                                }
                            }
                        }
                    }

                    if (flag2 && a_01.增加技能经验 && 技能来源 is PlayerObject playerObj)
                        playerObj.SkillGainExp(a_01.经验技能编号);
                }
                else if (task is A_02_触发陷阱技能 a_02)
                {
                    if (技能陷阱.DataSheet.TryGetValue(a_02.触发陷阱技能, out 技能陷阱 陷阱模板))
                    {
                        int num7 = 0;
                        var array = ComputingClass.GetLocationRange(技能锚点, ComputingClass.GetDirection(释放位置, 技能锚点), a_02.触发陷阱数量);
                        foreach (var coord in array)
                        {
                            if (!释放地图.IsBlocked(coord) && (陷阱模板.陷阱允许叠加 || !释放地图[coord].Any(o => o is TrapObject trapObj && trapObj.陷阱GroupId != 0 && trapObj.陷阱GroupId == 陷阱模板.分组编号)))
                            {
                                技能来源.Traps.Add(new TrapObject(技能来源, 陷阱模板, 释放地图, coord));
                                num7++;
                            }
                        }

                        if (num7 != 0 && a_02.经验技能编号 != 0 && 技能来源 is PlayerObject playerObj)
                            playerObj.SkillGainExp(a_02.经验技能编号);
                    }
                }
                else if (task is B_00_技能切换通知 b_00)
                {
                    if (技能来源.Buffs.ContainsKey(b_00.技能标记编号))
                    {
                        if (b_00.允许移除标记)
                            技能来源.移除Buff时处理(b_00.技能标记编号);
                    }
                    else if (游戏Buff.DataSheet.ContainsKey(b_00.技能标记编号))
                    {
                        技能来源.OnAddBuff(b_00.技能标记编号, 技能来源);
                    }
                }
                else if (task is B_01_技能释放通知 b_01)
                {
                    if (b_01.调整角色朝向)
                    {
                        var dir = ComputingClass.GetDirection(释放位置, 技能锚点);
                        if (dir == 技能来源.CurrentDirection)
                            技能来源.SendPacket(new 对象转动方向
                            {
                                对象编号 = 技能来源.ObjectId,
                                对象朝向 = (ushort)dir,
                                转向耗时 = ((ushort)((技能来源 is PlayerObject) ? 0 : 1))
                            });
                        else
                            技能来源.CurrentDirection = ComputingClass.GetDirection(释放位置, 技能锚点);
                    }

                    if (b_01.移除技能标记 && 技能模板.技能标记编号 != 0)
                        技能来源.移除Buff时处理(技能模板.技能标记编号);

                    if (b_01.自身冷却时间 != 0 || b_01.Buff增加冷却)
                    {
                        if (检查计数 && 技能来源 is PlayerObject playerObj)
                        {
                            if ((技能数据.RemainingTimeLeft.V -= 1) <= 0)
                                技能来源.Coolings[技能编号 | 16777216] = 释放时间.AddMilliseconds((技能数据.计数时间 - MainProcess.CurrentTime).TotalMilliseconds);

                            playerObj.ActiveConnection.发送封包(new 同步技能计数
                            {
                                SkillId = 技能数据.SkillId.V,
                                SkillCount = 技能数据.RemainingTimeLeft.V,
                                技能冷却 = (int)(技能数据.计数时间 - MainProcess.CurrentTime).TotalMilliseconds
                            });
                        }
                        if (b_01.自身冷却时间 > 0 || b_01.Buff增加冷却)
                        {
                            var num8 = b_01.自身冷却时间;

                            if (b_01.Buff增加冷却 && 技能来源.Buffs.ContainsKey(b_01.增加冷却Buff))
                                num8 += b_01.冷却增加时间;

                            var dateTime = 释放时间.AddMilliseconds(num8);

                            var dateTime2 = 技能来源.Coolings.ContainsKey(技能编号 | 0x1000000)
                                ? 技能来源.Coolings[技能编号 | 0x1000000]
                                : default(DateTime);

                            if (num8 > 0 && dateTime > dateTime2)
                            {
                                技能来源.Coolings[技能编号 | 0x1000000] = dateTime;
                                技能来源.SendPacket(new 添加技能冷却
                                {
                                    CoolingId = ((int)技能编号 | 0x1000000),
                                    Cooldown = num8
                                });
                            }
                        }
                    }

                    if (技能来源 is PlayerObject playerObj2 && b_01.分组冷却时间 != 0 && 分组编号 != 0)
                    {
                        DateTime dateTime2 = 释放时间.AddMilliseconds((double)b_01.分组冷却时间);
                        DateTime t2 = playerObj2.Coolings.ContainsKey((int)(分组编号 | 0)) ? playerObj2.Coolings[(int)(分组编号 | 0)] : default(DateTime);
                        if (dateTime2 > t2) playerObj2.Coolings[(int)(分组编号 | 0)] = dateTime2;
                        技能来源.SendPacket(new 添加技能冷却
                        {
                            CoolingId = (int)(分组编号 | 0),
                            Cooldown = b_01.分组冷却时间
                        });
                    }

                    if (b_01.角色忙绿时间 != 0)
                        技能来源.BusyTime = 释放时间.AddMilliseconds((double)b_01.角色忙绿时间);

                    if (b_01.发送释放通知)
                        技能来源.SendPacket(new StartToReleaseSkillPacket
                        {
                            对象编号 = !目标错位 || 技能目标 == null ? 技能来源.ObjectId : 技能目标.ObjectId, // On ride send 3, its horse id?
                            技能编号 = 技能编号,
                            技能等级 = 技能等级,
                            技能铭文 = 铭文编号,
                            目标编号 = 技能目标?.ObjectId ?? 0,
                            锚点坐标 = 技能锚点,
                            锚点高度 = 释放地图.GetTerrainHeight(技能锚点),
                            动作编号 = 动作编号,
                        });
                }
                else if (task is B_02_技能命中通知 b_02)
                {
                    if (b_02.命中扩展通知)
                        技能来源.SendPacket(new 触发技能扩展
                        {
                            对象编号 = ((!目标错位 || 技能目标 == null) ? 技能来源.ObjectId : 技能目标.ObjectId),
                            SkillId = 技能编号,
                            SkillLevel = 技能等级,
                            技能铭文 = 铭文编号,
                            动作编号 = 动作编号,
                            命中描述 = 命中详情.GetHitDescription(命中列表, 飞行耗时)
                        });
                    else
                        技能来源.SendPacket(new SkillHitNormal
                        {
                            ObjectId = ((!目标错位 || 技能目标 == null) ? 技能来源.ObjectId : 技能目标.ObjectId),
                            SkillId = 技能编号,
                            SkillLevel = 技能等级,
                            SkillInscription = 铭文编号,
                            ActionId = 动作编号,
                            HitDescription = 命中详情.GetHitDescription(命中列表, 飞行耗时)
                        });

                    if (b_02.计算飞行耗时)
                        飞行耗时 = ComputingClass.GridDistance(释放位置, 技能锚点) * b_02.单格飞行耗时;
                }
                else if (task is B_03_前摇结束通知 b_03)
                {
                    if (b_03.计算攻速缩减)
                    {
                        攻速缩减 = ComputingClass.ValueLimit(ComputingClass.CalcAttackSpeed(-5), 攻速缩减 + ComputingClass.CalcAttackSpeed(技能来源[GameObjectStats.攻击速度]), ComputingClass.CalcAttackSpeed(5));

                        if (攻速缩减 != 0)
                        {
                            foreach (var item in 节点列表)
                            {
                                if (item.Value is B_04_后摇结束通知)
                                {
                                    int num9 = item.Key - 攻速缩减;
                                    while (节点列表.ContainsKey(num9)) num9++;
                                    节点列表.Remove(item.Key);
                                    节点列表.Add(num9, item.Value);
                                    break;
                                }
                            }
                        }
                    }

                    if (b_03.禁止行走时间 != 0)
                        技能来源.WalkTime = 释放时间.AddMilliseconds(b_03.禁止行走时间);

                    if (b_03.禁止奔跑时间 != 0)
                        技能来源.RunTime = 释放时间.AddMilliseconds(b_03.禁止奔跑时间);

                    if (b_03.角色硬直时间 != 0)
                        技能来源.HardTime = 释放时间.AddMilliseconds((b_03.计算攻速缩减 ? (b_03.角色硬直时间 - 攻速缩减) : b_03.角色硬直时间));

                    if (b_03.发送结束通知)
                        技能来源.SendPacket(new SkillHitNormal
                        {
                            ObjectId = ((!目标错位 || 技能目标 == null) ? 技能来源.ObjectId : 技能目标.ObjectId),
                            SkillId = 技能编号,
                            SkillLevel = 技能等级,
                            SkillInscription = 铭文编号,
                            ActionId = 动作编号
                        });

                    if (b_03.解除技能陷阱 && 技能来源 is TrapObject trapObj)
                        trapObj.陷阱消失处理();
                }
                else if (task is B_04_后摇结束通知 b_04)
                {
                    技能来源.SendPacket(new 技能释放完成
                    {
                        SkillId = 技能编号,
                        动作编号 = 动作编号
                    });

                    if (b_04.后摇结束死亡)
                        技能来源.Dies(null, skillKill: false);
                }
                else if (task is C_00_计算技能锚点 c_00)
                {
                    if (c_00.计算当前位置)
                    {
                        技能目标 = null;
                        if (c_00.计算当前方向)
                            技能锚点 = ComputingClass.前方坐标(技能来源.CurrentPosition, 技能来源.CurrentDirection, c_00.技能最近距离);
                        else
                            技能锚点 = ComputingClass.GetFrontPosition(技能来源.CurrentPosition, 技能锚点, c_00.技能最近距离);
                    }
                    else if (ComputingClass.GridDistance(释放位置, 技能锚点) > c_00.技能最远距离)
                    {
                        技能目标 = null;
                        技能锚点 = ComputingClass.GetFrontPosition(释放位置, 技能锚点, c_00.技能最远距离);
                    }
                    else if (ComputingClass.GridDistance(释放位置, 技能锚点) < c_00.技能最近距离)
                    {
                        技能目标 = null;

                        if (释放位置 == 技能锚点)
                            技能锚点 = ComputingClass.前方坐标(释放位置, 技能来源.CurrentDirection, c_00.技能最近距离);
                        else
                            技能锚点 = ComputingClass.GetFrontPosition(释放位置, 技能锚点, c_00.技能最近距离);
                    }
                }
                else if (task is C_01_计算命中目标 c_01)
                {
                    if (c_01.清空命中列表)
                        命中列表 = new Dictionary<int, 命中详情>();

                    if (c_01.技能能否穿墙 || !释放地图.地形遮挡(释放位置, 技能锚点))
                    {
                        switch (c_01.技能锁定方式)
                        {
                            case 技能锁定类型.锁定自身:
                                技能来源.ProcessSkillHit(this, c_01);
                                break;
                            case 技能锁定类型.锁定目标:
                                技能目标?.ProcessSkillHit(this, c_01);
                                break;
                            case 技能锁定类型.锁定自身坐标:
                                foreach (var 坐标2 in ComputingClass.GetLocationRange(技能来源.CurrentPosition, ComputingClass.GetDirection(释放位置, 技能锚点), c_01.技能范围类型))
                                    foreach (var mapObj in 释放地图[坐标2])
                                        mapObj.ProcessSkillHit(this, c_01);
                                break;
                            case 技能锁定类型.锁定目标坐标:
                                {
                                    var array = ComputingClass.GetLocationRange((技能目标 != null) ? 技能目标.CurrentPosition : 技能锚点, ComputingClass.GetDirection(释放位置, 技能锚点), c_01.技能范围类型);

                                    foreach (var 坐标3 in array)
                                        foreach (MapObject mapObj in 释放地图[坐标3])
                                            mapObj.ProcessSkillHit(this, c_01);

                                    break;
                                }
                            case 技能锁定类型.锁定锚点坐标:
                                var array2 = ComputingClass.GetLocationRange(技能锚点, ComputingClass.GetDirection(释放位置, 技能锚点), c_01.技能范围类型);

                                foreach (var 坐标4 in array2)
                                    foreach (MapObject mapObj in 释放地图[坐标4])
                                        mapObj.ProcessSkillHit(this, c_01);

                                break;
                            case 技能锁定类型.放空锁定自身:
                                var array3 = ComputingClass.GetLocationRange(技能锚点, ComputingClass.GetDirection(释放位置, 技能锚点), c_01.技能范围类型);

                                foreach (Point 坐标5 in array3)
                                    foreach (MapObject mapObj in 释放地图[坐标5])
                                        mapObj.ProcessSkillHit(this, c_01);

                                if (命中列表.Count == 0) 技能来源.ProcessSkillHit(this, c_01);

                                break;
                        }
                    }

                    if (命中列表.Count == 0 && c_01.放空结束技能)
                    {
                        if (c_01.发送中断通知)
                            技能来源.SendPacket(new 技能释放中断
                            {
                                对象编号 = 技能来源.ObjectId,
                                SkillId = 技能编号,
                                SkillLevel = 技能等级,
                                技能铭文 = 铭文编号,
                                动作编号 = 动作编号,
                                技能分段 = 分段编号
                            });

                        技能来源.SkillTasks.Remove(this);
                        return;
                    }

                    if (c_01.补发释放通知)
                        技能来源.SendPacket(new StartToReleaseSkillPacket
                        {
                            对象编号 = ((!目标错位 || 技能目标 == null) ? 技能来源.ObjectId : 技能目标.ObjectId),
                            技能编号 = 技能编号,
                            技能等级 = 技能等级,
                            技能铭文 = 铭文编号,
                            目标编号 = 技能目标?.ObjectId ?? 0,
                            锚点坐标 = 技能锚点,
                            锚点高度 = 释放地图.GetTerrainHeight(技能锚点),
                            动作编号 = 动作编号
                        });

                    if (命中列表.Count != 0 && c_01.攻速提升类型 != SpecifyTargetType.无 && 命中列表[0].Object.IsSpecificType(技能来源, c_01.攻速提升类型))
                        攻速缩减 = ComputingClass.ValueLimit(ComputingClass.CalcAttackSpeed(-5), 攻速缩减 + ComputingClass.CalcAttackSpeed(c_01.攻速提升幅度), ComputingClass.CalcAttackSpeed(5));

                    if (c_01.清除目标状态 && c_01.清除状态列表.Count != 0)
                        foreach (var item in 命中列表)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                foreach (ushort 编号 in c_01.清除状态列表.ToList())
                                    item.Value.Object.移除Buff时处理(编号);

                    if (c_01.触发被动技能 && 命中列表.Count != 0 && ComputingClass.CheckProbability(c_01.触发被动概率))
                        技能来源[GameObjectStats.技能标志] = 1;

                    if (c_01.增加技能经验 && 命中列表.Count != 0 && 技能来源 is PlayerObject playerObj)
                        playerObj.SkillGainExp(c_01.经验技能编号);

                    if (c_01.计算飞行耗时 && c_01.单格飞行耗时 != 0)
                        飞行耗时 = ComputingClass.GridDistance(释放位置, 技能锚点) * c_01.单格飞行耗时;

                    if (c_01.技能命中通知)
                        技能来源.SendPacket(new SkillHitNormal
                        {
                            ObjectId = ((!目标错位 || 技能目标 == null) ? 技能来源.ObjectId : 技能目标.ObjectId),
                            SkillId = 技能编号,
                            SkillLevel = 技能等级,
                            SkillInscription = 铭文编号,
                            ActionId = 动作编号,
                            HitDescription = 命中详情.GetHitDescription(命中列表, 飞行耗时)
                        });

                    if (c_01.技能扩展通知)
                        技能来源.SendPacket(new 触发技能扩展
                        {
                            对象编号 = ((!目标错位 || 技能目标 == null) ? 技能来源.ObjectId : 技能目标.ObjectId),
                            SkillId = 技能编号,
                            SkillLevel = 技能等级,
                            技能铭文 = 铭文编号,
                            动作编号 = 动作编号,
                            命中描述 = 命中详情.GetHitDescription(命中列表, 飞行耗时)
                        });
                }
                else if (task is C_02_计算目标伤害 c_02)
                {
                    float num9 = 1f;

                    foreach (var item in 命中列表)
                    {
                        if (c_02.点爆命中目标 && item.Value.Object.Buffs.ContainsKey(c_02.点爆标记编号))
                            item.Value.Object.移除Buff时处理(c_02.点爆标记编号);
                        else if (c_02.点爆命中目标 && c_02.失败添加层数)
                        {
                            item.Value.Object.OnAddBuff(c_02.点爆标记编号, 技能来源);
                            continue;
                        }

                        item.Value.Object.被动受伤时处理(this, c_02, item.Value, num9);

                        if ((item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                        {
                            if (c_02.数量衰减伤害)
                                num9 = Math.Max(c_02.伤害衰减下限, num9 - c_02.伤害衰减系数);

                            技能来源.SendPacket(new 触发命中特效
                            {
                                对象编号 = ((!目标错位 || 技能目标 == null) ? 技能来源.ObjectId : 技能目标.ObjectId),
                                SkillId = 技能编号,
                                SkillLevel = 技能等级,
                                技能铭文 = 铭文编号,
                                动作编号 = 动作编号,
                                目标编号 = item.Value.Object.ObjectId,
                                技能反馈 = (ushort)item.Value.Feedback,
                                技能伤害 = -item.Value.Damage,
                                招架伤害 = item.Value.MissDamage
                            });
                        }
                    }

                    if (c_02.目标死亡回复)
                    {
                        foreach (var item in 命中列表)
                        {
                            if ((item.Value.Feedback & SkillHitFeedback.死亡) != SkillHitFeedback.正常 && item.Value.Object.IsSpecificType(技能来源, c_02.回复限定类型))
                            {
                                int num11 = c_02.体力回复基数;
                                if (c_02.等级差减回复)
                                {
                                    int Value = (技能来源.CurrentLevel - item.Value.Object.CurrentLevel) - c_02.减回复等级差;
                                    int num12 = c_02.零回复等级差 - c_02.减回复等级差;
                                    float num13 = ComputingClass.ValueLimit(0, Value, num12) / (float)num12;
                                    num11 = (int)((float)num11 - (float)num11 * num13);
                                }
                                if (num11 > 0)
                                {
                                    技能来源.CurrentHP += num11;
                                    技能来源.SendPacket(new 体力变动飘字
                                    {
                                        血量变化 = num11,
                                        对象编号 = 技能来源.ObjectId
                                    });
                                }
                            }
                        }
                    }

                    if (c_02.击杀减少冷却)
                    {
                        int num14 = 0;

                        foreach (var item in 命中列表)
                            if ((item.Value.Feedback & SkillHitFeedback.死亡) != SkillHitFeedback.正常 && item.Value.Object.IsSpecificType(技能来源, c_02.冷却减少类型))
                                num14 += (int)c_02.冷却减少时间;

                        if (num14 > 0)
                        {
                            if (技能来源.Coolings.TryGetValue((int)c_02.冷却减少技能 | 0x1000000, out var dateTime3))
                            {
                                dateTime3 -= TimeSpan.FromMilliseconds(num14);
                                技能来源.Coolings[c_02.冷却减少技能 | 0x1000000] = dateTime3;
                                技能来源.SendPacket(new 添加技能冷却
                                {
                                    CoolingId = (c_02.冷却减少技能 | 0x1000000),
                                    Cooldown = Math.Max(0, (int)(dateTime3 - MainProcess.CurrentTime).TotalMilliseconds)
                                });
                            }

                            if (c_02.冷却减少分组 != 0 && 技能来源 is PlayerObject PlayerObject8 && PlayerObject8.Coolings.TryGetValue((int)(c_02.冷却减少分组 | 0), out var dateTime4))
                            {
                                dateTime4 -= TimeSpan.FromMilliseconds(num14);
                                PlayerObject8.Coolings[(c_02.冷却减少分组 | 0)] = dateTime4;
                                技能来源.SendPacket(new 添加技能冷却
                                {
                                    CoolingId = (c_02.冷却减少分组 | 0),
                                    Cooldown = Math.Max(0, (int)(dateTime4 - MainProcess.CurrentTime).TotalMilliseconds)
                                });
                            }
                        }
                    }

                    if (c_02.命中减少冷却)
                    {
                        int num15 = 0;

                        foreach (var item in 命中列表)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常 && item.Value.Object.IsSpecificType(技能来源, c_02.冷却减少类型))
                                num15 += (int)c_02.冷却减少时间;

                        if (num15 > 0)
                        {
                            if (技能来源.Coolings.TryGetValue((int)c_02.冷却减少技能 | 0x1000000, out var dateTime5))
                            {
                                dateTime5 -= TimeSpan.FromMilliseconds(num15);
                                技能来源.Coolings[c_02.冷却减少技能 | 0x1000000] = dateTime5;
                                技能来源.SendPacket(new 添加技能冷却
                                {
                                    CoolingId = (c_02.冷却减少技能 | 0x1000000),
                                    Cooldown = Math.Max(0, (int)(dateTime5 - MainProcess.CurrentTime).TotalMilliseconds)
                                });
                            }

                            if (c_02.冷却减少分组 != 0)
                            {
                                if (技能来源 is PlayerObject PlayerObject9 && PlayerObject9.Coolings.TryGetValue((int)(c_02.冷却减少分组 | 0), out var dateTime6))
                                {
                                    dateTime6 -= TimeSpan.FromMilliseconds(num15);
                                    PlayerObject9.Coolings[(c_02.冷却减少分组 | 0)] = dateTime6;
                                    技能来源.SendPacket(new 添加技能冷却
                                    {
                                        CoolingId = (c_02.冷却减少分组 | 0),
                                        Cooldown = Math.Max(0, (int)(dateTime6 - MainProcess.CurrentTime).TotalMilliseconds)
                                    });
                                }
                            }
                        }
                    }

                    if (c_02.目标硬直时间 > 0)
                        foreach (var item in 命中列表)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                if (item.Value.Object is MonsterObject monsterObj && monsterObj.Category != MonsterLevelType.头目首领)
                                    item.Value.Object.HardTime = MainProcess.CurrentTime.AddMilliseconds(c_02.目标硬直时间);

                    if (c_02.清除目标状态 && c_02.清除状态列表.Count != 0)
                        foreach (var item in 命中列表)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                foreach (ushort 编号2 in c_02.清除状态列表)
                                    item.Value.Object.移除Buff时处理(编号2);

                    if (技能来源 is PlayerObject playerObj)
                    {
                        if (c_02.增加技能经验 && 命中列表.Count != 0)
                            playerObj.SkillGainExp(c_02.经验技能编号);

                        if (c_02.扣除武器持久 && 命中列表.Count != 0)
                            playerObj.武器损失持久();
                    }
                }
                else if (task is C_03_计算对象位移 c_03)
                {
                    byte[] ItSelf位移次数 = c_03.自身位移次数;
                    byte b2 = (byte)((((ItSelf位移次数 != null) ? ItSelf位移次数.Length : 0) > 技能等级) ? c_03.自身位移次数[技能等级] : 0);

                    if (c_03.角色ItSelf位移 && (释放地图 != 技能来源.CurrentMap || 分段编号 >= b2))
                    {
                        技能来源.SendPacket(new 技能释放中断
                        {
                            对象编号 = ((!目标错位 || 技能目标 == null) ? 技能来源.ObjectId : 技能目标.ObjectId),
                            SkillId = 技能编号,
                            SkillLevel = 技能等级,
                            技能铭文 = 铭文编号,
                            动作编号 = 动作编号,
                            技能分段 = 分段编号
                        });
                        技能来源.SendPacket(new 技能释放完成
                        {
                            SkillId = 技能编号,
                            动作编号 = 动作编号
                        });
                    }
                    else if (c_03.角色ItSelf位移)
                    {
                        int 数量 = (c_03.推动目标位移 ? c_03.连续推动数量 : 0);
                        byte[] ItSelf位移距离 = c_03.自身位移距离;
                        int num16 = ((((ItSelf位移距离 != null) ? ItSelf位移距离.Length : 0) > 技能等级) ? c_03.自身位移距离[技能等级] : 0);
                        int num17 = (c_03.允许超出锚点 || c_03.锚点反向位移) ? num16 : Math.Min(num16, ComputingClass.GridDistance(释放位置, 技能锚点));
                        Point 锚点 = c_03.锚点反向位移 ? ComputingClass.前方坐标(技能来源.CurrentPosition, ComputingClass.GetDirection(技能锚点, 技能来源.CurrentPosition), num17) : 技能锚点;
                        if (技能来源.CanBeDisplaced(技能来源, 锚点, num17, 数量, c_03.能否穿越障碍, out var point, out var array2))
                        {
                            foreach (MapObject mapObj in array2)
                            {
                                if (c_03.目标位移编号 != 0 && ComputingClass.CheckProbability(c_03.位移Buff概率))
                                    mapObj.OnAddBuff(c_03.目标位移编号, 技能来源);

                                if (c_03.目标附加编号 != 0 && ComputingClass.CheckProbability(c_03.附加Buff概率) && mapObj.IsSpecificType(技能来源, c_03.限定附加类型))
                                    mapObj.OnAddBuff(c_03.目标附加编号, 技能来源);

                                mapObj.CurrentDirection = ComputingClass.GetDirection(mapObj.CurrentPosition, 技能来源.CurrentPosition);
                                Point point2 = ComputingClass.前方坐标(mapObj.CurrentPosition, ComputingClass.GetDirection(技能来源.CurrentPosition, mapObj.CurrentPosition), 1);
                                mapObj.BusyTime = MainProcess.CurrentTime.AddMilliseconds((c_03.目标位移耗时 * 60));
                                mapObj.HardTime = MainProcess.CurrentTime.AddMilliseconds((c_03.目标位移耗时 * 60 + c_03.目标硬直时间));

                                mapObj.SendPacket(new 对象被动位移
                                {
                                    位移坐标 = point2,
                                    对象编号 = mapObj.ObjectId,
                                    位移朝向 = (ushort)mapObj.CurrentDirection,
                                    位移速度 = c_03.目标位移耗时
                                });

                                mapObj.ItSelf移动时处理(point2);

                                if (c_03.推动增加经验 && !经验增加 && 技能来源 is PlayerObject playerObj)
                                {
                                    playerObj.SkillGainExp(技能编号);
                                    经验增加 = true;
                                }
                            }

                            if (c_03.成功Buff编号 != 0 && ComputingClass.CheckProbability(c_03.成功Buff概率))
                                技能来源.OnAddBuff(c_03.成功Buff编号, 技能来源);

                            技能来源.CurrentDirection = ComputingClass.GetDirection(技能来源.CurrentPosition, point);
                            int num18 = c_03.自身位移耗时 * 技能来源.GetDistance(point);
                            技能来源.BusyTime = MainProcess.CurrentTime.AddMilliseconds((num18 * 60));
                            技能来源.SendPacket(new 对象被动位移
                            {
                                位移坐标 = point,
                                对象编号 = 技能来源.ObjectId,
                                位移朝向 = (ushort)技能来源.CurrentDirection,
                                位移速度 = (ushort)num18
                            });
                            技能来源.ItSelf移动时处理(point);

                            if (c_03.位移增加经验 && !经验增加 && 技能来源 is PlayerObject playerObj2)
                            {
                                playerObj2.SkillGainExp(技能编号);
                                经验增加 = true;
                            }

                            if (c_03.多段位移通知)
                            {
                                技能来源.SendPacket(new SkillHitNormal
                                {
                                    ObjectId = ((!目标错位 || 技能目标 == null) ? 技能来源.ObjectId : 技能目标.ObjectId),
                                    SkillId = 技能编号,
                                    SkillLevel = 技能等级,
                                    SkillInscription = 铭文编号,
                                    ActionId = 动作编号,
                                    SkillSegment = 分段编号
                                });
                            }

                            if (b2 > 1)
                                技能锚点 = ComputingClass.前方坐标(技能来源.CurrentPosition, 技能来源.CurrentDirection, num17);

                            分段编号++;
                        }
                        else
                        {
                            if (ComputingClass.CheckProbability(c_03.失败Buff概率))
                                技能来源.OnAddBuff(c_03.失败Buff编号, 技能来源);

                            技能来源.HardTime = MainProcess.CurrentTime.AddMilliseconds(c_03.自身硬直时间);
                            分段编号 = b2;
                        }

                        if (b2 > 1)
                        {
                            int num19 = keyValuePair.Key + (int)(c_03.自身位移耗时 * 60);

                            while (节点列表.ContainsKey(num19))
                                num19++;

                            节点列表.Add(num19, keyValuePair.Value);
                        }
                    }
                    else if (c_03.推动目标位移)
                    {
                        foreach (var item in 命中列表)
                        {
                            if (
                                (item.Value.Feedback & SkillHitFeedback.Miss) != SkillHitFeedback.正常
                                || (item.Value.Feedback & SkillHitFeedback.丢失) != SkillHitFeedback.正常
                                || (item.Value.Feedback & SkillHitFeedback.死亡) != SkillHitFeedback.正常
                                || !ComputingClass.CheckProbability(c_03.推动目标概率)
                                || !item.Value.Object.IsSpecificType(技能来源, c_03.推动目标类型)
                            ) continue;

                            byte[] 目标位移距离 = c_03.目标位移距离;
                            int val = ((((目标位移距离 != null) ? 目标位移距离.Length : 0) > 技能等级) ? c_03.目标位移距离[技能等级] : 0);
                            int num20 = ComputingClass.GridDistance(技能来源.CurrentPosition, item.Value.Object.CurrentPosition);
                            int num21 = Math.Max(0, Math.Min(8 - num20, val));

                            if (num21 == 0) continue;

                            var 方向 = ComputingClass.GetDirection(技能来源.CurrentPosition, item.Value.Object.CurrentPosition);
                            var 锚点2 = ComputingClass.前方坐标(item.Value.Object.CurrentPosition, 方向, num21);

                            if (!item.Value.Object.CanBeDisplaced(技能来源, 锚点2, num21, 0, false, out var point3, out var array4))
                                continue;

                            if (ComputingClass.CheckProbability(c_03.位移Buff概率))
                                item.Value.Object.OnAddBuff(c_03.目标位移编号, 技能来源);

                            if (ComputingClass.CheckProbability(c_03.附加Buff概率) && item.Value.Object.IsSpecificType(技能来源, c_03.限定附加类型))
                                item.Value.Object.OnAddBuff(c_03.目标附加编号, 技能来源);

                            item.Value.Object.CurrentDirection = ComputingClass.GetDirection(item.Value.Object.CurrentPosition, 技能来源.CurrentPosition);
                            ushort num22 = (ushort)(ComputingClass.GridDistance(item.Value.Object.CurrentPosition, point3) * c_03.目标位移耗时);
                            item.Value.Object.BusyTime = MainProcess.CurrentTime.AddMilliseconds((num22 * 60));
                            item.Value.Object.HardTime = MainProcess.CurrentTime.AddMilliseconds((num22 * 60 + c_03.目标硬直时间));
                            item.Value.Object.SendPacket(new 对象被动位移
                            {
                                位移坐标 = point3,
                                位移速度 = num22,
                                对象编号 = item.Value.Object.ObjectId,
                                位移朝向 = (ushort)item.Value.Object.CurrentDirection
                            });
                            item.Value.Object.ItSelf移动时处理(point3);
                            if (c_03.推动增加经验 && !经验增加 && 技能来源 is PlayerObject playerObj)
                            {
                                playerObj.SkillGainExp(技能编号);
                                经验增加 = true;
                            }
                        }
                    }
                }
                else if (task is C_04_计算目标诱惑 c_04)
                {
                    if (技能来源 is PlayerObject playerObj)
                        foreach (var item in 命中列表)
                            playerObj.玩家诱惑目标(this, c_04, item.Value.Object);
                }
                else if (task is C_06_计算宠物召唤 c_06)
                {
                    if (c_06.怪物召唤同伴)
                    {
                        if (c_06.召唤宠物名字 == null || c_06.召唤宠物名字.Length == 0)
                            return;

                        if (游戏怪物.DataSheet.TryGetValue(c_06.召唤宠物名字, out var 对应模板))
                            _ = new MonsterObject(对应模板, 释放地图, int.MaxValue, new Point[] { 释放位置 }, true, true) { 存活时间 = MainProcess.CurrentTime.AddMinutes(1.0) };
                    }
                    else if (技能来源 is PlayerObject playerObj)
                    {
                        if (c_06.检查技能铭文 && (!playerObj.MainSkills表.TryGetValue(技能编号, out var skill) || skill.Id != 铭文编号))
                            return;

                        if (c_06.召唤宠物名字 == null || c_06.召唤宠物名字.Length == 0)
                            return;

                        int num21 = ((c_06.召唤宠物数量?.Length > 技能等级) ? c_06.召唤宠物数量[技能等级] : 0);
                        if (playerObj.Pets.Count < num21 && 游戏怪物.DataSheet.TryGetValue(c_06.召唤宠物名字, out var value5))
                        {
                            byte GradeCap = (byte)((c_06.宠物等级上限?.Length > 技能等级) ? c_06.宠物等级上限[技能等级] : 0);
                            PetObject 宠物实例 = new PetObject(playerObj, value5, 技能等级, GradeCap, c_06.宠物绑定武器);
                            playerObj.ActiveConnection.发送封包(new 同步宠物等级
                            {
                                宠物编号 = 宠物实例.ObjectId,
                                宠物等级 = 宠物实例.宠物等级
                            });
                            playerObj.ActiveConnection.发送封包(new 游戏错误提示
                            {
                                错误代码 = 9473,
                                第一参数 = (int)playerObj.PetMode
                            });
                            playerObj.PetData.Add(宠物实例.PetData);
                            playerObj.Pets.Add(宠物实例);

                            if (c_06.增加技能经验)
                                playerObj.SkillGainExp(c_06.经验技能编号);
                        }
                    }
                }
                else if (task is C_05_计算目标回复 c_05)
                {
                    foreach (var keyValuePair20 in 命中列表)
                        keyValuePair20.Value.Object.被动回复时处理(this, c_05);

                    if (c_05.增加技能经验 && 命中列表.Count != 0 && 技能来源 is PlayerObject playerObj)
                        playerObj.SkillGainExp(c_05.经验技能编号);
                }
                else if (task is C_07_计算目标瞬移 c_07 && 技能来源 is PlayerObject playerObj)
                    playerObj.玩家瞬间移动(this, c_07);
            }

            if (节点列表.Count == 0)
            {
                if (是否开关技能 && 技能模板.检查技能标记)
                    技能来源.移除Buff时处理(技能模板.技能标记编号);

                技能来源.SkillTasks.Remove(this);
                return;
            }

            预约时间 = 释放时间.AddMilliseconds(飞行耗时 + 节点列表.First().Key);
            任务处理();
        }
        public void 技能中断()
        {
            节点列表.Clear();
            技能来源.SendPacket(new 技能释放中断
            {
                对象编号 = ((!目标错位 || 技能目标 == null) ? 技能来源.ObjectId : 技能目标.ObjectId),
                SkillId = 技能编号,
                SkillLevel = 技能等级,
                技能铭文 = 铭文编号,
                动作编号 = 动作编号,
                技能分段 = 分段编号
            });
        }
    }
}
