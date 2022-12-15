using System;
using System.Collections.Generic;
using GameServer.Maps;
using GameServer.Templates;

namespace GameServer.Data
{
    /// <summary>
    /// Buff数据
    /// </summary>
    public sealed class BuffData : GameData
    {

        public BuffData()
        {


        }


        public BuffData(MapObject 来源, MapObject 目标, ushort 编号)
        {


            this.Buff来源 = 来源;
            this.Buff编号.V = 编号;
            this.当前层数.V = this.Buff模板.Buff初始层数;
            this.持续时间.V = TimeSpan.FromMilliseconds((double)this.Buff模板.Buff持续时间);
            this.处理计时.V = TimeSpan.FromMilliseconds((double)this.Buff模板.Buff处理延迟);
            PlayerObject PlayerObject = 来源 as PlayerObject;
            if (PlayerObject != null)
            {
                SkillData SkillData;
                if (this.Buff模板.绑定技能等级 != 0 && PlayerObject.MainSkills表.TryGetValue(this.Buff模板.绑定技能等级, out SkillData))
                {
                    this.Buff等级.V = SkillData.SkillLevel.V;
                }
                if (this.Buff模板.持续时间延长 && this.Buff模板.技能等级延时)
                {
                    this.持续时间.V += TimeSpan.FromMilliseconds((double)((int)this.Buff等级.V * this.Buff模板.每级延长时间));
                }
                if (this.Buff模板.持续时间延长 && this.Buff模板.角色属性延时)
                {
                    this.持续时间.V += TimeSpan.FromMilliseconds((double)((float)PlayerObject[this.Buff模板.绑定角色属性] * this.Buff模板.属性延时系数));
                }
                SkillData SkillData2;
                if (this.Buff模板.持续时间延长 && this.Buff模板.特定铭文延时 && PlayerObject.MainSkills表.TryGetValue((ushort)(this.Buff模板.特定铭文技能 / 10), out SkillData2) && (int)SkillData2.Id == this.Buff模板.特定铭文技能 % 10)
                {
                    this.持续时间.V += TimeSpan.FromMilliseconds((double)this.Buff模板.铭文延长时间);
                }
            }
            else
            {
                PetObject PetObject = 来源 as PetObject;
                if (PetObject != null)
                {
                    SkillData SkillData3;
                    if (this.Buff模板.绑定技能等级 != 0 && PetObject.PlayerOwner.MainSkills表.TryGetValue(this.Buff模板.绑定技能等级, out SkillData3))
                    {
                        this.Buff等级.V = SkillData3.SkillLevel.V;
                    }
                    if (this.Buff模板.持续时间延长 && this.Buff模板.技能等级延时)
                    {
                        this.持续时间.V += TimeSpan.FromMilliseconds((double)((int)this.Buff等级.V * this.Buff模板.每级延长时间));
                    }
                    if (this.Buff模板.持续时间延长 && this.Buff模板.角色属性延时)
                    {
                        this.持续时间.V += TimeSpan.FromMilliseconds((double)((float)PetObject.PlayerOwner[this.Buff模板.绑定角色属性] * this.Buff模板.属性延时系数));
                    }
                    SkillData SkillData4;
                    if (this.Buff模板.持续时间延长 && this.Buff模板.特定铭文延时 && PetObject.PlayerOwner.MainSkills表.TryGetValue((ushort)(this.Buff模板.特定铭文技能 / 10), out SkillData4) && (int)SkillData4.Id == this.Buff模板.特定铭文技能 % 10)
                    {
                        this.持续时间.V += TimeSpan.FromMilliseconds((double)this.Buff模板.铭文延长时间);
                    }
                }
            }
            this.剩余时间.V = this.持续时间.V;
            if ((this.Buff效果 & BuffEffectType.造成伤害) != BuffEffectType.技能标志)
            {
                int[] DamageBase = this.Buff模板.Buff伤害基数;
                int? num = (DamageBase != null) ? new int?(DamageBase.Length) : null;
                int v = (int)this.Buff等级.V;
                int num2 = (num.GetValueOrDefault() > v & num != null) ? this.Buff模板.Buff伤害基数[(int)this.Buff等级.V] : 0;
                float[] DamageFactor = this.Buff模板.Buff伤害系数;
                num = ((DamageFactor != null) ? new int?(DamageFactor.Length) : null);
                v = (int)this.Buff等级.V;
                float num3 = (num.GetValueOrDefault() > v & num != null) ? this.Buff模板.Buff伤害系数[(int)this.Buff等级.V] : 0f;
                PlayerObject PlayerObject2 = 来源 as PlayerObject;
                SkillData SkillData5;
                if (PlayerObject2 != null && this.Buff模板.强化铭文编号 != 0 && PlayerObject2.MainSkills表.TryGetValue((ushort)(this.Buff模板.强化铭文编号 / 10), out SkillData5) && (int)SkillData5.Id == this.Buff模板.强化铭文编号 % 10)
                {
                    num2 += this.Buff模板.铭文强化基数;
                    num3 += this.Buff模板.铭文强化系数;
                }
                int num4 = 0;
                switch (this.伤害类型)
                {
                    case SkillDamageType.攻击:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.最小攻击], 来源[GameObjectStats.最大攻击], 来源[GameObjectStats.幸运]);
                        break;
                    case SkillDamageType.魔法:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.最小魔法], 来源[GameObjectStats.最大魔法], 来源[GameObjectStats.幸运]);
                        break;
                    case SkillDamageType.道术:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.最小道术], 来源[GameObjectStats.最大道术], 来源[GameObjectStats.幸运]);
                        break;
                    case SkillDamageType.刺术:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.最小刺术], 来源[GameObjectStats.最大刺术], 来源[GameObjectStats.幸运]);
                        break;
                    case SkillDamageType.弓术:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.最小弓术], 来源[GameObjectStats.最大弓术], 来源[GameObjectStats.幸运]);
                        break;
                    case SkillDamageType.毒性:
                        num4 = 来源[GameObjectStats.最大道术];
                        break;
                    case SkillDamageType.神圣:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.最小神圣], 来源[GameObjectStats.最大神圣], 0);
                        break;
                }
                this.伤害基数.V = num2 + (int)((float)num4 * num3);
            }
            if (目标 is PlayerObject)
            {
                GameDataGateway.Buff数据表.AddData(this, true);
            }
        }


        public override string ToString()
        {
            游戏Buff buff模板 = this.Buff模板;
            if (buff模板 == null)
            {
                return null;
            }
            return buff模板.Buff名字;
        }


        public BuffEffectType Buff效果
        {
            get
            {
                return this.Buff模板.Buff效果;
            }
        }


        public SkillDamageType 伤害类型
        {
            get
            {
                return this.Buff模板.Buff伤害类型;
            }
        }


        public 游戏Buff Buff模板
        {
            get
            {
                游戏Buff result;
                if (!游戏Buff.DataSheet.TryGetValue(this.Buff编号.V, out result))
                {
                    return null;
                }
                return result;
            }
        }

        public bool OnReleaseSkillRemove => Buff模板.OnReleaseSkillRemove;


        public bool 增益Buff
        {
            get
            {
                return this.Buff模板.作用类型 == BuffActionType.增益类型;
            }
        }


        public bool Buff同步
        {
            get
            {
                return this.Buff模板.同步至客户端;
            }
        }


        public bool 到期消失
        {
            get
            {
                游戏Buff buff模板 = this.Buff模板;
                return buff模板 != null && buff模板.到期主动消失;
            }
        }


        public bool 下线消失
        {
            get
            {
                return this.Buff模板.角色下线消失;
            }
        }


        public bool 死亡消失
        {
            get
            {
                return this.Buff模板.角色死亡消失;
            }
        }


        public bool 换图消失
        {
            get
            {
                return this.Buff模板.切换地图消失;
            }
        }


        public bool 绑定武器
        {
            get
            {
                return this.Buff模板.切换武器消失;
            }
        }


        public bool 添加冷却
        {
            get
            {
                return this.Buff模板.移除添加冷却;
            }
        }


        public ushort 绑定技能
        {
            get
            {
                return this.Buff模板.绑定技能等级;
            }
        }


        public ushort 冷却时间
        {
            get
            {
                return this.Buff模板.技能冷却时间;
            }
        }


        public int 处理延迟
        {
            get
            {
                return this.Buff模板.Buff处理延迟;
            }
        }


        public int 处理间隔
        {
            get
            {
                return this.Buff模板.Buff处理间隔;
            }
        }


        public byte 最大层数
        {
            get
            {
                return this.Buff模板.Buff最大层数;
            }
        }


        public ushort Buff分组
        {
            get
            {
                if (this.Buff模板.分组编号 == 0)
                {
                    return this.Buff编号.V;
                }
                return this.Buff模板.分组编号;
            }
        }


        public ushort[] 依存列表
        {
            get
            {
                return this.Buff模板.依存Buff列表;
            }
        }


        public Dictionary<GameObjectStats, int> Stat加成
        {
            get
            {
                if ((this.Buff效果 & BuffEffectType.属性增减) != BuffEffectType.技能标志)
                {
                    return this.Buff模板.基础StatsIncOrDec[(int)this.Buff等级.V];
                }
                return null;
            }
        }


        public MapObject Buff来源;


        public readonly DataMonitor<ushort> Buff编号;


        public readonly DataMonitor<TimeSpan> 持续时间;


        public readonly DataMonitor<TimeSpan> 剩余时间;


        public readonly DataMonitor<TimeSpan> 处理计时;


        public readonly DataMonitor<byte> 当前层数;


        public readonly DataMonitor<byte> Buff等级;


        public readonly DataMonitor<int> 伤害基数;
    }
}
