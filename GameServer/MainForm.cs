﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using GameServer.Properties;
using GameServer.Maps;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;
using GameServer.Extensions;

namespace GameServer
{

    public partial class MainForm : Form
    {

        public static void 加载系统数据()
        {
            MainForm MainForm = MainForm.Singleton;
            MainForm.添加系统日志("开始加载系统数据...");
            MainForm.地图数据表 = new DataTable("地图数据表");
            MainForm.地图数据行 = new Dictionary<游戏地图, DataRow>();
            MainForm.地图数据表.Columns.Add("地图编号", typeof(string));
            MainForm.地图数据表.Columns.Add("地图名称", typeof(string));
            MainForm.地图数据表.Columns.Add("等级限制", typeof(string));
            MainForm.地图数据表.Columns.Add("玩家数量", typeof(string));
            MainForm.地图数据表.Columns.Add("怪物总数", typeof(uint));
            MainForm.地图数据表.Columns.Add("存活怪物总数", typeof(uint));
            MainForm.地图数据表.Columns.Add("怪物复活次数", typeof(uint));
            MainForm.地图数据表.Columns.Add("怪物掉落次数", typeof(long));
            MainForm.地图数据表.Columns.Add("金币掉落总数", typeof(long));

            if (MainForm != null)
            {
                MainForm.dgvMaps.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.dgvMaps.DataSource = MainForm.地图数据表;
                }));
            }
            MainForm.怪物数据表 = new DataTable("怪物数据表");
            MainForm.怪物数据行 = new Dictionary<游戏怪物, DataRow>();
            MainForm.数据行怪物 = new Dictionary<DataRow, 游戏怪物>();
            MainForm.怪物数据表.Columns.Add("模板编号", typeof(string));
            MainForm.怪物数据表.Columns.Add("怪物名字", typeof(string));
            MainForm.怪物数据表.Columns.Add("怪物等级", typeof(string));
            MainForm.怪物数据表.Columns.Add("怪物经验", typeof(string));
            MainForm.怪物数据表.Columns.Add("怪物级别", typeof(string));
            MainForm.怪物数据表.Columns.Add("移动间隔", typeof(string));
            MainForm.怪物数据表.Columns.Add("漫游间隔", typeof(string));
            MainForm.怪物数据表.Columns.Add("仇恨范围", typeof(string));
            MainForm.怪物数据表.Columns.Add("仇恨时长", typeof(string));
            MainForm MainForm2 = MainForm.Singleton;
            if (MainForm2 != null)
            {
                MainForm2.怪物浏览表.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.怪物浏览表.DataSource = MainForm.怪物数据表;
                }));
            }
            MainForm.掉落数据表 = new DataTable("掉落数据表");
            MainForm.怪物掉落表 = new Dictionary<游戏怪物, List<KeyValuePair<游戏物品, long>>>();
            MainForm.掉落数据表.Columns.Add("物品名字", typeof(string));
            MainForm.掉落数据表.Columns.Add("掉落数量", typeof(string));
            MainForm MainForm3 = MainForm.Singleton;
            if (MainForm3 != null)
            {
                MainForm3.掉落浏览表.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.掉落浏览表.DataSource = MainForm.掉落数据表;
                }));
            }
            SystemDataService.LoadData();
            MainForm.添加系统日志("系统数据全部加载完成");
        }


        public static void 加载客户端数据()
        {
            MainForm MainForm = MainForm.Singleton;
            MainForm.添加系统日志("客户端数据加载中...");
            MainForm.角色数据表 = new DataTable("角色数据表");
            MainForm.技能数据表 = new DataTable("技能数据表");
            MainForm.装备数据表 = new DataTable("装备数据表");
            MainForm.背包数据表 = new DataTable("装备数据表");
            MainForm.仓库数据表 = new DataTable("装备数据表");
            MainForm.角色数据行 = new Dictionary<CharacterData, DataRow>();
            MainForm.数据行角色 = new Dictionary<DataRow, CharacterData>();

            MainForm.角色数据表.Columns.Add("角色名字", typeof(string));
            MainForm.角色数据表.Columns.Add("所属账号", typeof(string));
            MainForm.角色数据表.Columns.Add("角色职业", typeof(string));
            MainForm.角色数据表.Columns.Add("角色性别", typeof(string));
            MainForm.角色数据表.Columns.Add("角色封禁", typeof(string));
            MainForm.角色数据表.Columns.Add("所属行会", typeof(string));
            MainForm.角色数据表.Columns.Add("当前等级", typeof(string));
            MainForm.角色数据表.Columns.Add("当前经验", typeof(string));
            MainForm.角色数据表.Columns.Add("双倍经验", typeof(string));
            MainForm.角色数据表.Columns.Add("当前战力", typeof(string));
            MainForm.角色数据表.Columns.Add("当前地图", typeof(string));
            MainForm.角色数据表.Columns.Add("当前坐标", typeof(string));
            MainForm.角色数据表.Columns.Add("当前PK值", typeof(string));
            MainForm.角色数据表.Columns.Add("元宝数量", typeof(string));
            MainForm.角色数据表.Columns.Add("消耗元宝", typeof(string));
            MainForm.角色数据表.Columns.Add("金币数量", typeof(string));
            MainForm.角色数据表.Columns.Add("转出金币", typeof(string));
            MainForm.角色数据表.Columns.Add("背包大小", typeof(string));
            MainForm.角色数据表.Columns.Add("仓库大小", typeof(string));
            MainForm.角色数据表.Columns.Add("师门声望", typeof(string));
            MainForm.角色数据表.Columns.Add("账号封禁", typeof(string));
            MainForm.角色数据表.Columns.Add("冻结日期", typeof(string));
            MainForm.角色数据表.Columns.Add("删除日期", typeof(string));
            MainForm.角色数据表.Columns.Add("登陆日期", typeof(string));
            MainForm.角色数据表.Columns.Add("离线日期", typeof(string));
            MainForm.角色数据表.Columns.Add("网络地址", typeof(string));
            MainForm.角色数据表.Columns.Add("物理地址", typeof(string));
            MainForm.角色数据表.Columns.Add("本期特权", typeof(string));
            MainForm.角色数据表.Columns.Add("本期日期", typeof(string));
            MainForm.角色数据表.Columns.Add("上期特权", typeof(string));
            MainForm.角色数据表.Columns.Add("上期日期", typeof(string));
            MainForm.角色数据表.Columns.Add("剩余特权", typeof(string));
           

            if (MainForm != null)
            {
                MainForm.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.dgvCharacters.DataSource = MainForm.角色数据表;
                    for (int i = 0; i < MainForm.Singleton.dgvCharacters.Columns.Count; i++)
                    {
                        MainForm.Singleton.dgvCharacters.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }));
            }
            MainForm.角色技能表 = new Dictionary<CharacterData, List<KeyValuePair<ushort, SkillData>>>();
            MainForm.技能数据表.Columns.Add("技能名字", typeof(string));
            MainForm.技能数据表.Columns.Add("技能编号", typeof(string));
            MainForm.技能数据表.Columns.Add("当前等级", typeof(string));
            MainForm.技能数据表.Columns.Add("当前经验", typeof(string));
            MainForm MainForm2 = MainForm.Singleton;
            if (MainForm2 != null)
            {
                MainForm2.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.技能浏览表.DataSource = MainForm.技能数据表;
                }));
            }
            MainForm.角色装备表 = new Dictionary<CharacterData, List<KeyValuePair<byte, EquipmentData>>>();
            MainForm.装备数据表.Columns.Add("穿戴部位", typeof(string));
            MainForm.装备数据表.Columns.Add("穿戴装备", typeof(string));
            MainForm MainForm3 = MainForm.Singleton;
            if (MainForm3 != null)
            {
                MainForm3.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.装备浏览表.DataSource = MainForm.装备数据表;
                }));
            }
            MainForm.角色背包表 = new Dictionary<CharacterData, List<KeyValuePair<byte, ItemData>>>();
            MainForm.背包数据表.Columns.Add("背包位置", typeof(string));
            MainForm.背包数据表.Columns.Add("背包物品", typeof(string));
            MainForm MainForm4 = MainForm.Singleton;
            if (MainForm4 != null)
            {
                MainForm4.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.背包浏览表.DataSource = MainForm.背包数据表;
                }));
            }
            MainForm.角色仓库表 = new Dictionary<CharacterData, List<KeyValuePair<byte, ItemData>>>();
            MainForm.仓库数据表.Columns.Add("仓库位置", typeof(string));
            MainForm.仓库数据表.Columns.Add("仓库物品", typeof(string));
            MainForm MainForm5 = MainForm.Singleton;
            if (MainForm5 != null)
            {
                MainForm5.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.仓库浏览表.DataSource = MainForm.仓库数据表;
                }));
            }
            MainForm.封禁数据表 = new DataTable();
            MainForm.封禁数据行 = new Dictionary<string, DataRow>();
            MainForm.封禁数据表.Columns.Add("网络地址", typeof(string));
            MainForm.封禁数据表.Columns.Add("物理地址", typeof(string));
            MainForm.封禁数据表.Columns.Add("到期时间", typeof(string));
            MainForm MainForm6 = MainForm.Singleton;
            if (MainForm6 != null)
            {
                MainForm6.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.封禁浏览表.DataSource = MainForm.封禁数据表;
                }));
            }
            GameDataGateway.加载数据();
            MainForm.添加系统日志("客户端数据加载完成...");

        }


        public static void 服务启动回调()
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.定时发送公告.Enabled = true;
                MainForm.Singleton.保存按钮.BackColor = Color.LightSteelBlue;
                Control control = MainForm.Singleton.停止按钮;
                MainForm.Singleton.界面定时更新.Enabled = true;
                control.Enabled = true;
                Control control2 = MainForm.Singleton.启动按钮;
                Control control3 = MainForm.Singleton.保存按钮;
                Control control4 = MainForm.Singleton.重载数据;
                MainForm.Singleton.tabConfig.Enabled = false;
                control2.Enabled = false;
                control3.Enabled = true;
                control4.Enabled = true;
            }));
        }


        public static void 服务停止回调()
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.定时发送公告.Enabled = true;
                Control control = MainForm.Singleton.启动按钮;
                MainForm.Singleton.tabConfig.Enabled = true;
                control.Enabled = true;
                Control control2 = MainForm.Singleton.停止按钮;
                MainForm.Singleton.界面定时更新.Enabled = false;
                control2.Enabled = false;
                foreach (KeyValuePair<DataGridViewRow, DateTime> keyValuePair in MainForm.公告数据表)
                {
                    keyValuePair.Key.ReadOnly = false;
                    keyValuePair.Key.Cells["AnnounceStatus"].Value = "";
                    keyValuePair.Key.Cells["AnnounceTime"].Value = "";
                    keyValuePair.Key.Cells["RemainingTimeLeft"].Value = 0;
                }
                if (MainForm.Singleton.公告浏览表.SelectedRows.Count != 0)
                {
                    MainForm.Singleton.开始公告按钮.Enabled = true;
                    MainForm.Singleton.停止公告按钮.Enabled = false;
                }
                MainForm.公告数据表.Clear();
            }));
        }


        public static void 添加系统日志(string 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.系统日志.AppendText(string.Format("[{0}]: {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 内容) + "\r\n");
                MainForm.Singleton.系统日志.ScrollToCaret();
                Control control = MainForm.Singleton.清空系统日志;
                MainForm.Singleton.保存系统日志.Enabled = true;
                control.Enabled = true;
            }));
        }

        public static void 添加封包日志(GamePacket packet, bool incoming)
        {
            if (!Config.DebugPackets) return;
            if (packet.封包属性?.NoDebug ?? false) return;

            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null) return;
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                var isScrolled = Singleton.rtbPacketsLogs.SelectionStart == Singleton.rtbPacketsLogs.Text.Length;
                var data = packet.取字节(forceNoEncrypt: true);
                var message = string.Format(
                    "[{0}]: {1} {2} ({3}) - {{{4}}}\r\n",
                    DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    incoming ? "C->S" : "S->C",
                    packet.封包属性.Id,
                    packet.封包类型.Name,
                    string.Join(", ", data.Select(x => x.ToString()).ToArray())
                );
                Singleton.rtbPacketsLogs.AppendText(message, incoming ? Color.Blue : Color.Green);
                if (isScrolled) Singleton.rtbPacketsLogs.ScrollToCaret();
            }));
        }


        public static void 添加聊天日志(string preffix, byte[] text)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.聊天日志.AppendText(string.Format("[{0:F}]: {1}", DateTime.Now, preffix + Encoding.UTF8.GetString(text).Trim(new char[1])) + "\r\n");
                MainForm.Singleton.聊天日志.ScrollToCaret();
                Control control = MainForm.Singleton.清空聊天日志;
                MainForm.Singleton.保存聊天日志.Enabled = true;
                control.Enabled = true;
            }));
        }


        public static void 添加命令日志(string 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.命令日志.AppendText(string.Format("[{0:F}]: {1}", DateTime.Now, 内容) + "\r\n");
                MainForm.Singleton.命令日志.ScrollToCaret();
                MainForm.Singleton.清空命令日志.Enabled = true;
            }));
        }


        public static void 更新连接总数(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.连接总数统计.Text = string.Format("连接总数统计: {0}", 内容);
            }));
        }


        public static void 更新已登陆数(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.已经登录统计.Text = string.Format("已经登陆: {0}", 内容);
            }));
        }


        public static void 更新已经上线(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.已经上线统计.Text = string.Format("已经上线: {0}", 内容);
            }));
        }


        public static void 更新后台帧数(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.帧数统计.Text = string.Format("帧数: {0}", 内容);
            }));
        }


        public static void 更新接收字节(long 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.接收统计.Text = string.Format("接收: {0}", 内容);
            }));
        }


        public static void 更新发送字节(long 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.发送统计.Text = string.Format("发送: {0}", 内容);
            }));
        }


        public static void 更新对象统计(int 激活对象, int 次要对象, int 对象总数)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.对象统计.Text = string.Format("对象统计 {0} / {1} / {2}", 激活对象, 次要对象, 对象总数);
            }));
        }


        public static void 添加数据显示(CharacterData 数据)
        {
            if (!MainForm.角色数据行.ContainsKey(数据))
            {
                MainForm.角色数据行[数据] = MainForm.角色数据表.NewRow();
                MainForm.角色数据表.Rows.Add(MainForm.角色数据行[数据]);
            }
        }


        public static void 修改数据显示(CharacterData 数据, string 表头文本, string 表格内容)
        {
            if (MainForm.角色数据行.ContainsKey(数据))
            {
                MainForm.角色数据行[数据][表头文本] = 表格内容;
            }
        }


        public static void 添加角色数据(CharacterData 角色)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (!MainForm.角色数据行.ContainsKey(角色))
                {
                    DataRow dataRow = MainForm.角色数据表.NewRow();
                    dataRow["角色名字"] = 角色;
                    dataRow["所属账号"] = 角色.所属账号;
                    dataRow["账号封禁"] = ((角色.所属账号.V.封禁日期.V != default(DateTime)) ? 角色.所属账号.V.封禁日期 : null);
                    dataRow["角色封禁"] = ((角色.封禁日期.V != default(DateTime)) ? 角色.封禁日期 : null);
                    dataRow["冻结日期"] = ((角色.冻结日期.V != default(DateTime)) ? 角色.冻结日期 : null);
                    dataRow["删除日期"] = ((角色.删除日期.V != default(DateTime)) ? 角色.删除日期 : null);
                    dataRow["登陆日期"] = ((角色.登陆日期.V != default(DateTime)) ? 角色.登陆日期 : null);
                    dataRow["离线日期"] = ((角色.网络连接 == null) ? 角色.离线日期 : null);
                    dataRow["网络地址"] = 角色.网络地址;
                    dataRow["物理地址"] = 角色.物理地址;
                    dataRow["角色职业"] = 角色.角色职业;
                    dataRow["角色性别"] = 角色.角色性别;
                    dataRow["所属行会"] = 角色.所属行会;
                    dataRow["元宝数量"] = 角色.元宝数量;
                    dataRow["消耗元宝"] = 角色.消耗元宝;
                    dataRow["金币数量"] = 角色.金币数量;
                    dataRow["转出金币"] = 角色.转出金币;
                    dataRow["背包大小"] = 角色.背包大小;
                    dataRow["仓库大小"] = 角色.仓库大小;
                    dataRow["师门声望"] = 角色.师门声望;
                    dataRow["本期特权"] = 角色.本期特权;
                    dataRow["本期日期"] = 角色.本期日期;
                    dataRow["上期特权"] = 角色.上期特权;
                    dataRow["上期日期"] = 角色.上期日期;
                    dataRow["剩余特权"] = 角色.剩余特权;
                    dataRow["当前等级"] = 角色.当前等级;
                    dataRow["当前经验"] = 角色.当前经验;
                    dataRow["双倍经验"] = 角色.双倍经验;
                    dataRow["当前战力"] = 角色.当前战力;
                    游戏地图 游戏地图;
                    dataRow["当前地图"] = (游戏地图.DataSheet.TryGetValue((byte)角色.当前地图.V, out 游戏地图) ? 游戏地图.地图名字 : 角色.当前地图);
                    dataRow["当前PK值"] = 角色.当前PK值;
                    dataRow["当前坐标"] = string.Format("{0}, {1}", 角色.当前坐标.V.X, 角色.当前坐标.V.Y);
                    MainForm.角色数据行[角色] = dataRow;
                    MainForm.数据行角色[dataRow] = 角色;
                    MainForm.角色数据表.Rows.Add(dataRow);
                }
            }));
        }


        public static void 移除角色数据(CharacterData character)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                DataRow dataRow;
                if (MainForm.角色数据行.TryGetValue(character, out dataRow))
                {
                    MainForm.数据行角色.Remove(dataRow);
                    MainForm.角色数据表.Rows.Remove(dataRow);
                    MainForm.角色技能表.Remove(character);
                    MainForm.角色背包表.Remove(character);
                    MainForm.角色装备表.Remove(character);
                    MainForm.角色仓库表.Remove(character);
                }
            }));
        }


        public static void 界面更新处理(object sender, EventArgs e)
        {
            MainForm.技能数据表.Rows.Clear();
            MainForm.装备数据表.Rows.Clear();
            MainForm.背包数据表.Rows.Clear();
            MainForm.仓库数据表.Rows.Clear();
            MainForm.掉落数据表.Rows.Clear();
            if (MainForm.Singleton == null)
            {
                return;
            }
            if (MainForm.Singleton.dgvCharacters.Rows.Count > 0 && MainForm.Singleton.dgvCharacters.SelectedRows.Count > 0)
            {
                DataRow row = (MainForm.Singleton.dgvCharacters.Rows[MainForm.Singleton.dgvCharacters.SelectedRows[0].Index].DataBoundItem as DataRowView).Row;
                CharacterData key;
                if (MainForm.数据行角色.TryGetValue(row, out key))
                {
                    List<KeyValuePair<ushort, SkillData>> list;
                    if (MainForm.角色技能表.TryGetValue(key, out list))
                    {
                        foreach (KeyValuePair<ushort, SkillData> keyValuePair in list)
                        {
                            DataRow dataRow = MainForm.技能数据表.NewRow();
                            dataRow["技能名字"] = keyValuePair.Value.铭文模板.技能名字;
                            dataRow["技能编号"] = keyValuePair.Value.SkillId;
                            dataRow["当前等级"] = keyValuePair.Value.SkillLevel;
                            dataRow["当前经验"] = keyValuePair.Value.SkillExp;
                            MainForm.技能数据表.Rows.Add(dataRow);
                        }
                    }
                    List<KeyValuePair<byte, EquipmentData>> list2;
                    if (MainForm.角色装备表.TryGetValue(key, out list2))
                    {
                        foreach (KeyValuePair<byte, EquipmentData> keyValuePair2 in list2)
                        {
                            DataRow dataRow2 = MainForm.装备数据表.NewRow();
                            dataRow2["穿戴部位"] = (EquipmentWearingParts)keyValuePair2.Key;
                            dataRow2["穿戴装备"] = keyValuePair2.Value;
                            MainForm.装备数据表.Rows.Add(dataRow2);
                        }
                    }
                    List<KeyValuePair<byte, ItemData>> list3;
                    if (MainForm.角色背包表.TryGetValue(key, out list3))
                    {
                        foreach (KeyValuePair<byte, ItemData> keyValuePair3 in list3)
                        {
                            DataRow dataRow3 = MainForm.背包数据表.NewRow();
                            dataRow3["背包位置"] = keyValuePair3.Key;
                            dataRow3["背包物品"] = keyValuePair3.Value;
                            MainForm.背包数据表.Rows.Add(dataRow3);
                        }
                    }
                    List<KeyValuePair<byte, ItemData>> list4;
                    if (MainForm.角色仓库表.TryGetValue(key, out list4))
                    {
                        foreach (KeyValuePair<byte, ItemData> keyValuePair4 in list4)
                        {
                            DataRow dataRow4 = MainForm.仓库数据表.NewRow();
                            dataRow4["仓库位置"] = keyValuePair4.Key;
                            dataRow4["仓库物品"] = keyValuePair4.Value;
                            MainForm.仓库数据表.Rows.Add(dataRow4);
                        }
                    }
                }
            }
            if (MainForm.Singleton.怪物浏览表.Rows.Count > 0 && MainForm.Singleton.怪物浏览表.SelectedRows.Count > 0)
            {
                DataRow row2 = (MainForm.Singleton.怪物浏览表.Rows[MainForm.Singleton.怪物浏览表.SelectedRows[0].Index].DataBoundItem as DataRowView).Row;
                游戏怪物 key2;
                List<KeyValuePair<游戏物品, long>> list5;
                if (MainForm.数据行怪物.TryGetValue(row2, out key2) && MainForm.怪物掉落表.TryGetValue(key2, out list5))
                {
                    foreach (KeyValuePair<游戏物品, long> keyValuePair5 in list5)
                    {
                        DataRow dataRow5 = MainForm.掉落数据表.NewRow();
                        dataRow5["物品名字"] = keyValuePair5.Key.物品名字;
                        dataRow5["掉落数量"] = keyValuePair5.Value;
                        MainForm.掉落数据表.Rows.Add(dataRow5);
                    }
                }
            }
        }


        public static void 更新角色属性(CharacterData 角色, string fieldChanged, object 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                DataRow dataRow;
                if (MainForm.角色数据行.TryGetValue(角色, out dataRow))
                {
                    dataRow[fieldChanged] = 内容;
                }
            }));
        }


        public static void 更新角色技能(CharacterData 角色, List<KeyValuePair<ushort, SkillData>> 技能)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.角色技能表[角色] = 技能;
            }));
        }


        public static void 更新角色装备(CharacterData 角色, List<KeyValuePair<byte, EquipmentData>> 装备)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.角色装备表[角色] = 装备;
            }));
        }


        public static void 更新角色背包(CharacterData 角色, List<KeyValuePair<byte, ItemData>> 物品)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.角色背包表[角色] = 物品;
            }));
        }


        public static void 更新角色仓库(CharacterData 角色, List<KeyValuePair<byte, ItemData>> 物品)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.角色仓库表[角色] = 物品;
            }));
        }


        public static void 添加地图数据(MapInstance 地图)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (!MainForm.地图数据行.ContainsKey(地图.地图模板))
                {
                    DataRow dataRow = MainForm.地图数据表.NewRow();
                    dataRow["地图编号"] = 地图.MapId;
                    dataRow["地图名称"] = 地图.地图模板;
                    dataRow["等级限制"] = 地图.MinLevel;
                    dataRow["玩家数量"] = 地图.NrPlayers.Count;
                    dataRow["怪物总数"] = 地图.TotalMobs;
                    dataRow["存活怪物总数"] = 地图.MobsAlive;
                    dataRow["怪物复活次数"] = 地图.MobsRespawned;
                    dataRow["怪物掉落次数"] = 地图.MobsDrops;
                    dataRow["金币掉落总数"] = 地图.MobGoldDrop;
                    MainForm.地图数据行[地图.地图模板] = dataRow;
                    MainForm.地图数据表.Rows.Add(dataRow);
                }
            }));
        }


        public static void 更新地图数据(MapInstance map, string field, object content)
        {
            Singleton?.BeginInvoke(() =>
            {
                if (地图数据行.TryGetValue(map.地图模板, out DataRow dataRow))
                {
                    if (field == "存活怪物总数" || field == "怪物复活次数")
                    {
                        dataRow[field] = (uint)(Convert.ToUInt32(dataRow[field]) + (int)content);
                        return;
                    }
                    if (field == "金币掉落总数" || field == "怪物掉落次数")
                    {
                        dataRow[field] = Convert.ToInt64(dataRow[field]) + (long)content;
                        return;
                    }
                    dataRow[field] = content;
                }
            });
        }


        public static void 添加怪物数据(游戏怪物 怪物)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (!MainForm.怪物数据行.ContainsKey(怪物))
                {
                    DataRow dataRow = MainForm.怪物数据表.NewRow();
                    dataRow["模板编号"] = 怪物.怪物编号;
                    dataRow["怪物名字"] = 怪物.怪物名字;
                    dataRow["怪物等级"] = 怪物.怪物等级;
                    dataRow["怪物级别"] = 怪物.怪物级别;
                    dataRow["怪物经验"] = 怪物.怪物提供经验;
                    dataRow["移动间隔"] = 怪物.怪物移动间隔;
                    dataRow["仇恨范围"] = 怪物.怪物仇恨范围;
                    dataRow["仇恨时长"] = 怪物.怪物仇恨时间;
                    MainForm.怪物数据行[怪物] = dataRow;
                    MainForm.数据行怪物[dataRow] = 怪物;
                    MainForm.怪物数据表.Rows.Add(dataRow);
                }
            }));
        }


        public static void 更新掉落统计(游戏怪物 怪物, List<KeyValuePair<游戏物品, long>> 物品)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.怪物掉落表[怪物] = 物品;
            }));
        }


        public static void 添加封禁数据(string 地址, object 时间, bool NetAddress = true)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (!MainForm.封禁数据行.ContainsKey(地址))
                {
                    DataRow dataRow = MainForm.封禁数据表.NewRow();
                    dataRow["网络地址"] = (NetAddress ? 地址 : null);
                    dataRow["物理地址"] = (NetAddress ? null : 地址);
                    dataRow["到期时间"] = 时间;
                    MainForm.封禁数据行[地址] = dataRow;
                    MainForm.封禁数据表.Rows.Add(dataRow);
                }
            }));
        }


        public static void 更新封禁数据(string 地址, object 时间, bool NetAddress = true)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                DataRow dataRow;
                if (MainForm.封禁数据行.TryGetValue(地址, out dataRow))
                {
                    if (NetAddress)
                    {
                        dataRow["网络地址"] = 时间;
                        return;
                    }
                    dataRow["物理地址"] = 时间;
                }
            }));
        }


        public static void 移除封禁数据(string 地址)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                DataRow row;
                if (MainForm.封禁数据行.TryGetValue(地址, out row))
                {
                    MainForm.封禁数据行.Remove(地址);
                    MainForm.封禁数据表.Rows.Remove(row);
                }
            }));
        }


        public MainForm()
        {
            this.InitializeComponent();
            //根据配置文件判断是否显示数据包选项卡
            if (!Config.DebugPackets) MainTabs.TabPages.Remove(tabPackets);

            MainForm.Singleton = this;
            string 系统公告文本 = Settings.Default.系统公告文本;
            MainForm.公告数据表 = new Dictionary<DataGridViewRow, DateTime>();
            string[] array = 系统公告文本.Split(new char[]
            {
                '\r',
                '\n'
            }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < array.Length; i++)
            {
                string[] array2 = array[i].Split(new char[]
                {
                    '\t'
                });
                int index = this.公告浏览表.Rows.Add();

                this.公告浏览表.Rows[index].Cells["间隔分钟"].Value = array2[0];
                this.公告浏览表.Rows[index].Cells["公告次数"].Value = array2[1];
                this.公告浏览表.Rows[index].Cells["公告内容"].Value = array2[2];

            }
            this.dgvCharacters.ColumnHeadersDefaultCellStyle.Font = (this.dgvMaps.ColumnHeadersDefaultCellStyle.Font = (this.怪物浏览表.ColumnHeadersDefaultCellStyle.Font = (this.掉落浏览表.ColumnHeadersDefaultCellStyle.Font = (this.封禁浏览表.ColumnHeadersDefaultCellStyle.Font = (this.dgvCharacters.DefaultCellStyle.Font = (this.dgvMaps.DefaultCellStyle.Font = (this.怪物浏览表.DefaultCellStyle.Font = (this.封禁浏览表.DefaultCellStyle.Font = (this.掉落浏览表.DefaultCellStyle.Font = new Font("宋体", 9f))))))))));
            this.S_软件注册代码.Text = (Config.软件注册代码 = Settings.Default.软件注册码);
            this.S_GameData目录.Text = (Config.GameDataPath = Settings.Default.GameData目录);
            this.S_数据备份目录.Text = (Config.BackupFolder = Settings.Default.GameDataDirectory);
            this.S_GSPort.Value = (Config.客户端连接端口 = Settings.Default.GSPort);
            this.S_TSPort.Value = (Config.门票接收端口 = Settings.Default.TSPort);
            this.S_PacketLimit.Value = (Config.封包限定数量 = Settings.Default.PacketLimit);
            this.S_AbnormalBlockTime.Value = (Config.异常屏蔽时间 = Settings.Default.AbnormalBlockTime);
            this.S_DisconnectTime.Value = (Config.掉线判定时间 = Settings.Default.DisconnectTime);
            this.S_MaxLevel.Value = (Config.游戏开放等级 = Settings.Default.MaxLevel);
            this.S_NoobLevel.Value = (Config.新手扶持等级 = Settings.Default.NoobLevel);
            this.S_EquipRepairDto.Value = (Config.装备特修折扣 = Settings.Default.EquipRepairDto);
            this.S_ExtraDropRate.Value = (Config.物品额外爆率 = Settings.Default.ExtraDropRate);
            this.S_ExpRate.Value = (Config.怪物经验倍率 = Settings.Default.ExpRate);
            this.S_LessExpGrade.Value = (ComputingClass.LessExpGradeLevel = Config.减收益等级差 = (ushort)Settings.Default.LessExpGrade);
            this.S_LessExpGradeRate.Value = (ComputingClass.LessExpGradeRate = Config.收益减少比率 = Settings.Default.LessExpGradeRate);
            this.S_TemptationTime.Value = (Config.怪物诱惑时长 = Settings.Default.TemptationTime);
            this.S_ItemOwnershipTime.Value = (Config.物品归属时间 = (ushort)Settings.Default.ItemOwnershipTime);
            this.S_ItemCleaningTime.Value = (Config.物品清理时间 = (ushort)Settings.Default.ItemCleaningTime);


            Task.Run(delegate ()
            {
                Thread.Sleep(100);
                BeginInvoke(new MethodInvoker(delegate ()
                {
                        Control control = this.下方控件页;
                        this.tabConfig.Enabled = false;
                        control.Enabled = false;
                    }));
                加载系统数据();
                加载客户端数据();
                base.BeginInvoke(new MethodInvoker(delegate ()
                {
                        this.界面定时更新.Tick += MainForm.界面更新处理;
                        this.dgvCharacters.SelectionChanged += MainForm.界面更新处理;
                        this.怪物浏览表.SelectionChanged += MainForm.界面更新处理;
                        Control control = this.下方控件页;
                        this.tabConfig.Enabled = true;
                        control.Enabled = true;
                    }));
            });
        }



        private void 保存数据库_Click(object sender, EventArgs e)
        {
            Control 保存按钮 = this.保存按钮;
            Control 启动按钮 = this.启动按钮;
            Control 停止按钮 = this.停止按钮;
            停止按钮.Enabled = false;
            启动按钮.Enabled = false;
            保存按钮.Enabled = false;
            保存按钮.BackColor = Color.LightSteelBlue;
            Task.Run(delegate ()
            {
                MainForm.添加系统日志("正在保存用户数据...");
                GameDataGateway.SaveData();
                GameDataGateway.CleanUp();
                MainForm.添加系统日志("用户数据保存完成...");
                base.BeginInvoke(new MethodInvoker(delegate ()
                {
                    if (MainProcess.Running)
                    {
                        停止按钮.Enabled = true;
                    }
                    else
                    {
                        启动按钮.Enabled = true;
                    }
                    保存按钮.Enabled = true;
                        
                    }));
            });
        }


        private void 启动服务器_Click(object sender, EventArgs e)
        {
            MainProcess.Start();
            Config.软件注册代码 = (Settings.Default.软件注册码 = this.S_软件注册代码.Text);
            Settings.Default.Save();
            MainForm.地图数据表 = new DataTable("地图数据表");
            MainForm.地图数据行 = new Dictionary<游戏地图, DataRow>();
            MainForm.地图数据表.Columns.Add("地图编号", typeof(string));
            MainForm.地图数据表.Columns.Add("地图名称", typeof(string));
            MainForm.地图数据表.Columns.Add("等级限制", typeof(string));
            MainForm.地图数据表.Columns.Add("玩家数量", typeof(string));
            MainForm.地图数据表.Columns.Add("怪物总数", typeof(string));
            MainForm.地图数据表.Columns.Add("存活怪物总数", typeof(string));
            MainForm.地图数据表.Columns.Add("怪物复活次数", typeof(string));
            MainForm.地图数据表.Columns.Add("怪物掉落次数", typeof(string));
            MainForm.地图数据表.Columns.Add("金币掉落总数", typeof(string));
            MainForm.Singleton.dgvMaps.DataSource = MainForm.地图数据表;
            MainForm.怪物数据表 = new DataTable("怪物数据表");
            MainForm.怪物数据行 = new Dictionary<游戏怪物, DataRow>();
            MainForm.数据行怪物 = new Dictionary<DataRow, 游戏怪物>();
            MainForm.怪物数据表.Columns.Add("模板编号", typeof(string));
            MainForm.怪物数据表.Columns.Add("怪物名字", typeof(string));
            MainForm.怪物数据表.Columns.Add("怪物等级", typeof(string));
            MainForm.怪物数据表.Columns.Add("怪物经验", typeof(string));
            MainForm.怪物数据表.Columns.Add("怪物级别", typeof(string));
            MainForm.怪物数据表.Columns.Add("移动间隔", typeof(string));
            MainForm.怪物数据表.Columns.Add("漫游间隔", typeof(string));
            MainForm.怪物数据表.Columns.Add("仇恨范围", typeof(string));
            MainForm.怪物数据表.Columns.Add("仇恨时长", typeof(string));
            MainForm.Singleton.怪物浏览表.DataSource = MainForm.怪物数据表;
            MainForm.掉落数据表 = new DataTable("掉落数据表");
            MainForm.怪物掉落表 = new Dictionary<游戏怪物, List<KeyValuePair<游戏物品, long>>>();
            MainForm.掉落数据表.Columns.Add("物品名字", typeof(string));
            MainForm.掉落数据表.Columns.Add("掉落数量", typeof(string));
            MainForm.Singleton.掉落浏览表.DataSource = MainForm.掉落数据表;
            this.主选项卡.SelectedIndex = 0;
            this.保存按钮.BackColor = Color.LightSteelBlue;
            Control control = this.保存按钮;
            Control control2 = this.启动按钮;
            Control control3 = this.停止按钮;
            this.tabConfig.Enabled = false;
            control3.Enabled = false;
            control2.Enabled = false;
            control.Enabled = false;
            MainProcess.NextSaveDataTime = MainProcess.CurrentTime.AddSeconds(Settings.Default.数据保存间隔);
        }


        private void 停止服务器_Click(object sender, EventArgs e)
        {
            foreach (客户网络 connection in 网络服务网关.网络连接表)
            {
                try
                {
                    TcpClient tcpClient = connection.当前连接;
                    if (tcpClient != null)
                    {
                        Socket client = tcpClient.Client;
                        if (client != null)
                        {
                            client.Shutdown(SocketShutdown.Both);
                        }
                        tcpClient.Close();
                    }
                }
                catch
                {
                }
            }
            if (MessageBox.Show("确定要停止服务器吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                MainProcess.Stop();
                this.停止按钮.Enabled = false;
            }
        }


        private void 关闭主界面_Click(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("確定要关闭服务器吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                for (; ; )
                {
                    Thread 主线程 = MainProcess.MainThread;
                    if (主线程 == null || !主线程.IsAlive)
                    {
                        break;
                    }
                    MainProcess.Stop();
                    Thread.Sleep(1);
                }
                if (GameDataGateway.已经修改 && MessageBox.Show("是否需要保存已修改但尚未保存的数据?", "保存数据", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    GameDataGateway.SaveData();
                    GameDataGateway.CleanUp();
                    return;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }


        private void 保存数据提醒_Tick(object sender, EventArgs e)
        {
            if (this.保存按钮.Enabled && GameDataGateway.已经修改)
            {
                if (this.保存按钮.BackColor == Color.LightSteelBlue)
                {
                    this.保存按钮.BackColor = Color.PaleVioletRed;
                    return;
                }
                this.保存按钮.BackColor = Color.LightSteelBlue;
            }
        }

        private void 重载数据_Click(object sender, EventArgs e)
        {
            MainForm.添加系统日志("开始加载系统数据...");
            this.重载数据.Enabled = false;
            SystemDataService.ReloadData();
            this.重载数据.Enabled = true;
        }

        private void 清空系统日志_Click(object sender, EventArgs e)
        {
            this.系统日志.Clear();
            Control control = this.清空系统日志;
            this.保存系统日志.Enabled = false;
            control.Enabled = false;
        }


        private void 清空聊天日志_Click(object sender, EventArgs e)
        {
            this.聊天日志.Clear();
            Control control = this.清空聊天日志;
            this.保存聊天日志.Enabled = false;
            control.Enabled = false;
        }


        private void 清空命令日志_Click(object sender, EventArgs e)
        {
            this.命令日志.Clear();
            this.清空命令日志.Enabled = false;
        }


        private void 保存系统日志_Click(object sender, EventArgs e)
        {
            if (this.系统日志.Text != null && !(this.系统日志.Text == ""))
            {
                if (!Directory.Exists(".\\Log\\Sys"))
                {
                    Directory.CreateDirectory(".\\Log\\Sys");
                }
                File.WriteAllText(string.Format(".\\Log\\Sys\\{0:yyyy-MM-dd--HH-mm-ss}.txt", DateTime.Now), this.系统日志.Text.Replace("\n", "\r\n"));
                MainForm.添加系统日志("系统日志保存成功");
                this.清空系统日志_Click(sender, e);
                return;
            }
        }


        private void 保存聊天日志_Click(object sender, EventArgs e)
        {
            if (this.聊天日志.Text != null && !(this.聊天日志.Text == ""))
            {
                if (!Directory.Exists(".\\Log\\Chat"))
                {
                    Directory.CreateDirectory(".\\Log\\Chat");
                }
                File.WriteAllText(string.Format(".\\Log\\Chat\\{0:yyyy-MM-dd--HH-mm-ss}.txt", DateTime.Now), this.聊天日志.Text);
                MainForm.添加系统日志("聊天日志保存成功\r\n");
                this.清空聊天日志_Click(sender, e);
                return;
            }
        }


        private void 重载SystemData_Click(object sender, EventArgs e)
        {
            Control control = this.下方控件页;
            this.tabConfig.Enabled = false;
            control.Enabled = false;
            Task.Run(delegate ()
            {
                MainForm.加载系统数据();
                base.BeginInvoke(new MethodInvoker(delegate ()
                {
                        Control control2 = this.下方控件页;
                        this.tabConfig.Enabled = true;
                        control2.Enabled = true;
                    }));
            });
        }


        private void 重载客户数据_Click(object sender, EventArgs e)
        {
            Control control = this.下方控件页;
            this.tabConfig.Enabled = false;
            control.Enabled = false;
            Task.Run(delegate ()
            {
                MainForm.加载客户端数据();
                base.BeginInvoke(new MethodInvoker(delegate ()
                {
                        Control control2 = this.下方控件页;
                        this.tabConfig.Enabled = true;
                        control2.Enabled = true;
                    }));
            });
        }


        private void 选择数据目录_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "请选择文件夹"
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (sender == this.S_浏览数据目录)
                {
                    Config.GameDataPath = (Settings.Default.GameData目录 = (this.S_GameData目录.Text = folderBrowserDialog.SelectedPath));
                    Settings.Default.Save();
                    return;
                }
                if (sender == this.S_浏览备份目录)
                {
                    Config.BackupFolder = (Settings.Default.GameDataDirectory = (this.S_数据备份目录.Text = folderBrowserDialog.SelectedPath));
                    Settings.Default.Save();
                    return;
                }
                if (sender == this.S_浏览合并目录)
                {
                    this.S_合并数据目录.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }


        private void 更改设置Value_Value(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            if (numericUpDown != null)
            {
                string name = numericUpDown.Name;

                switch (name)
                {
                    case "S_收益减少比率":
                        Config.收益减少比率 = (Settings.Default.LessExpGradeRate = numericUpDown.Value);
                        break;
                    case "S_判定掉线时间":
                        Config.掉线判定时间 = (Settings.Default.DisconnectTime = (ushort)numericUpDown.Value);
                        break;
                    case "S_游戏开放等级":
                        Config.游戏开放等级 = (Settings.Default.MaxLevel = (byte)numericUpDown.Value);
                        break;
                    case "S_怪物诱惑时长":
                        Config.怪物诱惑时长 = (Settings.Default.TemptationTime = (ushort)numericUpDown.Value);
                        break;
                    case "S_怪物经验倍率":
                        Config.怪物经验倍率 = (Settings.Default.ExpRate = numericUpDown.Value);
                        break;
                    case "S_门票接收端口":
                        Config.门票接收端口 = (Settings.Default.TSPort = (ushort)numericUpDown.Value);
                        break;
                    case "S_异常屏蔽时间":
                        Config.异常屏蔽时间 = (Settings.Default.AbnormalBlockTime = (ushort)numericUpDown.Value);
                        break;
                    case "S_减收益等级差":
                        Config.减收益等级差 = (ushort)(Settings.Default.LessExpGrade = (byte)numericUpDown.Value);
                        break;
                    case "S_物品额外爆率":
                        Config.物品额外爆率 = (Settings.Default.ExtraDropRate = numericUpDown.Value);
                        break;
                    case "S_物品归属时间":
                        Config.物品归属时间 = (ushort)(Settings.Default.ItemOwnershipTime = (byte)numericUpDown.Value);
                        break;
                    case "S_新手扶持等级":
                        Config.新手扶持等级 = (Settings.Default.NoobLevel = (byte)numericUpDown.Value);
                        break;
                    case "S_装备特修折扣":
                        Config.装备特修折扣 = (Settings.Default.EquipRepairDto = numericUpDown.Value);
                        break;
                    case "S_物品清理时间":
                        Config.物品清理时间 = (ushort)(Settings.Default.ItemCleaningTime = (byte)numericUpDown.Value);
                        break;
                    case "S_封包限定数量":
                        Config.封包限定数量 = (Settings.Default.PacketLimit = (ushort)numericUpDown.Value);
                        break;
                    case "S_客户端连接端口":
                        Config.客户端连接端口 = (Settings.Default.GSPort = (ushort)numericUpDown.Value);
                        break;
                    default:
                        MessageBox.Show("未知属性! " + numericUpDown.Name);
                        break;
                }

                Settings.Default.Save();
            }
        }


        private void 执行GMCommand行_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13) && this.GMCommand文本.Text.Length > 0)
            {
                this.主选项卡.SelectedIndex = 0;
                this.MainTabs.SelectedIndex = 2;
                MainForm.添加命令日志("=> " + this.GMCommand文本.Text);
                GMCommand GMCommand;
                if (this.GMCommand文本.Text[0] != '@')
                {
                    MainForm.添加命令日志("<= 命令解析错误, GM命令必须以 '@' 开头. 输入 '@查看命令' 获取所有受支持的命令格式");
                }
                else if (this.GMCommand文本.Text.Trim(new char[]
                {
                    '@',
                    ' '
                }).Length == 0)
                {
                    MainForm.添加命令日志("<= 命令解析错误, GM命令不能为空. 输入 '@查看命令' 获取所有受支持的命令格式");
                }
                else if (GMCommand.解析命令(this.GMCommand文本.Text, out GMCommand))
                {
                    if (GMCommand.ExecutionWay == ExecutionWay.前台立即执行)
                    {
                        GMCommand.Execute();
                    }
                    else if (GMCommand.ExecutionWay == ExecutionWay.优先后台执行)
                    {
                        if (MainProcess.Running)
                        {
                            MainProcess.CommandsQueue.Enqueue(GMCommand);
                        }
                        else
                        {
                            GMCommand.Execute();
                        }
                    }
                    else if (GMCommand.ExecutionWay == ExecutionWay.只能后台执行)
                    {
                        if (MainProcess.Running)
                        {
                            MainProcess.CommandsQueue.Enqueue(GMCommand);
                        }
                        else
                        {
                            MainForm.添加命令日志("<= 命令执行失败, 当前命令只能在服务器运行时执行, 请先启动服务器");
                        }
                    }
                    else if (GMCommand.ExecutionWay == ExecutionWay.只能空闲执行)
                    {
                        if (!MainProcess.Running && (MainProcess.MainThread == null || !MainProcess.MainThread.IsAlive))
                        {
                            GMCommand.Execute();
                        }
                        else
                        {
                            MainForm.添加命令日志("<= 命令执行失败, 当前命令只能在服务器未运行时执行, 请先关闭服务器");
                        }
                    }
                    e.Handled = true;
                }
                this.GMCommand文本.Clear();
            }
        }


        private void 合并客户数据_Click(object sender, EventArgs e)
        {
            if (MainProcess.Running)
            {
                MessageBox.Show("合并数据只能在服务器未运行时执行");
                return;
            }
            Dictionary<Type, DataTableBase> Data型表 = GameDataGateway.数据类型表;
            if (Data型表 == null || Data型表.Count == 0)
            {
                MessageBox.Show("需要先加载当前客户数据后才能与指定客户数据合并");
                return;
            }
            if (!Directory.Exists(this.S_合并数据目录.Text))
            {
                MessageBox.Show("请选择有效的 Data.db 文件目录");
                return;
            }
            if (!File.Exists(this.S_合并数据目录.Text + "\\Data.db"))
            {
                MessageBox.Show("选择的目录中没有找到 Data.db 文件");
                return;
            }
            if (MessageBox.Show("即将执行数据合并操作\r\n\r\n此操作不可逆, 请做好数据备份\r\n\r\n确定要执行吗?", "危险操作", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                GameDataGateway.合并数据(this.S_合并数据目录.Text + "\\Data.db");
            }
        }


        private void 角色右键菜单_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem != null && MainForm.Singleton.dgvCharacters.Rows.Count > 0 && MainForm.Singleton.dgvCharacters.SelectedRows.Count > 0)
            {
                DataRow row = (MainForm.Singleton.dgvCharacters.Rows[MainForm.Singleton.dgvCharacters.SelectedRows[0].Index].DataBoundItem as DataRowView).Row;
                if (toolStripMenuItem.Name == "右键菜单_复制Account")
                {
                    Clipboard.SetDataObject(row["所属账号"]);
                }
                if (toolStripMenuItem.Name == "右键菜单_复制CharName")
                {
                    Clipboard.SetDataObject(row["角色名字"]);
                }
                if (toolStripMenuItem.Name == "右键菜单_复制NetAddress")
                {
                    Clipboard.SetDataObject(row["网络地址"]);
                }
                if (toolStripMenuItem.Name == "右键菜单_复制MacAddress")
                {
                    Clipboard.SetDataObject(row["物理地址"]);
                }
            }
        }


        private void 添加公告按钮_Click(object sender, EventArgs e)
        {
            int index = this.公告浏览表.Rows.Add();
            this.公告浏览表.Rows[index].Cells["公告计时"].Value = 5;
            this.公告浏览表.Rows[index].Cells["公告次数"].Value = 1;
            this.公告浏览表.Rows[index].Cells["公告内容"].Value = "编辑公告内容";
            string text = null;
            int i = 0;
            while (i < this.公告浏览表.Rows.Count)
            {
                object value = this.公告浏览表.Rows[i].Cells["公告计时"].Value;
                if (value == null)
                {
                    goto IL_CE;
                }
                string text2;
                if ((text2 = value.ToString()) == null)
                {
                    goto IL_CE;
                }
            IL_D4:
                string text3 = text2;
                object value2 = this.公告浏览表.Rows[i].Cells["公告次数"].Value;
                if (value2 == null)
                {
                    goto IL_109;
                }
                string text4;
                if ((text4 = value2.ToString()) == null)
                {
                    goto IL_109;
                }
            IL_10F:
                string text5 = text4;
                object value3 = this.公告浏览表.Rows[i].Cells["公告内容"].Value;
                if (value3 == null)
                {
                    goto IL_145;
                }
                string text6;
                if ((text6 = value3.ToString()) == null)
                {
                    goto IL_145;
                }
            IL_14B:
                string text7 = text6;
                text = string.Concat(new string[]
                {
                    text,
                    text3,
                    "\t",
                    text5,
                    "\t",
                    text7,
                    "\r\n"
                });
                i++;
                continue;
            IL_145:
                text6 = "";
                goto IL_14B;
            IL_109:
                text4 = "";
                goto IL_10F;
            IL_CE:
                text2 = "";
                goto IL_D4;
            }
            Settings.Default.系统公告文本 = text;
            Settings.Default.Save();
        }


        private void 删除公告按钮_Click(object sender, EventArgs e)
        {
            if (this.公告浏览表.Rows.Count != 0 && this.公告浏览表.SelectedRows.Count != 0)
            {
                DataGridViewRow key = this.公告浏览表.Rows[this.公告浏览表.SelectedRows[0].Index];
                MainForm.公告数据表.Remove(key);
                this.公告浏览表.Rows.RemoveAt(this.公告浏览表.SelectedRows[0].Index);
                string text = null;
                int i = 0;
                while (i < this.公告浏览表.Rows.Count)
                {
                    object value = this.公告浏览表.Rows[i].Cells["公告计时"].Value;
                    if (value == null)
                    {
                        goto IL_C0;
                    }
                    string text2;
                    if ((text2 = value.ToString()) == null)
                    {
                        goto IL_C0;
                    }
                IL_C6:
                    string text3 = text2;
                    object value2 = this.公告浏览表.Rows[i].Cells["公告次数"].Value;
                    if (value2 == null)
                    {
                        goto IL_FC;
                    }
                    string text4;
                    if ((text4 = value2.ToString()) == null)
                    {
                        goto IL_FC;
                    }
                IL_102:
                    string text5 = text4;
                    object value3 = this.公告浏览表.Rows[i].Cells["公告内容"].Value;
                    if (value3 == null)
                    {
                        goto IL_137;
                    }
                    string text6;
                    if ((text6 = value3.ToString()) == null)
                    {
                        goto IL_137;
                    }
                IL_13D:
                    string text7 = text6;
                    text = string.Concat(new string[]
                    {
                        text,
                        text3,
                        "\t",
                        text5,
                        "\t",
                        text7,
                        "\r\n"
                    });
                    i++;
                    continue;
                IL_137:
                    text6 = "";
                    goto IL_13D;
                IL_FC:
                    text4 = "";
                    goto IL_102;
                IL_C0:
                    text2 = "";
                    goto IL_C6;
                }
                Settings.Default.系统公告文本 = text;
                Settings.Default.Save();
                return;
            }
        }


        private void 开始公告按钮_Click(object sender, EventArgs e)
        {
            if (!MainProcess.Running || !this.停止按钮.Enabled)
            {
                Task.Run(delegate ()
                {
                    MessageBox.Show("服务器未启动，请先启动服务器");
                });
                return;
            }
            if (this.公告浏览表.Rows.Count == 0 || this.公告浏览表.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow dataGridViewRow = this.公告浏览表.Rows[this.公告浏览表.SelectedRows[0].Index];
            int num;
            if (dataGridViewRow.Cells["间隔分钟"].Value == null || !int.TryParse(dataGridViewRow.Cells["间隔分钟"].Value.ToString(), out num) || num <= 0)
            {
                Task.Run(delegate ()
                {
                    MessageBox.Show("系统公告开启失败，公告间隔必须为大于0的整数");
                });
                return;
            }
            int num2;
            if (!int.TryParse(dataGridViewRow.Cells["公告次数"].Value.ToString(), out num2) || num2 <= 0)
            {
                Task.Run(delegate ()
                {
                    MessageBox.Show("系统公告开启失败，公告数量必须为大于0的整数");
                });
                return;
            }
            if (dataGridViewRow.Cells["公告内容"].Value != null && dataGridViewRow.Cells["公告内容"].Value.ToString().Length > 0)
            {
                dataGridViewRow.ReadOnly = true;
                dataGridViewRow.Cells["状态"].Value = "√";
                dataGridViewRow.Cells["剩余次数"].Value = dataGridViewRow.Cells["公告次数"].Value;
                MainForm.公告数据表.Add(dataGridViewRow, DateTime.Now);
                this.开始公告按钮.Enabled = false;
                this.停止公告按钮.Enabled = true;
                return;
            }
            Task.Run(delegate ()
            {
                MessageBox.Show("系统公告开启失败，公告内容不能为空");
            });
        }


        private void 停止公告按钮_Click(object sender, EventArgs e)
        {
            if (this.公告浏览表.Rows.Count != 0 && this.公告浏览表.SelectedRows.Count != 0)
            {
                DataGridViewRow dataGridViewRow = this.公告浏览表.Rows[this.公告浏览表.SelectedRows[0].Index];
                MainForm.公告数据表.Remove(dataGridViewRow);
                dataGridViewRow.ReadOnly = false;
                dataGridViewRow.Cells["状态"].Value = "";
                dataGridViewRow.Cells["公告计时"].Value = "";
                dataGridViewRow.Cells["剩余次数"].Value = 0;
                this.开始公告按钮.Enabled = true;
                this.停止公告按钮.Enabled = false;
                return;
            }
        }


        private void 定时发送公告_Tick(object sender, EventArgs e)
        {
            if (MainProcess.Running && MainForm.公告数据表.Count != 0)
            {
                DateTime now = DateTime.Now;
                foreach (KeyValuePair<DataGridViewRow, DateTime> keyValuePair in MainForm.公告数据表.ToList<KeyValuePair<DataGridViewRow, DateTime>>())
                {
                    keyValuePair.Key.Cells["公告计时"].Value = (keyValuePair.Value - now).ToString("hh\\:mm\\:ss");
                    if (now > keyValuePair.Value)
                    {
                        网络服务网关.发送公告(keyValuePair.Key.Cells["公告内容"].Value.ToString(), true);
                        MainForm.公告数据表[keyValuePair.Key] = now.AddMinutes((double)Convert.ToInt32(keyValuePair.Key.Cells["间隔分钟"].Value));
                        int num = Convert.ToInt32(keyValuePair.Key.Cells["剩余次数"].Value) - 1;
                        keyValuePair.Key.Cells["剩余次数"].Value = num;
                        if (num <= 0)
                        {
                            MainForm.公告数据表.Remove(keyValuePair.Key);
                            keyValuePair.Key.ReadOnly = false;
                            keyValuePair.Key.Cells["状态"].Value = "";
                            if (keyValuePair.Key.Selected)
                            {
                                this.开始公告按钮.Enabled = true;
                                this.停止公告按钮.Enabled = false;
                            }
                        }
                    }
                }
                return;
            }
        }


        private void 公告浏览表_SelectionChanged(object sender, EventArgs e)
        {
            if (this.公告浏览表.Rows.Count == 0 || this.公告浏览表.SelectedRows.Count == 0)
            {
                Control control = this.开始公告按钮;
                this.停止公告按钮.Enabled = false;
                control.Enabled = false;
                return;
            }
            DataGridViewRow key = this.公告浏览表.Rows[this.公告浏览表.SelectedRows[0].Index];
            if (MainForm.公告数据表.ContainsKey(key))
            {
                this.开始公告按钮.Enabled = false;
                this.停止公告按钮.Enabled = true;
                return;
            }
            this.开始公告按钮.Enabled = true;
            this.停止公告按钮.Enabled = false;
        }


        private void 公告浏览表_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string text = null;
            int i = 0;
            while (i < this.公告浏览表.Rows.Count)
            {
                object value = this.公告浏览表.Rows[i].Cells["公告计时"].Value;
                if (value == null)
                {
                    goto IL_3D;
                }
                string text2;
                if ((text2 = value.ToString()) == null)
                {
                    goto IL_3D;
                }
            IL_43:
                string text3 = text2;
                object value2 = this.公告浏览表.Rows[i].Cells["公告次数"].Value;
                if (value2 == null)
                {
                    goto IL_79;
                }
                string text4;
                if ((text4 = value2.ToString()) == null)
                {
                    goto IL_79;
                }
            IL_7F:
                string text5 = text4;
                object value3 = this.公告浏览表.Rows[i].Cells["公告内容"].Value;
                if (value3 == null)
                {
                    goto IL_B4;
                }
                string text6;
                if ((text6 = value3.ToString()) == null)
                {
                    goto IL_B4;
                }
            IL_BA:
                string text7 = text6;
                text = string.Concat(new string[]
                {
                    text,
                    text3,
                    "\t",
                    text5,
                    "\t",
                    text7,
                    "\r\n"
                });
                i++;
                continue;
            IL_B4:
                text6 = "";
                goto IL_BA;
            IL_79:
                text4 = "";
                goto IL_7F;
            IL_3D:
                text2 = "";
                goto IL_43;
            }
            Settings.Default.系统公告文本 = text;
            Settings.Default.Save();
        }


        public static MainForm Singleton;


        private static DataTable 角色数据表;


        private static DataTable 技能数据表;


        private static DataTable 装备数据表;


        private static DataTable 背包数据表;


        private static DataTable 仓库数据表;


        private static DataTable 地图数据表;


        private static DataTable 怪物数据表;


        private static DataTable 掉落数据表;


        private static DataTable 封禁数据表;


        private static Dictionary<CharacterData, DataRow> 角色数据行;


        private static Dictionary<DataRow, CharacterData> 数据行角色;


        private static Dictionary<游戏地图, DataRow> 地图数据行;


        private static Dictionary<游戏怪物, DataRow> 怪物数据行;


        private static Dictionary<DataRow, 游戏怪物> 数据行怪物;


        private static Dictionary<string, DataRow> 封禁数据行;


        private static Dictionary<DataGridViewRow, DateTime> 公告数据表;


        private static Dictionary<CharacterData, List<KeyValuePair<ushort, SkillData>>> 角色技能表;


        private static Dictionary<CharacterData, List<KeyValuePair<byte, EquipmentData>>> 角色装备表;


        private static Dictionary<CharacterData, List<KeyValuePair<byte, ItemData>>> 角色背包表;


        private static Dictionary<CharacterData, List<KeyValuePair<byte, ItemData>>> 角色仓库表;


        private static Dictionary<游戏怪物, List<KeyValuePair<游戏物品, long>>> 怪物掉落表;

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = $"GameServer - Mir3D LOMCN - Ver: {Config.Version}";
        }

    }
}
