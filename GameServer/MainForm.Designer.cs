﻿namespace GameServer
{

  public partial class MainForm : global::System.Windows.Forms.Form
  {

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
      {
        this.components.Dispose();
      }
      base.Dispose(disposing);
    }


    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.主选项卡 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.重载数据 = new System.Windows.Forms.Button();
            this.清空命令日志 = new System.Windows.Forms.Button();
            this.对象统计 = new System.Windows.Forms.Label();
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.tabSystem = new System.Windows.Forms.TabPage();
            this.系统日志 = new System.Windows.Forms.RichTextBox();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.聊天日志 = new System.Windows.Forms.RichTextBox();
            this.tabCommands = new System.Windows.Forms.TabPage();
            this.命令日志 = new System.Windows.Forms.RichTextBox();
            this.tabPackets = new System.Windows.Forms.TabPage();
            this.rtbPacketsLogs = new System.Windows.Forms.RichTextBox();
            this.清空聊天日志 = new System.Windows.Forms.Button();
            this.保存聊天日志 = new System.Windows.Forms.Button();
            this.已经登录统计 = new System.Windows.Forms.Label();
            this.已经上线统计 = new System.Windows.Forms.Label();
            this.连接总数统计 = new System.Windows.Forms.Label();
            this.发送统计 = new System.Windows.Forms.Label();
            this.接收统计 = new System.Windows.Forms.Label();
            this.清空系统日志 = new System.Windows.Forms.Button();
            this.保存系统日志 = new System.Windows.Forms.Button();
            this.帧数统计 = new System.Windows.Forms.Label();
            this.tabCharacters = new System.Windows.Forms.TabPage();
            this.角色详情选项卡 = new System.Windows.Forms.TabControl();
            this.CharacterData_技能 = new System.Windows.Forms.TabPage();
            this.技能浏览表 = new System.Windows.Forms.DataGridView();
            this.CharacterData_装备 = new System.Windows.Forms.TabPage();
            this.装备浏览表 = new System.Windows.Forms.DataGridView();
            this.CharacterData_背包 = new System.Windows.Forms.TabPage();
            this.背包浏览表 = new System.Windows.Forms.DataGridView();
            this.CharacterData_仓库 = new System.Windows.Forms.TabPage();
            this.仓库浏览表 = new System.Windows.Forms.DataGridView();
            this.dgvCharacters = new System.Windows.Forms.DataGridView();
            this.角色右键菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.右键菜单_复制CharName = new System.Windows.Forms.ToolStripMenuItem();
            this.右键菜单_复制Account = new System.Windows.Forms.ToolStripMenuItem();
            this.右键菜单_复制网络地址 = new System.Windows.Forms.ToolStripMenuItem();
            this.右键菜单_复制物理地址 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMaps = new System.Windows.Forms.TabPage();
            this.dgvMaps = new System.Windows.Forms.DataGridView();
            this.tabMonsters = new System.Windows.Forms.TabPage();
            this.掉落浏览表 = new System.Windows.Forms.DataGridView();
            this.怪物浏览表 = new System.Windows.Forms.DataGridView();
            this.tabBans = new System.Windows.Forms.TabPage();
            this.封禁浏览表 = new System.Windows.Forms.DataGridView();
            this.tabAnnouncements = new System.Windows.Forms.TabPage();
            this.开始公告按钮 = new System.Windows.Forms.Button();
            this.停止公告按钮 = new System.Windows.Forms.Button();
            this.删除公告按钮 = new System.Windows.Forms.Button();
            this.添加公告按钮 = new System.Windows.Forms.Button();
            this.公告浏览表 = new System.Windows.Forms.DataGridView();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.S_软件授权分组 = new System.Windows.Forms.GroupBox();
            this.S_软件注册代码 = new System.Windows.Forms.TextBox();
            this.S_GameData分组 = new System.Windows.Forms.GroupBox();
            this.S_注意事项标签1 = new System.Windows.Forms.Label();
            this.S_重载客户数据 = new System.Windows.Forms.Button();
            this.S_重载SystemData = new System.Windows.Forms.Button();
            this.S_浏览合并目录 = new System.Windows.Forms.Button();
            this.S_浏览备份目录 = new System.Windows.Forms.Button();
            this.S_浏览数据目录 = new System.Windows.Forms.Button();
            this.S_合并客户数据 = new System.Windows.Forms.Button();
            this.S_合并数据目录 = new System.Windows.Forms.TextBox();
            this.S_合并目录标签 = new System.Windows.Forms.Label();
            this.S_数据备份目录 = new System.Windows.Forms.TextBox();
            this.S_GameData目录 = new System.Windows.Forms.TextBox();
            this.S_备份目录标签 = new System.Windows.Forms.Label();
            this.S_数据目录标签 = new System.Windows.Forms.Label();
            this.S_游戏设置分组 = new System.Windows.Forms.GroupBox();
            this.L_NoobLevel = new System.Windows.Forms.Label();
            this.S_NoobLevel = new System.Windows.Forms.NumericUpDown();
            this.S_物品归属标签 = new System.Windows.Forms.Label();
            this.S_ItemOwnershipTime = new System.Windows.Forms.NumericUpDown();
            this.S_收益衰减标签 = new System.Windows.Forms.Label();
            this.S_物品清理标签 = new System.Windows.Forms.Label();
            this.S_ItemCleaningTime = new System.Windows.Forms.NumericUpDown();
            this.S_诱惑时长标签 = new System.Windows.Forms.Label();
            this.S_TemptationTime = new System.Windows.Forms.NumericUpDown();
            this.S_LessExpGradeRate = new System.Windows.Forms.NumericUpDown();
            this.S_收益等级标签 = new System.Windows.Forms.Label();
            this.S_LessExpGrade = new System.Windows.Forms.NumericUpDown();
            this.S_经验倍率标签 = new System.Windows.Forms.Label();
            this.S_ExpRate = new System.Windows.Forms.NumericUpDown();
            this.S_特修折扣标签 = new System.Windows.Forms.Label();
            this.S_EquipRepairDto = new System.Windows.Forms.NumericUpDown();
            this.S_怪物爆率标签 = new System.Windows.Forms.Label();
            this.S_ExtraDropRate = new System.Windows.Forms.NumericUpDown();
            this.S_OpenLevelCommand标签 = new System.Windows.Forms.Label();
            this.S_MaxLevel = new System.Windows.Forms.NumericUpDown();
            this.S_网络设置分组 = new System.Windows.Forms.GroupBox();
            this.S_掉线判定标签 = new System.Windows.Forms.Label();
            this.S_DisconnectTime = new System.Windows.Forms.NumericUpDown();
            this.S_限定封包标签 = new System.Windows.Forms.Label();
            this.S_PacketLimit = new System.Windows.Forms.NumericUpDown();
            this.L_AbnormalBlockTime = new System.Windows.Forms.Label();
            this.S_AbnormalBlockTime = new System.Windows.Forms.NumericUpDown();
            this.S_接收端口标签 = new System.Windows.Forms.Label();
            this.S_TSPort = new System.Windows.Forms.NumericUpDown();
            this.S_监听端口标签 = new System.Windows.Forms.Label();
            this.S_GSPort = new System.Windows.Forms.NumericUpDown();
            this.界面定时更新 = new System.Windows.Forms.Timer(this.components);
            this.下方控件页 = new System.Windows.Forms.Panel();
            this.保存按钮 = new System.Windows.Forms.Button();
            this.GMCommand文本 = new System.Windows.Forms.TextBox();
            this.GMCommand标签 = new System.Windows.Forms.Label();
            this.启动按钮 = new System.Windows.Forms.Button();
            this.停止按钮 = new System.Windows.Forms.Button();
            this.保存数据提醒 = new System.Windows.Forms.Timer(this.components);
            this.定时发送公告 = new System.Windows.Forms.Timer(this.components);
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.间隔分钟 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.公告次数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.剩余次数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.公告计时 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.公告内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.主选项卡.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.MainTabs.SuspendLayout();
            this.tabSystem.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.tabCommands.SuspendLayout();
            this.tabPackets.SuspendLayout();
            this.tabCharacters.SuspendLayout();
            this.角色详情选项卡.SuspendLayout();
            this.CharacterData_技能.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.技能浏览表)).BeginInit();
            this.CharacterData_装备.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.装备浏览表)).BeginInit();
            this.CharacterData_背包.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.背包浏览表)).BeginInit();
            this.CharacterData_仓库.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.仓库浏览表)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharacters)).BeginInit();
            this.角色右键菜单.SuspendLayout();
            this.tabMaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).BeginInit();
            this.tabMonsters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.掉落浏览表)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.怪物浏览表)).BeginInit();
            this.tabBans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.封禁浏览表)).BeginInit();
            this.tabAnnouncements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.公告浏览表)).BeginInit();
            this.tabConfig.SuspendLayout();
            this.S_软件授权分组.SuspendLayout();
            this.S_GameData分组.SuspendLayout();
            this.S_游戏设置分组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.S_NoobLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_ItemOwnershipTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_ItemCleaningTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_TemptationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_LessExpGradeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_LessExpGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_ExpRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_EquipRepairDto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_ExtraDropRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_MaxLevel)).BeginInit();
            this.S_网络设置分组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.S_DisconnectTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_PacketLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_AbnormalBlockTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_TSPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_GSPort)).BeginInit();
            this.下方控件页.SuspendLayout();
            this.SuspendLayout();
            // 
            // 主选项卡
            // 
            this.主选项卡.AllowDrop = true;
            this.主选项卡.Controls.Add(this.tabMain);
            this.主选项卡.Controls.Add(this.tabCharacters);
            this.主选项卡.Controls.Add(this.tabMaps);
            this.主选项卡.Controls.Add(this.tabMonsters);
            this.主选项卡.Controls.Add(this.tabBans);
            this.主选项卡.Controls.Add(this.tabAnnouncements);
            this.主选项卡.Controls.Add(this.tabConfig);
            this.主选项卡.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.主选项卡.ItemSize = new System.Drawing.Size(170, 30);
            this.主选项卡.Location = new System.Drawing.Point(4, 5);
            this.主选项卡.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.主选项卡.Name = "主选项卡";
            this.主选项卡.SelectedIndex = 0;
            this.主选项卡.Size = new System.Drawing.Size(1391, 855);
            this.主选项卡.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.主选项卡.TabIndex = 5;
            this.主选项卡.TabStop = false;
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.Color.Gainsboro;
            this.tabMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabMain.Controls.Add(this.重载数据);
            this.tabMain.Controls.Add(this.清空命令日志);
            this.tabMain.Controls.Add(this.对象统计);
            this.tabMain.Controls.Add(this.MainTabs);
            this.tabMain.Controls.Add(this.清空聊天日志);
            this.tabMain.Controls.Add(this.保存聊天日志);
            this.tabMain.Controls.Add(this.已经登录统计);
            this.tabMain.Controls.Add(this.已经上线统计);
            this.tabMain.Controls.Add(this.连接总数统计);
            this.tabMain.Controls.Add(this.发送统计);
            this.tabMain.Controls.Add(this.接收统计);
            this.tabMain.Controls.Add(this.清空系统日志);
            this.tabMain.Controls.Add(this.保存系统日志);
            this.tabMain.Controls.Add(this.帧数统计);
            this.tabMain.Location = new System.Drawing.Point(4, 34);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMain.Size = new System.Drawing.Size(1383, 817);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "首页";
            // 
            // 重载数据
            // 
            this.重载数据.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.重载数据.Enabled = false;
            this.重载数据.Location = new System.Drawing.Point(1068, 411);
            this.重载数据.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.重载数据.Name = "重载数据";
            this.重载数据.Size = new System.Drawing.Size(301, 57);
            this.重载数据.TabIndex = 15;
            this.重载数据.Text = "重载数据";
            this.重载数据.UseVisualStyleBackColor = false;
            this.重载数据.Click += new System.EventHandler(this.重载数据_Click);
            // 
            // 清空命令日志
            // 
            this.清空命令日志.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.清空命令日志.Enabled = false;
            this.清空命令日志.Location = new System.Drawing.Point(1068, 558);
            this.清空命令日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.清空命令日志.Name = "清空命令日志";
            this.清空命令日志.Size = new System.Drawing.Size(301, 57);
            this.清空命令日志.TabIndex = 18;
            this.清空命令日志.Text = "清空命令日志";
            this.清空命令日志.UseVisualStyleBackColor = false;
            this.清空命令日志.Click += new System.EventHandler(this.清空命令日志_Click);
            // 
            // 对象统计
            // 
            this.对象统计.AutoSize = true;
            this.对象统计.ForeColor = System.Drawing.Color.Blue;
            this.对象统计.Location = new System.Drawing.Point(1068, 219);
            this.对象统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.对象统计.Name = "对象统计";
            this.对象统计.Size = new System.Drawing.Size(71, 16);
            this.对象统计.TabIndex = 17;
            this.对象统计.Text = "对象统计:";
            // 
            // MainTabs
            // 
            this.MainTabs.Controls.Add(this.tabSystem);
            this.MainTabs.Controls.Add(this.tabChat);
            this.MainTabs.Controls.Add(this.tabCommands);
            this.MainTabs.Controls.Add(this.tabPackets);
            this.MainTabs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainTabs.ItemSize = new System.Drawing.Size(230, 20);
            this.MainTabs.Location = new System.Drawing.Point(3, 3);
            this.MainTabs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(1033, 621);
            this.MainTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabs.TabIndex = 16;
            // 
            // tabSystem
            // 
            this.tabSystem.BackColor = System.Drawing.Color.Gainsboro;
            this.tabSystem.Controls.Add(this.系统日志);
            this.tabSystem.Location = new System.Drawing.Point(4, 24);
            this.tabSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSystem.Size = new System.Drawing.Size(1025, 593);
            this.tabSystem.TabIndex = 0;
            this.tabSystem.Text = "系统日志";
            // 
            // 系统日志
            // 
            this.系统日志.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.系统日志.Dock = System.Windows.Forms.DockStyle.Fill;
            this.系统日志.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.系统日志.Location = new System.Drawing.Point(4, 5);
            this.系统日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.系统日志.Name = "系统日志";
            this.系统日志.ReadOnly = true;
            this.系统日志.Size = new System.Drawing.Size(1017, 583);
            this.系统日志.TabIndex = 0;
            this.系统日志.Text = "";
            // 
            // tabChat
            // 
            this.tabChat.BackColor = System.Drawing.Color.Gainsboro;
            this.tabChat.Controls.Add(this.聊天日志);
            this.tabChat.Location = new System.Drawing.Point(4, 24);
            this.tabChat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabChat.Size = new System.Drawing.Size(1025, 593);
            this.tabChat.TabIndex = 1;
            this.tabChat.Text = "聊天日志";
            // 
            // 聊天日志
            // 
            this.聊天日志.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.聊天日志.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.聊天日志.Location = new System.Drawing.Point(0, 0);
            this.聊天日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.聊天日志.Name = "聊天日志";
            this.聊天日志.ReadOnly = true;
            this.聊天日志.Size = new System.Drawing.Size(1020, 573);
            this.聊天日志.TabIndex = 1;
            this.聊天日志.Text = "";
            // 
            // tabCommands
            // 
            this.tabCommands.BackColor = System.Drawing.Color.Gainsboro;
            this.tabCommands.Controls.Add(this.命令日志);
            this.tabCommands.Location = new System.Drawing.Point(4, 24);
            this.tabCommands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabCommands.Name = "tabCommands";
            this.tabCommands.Size = new System.Drawing.Size(1025, 593);
            this.tabCommands.TabIndex = 2;
            this.tabCommands.Text = "命令日志";
            // 
            // 命令日志
            // 
            this.命令日志.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.命令日志.Dock = System.Windows.Forms.DockStyle.Fill;
            this.命令日志.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.命令日志.Location = new System.Drawing.Point(0, 0);
            this.命令日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.命令日志.Name = "命令日志";
            this.命令日志.ReadOnly = true;
            this.命令日志.Size = new System.Drawing.Size(1025, 593);
            this.命令日志.TabIndex = 2;
            this.命令日志.Text = "";
            // 
            // tabPackets
            // 
            this.tabPackets.Controls.Add(this.rtbPacketsLogs);
            this.tabPackets.Location = new System.Drawing.Point(4, 24);
            this.tabPackets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPackets.Name = "tabPackets";
            this.tabPackets.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPackets.Size = new System.Drawing.Size(1025, 593);
            this.tabPackets.TabIndex = 3;
            this.tabPackets.Text = "数据包";
            this.tabPackets.UseVisualStyleBackColor = true;
            // 
            // rtbPacketsLogs
            // 
            this.rtbPacketsLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtbPacketsLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPacketsLogs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbPacketsLogs.Location = new System.Drawing.Point(3, 2);
            this.rtbPacketsLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbPacketsLogs.Name = "rtbPacketsLogs";
            this.rtbPacketsLogs.ReadOnly = true;
            this.rtbPacketsLogs.Size = new System.Drawing.Size(1019, 589);
            this.rtbPacketsLogs.TabIndex = 2;
            this.rtbPacketsLogs.Text = "";
            // 
            // 清空聊天日志
            // 
            this.清空聊天日志.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.清空聊天日志.Enabled = false;
            this.清空聊天日志.Location = new System.Drawing.Point(1068, 485);
            this.清空聊天日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.清空聊天日志.Name = "清空聊天日志";
            this.清空聊天日志.Size = new System.Drawing.Size(301, 57);
            this.清空聊天日志.TabIndex = 15;
            this.清空聊天日志.Text = "清空聊天日志";
            this.清空聊天日志.UseVisualStyleBackColor = false;
            this.清空聊天日志.Click += new System.EventHandler(this.清空聊天日志_Click);
            // 
            // 保存聊天日志
            // 
            this.保存聊天日志.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.保存聊天日志.Enabled = false;
            this.保存聊天日志.Location = new System.Drawing.Point(1068, 337);
            this.保存聊天日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.保存聊天日志.Name = "保存聊天日志";
            this.保存聊天日志.Size = new System.Drawing.Size(301, 57);
            this.保存聊天日志.TabIndex = 14;
            this.保存聊天日志.Text = "保存聊天日志";
            this.保存聊天日志.UseVisualStyleBackColor = false;
            this.保存聊天日志.Click += new System.EventHandler(this.保存聊天日志_Click);
            // 
            // 已经登录统计
            // 
            this.已经登录统计.AutoSize = true;
            this.已经登录统计.ForeColor = System.Drawing.Color.Blue;
            this.已经登录统计.Location = new System.Drawing.Point(1068, 63);
            this.已经登录统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.已经登录统计.Name = "已经登录统计";
            this.已经登录统计.Size = new System.Drawing.Size(71, 16);
            this.已经登录统计.TabIndex = 13;
            this.已经登录统计.Text = "已经登陆:";
            // 
            // 已经上线统计
            // 
            this.已经上线统计.AutoSize = true;
            this.已经上线统计.ForeColor = System.Drawing.Color.Blue;
            this.已经上线统计.Location = new System.Drawing.Point(1068, 94);
            this.已经上线统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.已经上线统计.Name = "已经上线统计";
            this.已经上线统计.Size = new System.Drawing.Size(71, 16);
            this.已经上线统计.TabIndex = 12;
            this.已经上线统计.Text = "已经上线:";
            // 
            // 连接总数统计
            // 
            this.连接总数统计.AutoSize = true;
            this.连接总数统计.ForeColor = System.Drawing.Color.Blue;
            this.连接总数统计.Location = new System.Drawing.Point(1068, 32);
            this.连接总数统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.连接总数统计.Name = "连接总数统计";
            this.连接总数统计.Size = new System.Drawing.Size(97, 16);
            this.连接总数统计.TabIndex = 11;
            this.连接总数统计.Text = "连接总数统计";
            // 
            // 发送统计
            // 
            this.发送统计.AutoSize = true;
            this.发送统计.ForeColor = System.Drawing.Color.Blue;
            this.发送统计.Location = new System.Drawing.Point(1068, 188);
            this.发送统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.发送统计.Name = "发送统计";
            this.发送统计.Size = new System.Drawing.Size(41, 16);
            this.发送统计.TabIndex = 10;
            this.发送统计.Text = "发送:";
            // 
            // 接收统计
            // 
            this.接收统计.AutoSize = true;
            this.接收统计.ForeColor = System.Drawing.Color.Blue;
            this.接收统计.Location = new System.Drawing.Point(1068, 156);
            this.接收统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.接收统计.Name = "接收统计";
            this.接收统计.Size = new System.Drawing.Size(41, 16);
            this.接收统计.TabIndex = 9;
            this.接收统计.Text = "接收:";
            // 
            // 清空系统日志
            // 
            this.清空系统日志.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.清空系统日志.Enabled = false;
            this.清空系统日志.Location = new System.Drawing.Point(1068, 411);
            this.清空系统日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.清空系统日志.Name = "清空系统日志";
            this.清空系统日志.Size = new System.Drawing.Size(301, 57);
            this.清空系统日志.TabIndex = 8;
            this.清空系统日志.Text = "Empty the system logs";
            this.清空系统日志.UseVisualStyleBackColor = false;
            this.清空系统日志.Visible = false;
            this.清空系统日志.Click += new System.EventHandler(this.清空系统日志_Click);
            // 
            // 保存系统日志
            // 
            this.保存系统日志.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.保存系统日志.Enabled = false;
            this.保存系统日志.Location = new System.Drawing.Point(1068, 263);
            this.保存系统日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.保存系统日志.Name = "保存系统日志";
            this.保存系统日志.Size = new System.Drawing.Size(301, 57);
            this.保存系统日志.TabIndex = 7;
            this.保存系统日志.Text = "保存系统日志";
            this.保存系统日志.UseVisualStyleBackColor = false;
            this.保存系统日志.Click += new System.EventHandler(this.保存系统日志_Click);
            // 
            // 帧数统计
            // 
            this.帧数统计.AutoSize = true;
            this.帧数统计.ForeColor = System.Drawing.Color.Blue;
            this.帧数统计.Location = new System.Drawing.Point(1068, 126);
            this.帧数统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.帧数统计.Name = "帧数统计";
            this.帧数统计.Size = new System.Drawing.Size(41, 16);
            this.帧数统计.TabIndex = 1;
            this.帧数统计.Text = "帧数:";
            // 
            // tabCharacters
            // 
            this.tabCharacters.BackColor = System.Drawing.Color.Gainsboro;
            this.tabCharacters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabCharacters.Controls.Add(this.角色详情选项卡);
            this.tabCharacters.Controls.Add(this.dgvCharacters);
            this.tabCharacters.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabCharacters.Location = new System.Drawing.Point(4, 34);
            this.tabCharacters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabCharacters.Name = "tabCharacters";
            this.tabCharacters.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabCharacters.Size = new System.Drawing.Size(1383, 817);
            this.tabCharacters.TabIndex = 4;
            this.tabCharacters.Text = "游戏玩家";
            // 
            // 角色详情选项卡
            // 
            this.角色详情选项卡.Controls.Add(this.CharacterData_技能);
            this.角色详情选项卡.Controls.Add(this.CharacterData_装备);
            this.角色详情选项卡.Controls.Add(this.CharacterData_背包);
            this.角色详情选项卡.Controls.Add(this.CharacterData_仓库);
            this.角色详情选项卡.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.角色详情选项卡.ItemSize = new System.Drawing.Size(85, 20);
            this.角色详情选项卡.Location = new System.Drawing.Point(981, 5);
            this.角色详情选项卡.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.角色详情选项卡.Name = "角色详情选项卡";
            this.角色详情选项卡.SelectedIndex = 0;
            this.角色详情选项卡.Size = new System.Drawing.Size(402, 615);
            this.角色详情选项卡.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.角色详情选项卡.TabIndex = 2;
            // 
            // CharacterData_技能
            // 
            this.CharacterData_技能.BackColor = System.Drawing.Color.Gainsboro;
            this.CharacterData_技能.Controls.Add(this.技能浏览表);
            this.CharacterData_技能.Location = new System.Drawing.Point(4, 24);
            this.CharacterData_技能.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CharacterData_技能.Name = "CharacterData_技能";
            this.CharacterData_技能.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CharacterData_技能.Size = new System.Drawing.Size(394, 587);
            this.CharacterData_技能.TabIndex = 0;
            this.CharacterData_技能.Text = "技能";
            // 
            // 技能浏览表
            // 
            this.技能浏览表.AllowUserToAddRows = false;
            this.技能浏览表.AllowUserToDeleteRows = false;
            this.技能浏览表.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.技能浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.技能浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.技能浏览表.BackgroundColor = System.Drawing.Color.LightGray;
            this.技能浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.技能浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.技能浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.技能浏览表.ColumnHeadersHeight = 29;
            this.技能浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.技能浏览表.DefaultCellStyle = dataGridViewCellStyle3;
            this.技能浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.技能浏览表.Location = new System.Drawing.Point(0, 0);
            this.技能浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.技能浏览表.MultiSelect = false;
            this.技能浏览表.Name = "技能浏览表";
            this.技能浏览表.ReadOnly = true;
            this.技能浏览表.RowHeadersVisible = false;
            this.技能浏览表.RowHeadersWidth = 51;
            this.技能浏览表.RowTemplate.Height = 23;
            this.技能浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.技能浏览表.ShowCellToolTips = false;
            this.技能浏览表.Size = new System.Drawing.Size(386, 570);
            this.技能浏览表.TabIndex = 3;
            // 
            // CharacterData_装备
            // 
            this.CharacterData_装备.BackColor = System.Drawing.Color.Gainsboro;
            this.CharacterData_装备.Controls.Add(this.装备浏览表);
            this.CharacterData_装备.Location = new System.Drawing.Point(4, 24);
            this.CharacterData_装备.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CharacterData_装备.Name = "CharacterData_装备";
            this.CharacterData_装备.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CharacterData_装备.Size = new System.Drawing.Size(394, 587);
            this.CharacterData_装备.TabIndex = 1;
            this.CharacterData_装备.Text = "装备";
            // 
            // 装备浏览表
            // 
            this.装备浏览表.AllowUserToAddRows = false;
            this.装备浏览表.AllowUserToDeleteRows = false;
            this.装备浏览表.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.装备浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.装备浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.装备浏览表.BackgroundColor = System.Drawing.Color.LightGray;
            this.装备浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.装备浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.装备浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.装备浏览表.ColumnHeadersHeight = 29;
            this.装备浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.装备浏览表.DefaultCellStyle = dataGridViewCellStyle6;
            this.装备浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.装备浏览表.Location = new System.Drawing.Point(0, 0);
            this.装备浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.装备浏览表.MultiSelect = false;
            this.装备浏览表.Name = "装备浏览表";
            this.装备浏览表.ReadOnly = true;
            this.装备浏览表.RowHeadersVisible = false;
            this.装备浏览表.RowHeadersWidth = 51;
            this.装备浏览表.RowTemplate.Height = 23;
            this.装备浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.装备浏览表.ShowCellToolTips = false;
            this.装备浏览表.Size = new System.Drawing.Size(386, 570);
            this.装备浏览表.TabIndex = 4;
            // 
            // CharacterData_背包
            // 
            this.CharacterData_背包.BackColor = System.Drawing.Color.Gainsboro;
            this.CharacterData_背包.Controls.Add(this.背包浏览表);
            this.CharacterData_背包.Location = new System.Drawing.Point(4, 24);
            this.CharacterData_背包.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CharacterData_背包.Name = "CharacterData_背包";
            this.CharacterData_背包.Size = new System.Drawing.Size(394, 587);
            this.CharacterData_背包.TabIndex = 2;
            this.CharacterData_背包.Text = "背包";
            // 
            // 背包浏览表
            // 
            this.背包浏览表.AllowUserToAddRows = false;
            this.背包浏览表.AllowUserToDeleteRows = false;
            this.背包浏览表.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.背包浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.背包浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.背包浏览表.BackgroundColor = System.Drawing.Color.LightGray;
            this.背包浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.背包浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.背包浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.背包浏览表.ColumnHeadersHeight = 29;
            this.背包浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.背包浏览表.DefaultCellStyle = dataGridViewCellStyle9;
            this.背包浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.背包浏览表.Location = new System.Drawing.Point(0, 0);
            this.背包浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.背包浏览表.MultiSelect = false;
            this.背包浏览表.Name = "背包浏览表";
            this.背包浏览表.ReadOnly = true;
            this.背包浏览表.RowHeadersVisible = false;
            this.背包浏览表.RowHeadersWidth = 51;
            this.背包浏览表.RowTemplate.Height = 23;
            this.背包浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.背包浏览表.ShowCellToolTips = false;
            this.背包浏览表.Size = new System.Drawing.Size(386, 570);
            this.背包浏览表.TabIndex = 4;
            // 
            // CharacterData_仓库
            // 
            this.CharacterData_仓库.BackColor = System.Drawing.Color.Gainsboro;
            this.CharacterData_仓库.Controls.Add(this.仓库浏览表);
            this.CharacterData_仓库.Location = new System.Drawing.Point(4, 24);
            this.CharacterData_仓库.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CharacterData_仓库.Name = "CharacterData_仓库";
            this.CharacterData_仓库.Size = new System.Drawing.Size(394, 587);
            this.CharacterData_仓库.TabIndex = 3;
            this.CharacterData_仓库.Text = "仓库";
            // 
            // 仓库浏览表
            // 
            this.仓库浏览表.AllowUserToAddRows = false;
            this.仓库浏览表.AllowUserToDeleteRows = false;
            this.仓库浏览表.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.仓库浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.仓库浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.仓库浏览表.BackgroundColor = System.Drawing.Color.LightGray;
            this.仓库浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.仓库浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.仓库浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.仓库浏览表.ColumnHeadersHeight = 29;
            this.仓库浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.仓库浏览表.DefaultCellStyle = dataGridViewCellStyle12;
            this.仓库浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.仓库浏览表.Location = new System.Drawing.Point(0, 0);
            this.仓库浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.仓库浏览表.MultiSelect = false;
            this.仓库浏览表.Name = "仓库浏览表";
            this.仓库浏览表.ReadOnly = true;
            this.仓库浏览表.RowHeadersVisible = false;
            this.仓库浏览表.RowHeadersWidth = 51;
            this.仓库浏览表.RowTemplate.Height = 23;
            this.仓库浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.仓库浏览表.ShowCellToolTips = false;
            this.仓库浏览表.Size = new System.Drawing.Size(386, 570);
            this.仓库浏览表.TabIndex = 5;
            // 
            // dgvCharacters
            // 
            this.dgvCharacters.AllowUserToAddRows = false;
            this.dgvCharacters.AllowUserToDeleteRows = false;
            this.dgvCharacters.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCharacters.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvCharacters.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvCharacters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCharacters.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCharacters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvCharacters.ColumnHeadersHeight = 29;
            this.dgvCharacters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCharacters.ContextMenuStrip = this.角色右键菜单;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCharacters.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvCharacters.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCharacters.Location = new System.Drawing.Point(0, 5);
            this.dgvCharacters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCharacters.MultiSelect = false;
            this.dgvCharacters.Name = "dgvCharacters";
            this.dgvCharacters.ReadOnly = true;
            this.dgvCharacters.RowHeadersVisible = false;
            this.dgvCharacters.RowHeadersWidth = 51;
            this.dgvCharacters.RowTemplate.Height = 23;
            this.dgvCharacters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCharacters.ShowCellToolTips = false;
            this.dgvCharacters.Size = new System.Drawing.Size(979, 615);
            this.dgvCharacters.TabIndex = 1;
            // 
            // 角色右键菜单
            // 
            this.角色右键菜单.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.角色右键菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.右键菜单_复制CharName,
            this.右键菜单_复制Account,
            this.右键菜单_复制网络地址,
            this.右键菜单_复制物理地址});
            this.角色右键菜单.Name = "角色右键菜单";
            this.角色右键菜单.Size = new System.Drawing.Size(181, 114);
            // 
            // 右键菜单_复制CharName
            // 
            this.右键菜单_复制CharName.Name = "右键菜单_复制CharName";
            this.右键菜单_复制CharName.Size = new System.Drawing.Size(180, 22);
            this.右键菜单_复制CharName.Text = "复制角色名字";
            this.右键菜单_复制CharName.Click += new System.EventHandler(this.角色右键菜单_Click);
            // 
            // 右键菜单_复制Account
            // 
            this.右键菜单_复制Account.Name = "右键菜单_复制Account";
            this.右键菜单_复制Account.Size = new System.Drawing.Size(180, 22);
            this.右键菜单_复制Account.Text = "复制账号名字";
            this.右键菜单_复制Account.Click += new System.EventHandler(this.角色右键菜单_Click);
            // 
            // 右键菜单_复制网络地址
            // 
            this.右键菜单_复制网络地址.Name = "右键菜单_复制网络地址";
            this.右键菜单_复制网络地址.Size = new System.Drawing.Size(180, 22);
            this.右键菜单_复制网络地址.Text = "复制IP地址";
            this.右键菜单_复制网络地址.Click += new System.EventHandler(this.角色右键菜单_Click);
            // 
            // 右键菜单_复制物理地址
            // 
            this.右键菜单_复制物理地址.Name = "右键菜单_复制物理地址";
            this.右键菜单_复制物理地址.Size = new System.Drawing.Size(180, 22);
            this.右键菜单_复制物理地址.Text = "复制物理地址";
            this.右键菜单_复制物理地址.Click += new System.EventHandler(this.角色右键菜单_Click);
            // 
            // tabMaps
            // 
            this.tabMaps.BackColor = System.Drawing.Color.Gainsboro;
            this.tabMaps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabMaps.Controls.Add(this.dgvMaps);
            this.tabMaps.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabMaps.Location = new System.Drawing.Point(4, 34);
            this.tabMaps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMaps.Name = "tabMaps";
            this.tabMaps.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMaps.Size = new System.Drawing.Size(1383, 817);
            this.tabMaps.TabIndex = 1;
            this.tabMaps.Text = "游戏地图";
            // 
            // dgvMaps
            // 
            this.dgvMaps.AllowUserToAddRows = false;
            this.dgvMaps.AllowUserToDeleteRows = false;
            this.dgvMaps.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMaps.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvMaps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaps.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvMaps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMaps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvMaps.ColumnHeadersHeight = 29;
            this.dgvMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaps.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvMaps.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMaps.Location = new System.Drawing.Point(0, 5);
            this.dgvMaps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMaps.MultiSelect = false;
            this.dgvMaps.Name = "dgvMaps";
            this.dgvMaps.ReadOnly = true;
            this.dgvMaps.RowHeadersVisible = false;
            this.dgvMaps.RowHeadersWidth = 51;
            this.dgvMaps.RowTemplate.Height = 23;
            this.dgvMaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaps.ShowCellToolTips = false;
            this.dgvMaps.Size = new System.Drawing.Size(1385, 615);
            this.dgvMaps.TabIndex = 2;
            // 
            // tabMonsters
            // 
            this.tabMonsters.BackColor = System.Drawing.Color.Gainsboro;
            this.tabMonsters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabMonsters.Controls.Add(this.掉落浏览表);
            this.tabMonsters.Controls.Add(this.怪物浏览表);
            this.tabMonsters.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabMonsters.Location = new System.Drawing.Point(4, 34);
            this.tabMonsters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMonsters.Name = "tabMonsters";
            this.tabMonsters.Size = new System.Drawing.Size(1383, 817);
            this.tabMonsters.TabIndex = 2;
            this.tabMonsters.Text = "游戏怪物";
            // 
            // 掉落浏览表
            // 
            this.掉落浏览表.AllowUserToAddRows = false;
            this.掉落浏览表.AllowUserToDeleteRows = false;
            this.掉落浏览表.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.掉落浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.掉落浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.掉落浏览表.BackgroundColor = System.Drawing.Color.LightGray;
            this.掉落浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.掉落浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.掉落浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.掉落浏览表.ColumnHeadersHeight = 29;
            this.掉落浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.掉落浏览表.DefaultCellStyle = dataGridViewCellStyle21;
            this.掉落浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.掉落浏览表.Location = new System.Drawing.Point(1053, 5);
            this.掉落浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.掉落浏览表.MultiSelect = false;
            this.掉落浏览表.Name = "掉落浏览表";
            this.掉落浏览表.ReadOnly = true;
            this.掉落浏览表.RowHeadersVisible = false;
            this.掉落浏览表.RowHeadersWidth = 51;
            this.掉落浏览表.RowTemplate.Height = 23;
            this.掉落浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.掉落浏览表.ShowCellToolTips = false;
            this.掉落浏览表.Size = new System.Drawing.Size(332, 615);
            this.掉落浏览表.TabIndex = 5;
            // 
            // 怪物浏览表
            // 
            this.怪物浏览表.AllowUserToAddRows = false;
            this.怪物浏览表.AllowUserToDeleteRows = false;
            this.怪物浏览表.AllowUserToResizeRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.怪物浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.怪物浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.怪物浏览表.BackgroundColor = System.Drawing.Color.LightGray;
            this.怪物浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.怪物浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.怪物浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.怪物浏览表.ColumnHeadersHeight = 29;
            this.怪物浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.怪物浏览表.DefaultCellStyle = dataGridViewCellStyle24;
            this.怪物浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.怪物浏览表.Location = new System.Drawing.Point(0, 5);
            this.怪物浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.怪物浏览表.MultiSelect = false;
            this.怪物浏览表.Name = "怪物浏览表";
            this.怪物浏览表.ReadOnly = true;
            this.怪物浏览表.RowHeadersVisible = false;
            this.怪物浏览表.RowHeadersWidth = 51;
            this.怪物浏览表.RowTemplate.Height = 23;
            this.怪物浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.怪物浏览表.ShowCellToolTips = false;
            this.怪物浏览表.Size = new System.Drawing.Size(1046, 615);
            this.怪物浏览表.TabIndex = 3;
            // 
            // tabBans
            // 
            this.tabBans.BackColor = System.Drawing.Color.Gainsboro;
            this.tabBans.Controls.Add(this.封禁浏览表);
            this.tabBans.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabBans.Location = new System.Drawing.Point(4, 34);
            this.tabBans.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabBans.Name = "tabBans";
            this.tabBans.Size = new System.Drawing.Size(1383, 817);
            this.tabBans.TabIndex = 12;
            this.tabBans.Text = "封号数据";
            // 
            // 封禁浏览表
            // 
            this.封禁浏览表.AllowUserToAddRows = false;
            this.封禁浏览表.AllowUserToDeleteRows = false;
            this.封禁浏览表.AllowUserToResizeRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.封禁浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.封禁浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.封禁浏览表.BackgroundColor = System.Drawing.Color.LightGray;
            this.封禁浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.封禁浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.封禁浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.封禁浏览表.ColumnHeadersHeight = 29;
            this.封禁浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.封禁浏览表.DefaultCellStyle = dataGridViewCellStyle27;
            this.封禁浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.封禁浏览表.Location = new System.Drawing.Point(147, 5);
            this.封禁浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.封禁浏览表.MultiSelect = false;
            this.封禁浏览表.Name = "封禁浏览表";
            this.封禁浏览表.ReadOnly = true;
            this.封禁浏览表.RowHeadersVisible = false;
            this.封禁浏览表.RowHeadersWidth = 51;
            this.封禁浏览表.RowTemplate.Height = 23;
            this.封禁浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.封禁浏览表.ShowCellToolTips = false;
            this.封禁浏览表.Size = new System.Drawing.Size(1000, 615);
            this.封禁浏览表.TabIndex = 6;
            // 
            // tabAnnouncements
            // 
            this.tabAnnouncements.BackColor = System.Drawing.Color.Gainsboro;
            this.tabAnnouncements.Controls.Add(this.开始公告按钮);
            this.tabAnnouncements.Controls.Add(this.停止公告按钮);
            this.tabAnnouncements.Controls.Add(this.删除公告按钮);
            this.tabAnnouncements.Controls.Add(this.添加公告按钮);
            this.tabAnnouncements.Controls.Add(this.公告浏览表);
            this.tabAnnouncements.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabAnnouncements.Location = new System.Drawing.Point(4, 34);
            this.tabAnnouncements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabAnnouncements.Name = "tabAnnouncements";
            this.tabAnnouncements.Size = new System.Drawing.Size(1383, 817);
            this.tabAnnouncements.TabIndex = 13;
            this.tabAnnouncements.Text = "公告数据";
            // 
            // 开始公告按钮
            // 
            this.开始公告按钮.Enabled = false;
            this.开始公告按钮.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.开始公告按钮.Location = new System.Drawing.Point(6, 562);
            this.开始公告按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.开始公告按钮.Name = "开始公告按钮";
            this.开始公告按钮.Size = new System.Drawing.Size(343, 43);
            this.开始公告按钮.TabIndex = 7;
            this.开始公告按钮.Text = "开始选中公告";
            this.开始公告按钮.UseVisualStyleBackColor = true;
            this.开始公告按钮.Click += new System.EventHandler(this.开始公告按钮_Click);
            // 
            // 停止公告按钮
            // 
            this.停止公告按钮.Enabled = false;
            this.停止公告按钮.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.停止公告按钮.Location = new System.Drawing.Point(349, 562);
            this.停止公告按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.停止公告按钮.Name = "停止公告按钮";
            this.停止公告按钮.Size = new System.Drawing.Size(343, 43);
            this.停止公告按钮.TabIndex = 6;
            this.停止公告按钮.Text = "停止公告发送";
            this.停止公告按钮.UseVisualStyleBackColor = true;
            this.停止公告按钮.Click += new System.EventHandler(this.停止公告按钮_Click);
            // 
            // 删除公告按钮
            // 
            this.删除公告按钮.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.删除公告按钮.Location = new System.Drawing.Point(1035, 562);
            this.删除公告按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.删除公告按钮.Name = "删除公告按钮";
            this.删除公告按钮.Size = new System.Drawing.Size(343, 43);
            this.删除公告按钮.TabIndex = 5;
            this.删除公告按钮.Text = "删除选中公告";
            this.删除公告按钮.UseVisualStyleBackColor = true;
            this.删除公告按钮.Click += new System.EventHandler(this.删除公告按钮_Click);
            // 
            // 添加公告按钮
            // 
            this.添加公告按钮.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.添加公告按钮.Location = new System.Drawing.Point(692, 562);
            this.添加公告按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.添加公告按钮.Name = "添加公告按钮";
            this.添加公告按钮.Size = new System.Drawing.Size(343, 43);
            this.添加公告按钮.TabIndex = 4;
            this.添加公告按钮.Text = "添加系统公告";
            this.添加公告按钮.UseVisualStyleBackColor = true;
            this.添加公告按钮.Click += new System.EventHandler(this.添加公告按钮_Click);
            // 
            // 公告浏览表
            // 
            this.公告浏览表.AllowUserToAddRows = false;
            this.公告浏览表.AllowUserToDeleteRows = false;
            this.公告浏览表.AllowUserToResizeColumns = false;
            this.公告浏览表.AllowUserToResizeRows = false;
            this.公告浏览表.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.公告浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.公告浏览表.ColumnHeadersHeight = 29;
            this.公告浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.公告浏览表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.状态,
            this.间隔分钟,
            this.公告次数,
            this.剩余次数,
            this.公告计时,
            this.公告内容});
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.公告浏览表.DefaultCellStyle = dataGridViewCellStyle29;
            this.公告浏览表.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.公告浏览表.Location = new System.Drawing.Point(6, 5);
            this.公告浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.公告浏览表.MultiSelect = false;
            this.公告浏览表.Name = "公告浏览表";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.公告浏览表.RowHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.公告浏览表.RowHeadersVisible = false;
            this.公告浏览表.RowHeadersWidth = 51;
            this.公告浏览表.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.公告浏览表.RowTemplate.Height = 23;
            this.公告浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.公告浏览表.ShowCellToolTips = false;
            this.公告浏览表.Size = new System.Drawing.Size(1375, 533);
            this.公告浏览表.TabIndex = 3;
            this.公告浏览表.TabStop = false;
            this.公告浏览表.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.公告浏览表_CellEndEdit);
            this.公告浏览表.SelectionChanged += new System.EventHandler(this.公告浏览表_SelectionChanged);
            // 
            // tabConfig
            // 
            this.tabConfig.BackColor = System.Drawing.Color.Gainsboro;
            this.tabConfig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabConfig.Controls.Add(this.S_软件授权分组);
            this.tabConfig.Controls.Add(this.S_GameData分组);
            this.tabConfig.Controls.Add(this.S_游戏设置分组);
            this.tabConfig.Controls.Add(this.S_网络设置分组);
            this.tabConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabConfig.Location = new System.Drawing.Point(4, 34);
            this.tabConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Size = new System.Drawing.Size(1383, 817);
            this.tabConfig.TabIndex = 11;
            this.tabConfig.Text = "游戏设置";
            // 
            // S_软件授权分组
            // 
            this.S_软件授权分组.Controls.Add(this.S_软件注册代码);
            this.S_软件授权分组.Location = new System.Drawing.Point(18, 524);
            this.S_软件授权分组.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_软件授权分组.Name = "S_软件授权分组";
            this.S_软件授权分组.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_软件授权分组.Size = new System.Drawing.Size(690, 77);
            this.S_软件授权分组.TabIndex = 11;
            this.S_软件授权分组.TabStop = false;
            this.S_软件授权分组.Text = "Registration code";
            // 
            // S_软件注册代码
            // 
            this.S_软件注册代码.Location = new System.Drawing.Point(7, 29);
            this.S_软件注册代码.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_软件注册代码.Name = "S_软件注册代码";
            this.S_软件注册代码.Size = new System.Drawing.Size(675, 21);
            this.S_软件注册代码.TabIndex = 11;
            this.S_软件注册代码.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // S_GameData分组
            // 
            this.S_GameData分组.Controls.Add(this.S_注意事项标签1);
            this.S_GameData分组.Controls.Add(this.S_重载客户数据);
            this.S_GameData分组.Controls.Add(this.S_重载SystemData);
            this.S_GameData分组.Controls.Add(this.S_浏览合并目录);
            this.S_GameData分组.Controls.Add(this.S_浏览备份目录);
            this.S_GameData分组.Controls.Add(this.S_浏览数据目录);
            this.S_GameData分组.Controls.Add(this.S_合并客户数据);
            this.S_GameData分组.Controls.Add(this.S_合并数据目录);
            this.S_GameData分组.Controls.Add(this.S_合并目录标签);
            this.S_GameData分组.Controls.Add(this.S_数据备份目录);
            this.S_GameData分组.Controls.Add(this.S_GameData目录);
            this.S_GameData分组.Controls.Add(this.S_备份目录标签);
            this.S_GameData分组.Controls.Add(this.S_数据目录标签);
            this.S_GameData分组.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_GameData分组.Location = new System.Drawing.Point(741, 17);
            this.S_GameData分组.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_GameData分组.Name = "S_GameData分组";
            this.S_GameData分组.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_GameData分组.Size = new System.Drawing.Size(571, 586);
            this.S_GameData分组.TabIndex = 10;
            this.S_GameData分组.TabStop = false;
            this.S_GameData分组.Text = "游戏数据";
            // 
            // S_注意事项标签1
            // 
            this.S_注意事项标签1.AutoSize = true;
            this.S_注意事项标签1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_注意事项标签1.ForeColor = System.Drawing.Color.Blue;
            this.S_注意事项标签1.Location = new System.Drawing.Point(20, 328);
            this.S_注意事项标签1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_注意事项标签1.Name = "S_注意事项标签1";
            this.S_注意事项标签1.Size = new System.Drawing.Size(259, 15);
            this.S_注意事项标签1.TabIndex = 21;
            this.S_注意事项标签1.Text = "本页所有时间设置均以分钟为单位，请注意设置";
            // 
            // S_重载客户数据
            // 
            this.S_重载客户数据.Location = new System.Drawing.Point(20, 162);
            this.S_重载客户数据.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_重载客户数据.Name = "S_重载客户数据";
            this.S_重载客户数据.Size = new System.Drawing.Size(518, 33);
            this.S_重载客户数据.TabIndex = 13;
            this.S_重载客户数据.Text = "Reload users database";
            this.S_重载客户数据.UseVisualStyleBackColor = true;
            this.S_重载客户数据.Click += new System.EventHandler(this.重载客户数据_Click);
            // 
            // S_重载SystemData
            // 
            this.S_重载SystemData.Location = new System.Drawing.Point(20, 122);
            this.S_重载SystemData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_重载SystemData.Name = "S_重载SystemData";
            this.S_重载SystemData.Size = new System.Drawing.Size(518, 33);
            this.S_重载SystemData.TabIndex = 12;
            this.S_重载SystemData.Text = "Reload system data";
            this.S_重载SystemData.UseVisualStyleBackColor = true;
            this.S_重载SystemData.Click += new System.EventHandler(this.重载SystemData_Click);
            // 
            // S_浏览合并目录
            // 
            this.S_浏览合并目录.Location = new System.Drawing.Point(511, 235);
            this.S_浏览合并目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_浏览合并目录.Name = "S_浏览合并目录";
            this.S_浏览合并目录.Size = new System.Drawing.Size(27, 33);
            this.S_浏览合并目录.TabIndex = 11;
            this.S_浏览合并目录.Text = "S";
            this.S_浏览合并目录.UseVisualStyleBackColor = true;
            this.S_浏览合并目录.Click += new System.EventHandler(this.选择数据目录_Click);
            // 
            // S_浏览备份目录
            // 
            this.S_浏览备份目录.Location = new System.Drawing.Point(511, 77);
            this.S_浏览备份目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_浏览备份目录.Name = "S_浏览备份目录";
            this.S_浏览备份目录.Size = new System.Drawing.Size(27, 33);
            this.S_浏览备份目录.TabIndex = 10;
            this.S_浏览备份目录.Text = "S";
            this.S_浏览备份目录.UseVisualStyleBackColor = true;
            this.S_浏览备份目录.Click += new System.EventHandler(this.选择数据目录_Click);
            // 
            // S_浏览数据目录
            // 
            this.S_浏览数据目录.Location = new System.Drawing.Point(511, 35);
            this.S_浏览数据目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_浏览数据目录.Name = "S_浏览数据目录";
            this.S_浏览数据目录.Size = new System.Drawing.Size(27, 33);
            this.S_浏览数据目录.TabIndex = 9;
            this.S_浏览数据目录.Text = "S";
            this.S_浏览数据目录.UseVisualStyleBackColor = true;
            this.S_浏览数据目录.Click += new System.EventHandler(this.选择数据目录_Click);
            // 
            // S_合并客户数据
            // 
            this.S_合并客户数据.Location = new System.Drawing.Point(20, 280);
            this.S_合并客户数据.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_合并客户数据.Name = "S_合并客户数据";
            this.S_合并客户数据.Size = new System.Drawing.Size(518, 33);
            this.S_合并客户数据.TabIndex = 8;
            this.S_合并客户数据.Text = "Save users data";
            this.S_合并客户数据.UseVisualStyleBackColor = true;
            this.S_合并客户数据.Click += new System.EventHandler(this.合并客户数据_Click);
            // 
            // S_合并数据目录
            // 
            this.S_合并数据目录.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_合并数据目录.Location = new System.Drawing.Point(133, 238);
            this.S_合并数据目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_合并数据目录.Name = "S_合并数据目录";
            this.S_合并数据目录.Size = new System.Drawing.Size(382, 21);
            this.S_合并数据目录.TabIndex = 7;
            // 
            // S_合并目录标签
            // 
            this.S_合并目录标签.AutoSize = true;
            this.S_合并目录标签.Location = new System.Drawing.Point(20, 246);
            this.S_合并目录标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_合并目录标签.Name = "S_合并目录标签";
            this.S_合并目录标签.Size = new System.Drawing.Size(82, 15);
            this.S_合并目录标签.TabIndex = 6;
            this.S_合并目录标签.Text = "Data directory";
            // 
            // S_数据备份目录
            // 
            this.S_数据备份目录.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_数据备份目录.Location = new System.Drawing.Point(133, 79);
            this.S_数据备份目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_数据备份目录.Name = "S_数据备份目录";
            this.S_数据备份目录.ReadOnly = true;
            this.S_数据备份目录.Size = new System.Drawing.Size(382, 21);
            this.S_数据备份目录.TabIndex = 5;
            this.S_数据备份目录.Text = ".\\Backup";
            // 
            // S_GameData目录
            // 
            this.S_GameData目录.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_GameData目录.Location = new System.Drawing.Point(133, 39);
            this.S_GameData目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_GameData目录.Name = "S_GameData目录";
            this.S_GameData目录.ReadOnly = true;
            this.S_GameData目录.Size = new System.Drawing.Size(382, 21);
            this.S_GameData目录.TabIndex = 4;
            this.S_GameData目录.Text = ".\\Database";
            // 
            // S_备份目录标签
            // 
            this.S_备份目录标签.AutoSize = true;
            this.S_备份目录标签.Location = new System.Drawing.Point(20, 86);
            this.S_备份目录标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_备份目录标签.Name = "S_备份目录标签";
            this.S_备份目录标签.Size = new System.Drawing.Size(82, 15);
            this.S_备份目录标签.TabIndex = 3;
            this.S_备份目录标签.Text = "Backup folder";
            // 
            // S_数据目录标签
            // 
            this.S_数据目录标签.AutoSize = true;
            this.S_数据目录标签.Location = new System.Drawing.Point(20, 45);
            this.S_数据目录标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_数据目录标签.Name = "S_数据目录标签";
            this.S_数据目录标签.Size = new System.Drawing.Size(103, 15);
            this.S_数据目录标签.TabIndex = 1;
            this.S_数据目录标签.Text = "Gamedata Folder";
            // 
            // S_游戏设置分组
            // 
            this.S_游戏设置分组.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.S_游戏设置分组.Controls.Add(this.L_NoobLevel);
            this.S_游戏设置分组.Controls.Add(this.S_NoobLevel);
            this.S_游戏设置分组.Controls.Add(this.S_物品归属标签);
            this.S_游戏设置分组.Controls.Add(this.S_ItemOwnershipTime);
            this.S_游戏设置分组.Controls.Add(this.S_收益衰减标签);
            this.S_游戏设置分组.Controls.Add(this.S_物品清理标签);
            this.S_游戏设置分组.Controls.Add(this.S_ItemCleaningTime);
            this.S_游戏设置分组.Controls.Add(this.S_诱惑时长标签);
            this.S_游戏设置分组.Controls.Add(this.S_TemptationTime);
            this.S_游戏设置分组.Controls.Add(this.S_LessExpGradeRate);
            this.S_游戏设置分组.Controls.Add(this.S_收益等级标签);
            this.S_游戏设置分组.Controls.Add(this.S_LessExpGrade);
            this.S_游戏设置分组.Controls.Add(this.S_经验倍率标签);
            this.S_游戏设置分组.Controls.Add(this.S_ExpRate);
            this.S_游戏设置分组.Controls.Add(this.S_特修折扣标签);
            this.S_游戏设置分组.Controls.Add(this.S_EquipRepairDto);
            this.S_游戏设置分组.Controls.Add(this.S_怪物爆率标签);
            this.S_游戏设置分组.Controls.Add(this.S_ExtraDropRate);
            this.S_游戏设置分组.Controls.Add(this.S_OpenLevelCommand标签);
            this.S_游戏设置分组.Controls.Add(this.S_MaxLevel);
            this.S_游戏设置分组.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_游戏设置分组.Location = new System.Drawing.Point(350, 17);
            this.S_游戏设置分组.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_游戏设置分组.Name = "S_游戏设置分组";
            this.S_游戏设置分组.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_游戏设置分组.Size = new System.Drawing.Size(357, 476);
            this.S_游戏设置分组.TabIndex = 8;
            this.S_游戏设置分组.TabStop = false;
            this.S_游戏设置分组.Text = "游戏设置";
            // 
            // L_NoobLevel
            // 
            this.L_NoobLevel.AutoSize = true;
            this.L_NoobLevel.Location = new System.Drawing.Point(70, 90);
            this.L_NoobLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_NoobLevel.Name = "L_NoobLevel";
            this.L_NoobLevel.Size = new System.Drawing.Size(55, 15);
            this.L_NoobLevel.TabIndex = 21;
            this.L_NoobLevel.Text = "帮扶等级";
            // 
            // S_NoobLevel
            // 
            this.S_NoobLevel.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_NoobLevel.Location = new System.Drawing.Point(189, 80);
            this.S_NoobLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_NoobLevel.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.S_NoobLevel.Name = "S_新手扶持等级";
            this.S_NoobLevel.Size = new System.Drawing.Size(127, 24);
            this.S_NoobLevel.TabIndex = 20;
            this.S_NoobLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // S_物品归属标签
            // 
            this.S_物品归属标签.AutoSize = true;
            this.S_物品归属标签.Location = new System.Drawing.Point(70, 418);
            this.S_物品归属标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_物品归属标签.Name = "S_物品归属标签";
            this.S_物品归属标签.Size = new System.Drawing.Size(79, 15);
            this.S_物品归属标签.TabIndex = 19;
            this.S_物品归属标签.Text = "物品归属时间";
            // 
            // S_ItemOwnershipTime
            // 
            this.S_ItemOwnershipTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_ItemOwnershipTime.Location = new System.Drawing.Point(189, 416);
            this.S_ItemOwnershipTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_ItemOwnershipTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.S_ItemOwnershipTime.Name = "S_物品归属时间";
            this.S_ItemOwnershipTime.Size = new System.Drawing.Size(127, 24);
            this.S_ItemOwnershipTime.TabIndex = 18;
            this.S_ItemOwnershipTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_ItemOwnershipTime.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_收益衰减标签
            // 
            this.S_收益衰减标签.AutoSize = true;
            this.S_收益衰减标签.Location = new System.Drawing.Point(70, 286);
            this.S_收益衰减标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_收益衰减标签.Name = "S_收益衰减标签";
            this.S_收益衰减标签.Size = new System.Drawing.Size(79, 15);
            this.S_收益衰减标签.TabIndex = 13;
            this.S_收益衰减标签.Text = "收益减少比率";
            // 
            // S_物品清理标签
            // 
            this.S_物品清理标签.AutoSize = true;
            this.S_物品清理标签.Location = new System.Drawing.Point(70, 377);
            this.S_物品清理标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_物品清理标签.Name = "S_物品清理标签";
            this.S_物品清理标签.Size = new System.Drawing.Size(55, 15);
            this.S_物品清理标签.TabIndex = 17;
            this.S_物品清理标签.Text = "物品清理";
            // 
            // S_ItemCleaningTime
            // 
            this.S_ItemCleaningTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_ItemCleaningTime.Location = new System.Drawing.Point(189, 373);
            this.S_ItemCleaningTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_ItemCleaningTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.S_ItemCleaningTime.Name = "S_物品清理时间";
            this.S_ItemCleaningTime.Size = new System.Drawing.Size(127, 24);
            this.S_ItemCleaningTime.TabIndex = 16;
            this.S_ItemCleaningTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_ItemCleaningTime.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_诱惑时长标签
            // 
            this.S_诱惑时长标签.AutoSize = true;
            this.S_诱惑时长标签.Location = new System.Drawing.Point(70, 331);
            this.S_诱惑时长标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_诱惑时长标签.Name = "S_诱惑时长标签";
            this.S_诱惑时长标签.Size = new System.Drawing.Size(55, 15);
            this.S_诱惑时长标签.TabIndex = 15;
            this.S_诱惑时长标签.Text = "诱惑时长";
            // 
            // S_TemptationTime
            // 
            this.S_TemptationTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_TemptationTime.Location = new System.Drawing.Point(189, 328);
            this.S_TemptationTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_TemptationTime.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.S_TemptationTime.Name = "S_怪物诱惑时长";
            this.S_TemptationTime.Size = new System.Drawing.Size(127, 24);
            this.S_TemptationTime.TabIndex = 14;
            this.S_TemptationTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_TemptationTime.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_LessExpGradeRate
            // 
            this.S_LessExpGradeRate.DecimalPlaces = 2;
            this.S_LessExpGradeRate.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_LessExpGradeRate.Location = new System.Drawing.Point(189, 286);
            this.S_LessExpGradeRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_LessExpGradeRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.S_LessExpGradeRate.Name = "S_收益减少比率";
            this.S_LessExpGradeRate.Size = new System.Drawing.Size(127, 24);
            this.S_LessExpGradeRate.TabIndex = 12;
            this.S_LessExpGradeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_LessExpGradeRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.S_LessExpGradeRate.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_收益等级标签
            // 
            this.S_收益等级标签.AutoSize = true;
            this.S_收益等级标签.Location = new System.Drawing.Point(69, 249);
            this.S_收益等级标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_收益等级标签.Name = "S_收益等级标签";
            this.S_收益等级标签.Size = new System.Drawing.Size(91, 15);
            this.S_收益等级标签.TabIndex = 11;
            this.S_收益等级标签.Text = "获取经验等级差";
            // 
            // S_LessExpGrade
            // 
            this.S_LessExpGrade.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_LessExpGrade.Location = new System.Drawing.Point(189, 246);
            this.S_LessExpGrade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_LessExpGrade.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.S_LessExpGrade.Name = "S_减收益等级差";
            this.S_LessExpGrade.Size = new System.Drawing.Size(127, 24);
            this.S_LessExpGrade.TabIndex = 10;
            this.S_LessExpGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_LessExpGrade.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_经验倍率标签
            // 
            this.S_经验倍率标签.AutoSize = true;
            this.S_经验倍率标签.Location = new System.Drawing.Point(70, 209);
            this.S_经验倍率标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_经验倍率标签.Name = "S_经验倍率标签";
            this.S_经验倍率标签.Size = new System.Drawing.Size(55, 15);
            this.S_经验倍率标签.TabIndex = 9;
            this.S_经验倍率标签.Text = "经验倍率";
            // 
            // S_ExpRate
            // 
            this.S_ExpRate.DecimalPlaces = 2;
            this.S_ExpRate.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_ExpRate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.S_ExpRate.Location = new System.Drawing.Point(189, 202);
            this.S_ExpRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_ExpRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.S_ExpRate.Name = "S_怪物经验倍率";
            this.S_ExpRate.Size = new System.Drawing.Size(127, 24);
            this.S_ExpRate.TabIndex = 8;
            this.S_ExpRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_ExpRate.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_特修折扣标签
            // 
            this.S_特修折扣标签.AutoSize = true;
            this.S_特修折扣标签.Location = new System.Drawing.Point(70, 130);
            this.S_特修折扣标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_特修折扣标签.Name = "S_特修折扣标签";
            this.S_特修折扣标签.Size = new System.Drawing.Size(55, 15);
            this.S_特修折扣标签.TabIndex = 7;
            this.S_特修折扣标签.Text = "特修折扣";
            // 
            // S_EquipRepairDto
            // 
            this.S_EquipRepairDto.DecimalPlaces = 2;
            this.S_EquipRepairDto.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_EquipRepairDto.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.S_EquipRepairDto.Location = new System.Drawing.Point(189, 120);
            this.S_EquipRepairDto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_EquipRepairDto.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.S_EquipRepairDto.Name = "S_装备特修折扣";
            this.S_EquipRepairDto.Size = new System.Drawing.Size(127, 24);
            this.S_EquipRepairDto.TabIndex = 6;
            this.S_EquipRepairDto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_EquipRepairDto.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_怪物爆率标签
            // 
            this.S_怪物爆率标签.AutoSize = true;
            this.S_怪物爆率标签.Location = new System.Drawing.Point(70, 172);
            this.S_怪物爆率标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_怪物爆率标签.Name = "S_怪物爆率标签";
            this.S_怪物爆率标签.Size = new System.Drawing.Size(55, 15);
            this.S_怪物爆率标签.TabIndex = 5;
            this.S_怪物爆率标签.Text = "额外爆率";
            // 
            // S_ExtraDropRate
            // 
            this.S_ExtraDropRate.DecimalPlaces = 2;
            this.S_ExtraDropRate.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_ExtraDropRate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.S_ExtraDropRate.Location = new System.Drawing.Point(189, 162);
            this.S_ExtraDropRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_ExtraDropRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.S_ExtraDropRate.Name = "S_物品额外爆率";
            this.S_ExtraDropRate.Size = new System.Drawing.Size(127, 24);
            this.S_ExtraDropRate.TabIndex = 4;
            this.S_ExtraDropRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_ExtraDropRate.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_OpenLevelCommand标签
            // 
            this.S_OpenLevelCommand标签.AutoSize = true;
            this.S_OpenLevelCommand标签.Location = new System.Drawing.Point(70, 49);
            this.S_OpenLevelCommand标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_OpenLevelCommand标签.Name = "S_OpenLevelCommand标签";
            this.S_OpenLevelCommand标签.Size = new System.Drawing.Size(55, 15);
            this.S_OpenLevelCommand标签.TabIndex = 3;
            this.S_OpenLevelCommand标签.Text = "等级上限";
            // 
            // S_MaxLevel
            // 
            this.S_MaxLevel.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_MaxLevel.Location = new System.Drawing.Point(189, 39);
            this.S_MaxLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_MaxLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.S_MaxLevel.Name = "S_游戏开放等级";
            this.S_MaxLevel.Size = new System.Drawing.Size(127, 24);
            this.S_MaxLevel.TabIndex = 2;
            this.S_MaxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_MaxLevel.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_网络设置分组
            // 
            this.S_网络设置分组.Controls.Add(this.S_掉线判定标签);
            this.S_网络设置分组.Controls.Add(this.S_DisconnectTime);
            this.S_网络设置分组.Controls.Add(this.S_限定封包标签);
            this.S_网络设置分组.Controls.Add(this.S_PacketLimit);
            this.S_网络设置分组.Controls.Add(this.L_AbnormalBlockTime);
            this.S_网络设置分组.Controls.Add(this.S_AbnormalBlockTime);
            this.S_网络设置分组.Controls.Add(this.S_接收端口标签);
            this.S_网络设置分组.Controls.Add(this.S_TSPort);
            this.S_网络设置分组.Controls.Add(this.S_监听端口标签);
            this.S_网络设置分组.Controls.Add(this.S_GSPort);
            this.S_网络设置分组.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_网络设置分组.Location = new System.Drawing.Point(18, 17);
            this.S_网络设置分组.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_网络设置分组.Name = "S_网络设置分组";
            this.S_网络设置分组.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_网络设置分组.Size = new System.Drawing.Size(298, 476);
            this.S_网络设置分组.TabIndex = 0;
            this.S_网络设置分组.TabStop = false;
            this.S_网络设置分组.Text = "网络设置";
            // 
            // S_掉线判定标签
            // 
            this.S_掉线判定标签.AutoSize = true;
            this.S_掉线判定标签.Location = new System.Drawing.Point(32, 209);
            this.S_掉线判定标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_掉线判定标签.Name = "S_掉线判定标签";
            this.S_掉线判定标签.Size = new System.Drawing.Size(79, 15);
            this.S_掉线判定标签.TabIndex = 9;
            this.S_掉线判定标签.Text = "断联判定时间";
            // 
            // S_DisconnectTime
            // 
            this.S_DisconnectTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_DisconnectTime.Location = new System.Drawing.Point(144, 204);
            this.S_DisconnectTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_DisconnectTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.S_DisconnectTime.Name = "S_判定掉线时间";
            this.S_DisconnectTime.Size = new System.Drawing.Size(127, 24);
            this.S_DisconnectTime.TabIndex = 8;
            this.S_DisconnectTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_DisconnectTime.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_限定封包标签
            // 
            this.S_限定封包标签.AutoSize = true;
            this.S_限定封包标签.Location = new System.Drawing.Point(32, 127);
            this.S_限定封包标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_限定封包标签.Name = "S_限定封包标签";
            this.S_限定封包标签.Size = new System.Drawing.Size(79, 15);
            this.S_限定封包标签.TabIndex = 7;
            this.S_限定封包标签.Text = "封包限定数量";
            // 
            // S_PacketLimit
            // 
            this.S_PacketLimit.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_PacketLimit.Location = new System.Drawing.Point(144, 122);
            this.S_PacketLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_PacketLimit.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.S_PacketLimit.Name = "S_封包限定数量";
            this.S_PacketLimit.Size = new System.Drawing.Size(127, 24);
            this.S_PacketLimit.TabIndex = 6;
            this.S_PacketLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_PacketLimit.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // L_AbnormalBlockTime
            // 
            this.L_AbnormalBlockTime.AutoSize = true;
            this.L_AbnormalBlockTime.Location = new System.Drawing.Point(32, 169);
            this.L_AbnormalBlockTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_AbnormalBlockTime.Name = "L_AbnormalBlockTime";
            this.L_AbnormalBlockTime.Size = new System.Drawing.Size(79, 15);
            this.L_AbnormalBlockTime.TabIndex = 5;
            this.L_AbnormalBlockTime.Text = "异常锁定时间";
            // 
            // S_AbnormalBlockTime
            // 
            this.S_AbnormalBlockTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_AbnormalBlockTime.Location = new System.Drawing.Point(144, 162);
            this.S_AbnormalBlockTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_AbnormalBlockTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.S_AbnormalBlockTime.Name = "S_异常屏蔽时间";
            this.S_AbnormalBlockTime.Size = new System.Drawing.Size(127, 24);
            this.S_AbnormalBlockTime.TabIndex = 4;
            this.S_AbnormalBlockTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_AbnormalBlockTime.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_接收端口标签
            // 
            this.S_接收端口标签.AutoSize = true;
            this.S_接收端口标签.Location = new System.Drawing.Point(32, 86);
            this.S_接收端口标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_接收端口标签.Name = "S_接收端口标签";
            this.S_接收端口标签.Size = new System.Drawing.Size(79, 15);
            this.S_接收端口标签.TabIndex = 3;
            this.S_接收端口标签.Text = "门票接收端口";
            // 
            // S_TSPort
            // 
            this.S_TSPort.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_TSPort.Location = new System.Drawing.Point(144, 80);
            this.S_TSPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_TSPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.S_TSPort.Name = "S_门票接收端口";
            this.S_TSPort.Size = new System.Drawing.Size(127, 24);
            this.S_TSPort.TabIndex = 2;
            this.S_TSPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_TSPort.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // S_监听端口标签
            // 
            this.S_监听端口标签.AutoSize = true;
            this.S_监听端口标签.Location = new System.Drawing.Point(32, 45);
            this.S_监听端口标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_监听端口标签.Name = "S_监听端口标签";
            this.S_监听端口标签.Size = new System.Drawing.Size(67, 15);
            this.S_监听端口标签.TabIndex = 1;
            this.S_监听端口标签.Text = "服务器端口";
            // 
            // S_GSPort
            // 
            this.S_GSPort.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S_GSPort.Location = new System.Drawing.Point(144, 39);
            this.S_GSPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S_GSPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.S_GSPort.Name = "S_客户端连接端口";
            this.S_GSPort.Size = new System.Drawing.Size(127, 24);
            this.S_GSPort.TabIndex = 0;
            this.S_GSPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S_GSPort.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
            // 
            // 界面定时更新
            // 
            this.界面定时更新.Interval = 2500;
            // 
            // 下方控件页
            // 
            this.下方控件页.BackColor = System.Drawing.Color.Transparent;
            this.下方控件页.Controls.Add(this.保存按钮);
            this.下方控件页.Controls.Add(this.GMCommand文本);
            this.下方控件页.Controls.Add(this.GMCommand标签);
            this.下方控件页.Controls.Add(this.启动按钮);
            this.下方控件页.Controls.Add(this.停止按钮);
            this.下方控件页.Location = new System.Drawing.Point(4, 680);
            this.下方控件页.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.下方控件页.Name = "下方控件页";
            this.下方控件页.Size = new System.Drawing.Size(1397, 85);
            this.下方控件页.TabIndex = 6;
            // 
            // 保存按钮
            // 
            this.保存按钮.BackColor = System.Drawing.Color.LightSteelBlue;
            this.保存按钮.Enabled = false;
            this.保存按钮.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.保存按钮.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.保存按钮.Image = global::GameServer.Properties.Resources.Save_Image;
            this.保存按钮.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.保存按钮.Location = new System.Drawing.Point(918, 9);
            this.保存按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.保存按钮.Name = "保存按钮";
            this.保存按钮.Size = new System.Drawing.Size(153, 54);
            this.保存按钮.TabIndex = 17;
            this.保存按钮.Text = "保存数据";
            this.保存按钮.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.保存按钮.UseVisualStyleBackColor = false;
            this.保存按钮.Click += new System.EventHandler(this.保存数据库_Click);
            // 
            // GMCommand文本
            // 
            this.GMCommand文本.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.GMCommand文本.Location = new System.Drawing.Point(95, 23);
            this.GMCommand文本.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GMCommand文本.Name = "GMCommand文本";
            this.GMCommand文本.Size = new System.Drawing.Size(815, 23);
            this.GMCommand文本.TabIndex = 16;
            this.GMCommand文本.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.执行GMCommand行_Press);
            // 
            // GMCommand标签
            // 
            this.GMCommand标签.AutoSize = true;
            this.GMCommand标签.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GMCommand标签.Location = new System.Drawing.Point(21, 29);
            this.GMCommand标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GMCommand标签.Name = "GMCommand标签";
            this.GMCommand标签.Size = new System.Drawing.Size(66, 16);
            this.GMCommand标签.TabIndex = 13;
            this.GMCommand标签.Text = "GM Box:";
            this.GMCommand标签.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // 启动按钮
            // 
            this.启动按钮.BackColor = System.Drawing.Color.LightSteelBlue;
            this.启动按钮.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.启动按钮.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.启动按钮.ForeColor = System.Drawing.Color.Green;
            this.启动按钮.Image = global::GameServer.Properties.Resources.Start_Image;
            this.启动按钮.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.启动按钮.Location = new System.Drawing.Point(1078, 9);
            this.启动按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.启动按钮.Name = "启动按钮";
            this.启动按钮.Size = new System.Drawing.Size(153, 54);
            this.启动按钮.TabIndex = 12;
            this.启动按钮.Text = "启动服务";
            this.启动按钮.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.启动按钮.UseVisualStyleBackColor = false;
            this.启动按钮.Click += new System.EventHandler(this.启动服务器_Click);
            // 
            // 停止按钮
            // 
            this.停止按钮.BackColor = System.Drawing.Color.LightSteelBlue;
            this.停止按钮.Enabled = false;
            this.停止按钮.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.停止按钮.ForeColor = System.Drawing.Color.Brown;
            this.停止按钮.Image = global::GameServer.Properties.Resources.Stop_Image;
            this.停止按钮.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.停止按钮.Location = new System.Drawing.Point(1238, 9);
            this.停止按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.停止按钮.Name = "停止按钮";
            this.停止按钮.Size = new System.Drawing.Size(153, 54);
            this.停止按钮.TabIndex = 11;
            this.停止按钮.Text = "停止服务";
            this.停止按钮.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.停止按钮.UseVisualStyleBackColor = false;
            this.停止按钮.Click += new System.EventHandler(this.停止服务器_Click);
            // 
            // 保存数据提醒
            // 
            this.保存数据提醒.Enabled = true;
            this.保存数据提醒.Interval = 500;
            this.保存数据提醒.Tick += new System.EventHandler(this.保存数据提醒_Tick);
            // 
            // 定时发送公告
            // 
            this.定时发送公告.Tick += new System.EventHandler(this.定时发送公告_Tick);
            // 
            // 状态
            // 
            this.状态.Frozen = true;
            this.状态.HeaderText = "状态";
            this.状态.MinimumWidth = 6;
            this.状态.Name = "状态";
            this.状态.ReadOnly = true;
            this.状态.Width = 60;
            // 
            // 间隔分钟
            // 
            this.间隔分钟.DataPropertyName = "间隔分钟";
            this.间隔分钟.Frozen = true;
            this.间隔分钟.HeaderText = "间隔分钟";
            this.间隔分钟.MinimumWidth = 6;
            this.间隔分钟.Name = "间隔分钟";
            this.间隔分钟.Width = 80;
            // 
            // 公告次数
            // 
            this.公告次数.DataPropertyName = "公告次数";
            this.公告次数.Frozen = true;
            this.公告次数.HeaderText = "公告次数";
            this.公告次数.MinimumWidth = 6;
            this.公告次数.Name = "公告次数";
            this.公告次数.Width = 80;
            // 
            // 剩余次数
            // 
            this.剩余次数.Frozen = true;
            this.剩余次数.HeaderText = "剩余次数";
            this.剩余次数.MinimumWidth = 6;
            this.剩余次数.Name = "剩余次数";
            this.剩余次数.ReadOnly = true;
            this.剩余次数.Width = 80;
            // 
            // 公告计时
            // 
            this.公告计时.Frozen = true;
            this.公告计时.HeaderText = "公告计时";
            this.公告计时.MinimumWidth = 6;
            this.公告计时.Name = "公告计时";
            this.公告计时.ReadOnly = true;
            this.公告计时.Width = 90;
            // 
            // 公告内容
            // 
            this.公告内容.DataPropertyName = "公告内容";
            this.公告内容.Frozen = true;
            this.公告内容.HeaderText = "公告内容";
            this.公告内容.MinimumWidth = 6;
            this.公告内容.Name = "公告内容";
            this.公告内容.Width = 884;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 749);
            this.Controls.Add(this.下方控件页);
            this.Controls.Add(this.主选项卡);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameServer - Mir3D LOMCN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.关闭主界面_Click);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.主选项卡.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.MainTabs.ResumeLayout(false);
            this.tabSystem.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.tabCommands.ResumeLayout(false);
            this.tabPackets.ResumeLayout(false);
            this.tabCharacters.ResumeLayout(false);
            this.角色详情选项卡.ResumeLayout(false);
            this.CharacterData_技能.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.技能浏览表)).EndInit();
            this.CharacterData_装备.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.装备浏览表)).EndInit();
            this.CharacterData_背包.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.背包浏览表)).EndInit();
            this.CharacterData_仓库.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.仓库浏览表)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharacters)).EndInit();
            this.角色右键菜单.ResumeLayout(false);
            this.tabMaps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).EndInit();
            this.tabMonsters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.掉落浏览表)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.怪物浏览表)).EndInit();
            this.tabBans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.封禁浏览表)).EndInit();
            this.tabAnnouncements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.公告浏览表)).EndInit();
            this.tabConfig.ResumeLayout(false);
            this.S_软件授权分组.ResumeLayout(false);
            this.S_软件授权分组.PerformLayout();
            this.S_GameData分组.ResumeLayout(false);
            this.S_GameData分组.PerformLayout();
            this.S_游戏设置分组.ResumeLayout(false);
            this.S_游戏设置分组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.S_NoobLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_ItemOwnershipTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_ItemCleaningTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_TemptationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_LessExpGradeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_LessExpGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_ExpRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_EquipRepairDto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_ExtraDropRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_MaxLevel)).EndInit();
            this.S_网络设置分组.ResumeLayout(false);
            this.S_网络设置分组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.S_DisconnectTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_PacketLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_AbnormalBlockTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_TSPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_GSPort)).EndInit();
            this.下方控件页.ResumeLayout(false);
            this.下方控件页.PerformLayout();
            this.ResumeLayout(false);

    }


    private global::System.ComponentModel.IContainer components;


    private global::System.Windows.Forms.RichTextBox 系统日志;


    private global::System.Windows.Forms.Label 帧数统计;


    private global::System.Windows.Forms.Button 保存系统日志;


    private global::System.Windows.Forms.Button 清空系统日志;


    private global::System.Windows.Forms.Label 发送统计;


    private global::System.Windows.Forms.Label 接收统计;


    private global::System.Windows.Forms.Label 已经上线统计;


    private global::System.Windows.Forms.Label 连接总数统计;


    private global::System.Windows.Forms.Label 已经登录统计;


    private global::System.Windows.Forms.Button 保存聊天日志;


    private global::System.Windows.Forms.Button 清空聊天日志;


    private global::System.Windows.Forms.TabControl 角色详情选项卡;


    private global::System.Windows.Forms.TabPage CharacterData_技能;


    private global::System.Windows.Forms.TabPage CharacterData_装备;


    private global::System.Windows.Forms.TabPage CharacterData_背包;


    private global::System.Windows.Forms.TabPage CharacterData_仓库;


    public global::System.Windows.Forms.TabControl 主选项卡;


    public global::System.Windows.Forms.DataGridView dgvCharacters;


    public global::System.Windows.Forms.DataGridView 技能浏览表;


    private global::System.Windows.Forms.DataGridView 装备浏览表;


    public global::System.Windows.Forms.DataGridView 背包浏览表;


    public global::System.Windows.Forms.DataGridView 仓库浏览表;


    private global::System.Windows.Forms.Timer 界面定时更新;


    private global::System.Windows.Forms.TabPage tabSystem;


    private global::System.Windows.Forms.TabPage tabChat;


    private global::System.Windows.Forms.RichTextBox 聊天日志;


    public global::System.Windows.Forms.DataGridView dgvMaps;


    public global::System.Windows.Forms.DataGridView 怪物浏览表;


    private global::System.Windows.Forms.DataGridView 掉落浏览表;


    private global::System.Windows.Forms.GroupBox S_网络设置分组;


    private global::System.Windows.Forms.Label S_监听端口标签;


    private global::System.Windows.Forms.NumericUpDown S_GSPort;


    private global::System.Windows.Forms.Label S_接收端口标签;


    private global::System.Windows.Forms.NumericUpDown S_TSPort;


    private global::System.Windows.Forms.Label L_AbnormalBlockTime;


    private global::System.Windows.Forms.NumericUpDown S_AbnormalBlockTime;


    private global::System.Windows.Forms.GroupBox S_游戏设置分组;


    private global::System.Windows.Forms.Label S_特修折扣标签;


    private global::System.Windows.Forms.NumericUpDown S_EquipRepairDto;


    private global::System.Windows.Forms.Label S_怪物爆率标签;


    private global::System.Windows.Forms.Label S_OpenLevelCommand标签;


    private global::System.Windows.Forms.Label S_限定封包标签;


    private global::System.Windows.Forms.NumericUpDown S_PacketLimit;


    private global::System.Windows.Forms.Label S_掉线判定标签;


    private global::System.Windows.Forms.NumericUpDown S_DisconnectTime;


    private global::System.Windows.Forms.Label S_经验倍率标签;


    private global::System.Windows.Forms.Label S_收益等级标签;


    private global::System.Windows.Forms.NumericUpDown S_LessExpGrade;


    private global::System.Windows.Forms.Label S_收益衰减标签;


    private global::System.Windows.Forms.NumericUpDown S_LessExpGradeRate;


    private global::System.Windows.Forms.Label S_诱惑时长标签;


    private global::System.Windows.Forms.NumericUpDown S_TemptationTime;


    private global::System.Windows.Forms.Label S_物品归属标签;


    private global::System.Windows.Forms.NumericUpDown S_ItemOwnershipTime;


    private global::System.Windows.Forms.Label S_物品清理标签;


    private global::System.Windows.Forms.NumericUpDown S_ItemCleaningTime;














    private global::System.Windows.Forms.TextBox GMCommand文本;


    private global::System.Windows.Forms.Label GMCommand标签;


    public global::System.Windows.Forms.Button 启动按钮;


    public global::System.Windows.Forms.Button 停止按钮;



    public global::System.Windows.Forms.Button 保存按钮;


    private global::System.Windows.Forms.Label 对象统计;










    private global::System.Windows.Forms.TabPage tabCommands;


    private global::System.Windows.Forms.RichTextBox 命令日志;


    private global::System.Windows.Forms.Button 清空命令日志;


    private global::System.Windows.Forms.Timer 保存数据提醒;


    public global::System.Windows.Forms.TabPage tabConfig;


    public global::System.Windows.Forms.Panel 下方控件页;


    private global::System.Windows.Forms.ContextMenuStrip 角色右键菜单;


    private global::System.Windows.Forms.ToolStripMenuItem 右键菜单_复制CharName;


    private global::System.Windows.Forms.ToolStripMenuItem 右键菜单_复制Account;


    private global::System.Windows.Forms.ToolStripMenuItem 右键菜单_复制网络地址;


    private global::System.Windows.Forms.ToolStripMenuItem 右键菜单_复制物理地址;


    public global::System.Windows.Forms.TabPage tabBans;


    private global::System.Windows.Forms.TabPage tabAnnouncements;


    public global::System.Windows.Forms.TabPage tabMain;


    public global::System.Windows.Forms.TabPage tabMaps;


    public global::System.Windows.Forms.TabPage tabMonsters;


    public global::System.Windows.Forms.TabPage tabCharacters;


    private global::System.Windows.Forms.DataGridView 封禁浏览表;


    public global::System.Windows.Forms.NumericUpDown S_ExtraDropRate;


    public global::System.Windows.Forms.NumericUpDown S_ExpRate;


    public global::System.Windows.Forms.NumericUpDown S_MaxLevel;


    private global::System.Windows.Forms.Button 删除公告按钮;


    private global::System.Windows.Forms.Button 添加公告按钮;


    public global::System.Windows.Forms.Timer 定时发送公告;


    public global::System.Windows.Forms.DataGridView 公告浏览表;


    public global::System.Windows.Forms.Button 开始公告按钮;


    public global::System.Windows.Forms.Button 停止公告按钮;








    private global::System.Windows.Forms.Label L_NoobLevel;


    public global::System.Windows.Forms.NumericUpDown S_NoobLevel;


    public global::System.Windows.Forms.TabControl MainTabs;


    private global::System.Windows.Forms.GroupBox S_软件授权分组;


    private global::System.Windows.Forms.TextBox S_软件注册代码;
    private System.Windows.Forms.TabPage tabPackets;
    private System.Windows.Forms.RichTextBox rtbPacketsLogs;
    private System.Windows.Forms.Button 重载数据;
        private System.Windows.Forms.GroupBox S_GameData分组;
        private System.Windows.Forms.Label S_注意事项标签1;
        private System.Windows.Forms.Button S_重载客户数据;
        private System.Windows.Forms.Button S_重载SystemData;
        private System.Windows.Forms.Button S_浏览合并目录;
        private System.Windows.Forms.Button S_浏览备份目录;
        private System.Windows.Forms.Button S_浏览数据目录;
        private System.Windows.Forms.Button S_合并客户数据;
        private System.Windows.Forms.TextBox S_合并数据目录;
        private System.Windows.Forms.Label S_合并目录标签;
        private System.Windows.Forms.TextBox S_数据备份目录;
        private System.Windows.Forms.TextBox S_GameData目录;
        private System.Windows.Forms.Label S_备份目录标签;
        private System.Windows.Forms.Label S_数据目录标签;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 间隔分钟;
        private System.Windows.Forms.DataGridViewTextBoxColumn 公告次数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 剩余次数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 公告计时;
        private System.Windows.Forms.DataGridViewTextBoxColumn 公告内容;
    }
}
