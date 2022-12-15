using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using GameServer.Maps;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Data
{
    /// <summary>
    /// 角色数据
    /// </summary>
    [FastDataReturn(SearchFilder = "角色名字")]
    public sealed class CharacterData : GameData
    {

        public int 角色编号 => 数据索引.V;


        public long 角色经验
        {
            get => 当前经验.V;
            set => 当前经验.V = value;
        }


        public byte 角色等级
        {
            get
            {
                return this.当前等级.V;
            }
            set
            {
                if (this.当前等级.V == value)
                {
                    return;
                }
                this.当前等级.V = value;
                SystemData.Data.更新等级(this);
            }
        }


        public int 角色战力
        {
            get => 当前战力.V;
            set
            {
                if (当前战力.V == value)
                    return;
                当前战力.V = value;
                SystemData.Data.UpdatedPowerCombat(this);
            }
        }


        public int 角色PK值
        {
            get => 当前PK值.V;
            set
            {
                if (当前PK值.V == value)
                    return;
                当前PK值.V = value;
                SystemData.Data.UpdatedPKLevel(this);
            }
        }

        public long 升级经验 => CharacterProgression.升级所需经验[角色等级];

        public int 元宝数量
        {
            get
            {
                if (!角色货币.TryGetValue(GameCurrency.元宝, out int result))
                    return 0;
                return result;
            }
            set
            {
                角色货币[GameCurrency.元宝] = value;
                MainForm.更新角色属性(this, nameof(元宝数量), value);
            }
        }


        public int 金币数量
        {
            get
            {
                int result;
                if (!this.角色货币.TryGetValue(GameCurrency.金币, out result))
                {
                    return 0;
                }
                return result;
            }
            set
            {
                this.角色货币[GameCurrency.金币] = value;
                MainForm.更新角色属性(this, nameof(金币数量), value);
            }
        }


        public int 师门声望
        {
            get
            {
                int result;
                if (!this.角色货币.TryGetValue(GameCurrency.名师声望, out result))
                {
                    return 0;
                }
                return result;
            }
            set
            {
                this.角色货币[GameCurrency.名师声望] = value;
                MainForm.更新角色属性(this, nameof(师门声望), value);
            }
        }


        public byte 师门参数
        {
            get
            {
                if (当前师门 != null)
                {
                    if (当前师门.MasterId == 角色编号)
                        return 2;
                    return 1;
                }
                else
                {
                    if (角色等级 < 30)
                        return 0;
                    return 2;
                }
            }
        }


        public TeamData 当前队伍
        {
            get
            {
                return this.所属队伍.V;
            }
            set
            {
                if (this.所属队伍.V != value)
                {
                    this.所属队伍.V = value;
                }
            }
        }


        public TeacherData 当前师门
        {
            get
            {
                return this.所属师门.V;
            }
            set
            {
                if (this.所属师门.V != value)
                {
                    this.所属师门.V = value;
                }
            }
        }


        public GuildData 当前行会
        {
            get
            {
                return this.所属行会.V;
            }
            set
            {
                if (this.所属行会.V != value)
                {
                    this.所属行会.V = value;
                }
            }
        }

        public 客户网络 网络连接 { get; set; }


        public void 获得经验(int 经验值)
        {
            if (this.角色等级 >= Config.游戏开放等级 && this.角色经验 >= this.升级经验)
            {
                return;
            }
            if ((this.角色经验 += 经验值) > this.升级经验 && this.角色等级 < Config.游戏开放等级)
            {
                while (this.角色经验 >= this.升级经验)
                {
                    this.角色经验 -= this.升级经验;
                    this.角色等级 += 1;
                }
            }
        }


        public void 角色下线()
        {
            this.网络连接.玩家实例 = null;
            this.网络连接 = null;
            网络服务网关.已上线连接数 -= 1U;
            this.离线日期.V = MainProcess.CurrentTime;
            MainForm.更新角色属性(this, nameof(离线日期), this.离线日期);
        }


        public void 角色上线(客户网络 connection)
        {
            this.网络连接 = connection;
            网络服务网关.已上线连接数 += 1U;
            this.物理地址.V = connection.MacAddress;
            this.网络地址.V = connection.网络地址;
            MainForm.更新角色属性(this, nameof(离线日期), null);
            MainForm.添加系统日志(string.Format("玩家 [{0}] [等级 {1}] 已经进入游戏", this.角色名字, this.当前等级));
        }


        public void 发送邮件(MailData mail)
        {
            mail.ShippingAddress.V = this;
            角色邮件.Add(mail);
            未读邮件.Add(mail);
            网络连接?.发送封包(new 未读邮件提醒
            {
                邮件数量 = this.未读邮件.Count
            });
        }


        public bool 角色在线(out 客户网络 网络)
        {
            网络 = 网络连接;
            return 网络 != null;
        }

        public bool 查找背包空位(out byte 空位)
        {
            for (byte b = 0; b < 背包大小.V; b += 1)
            {
                //判断角色背包表中是否包含位置b，如果不包含说明此位置为空
                if (!角色背包.ContainsKey(b))
                {
                    空位 = b;
                    return true;
                }
            }
            空位 = byte.MaxValue;
            return false;
        }

        public bool 查找背包空位(byte 数量, out byte[] 空位)
        {
            var tmp = new List<byte>();

            for (byte b = 0; b < 背包大小.V && 数量 > tmp.Count; b += 1)
            {
                if (!角色背包.ContainsKey(b))
                    tmp.Add(b);
            }

            空位 = tmp.ToArray();

            return tmp.Count == 数量;
        }

        public CharacterQuest[] 获取正在进行的任务()
        {
            return 玩家任务.Where(x => x.完成时间.V == DateTime.MinValue).ToArray();
        }

        public CharacterData()
        {
        }

        public CharacterData(AccountData 账号, string 名字, GameObjectRace 职业, GameObjectGender 性别, ObjectHairType 发型, ObjectHairColorType 发色, ObjectFaceType 脸型)
        {
            this.当前等级.V = 1;
            this.背包大小.V = 32;
            this.仓库大小.V = 16;
            this.扩展背包大小.V = 32;

            this.所属账号.V = 账号;
            this.角色名字.V = 名字;
            this.角色职业.V = 职业;
            this.角色性别.V = 性别;
            this.角色发型.V = 发型;
            this.角色发色.V = 发色;
            this.角色脸型.V = 脸型;
            this.创建日期.V = MainProcess.CurrentTime;
            this.当前血量.V = CharacterProgression.GetData(职业, 1)[GameObjectStats.最大体力];
            this.当前蓝量.V = CharacterProgression.GetData(职业, 1)[GameObjectStats.最大魔力];
            this.当前朝向.V = ComputingClass.随机方向();
            this.当前地图.V = 142;
            this.重生地图.V = 142;
            this.当前坐标.V = MapGatewayProcess.GetMapInstance(142).ResurrectionArea.RandomCoords;
            this.玩家设置.SetValue(new uint[128].ToList<uint>());

            添加初始货币();
            添加出生物品();
            添加初始技能();

            GameDataGateway.角色数据表.AddData(this, true);
            账号.角色列表.Add(this);
            this.加载完成();
        }


        public override string ToString()
        {
            DataMonitor<string> DataMonitor = this.角色名字;
            if (DataMonitor == null)
            {
                return null;
            }
            return DataMonitor.V;
        }

        private void 添加初始货币()
        {
            for (int i = 0; i <= 19; i++)
            {
                var currencyType = (GameCurrency)i;
                switch (currencyType)
                {
                    case GameCurrency.金币:
                        角色货币[(GameCurrency)i] = 0;
                        break;
                    default:
                        角色货币[(GameCurrency)i] = 0;
                        break;
                }
            }
        }

        public void 添加初始技能()
        {
            var basicInscriptionSkills = new List<ushort>();

            switch (角色职业.V)
            {
                case GameObjectRace.战士:
                    basicInscriptionSkills.Add(10300);
                    break;
                case GameObjectRace.法师:
                    basicInscriptionSkills.Add(25300);
                    break;
                case GameObjectRace.刺客:
                    basicInscriptionSkills.Add(15300);
                    break;
                case GameObjectRace.弓手:
                    basicInscriptionSkills.Add(20400);
                    break;
                case GameObjectRace.道士:
                    basicInscriptionSkills.Add(30000);
                    break;
                case GameObjectRace.龙枪:
                    basicInscriptionSkills.Add(12000);
                    break;
                default:
                    basicInscriptionSkills.Add(12000);
                    break;
            }

            foreach (var skill in basicInscriptionSkills)
            {
                if (铭文技能.DataSheet.TryGetValue(skill, out 铭文技能 inscriptionSkill))
                {
                    SkillData SkillData = new SkillData(inscriptionSkill.技能编号);
                    this.技能数据.Add(SkillData.SkillId.V, SkillData);
                    this.快捷栏位[0] = SkillData;
                    SkillData.ShorcutField.V = 0;
                }
            }
        }

        private void 添加出生物品()
        {
            foreach (var inscriptionItem in 出生物品.所有出生物品)
            {
                if (inscriptionItem.需要性别 != null && inscriptionItem.需要性别 != 角色性别.V)
                    continue;

                if (inscriptionItem.需要职业?.Length > 0 && !inscriptionItem.需要职业.Contains(角色职业.V))
                    continue;

                if (!游戏物品.DataSheet.TryGetValue(inscriptionItem.物品编号, out 游戏物品 item))
                    continue;

                if (inscriptionItem.角色背包 == ItemBackPack.人物穿戴 && item is not 装备物品)
                    continue;

                switch (inscriptionItem.角色背包)
                {
                    case ItemBackPack.人物背包:
                        for (var i = 0; i < (inscriptionItem.数量 ?? 1); i++)
                            if (查找背包空位(out byte 空闲位置))
                                角色背包[空闲位置] = item is 装备物品
                                    ? new EquipmentData((装备物品)item, this, 1, 空闲位置, false)
                                    : new ItemData(item, this, 1, 空闲位置, 1);
                        break;
                    case ItemBackPack.人物穿戴:
                        var equipment = (装备物品)item;
                        角色装备[equipment.Location] = new EquipmentData(equipment, this, 0, equipment.Location, false);
                        break;
                }
            }
        }

        public void 订阅事件()
        {
            this.所属账号.更改事件 += delegate (AccountData O)
            {
                MainForm.更新角色属性(this, "所属账号", O);
                MainForm.更新角色属性(this, "账号封禁", (O.封禁日期.V != default(DateTime)) ? O.封禁日期 : null);
            };
            this.所属账号.V.封禁日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新角色属性(this, "账号封禁", (O != default(DateTime)) ? O : null);
            };
            this.角色名字.更改事件 += delegate (string O)
            {
                MainForm.更新角色属性(this, "角色名字", O);
            };
            this.封禁日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新角色属性(this, "角色封禁", (O != default(DateTime)) ? O : null);
            };
            this.冻结日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新角色属性(this, "冻结日期", (O != default(DateTime)) ? O : null);
            };
            this.删除日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新角色属性(this, "删除日期", (O != default(DateTime)) ? O : null);
            };
            this.登陆日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新角色属性(this, "登陆日期", (O != default(DateTime)) ? O : null);
            };
            this.离线日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新角色属性(this, "离线日期", (this.网络连接 == null) ? O : null);
            };
            this.网络地址.更改事件 += delegate (string O)
            {
                MainForm.更新角色属性(this, "网络地址", O);
            };
            this.物理地址.更改事件 += delegate (string O)
            {
                MainForm.更新角色属性(this, "物理地址", O);
            };
            this.角色职业.更改事件 += delegate (GameObjectRace O)
            {
                MainForm.更新角色属性(this, "角色职业", O);
            };
            this.角色性别.更改事件 += delegate (GameObjectGender O)
            {
                MainForm.更新角色属性(this, "角色性别", O);
            };
            this.所属行会.更改事件 += delegate (GuildData O)
            {
                MainForm.更新角色属性(this, "所属行会", O);
            };
            this.消耗元宝.更改事件 += delegate (long O)
            {
                MainForm.更新角色属性(this, "消耗元宝", O);
            };
            this.转出金币.更改事件 += delegate (long O)
            {
                MainForm.更新角色属性(this, "转出金币", O);
            };
            this.背包大小.更改事件 += delegate (byte O)
            {
                MainForm.更新角色属性(this, "背包大小", O);
            };
            this.仓库大小.更改事件 += delegate (byte O)
            {
                MainForm.更新角色属性(this, "仓库大小", O);
            };
            this.本期特权.更改事件 += delegate (byte O)
            {
                MainForm.更新角色属性(this, "本期特权", O);
            };
            this.本期日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新角色属性(this, "本期日期", O);
            };
            this.上期特权.更改事件 += delegate (byte O)
            {
                MainForm.更新角色属性(this, "上期特权", O);
            };
            this.上期日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新角色属性(this, "上期日期", O);
            };
            this.剩余特权.更改事件 += delegate (List<KeyValuePair<byte, int>> O)
            {
                MainForm.更新角色属性(this, "剩余特权", O.Sum((KeyValuePair<byte, int> X) => X.Value));
            };
            this.当前等级.更改事件 += delegate (byte O)
            {
                MainForm.更新角色属性(this, "当前等级", O);
            };
            this.当前经验.更改事件 += delegate (long O)
            {
                MainForm.更新角色属性(this, "当前经验", O);
            };
            this.双倍经验.更改事件 += delegate (int O)
            {
                MainForm.更新角色属性(this, "双倍经验", O);
            };
            this.当前战力.更改事件 += delegate (int O)
            {
                MainForm.更新角色属性(this, "当前战力", O);
            };
            this.当前地图.更改事件 += delegate (int O)
            {
                游戏地图 游戏地图;
                MainForm.更新角色属性(this, "当前地图", 游戏地图.DataSheet.TryGetValue((byte)O, out 游戏地图) ? 游戏地图 : O);
            };
            this.当前坐标.更改事件 += delegate (Point O)
            {
                MainForm.更新角色属性(this, "当前坐标", string.Format("{0}, {1}", O.X, O.Y));
            };
            this.当前PK值.更改事件 += delegate (int O)
            {
                MainForm.更新角色属性(this, "当前PK值", O);
            };
            this.技能数据.更改事件 += delegate (List<KeyValuePair<ushort, SkillData>> O)
            {
                MainForm.更新角色技能(this, O);
            };
            this.角色装备.更改事件 += delegate (List<KeyValuePair<byte, EquipmentData>> O)
            {
                MainForm.更新角色装备(this, O);
            };
            this.角色背包.更改事件 += delegate (List<KeyValuePair<byte, ItemData>> O)
            {
                MainForm.更新角色背包(this, O);
            };
            this.角色仓库.更改事件 += delegate (List<KeyValuePair<byte, ItemData>> O)
            {
                MainForm.更新角色仓库(this, O);
            };
        }

        public override void 加载完成()
        {
            订阅事件();
            MainForm.添加角色数据(this);
            MainForm.更新角色技能(this, this.技能数据.ToList<KeyValuePair<ushort, SkillData>>());
            MainForm.更新角色装备(this, this.角色装备.ToList<KeyValuePair<byte, EquipmentData>>());
            MainForm.更新角色背包(this, this.角色背包.ToList<KeyValuePair<byte, ItemData>>());
            MainForm.更新角色仓库(this, this.角色仓库.ToList<KeyValuePair<byte, ItemData>>());
        }

        public override void 删除数据()
        {
            this.所属账号.V.角色列表.Remove(this);
            this.所属账号.V.冻结列表.Remove(this);
            this.所属账号.V.删除列表.Remove(this);

            this.升级装备.V?.删除数据();

            foreach (var pet in 宠物数据)
                pet.删除数据();

            foreach (var mail in 角色邮件)
                mail.删除数据();

            foreach (var item in 角色背包)
                item.Value.删除数据();

            foreach (var item in 角色装备)
                item.Value.删除数据();

            foreach (var item in 角色仓库)
                item.Value.删除数据();

            foreach (var skill in 技能数据)
                skill.Value.删除数据();

            foreach (var buff in Buff数据)
                buff.Value.删除数据();

            foreach (var quest in 玩家任务)
                quest.删除数据();

            if (所属队伍.V != null)
            {
                if (this == 所属队伍.V.队长数据)
                    所属队伍.V.删除数据();
                else
                    所属队伍.V.Members.Remove(this);
            }

            if (所属师门.V != null)
            {
                if (this == 所属师门.V.师父数据)
                    所属师门.V.删除数据();
                else
                    所属师门.V.移除徒弟(this);
            }

            if (所属行会.V != null)
            {
                所属行会.V.行会成员.Remove(this);
                所属行会.V.行会禁言.Remove(this);
            }

            foreach (CharacterData CharacterData in 好友列表)
                CharacterData.好友列表.Remove(this);

            foreach (CharacterData CharacterData2 in 粉丝列表)
                CharacterData2.偶像列表.Remove(this);

            foreach (CharacterData CharacterData3 in 仇恨列表)
                CharacterData3.仇人列表.Remove(this);

            base.删除数据();
        }

        public byte[] 角色描述()
        {
            using var ms = new MemoryStream(new byte[94]);
            using var bw = new BinaryWriter(ms);
            角色描述(bw);
            return ms.ToArray();
        }

        public void 角色描述(BinaryWriter binaryWriter)
        {
            var name = 名字描述();
            var pos = (int)binaryWriter.BaseStream.Position;

            binaryWriter.Write(数据索引.V);
            binaryWriter.Write(name);
            binaryWriter.Write((byte)0);
            binaryWriter.Seek(pos + 61, SeekOrigin.Begin);
            binaryWriter.Write((byte)角色职业.V);
            binaryWriter.Write((byte)角色性别.V);
            binaryWriter.Write((byte)角色发型.V);
            binaryWriter.Write((byte)角色发色.V);
            binaryWriter.Write((byte)角色脸型.V);
            binaryWriter.Write((byte)0);
            binaryWriter.Write(角色等级);
            binaryWriter.Write(当前地图.V);
            binaryWriter.Write(角色装备[0]?.升级次数.V ?? 0);
            binaryWriter.Write((角色装备[0]?.对应模板.V?.物品编号).GetValueOrDefault());
            binaryWriter.Write((角色装备[1]?.对应模板.V?.物品编号).GetValueOrDefault());
            binaryWriter.Write((角色装备[2]?.对应模板.V?.物品编号).GetValueOrDefault());
            binaryWriter.Write(ComputingClass.TimeShift(离线日期.V));
            binaryWriter.Write((!冻结日期.V.Equals(default(DateTime))) ? ComputingClass.TimeShift(冻结日期.V) : 0);

            binaryWriter.BaseStream.Seek(pos + 94, SeekOrigin.Begin);
        }


        public byte[] 名字描述()
        {
            return Encoding.UTF8.GetBytes(this.角色名字.V);
        }


        public byte[] 角色设置()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    foreach (uint value in this.玩家设置)
                    {
                        binaryWriter.Write(value);
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }


        public byte[] 邮箱描述()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write((ushort)this.角色邮件.Count);
                    foreach (MailData MailData in this.角色邮件)
                    {
                        binaryWriter.Write(MailData.邮件检索描述());
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }


        public readonly DataMonitor<string> 角色名字;


        public readonly DataMonitor<string> 网络地址;


        public readonly DataMonitor<string> 物理地址;


        public readonly DataMonitor<DateTime> 创建日期;


        public readonly DataMonitor<DateTime> 登陆日期;


        public readonly DataMonitor<DateTime> 冻结日期;


        public readonly DataMonitor<DateTime> 删除日期;


        public readonly DataMonitor<DateTime> 离线日期;


        public readonly DataMonitor<DateTime> 监禁日期;


        public readonly DataMonitor<DateTime> 封禁日期;


        public readonly DataMonitor<TimeSpan> 灰名时间;


        public readonly DataMonitor<TimeSpan> 减PK时间;


        public readonly DataMonitor<DateTime> 武斗日期;


        public readonly DataMonitor<DateTime> 攻沙日期;


        public readonly DataMonitor<DateTime> 领奖日期;


        public readonly DataMonitor<DateTime> 屠魔大厅;


        public readonly DataMonitor<DateTime> 屠魔兑换;


        public readonly DataMonitor<int> 屠魔次数;


        public readonly DataMonitor<DateTime> 分解日期;


        public readonly DataMonitor<int> 分解经验;


        public readonly DataMonitor<GameObjectRace> 角色职业;


        public readonly DataMonitor<GameObjectGender> 角色性别;


        public readonly DataMonitor<ObjectHairType> 角色发型;


        public readonly DataMonitor<ObjectHairColorType> 角色发色;


        public readonly DataMonitor<ObjectFaceType> 角色脸型;


        public readonly DataMonitor<int> 当前血量;


        public readonly DataMonitor<int> 当前蓝量;


        public readonly DataMonitor<byte> 当前等级;


        public readonly DataMonitor<long> 当前经验;


        public readonly DataMonitor<int> 双倍经验;


        public readonly DataMonitor<int> 当前战力;


        public readonly DataMonitor<int> 当前PK值;


        public readonly DataMonitor<int> 当前地图;


        public readonly DataMonitor<int> 重生地图;


        public readonly DataMonitor<Point> 当前坐标;


        public readonly DataMonitor<GameDirection> 当前朝向;


        public readonly DataMonitor<攻击模式> 攻击模式;


        public readonly DataMonitor<PetMode> 宠物模式;


        public readonly HashMonitor<PetData> 宠物数据;


        public readonly DataMonitor<byte> 背包大小;
        public readonly DataMonitor<byte> 仓库大小;
        public readonly DataMonitor<byte> 扩展背包大小;

        public readonly DataMonitor<long> 消耗元宝;


        public readonly DataMonitor<long> 转出金币;


        public readonly ListMonitor<uint> 玩家设置;


        public readonly DataMonitor<EquipmentData> 升级装备;


        public readonly DataMonitor<DateTime> 取回时间;


        public readonly DataMonitor<bool> 升级成功;


        public readonly DataMonitor<byte> 当前称号;


        public readonly MonitorDictionary<byte, int> 历史排名;


        public readonly MonitorDictionary<byte, int> 当前排名;


        public readonly MonitorDictionary<byte, DateTime> 称号列表;


        public readonly MonitorDictionary<GameCurrency, int> 角色货币;


        public readonly MonitorDictionary<byte, ItemData> 角色背包;
        public readonly MonitorDictionary<byte, ItemData> 角色仓库;
        public readonly DataMonitor<bool> 仓库锁;
        public readonly MonitorDictionary<byte, ItemData> 扩展背包;
        public readonly MonitorDictionary<byte, EquipmentData> 角色装备;
        public readonly MonitorDictionary<ushort, AchievementData> 角色成就;
        public readonly MonitorDictionary<byte, int> 成就变量;


        public readonly MonitorDictionary<byte, SkillData> 快捷栏位;


        public readonly MonitorDictionary<ushort, BuffData> Buff数据;


        public readonly MonitorDictionary<ushort, SkillData> 技能数据;


        public readonly MonitorDictionary<int, DateTime> 冷却数据;


        public readonly HashMonitor<MailData> 角色邮件;


        public readonly HashMonitor<MailData> 未读邮件;


        public readonly DataMonitor<byte> 预定特权;


        public readonly DataMonitor<byte> 本期特权;


        public readonly DataMonitor<byte> 上期特权;


        public readonly DataMonitor<uint> 本期记录;


        public readonly DataMonitor<uint> 上期记录;


        public readonly DataMonitor<DateTime> 本期日期;


        public readonly DataMonitor<DateTime> 上期日期;


        public readonly DataMonitor<DateTime> 补给日期;


        public readonly DataMonitor<DateTime> 战备日期;


        public readonly MonitorDictionary<byte, int> 剩余特权;


        public readonly DataMonitor<AccountData> 所属账号;


        public readonly DataMonitor<TeamData> 所属队伍;


        public readonly DataMonitor<GuildData> 所属行会;


        public readonly DataMonitor<TeacherData> 所属师门;


        public readonly HashMonitor<CharacterData> 好友列表;


        public readonly HashMonitor<CharacterData> 偶像列表;


        public readonly HashMonitor<CharacterData> 粉丝列表;


        public readonly HashMonitor<CharacterData> 仇人列表;


        public readonly HashMonitor<CharacterData> 仇恨列表;

        public readonly HashMonitor<CharacterData> 黑名单表;

        public readonly ListMonitor<ushort> 拥有坐骑;

        public readonly DataMonitor<ushort> 当前坐骑;

        public readonly HashMonitor<CharacterQuest> 玩家任务;

        public readonly DataMonitor<bool> 觉醒经验启用;

        public readonly DataMonitor<int> 觉醒经验;
    }
}
