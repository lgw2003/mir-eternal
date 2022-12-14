using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using GameServer.Maps;
using GameServer.Data;
using GamePackets.Client;
using System.Text;

namespace GameServer.Networking
{

    public sealed class 客户网络
    {
        private DateTime 掉线判定时间;
        private bool 正在发送;
        private byte[] 剩余数据;
        private readonly EventHandler<Exception> 断网事件;
        private ConcurrentQueue<GamePacket> 接收列表;
        private ConcurrentQueue<GamePacket> 发送列表;
        public bool 正在断开;
        public readonly DateTime 接入时间;
        public readonly TcpClient 当前连接;
        public 游戏阶段 CurrentStage;
        public AccountData 账号数据;
        public PlayerObject 玩家实例;
        public string 网络地址;
        public string MacAddress;
        public int TotalSended;
        public int TotalReceived;

        public 客户网络(TcpClient tcpClient)
        {
            剩余数据 = new byte[0];
            接收列表 = new ConcurrentQueue<GamePacket>();
            发送列表 = new ConcurrentQueue<GamePacket>();

            当前连接 = tcpClient;
            当前连接.NoDelay = true;
            接入时间 = MainProcess.CurrentTime;
            掉线判定时间 = MainProcess.CurrentTime.AddMinutes(Config.掉线判定时间);
            断网事件 = (EventHandler<Exception>)Delegate.Combine(断网事件, new EventHandler<Exception>(NetworkServiceGateway.断网回调));
            网络地址 = 当前连接.Client.RemoteEndPoint.ToString().Split(':')[0];
            开始异步接收();
        }

        public void 处理数据()
        {
            try
            {
                if (!正在断开 && !NetworkServiceGateway.网络服务停止)
                {
                    if (MainProcess.CurrentTime > 掉线判定时间)
                    {
                        尝试断开连接(new Exception("长时间无响应,断开连接."));
                    }
                    else
                    {
                        处理已收封包();
                        发送全部封包();
                    }
                }
                else if (!正在发送 && 接收列表.Count == 0 && 发送列表.Count == 0)
                {
                    玩家实例?.Disconnect();
                    账号数据?.Disconnect();
                    NetworkServiceGateway.Disconnected(this);
                    当前连接.Client.Shutdown(SocketShutdown.Both);
                    当前连接.Close();
                    接收列表 = null;
                    发送列表 = null;
                    CurrentStage = 游戏阶段.正在登陆;
                }
                else
                {
                    处理已收封包();
                    发送全部封包();
                }
            }
            catch (Exception ex)
            {
                if (玩家实例 != null)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("处理网络数据时出现异常, 已断开对应连接");
                    sb.AppendLine($"账号:[{账号数据?.Account.V ?? "None"}]");
                    sb.AppendLine($"角色:[{玩家实例?.ObjectName ?? "None"}]");
                    sb.AppendLine($"IP:[{网络地址}]");
                    sb.AppendLine($"MAC:[{MacAddress}]");
                    sb.Append($"错误提示:[{ex.Message}]");
                    MainProcess.AddSystemLog(sb.ToString());
                }

                玩家实例?.Disconnect();
                账号数据?.Disconnect();
                NetworkServiceGateway.Disconnected(this);
                当前连接.Client?.Shutdown(SocketShutdown.Both);
                当前连接?.Close();

                接收列表 = null;
                发送列表 = null;
                CurrentStage = 游戏阶段.正在登陆;
            }
        }
        public void 发送封包(GamePacket packet)
        {
            if (!正在断开 && !NetworkServiceGateway.网络服务停止 && packet != null)
            {
                if (Config.SendPacketsAsync)
                {
                    发送列表.Enqueue(packet);
                }
                else
                {
                    MainForm.AddPacketLog(packet, false);
                    当前连接.Client.Send(packet.取字节());
                }
            }
        }
        public void SendRaw(ushort type, ushort length, byte[] data, bool encoded = true)
        {
            byte[] output;
            if (length == 0)
            {
                output = new byte[data.Length + 4];
                Array.Copy(BitConverter.GetBytes((ushort)type), 0, output, 0, 2);
                Array.Copy(BitConverter.GetBytes((ushort)output.Length), 0, output, 2, 2);
                Array.Copy(data, 0, output, 4, data.Length);
            }
            else
            {
                output = new byte[data.Length + 2];
                Array.Copy(BitConverter.GetBytes((ushort)type), 0, output, 0, 2);
                Array.Copy(data, 0, output, 2, data.Length);
            }

            if (encoded)
                for (var i = 4; i < output.Length; i++)
                    output[i] ^= GamePacket.加密字节;

            当前连接.Client.Send(output);
        }
        public void 尝试断开连接(Exception e)
        {
            if (!this.正在断开)
            {
                this.正在断开 = true;
                EventHandler<Exception> eventHandler = this.断网事件;
                if (eventHandler == null)
                {
                    return;
                }
                eventHandler(this, e);
            }
        }
        private void 处理已收封包()
        {
            while (!接收列表.IsEmpty)
            {
                if (接收列表.Count > Config.PacketLimit)
                {
                    接收列表.Clear();
                    NetworkServiceGateway.屏蔽网络(this.网络地址);
                    尝试断开连接(new Exception("封包超出总数限制，断开连接并限制登陆."));
                    return;
                }

                if (接收列表.TryDequeue(out GamePacket packet))
                {
                    //接收封包发送到封包调试界面
                    MainForm.AddPacketLog(packet, true);
                    if (!GamePacket.封包处理方法.TryGetValue(packet.封包类型, out MethodInfo methodInfo))
                    {
                        尝试断开连接(new Exception("没有找到封包处理方法, 断开连接. 封包类型: " + packet.封包类型.FullName));
                        return;
                    }
                    methodInfo.Invoke(this, new object[] { packet });
                }
            }
        }
        private void 发送全部封包()
        {
            List<byte> list = new();

            while (发送列表.TryDequeue(out GamePacket packet))
            {
                //将发送封包输出到封包调试界面
                MainForm.AddPacketLog(packet, false);
                list.AddRange(packet.取字节());
            }

            if (list.Count != 0)
            {
                开始异步发送(list);
            }
        }
        private void 延迟掉线时间()
        {
            this.掉线判定时间 = MainProcess.CurrentTime.AddMinutes((double)Config.掉线判定时间);
        }
        private void 开始异步接收()
        {
            try
            {
                if (!this.正在断开 && !NetworkServiceGateway.网络服务停止)
                {
                    byte[] array = new byte[8192];
                    this.当前连接.Client.BeginReceive(array, 0, array.Length, SocketFlags.None, new AsyncCallback(this.接收完成回调), array);
                }
            }
            catch (Exception ex)
            {
                this.尝试断开连接(new Exception("异步接收错误: " + ex.Message));
            }
        }
        private void 接收完成回调(IAsyncResult result)
        {
            try
            {
                if (!this.正在断开 && !NetworkServiceGateway.网络服务停止 && this.当前连接.Client != null)
                {
                    Socket client = this.当前连接.Client;
                    int num = (client != null) ? client.EndReceive(result) : 0;
                    if (num > 0)
                    {
                        this.TotalReceived += num;
                        NetworkServiceGateway.ReceivedBytes += (long)num;
                        Array src = result.AsyncState as byte[];
                        byte[] dst = new byte[this.剩余数据.Length + num];
                        Buffer.BlockCopy(this.剩余数据, 0, dst, 0, this.剩余数据.Length);
                        Buffer.BlockCopy(src, 0, dst, this.剩余数据.Length, num);
                        this.剩余数据 = dst;
                        for (; ; )
                        {
                            try
                            {
                                GamePacket GamePacket = GamePacket.GetPacket(this.剩余数据, out this.剩余数据);
                                if (GamePacket == null)
                                {
                                    break;
                                }
                                this.接收列表.Enqueue(GamePacket);
                            }
                            catch (Exception ex)
                            {
                                this.尝试断开连接(ex);
                                break;
                            }
                        }
                        this.延迟掉线时间();
                        this.开始异步接收();
                    }
                    else
                    {
                        this.尝试断开连接(new Exception("Client disconnected."));
                    }
                }
            }
            catch (Exception ex)
            {
                this.尝试断开连接(new Exception("Packet construction error, message: " + ex.Message));
            }
        }
        private void 开始异步发送(List<byte> 数据)
        {
            try
            {
                this.正在发送 = true;
                this.当前连接.Client.BeginSend(数据.ToArray(), 0, 数据.Count, SocketFlags.None, new AsyncCallback(this.发送完成回调), null);
            }
            catch (Exception ex)
            {
                this.正在发送 = false;
                this.发送列表 = new ConcurrentQueue<GamePacket>();
                this.尝试断开连接(new Exception("Asynchronous sending error: " + ex.Message));
            }
        }
        private void 发送完成回调(IAsyncResult 异步参数)
        {
            try
            {
                int num = this.当前连接.Client.EndSend(异步参数);
                this.TotalSended += num;
                NetworkServiceGateway.SendedBytes += (long)num;
                if (num == 0)
                {
                    this.发送列表 = new ConcurrentQueue<GamePacket>();
                    this.尝试断开连接(new Exception("Error sending callback!"));
                }
                this.正在发送 = false;
            }
            catch (Exception ex)
            {
                this.正在发送 = false;
                this.发送列表 = new ConcurrentQueue<GamePacket>();
                this.尝试断开连接(new Exception("Sending callback errors: " + ex.Message));
            }
        }
        public void 处理封包(坐骑御兽之力封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.添加坐骑技能包(P.坐骑编号, P.Unknown);
        }
        public void 处理封包(当前选中坐骑封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家选中坐骑(P.坐骑编号);
        }
        public void 处理封包(玩家装备锁定封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
        }
        public void 处理封包(UnknownC1 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家进入场景();
            this.CurrentStage = 游戏阶段.正在游戏;
        }
        public void 处理封包(PlayerEnterScenePacket P)
        {

        }

        public void 处理封包(UnknownC2 P)
        {

        }
        public void 处理封包(UnknownC3 P)
        {
            //// 货币数量变动 (Server)
            //SendPacket(
            //149,
            //30,
            //new byte[] { 13, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0 }
            //);

            this.玩家实例.ActiveConnection?.发送封包(new UnknownS5
            {
                U1 = P.U1,
                U2 = 19225
            });
            //// u218 (Server)
            //SendPacket(
            //218,
            //10,
            //new byte[] { 59, 0, 0, 0, 25, 75, 0, 0 }
            //);
        }
        public void 处理封包(UnknownC4 P)
        {

        }
        public void 处理封包(UnknownC5 P)
        {

        }
        public void 处理封包(预留封包零一 P)
        {
        }
        public void 处理封包(预留封包零二 P)
        {
        }
        public void 处理封包(预留封包零三 P)
        {
        }

        public void 处理封包(切换觉醒栏经验封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            玩家实例.切换觉醒栏经验封包(P.Enabled);
        }

        public void 处理封包(升级觉醒技能封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            玩家实例.升级觉醒技能封包(P.SkillId);
        }

        public void 处理封包(玩家仓库锁定封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            玩家实例.请求仓库锁定(P.Enabled);
        }

        public void 处理封包(发送消息码验证封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            玩家实例.验证消息码(P.Code);
        }

        public void 处理封包(玩家完成任务封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            玩家实例.完成任务(P.QuestId);
        }
        public void 处理封包(任务传送封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.任务传送(P.QuestId);
        }
        public void 处理封包(接受奖励封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.接受奖励(P.QuestId);
        }
        public void 处理封包(上传游戏设置封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家更改设置(P.字节描述);
        }
        public void 处理封包(客户碰触法阵封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(玩家进入法阵封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家进入法阵(P.法阵编号);
        }
        public void 处理封包(点击Npcc对话封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }

            this.玩家实例.执行NPC流程(P.对象编号, P.任务编号);
        }
        public void 处理封包(请求对象数据封包 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.请求对象外观(P.对象编号, P.状态编号);
        }
        public void 处理封包(客户网速测试封包 P)
        {
            if (CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            发送封包(new 网速测试应答封包
            {
                当前时间 = P.客户时间
            });
        }
        public void 处理封包(测试网关网速 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }

            发送封包(new 登陆查询应答封包
            {
                当前时间 = P.客户时间
            });
        }
        public void 处理封包(客户请求复活封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家请求复活();
        }
        public void 处理封包(切换攻击模式封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (Enum.IsDefined(typeof(攻击模式), (int)P.AttackMode) && Enum.TryParse<攻击模式>(P.AttackMode.ToString(), out 攻击模式 模式))
            {
                this.玩家实例.更改攻击模式(模式);
                return;
            }
            this.尝试断开连接(new Exception("Wrong enumeration parameter is provided when changing the AttackMode. About to be disconnected."));
        }
        public void 处理封包(更改宠物模式封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (Enum.IsDefined(typeof(PetMode), (int)P.PetMode) && Enum.TryParse<PetMode>(P.PetMode.ToString(), out PetMode 模式))
            {
                this.玩家实例.更改宠物模式(模式);
                return;
            }
            this.尝试断开连接(new Exception(string.Format("Wrong enumeration parameter is provided when changing PetMode. About to be disconnected. Parameter - {0}", P.PetMode)));
        }
        public void 处理封包(上传角色位置封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家同步位置();
        }
        public void 处理封包(玩家角色转动封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (Enum.IsDefined(typeof(GameDirection), (int)P.转动方向) && Enum.TryParse<GameDirection>(P.转动方向.ToString(), out GameDirection 转动方向))
            {
                this.玩家实例.玩家角色转动(转动方向);
                return;
            }
            this.尝试断开连接(new Exception("Wrong enumeration parameter provided when player character is rotated. Disconnection is imminent."));
        }
        public void 处理封包(玩家角色走动封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家角色走动(P.坐标);
        }
        public void 处理封包(玩家角色跑动封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家角色跑动(P.坐标);
        }
        public void 处理封包(玩家开关技能封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家开关技能(P.SkillId);
        }
        public void 处理封包(玩家装备技能封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (P.技能栏位 < 32)
            {
                this.玩家实例.装备技能(P.技能栏位, P.技能编号);
                return;
            }
            this.尝试断开连接(new Exception("Player supplied wrong packet parameters when assembling skills. Disconnection is imminent."));
        }
        public void 处理封包(玩家释放技能封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.释放技能(P.技能编号, P.动作编号, P.目标编号, P.锚点坐标);
        }
        public void 处理封包(战斗姿态切换封包 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家切换姿态();
        }
        public void 处理封包(玩家更换角色封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.账号数据.更换角色(this);
            this.CurrentStage = 游戏阶段.选择角色;
        }
        public void 处理封包(场景加载完成封包 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家进入场景();
            this.CurrentStage = 游戏阶段.正在游戏;
        }
        public void 处理封包(玩家退出副本封包 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家退出副本();
        }
        public void 处理封包(玩家退出登录封包 P)
        {
            if (this.CurrentStage == 游戏阶段.正在登陆)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.账号数据.返回登录(this);
        }
        public void 处理封包(打开角色背包封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(角色拾取物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }

            // TODO: Pickup items
        }
        public void 处理封包(玩家丢弃物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家丢弃物品(P.背包类型, P.物品位置, P.丢弃数量);
        }
        public void 处理封包(玩家转移物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.转移物品(P.当前背包, P.原有位置, P.目标背包, P.目标位置);
        }
        public void 处理封包(玩家使用物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.使用物品(P.背包类型, P.物品位置);
        }
        public void 处理封包(玩家喝修复油封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家喝修复油(P.背包类型, P.物品位置);
        }
        public void 处理封包(玩家扩展背包封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.扩展背包(P.背包类型, P.扩展大小);
        }
        public void 处理封包(请求商店数据封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.请求商店数据(P.版本编号);
        }
        public void 处理封包(玩家购买物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家购买物品(P.商店编号, P.物品位置, P.购入数量);
        }
        public void 处理封包(玩家出售物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家出售物品(P.背包类型, P.物品位置, P.卖出数量);
        }
        public void 处理封包(查询回购列表封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.请求回购清单();
        }
        public void 处理封包(玩家回购物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (P.物品位置 < 100)
            {
                this.玩家实例.玩家回购物品(P.物品位置);
                return;
            }
            this.尝试断开连接(new Exception("The player has provided the wrong location parameters when buying back the item. Disconnection is imminent."));
        }
        public void 处理封包(商店修理单件封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.商店修理单件(P.背包类型, P.物品位置);
        }
        public void 处理封包(商店修理全部封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.商店修理全部();
        }
        public void 处理封包(商店特修单件封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.商店特修单件(P.物品容器, P.物品位置);
        }
        public void 处理封包(随身修理单件封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.随身修理单件(P.物品容器, P.物品位置, P.Id);
        }
        public void 处理封包(随身特修全部封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.随身修理全部();
        }
        public void 处理封包(玩家整理背包封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家整理背包(P.背包类型);
        }
        public void 处理封包(玩家拆分物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家拆分物品(P.当前背包, P.物品位置, P.拆分数量, P.目标背包, P.目标位置);
        }
        public void 处理封包(玩家分解物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (Enum.TryParse<ItemBackPack>(P.背包类型.ToString(), out ItemBackPack ItemBackPack) && Enum.IsDefined(typeof(ItemBackPack), ItemBackPack))
            {
                this.玩家实例.玩家分解物品(P.背包类型, P.物品位置, P.分解数量);
                return;
            }
            this.尝试断开连接(new Exception("Player provides wrong enumeration parameters when breaking down an item. Disconnection is imminent."));
        }
        public void 处理封包(玩家合成物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家合成物品();
        }
        public void 处理封包(玩家镶嵌灵石封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家镶嵌灵石(P.装备类型, P.装备位置, P.装备孔位, P.灵石类型, P.灵石位置);
        }
        public void 处理封包(玩家拆除灵石封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家拆除灵石(P.装备类型, P.装备位置, P.装备孔位);
        }
        public void 处理封包(普通铭文洗练封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.普通铭文洗练(P.装备类型, P.装备位置, P.Id);
        }
        public void 处理封包(高级铭文洗练封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.高级铭文洗练(P.装备类型, P.装备位置, P.Id);
        }
        public void 处理封包(替换铭文洗练封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.替换铭文洗练(P.装备类型, P.装备位置, P.Id);
        }
        public void 处理封包(替换高级铭文封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.高级洗练确认(P.装备类型, P.装备位置);
        }
        public void 处理封包(替换低级铭文封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.替换洗练确认(P.装备类型, P.装备位置);
        }
        public void 处理封包(放弃铭文替换封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.放弃替换铭文();
        }
        public void 处理封包(解锁双铭文位封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.解锁双铭文位(P.装备类型, P.装备位置, P.操作参数);
        }
        public void 处理封包(切换双铭文位封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.切换双铭文位(P.装备类型, P.装备位置, P.操作参数);
        }
        public void 处理封包(传承武器铭文封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.传承武器铭文(P.来源类型, P.来源位置, P.目标类型, P.目标位置);
        }
        public void 处理封包(升级武器普通封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.升级武器普通(P.首饰组, P.材料组);
        }
        public void 处理封包(玩家选中目标封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.选中目标(P.对象编号);
        }
        public void 处理封包(开始Npcc对话封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.开始Npcc对话(P.对象编号);
        }
        public void 处理封包(继续Npcc对话封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.继续Npcc对话(P.Id);
        }
        public void 处理封包(查看玩家装备 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查看对象装备(P.对象编号);
        }
        public void 处理封包(请求龙卫数据封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(请求魂石数据封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(查询奖励找回封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(同步角色战力封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询玩家战力(P.对象编号);
        }
        public void 处理封包(查询问卷调查封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(玩家申请交易封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家申请交易(P.对象编号);
        }
        public void 处理封包(玩家同意交易封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家同意交易(P.对象编号);
        }
        public void 处理封包(玩家结束交易封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家结束交易();
        }
        public void 处理封包(玩家放入金币封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家放入金币(P.NumberGoldCoins);
        }
        public void 处理封包(玩家放入物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家放入物品(P.放入位置, P.放入物品, P.物品容器, P.物品位置);
        }
        public void 处理封包(玩家锁定交易 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家锁定交易();
        }
        public void 处理封包(玩家解锁交易封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家解锁交易();
        }
        public void 处理封包(玩家确认交易封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家确认交易();
        }
        public void 处理封包(玩家准备摆摊封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家准备摆摊();
        }
        public void 处理封包(玩家重整摊位封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家重整摊位();
        }
        public void 处理封包(玩家开始摆摊封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家开始摆摊();
        }
        public void 处理封包(玩家收起摊位封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家收起摊位();
        }
        public void 处理封包(物品放入摊位封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.物品放入摊位(P.放入位置, P.物品容器, P.物品位置, P.物品数量, P.物品价格);
        }
        public void 处理封包(取回摊位物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.取回摊位物品(P.取回位置);
        }
        public void 处理封包(更改摊位名字封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.更改摊位名字(P.摊位名字);
        }
        public void 处理封包(更改摊位外观封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.升级摊位外观(P.外观编号);
        }
        public void 处理封包(打开角色摊位封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家打开摊位(P.对象编号);
        }
        public void 处理封包(购买摊位物品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.购买摊位物品(P.对象编号, P.物品位置, P.购买数量);
        }
        public void 处理封包(玩家添加关注封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家添加关注(P.对象编号, P.对象名字);
        }
        public void 处理封包(取消好友关注封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家取消关注(P.对象编号);
        }
        public void 处理封包(新建好友分组封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(移动好友分组封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(发送好友聊天封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (P.字节数据.Length < 7)
            {
                this.尝试断开连接(new Exception(string.Format("数据太短,断开连接.  处理封包: {0},  数据长度:{1}", P.GetType(), P.字节数据.Length)));
                return;
            }
            if (P.字节数据.Last<byte>() != 0)
            {
                this.尝试断开连接(new Exception(string.Format("数据错误,断开连接.  处理封包: {0},  无结束符.", P.GetType())));
                return;
            }
            this.玩家实例.玩家好友聊天(P.字节数据);
        }
        public void 处理封包(玩家添加仇人封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家添加仇人(P.对象编号);
        }
        public void 处理封包(玩家删除仇人封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家删除仇人(P.对象编号);
        }
        public void 处理封包(玩家屏蔽对象封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家屏蔽目标(P.对象编号);
        }
        public void 处理封包(玩家解除屏蔽封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家解除屏蔽(P.对象编号);
        }
        public void 处理封包(玩家比较成就封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(发送聊天信息封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (P.字节数据.Length < 7)
            {
                this.尝试断开连接(new Exception(string.Format("数据太短,断开连接.  处理封包: {0},  数据长度:{1}", P.GetType(), P.字节数据.Length)));
                return;
            }
            if (P.字节数据.Last<byte>() != 0)
            {
                this.尝试断开连接(new Exception(string.Format("数据错误,断开连接.  处理封包: {0},  无结束符.", P.GetType())));
                return;
            }
            this.玩家实例.玩家发送广播(P.字节数据);
        }
        public void 处理封包(发送社交消息封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (P.字节数据.Length < 6)
            {
                this.尝试断开连接(new Exception(string.Format("数据太短,断开连接.  处理封包: {0},  数据长度:{1}", P.GetType(), P.字节数据.Length)));
                return;
            }
            if (P.字节数据.Last<byte>() != 0)
            {
                this.尝试断开连接(new Exception(string.Format("数据错误,断开连接.  处理封包: {0},  无结束符.", P.GetType())));
                return;
            }
            this.玩家实例.玩家发送消息(P.字节数据);
        }
        public void 处理封包(请求角色资料封包 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.请求角色资料(P.角色编号);
        }
        public void 处理封包(上传社交信息封包 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(查询附近队伍封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询附近队伍();
        }
        public void 处理封包(查询队伍信息封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询队伍信息(P.对象编号);
        }
        public void 处理封包(申请创建队伍封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请创建队伍(P.对象编号, P.分配方式);
        }
        public void 处理封包(发送组队请求封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.发送组队请求(P.对象编号);
        }
        public void 处理封包(申请离开队伍封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请队员离队(P.对象编号);
        }
        public void 处理封包(申请更改队伍封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请移交队长(P.队长编号);
        }
        public void 处理封包(回应组队请求封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.回应组队请求(P.对象编号, P.组队方式, P.回应方式);
        }
        public void 处理封包(玩家装配称号封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家使用称号(P.Id);
        }
        public void 处理封包(玩家卸下称号封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家卸下称号();
        }
        public void 处理封包(申请发送邮件封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请发送邮件(P.字节数据);
        }
        public void 处理封包(查询邮箱内容封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询邮件内容();
        }
        public void 处理封包(查看邮件内容封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查看邮件内容(P.邮件编号);
        }
        public void 处理封包(删除指定邮件封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.删除指定邮件(P.邮件编号);
        }
        public void 处理封包(提取邮件附件封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.提取邮件附件(P.邮件编号);
        }
        public void 处理封包(查询行会信息封包 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询行会信息(P.行会编号);
        }
        public void 处理封包(更多行会信息封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.更多行会信息();
        }
        public void 处理封包(查看行会列表封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查看行会列表(P.行会编号, P.查看方式);
        }
        public void 处理封包(查找对应行会封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.FindCorrespondingGuildPacket(P.行会编号, P.行会名称);
        }
        public void 处理封包(申请加入行会封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请加入行会(P.行会编号, P.GuildName);
        }
        public void 处理封包(查看申请列表封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查看申请列表();
        }
        public void 处理封包(处理入会申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.处理入会申请(P.对象编号, P.处理类型);
        }
        public void 处理封包(处理入会邀请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.处理入会邀请(P.对象编号, P.处理类型);
        }
        public void 处理封包(邀请加入行会封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.邀请加入行会(P.对象名字);
        }
        public void 处理封包(打开宝箱封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }

            this.玩家实例.打开宝箱(P.宝箱编号);
        }
        public void 处理封包(申请创建行会封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请创建行会(P.Data);
        }
        public void 处理封包(申请解散行会封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请解散行会();
        }
        public void 处理封包(捐献行会资金封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.DonateGuildFundsPacket(P.NumberGoldCoins);
        }
        public void 处理封包(发放行会福利封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.发送行会福利();
        }
        public void 处理封包(申请离开行会封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请离开行会();
        }
        public void 处理封包(更改行会公告封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.更改行会公告(P.行会公告);
        }
        public void 处理封包(更改行会宣言封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.更改行会宣言(P.行会宣言);
        }
        public void 处理封包(设置行会禁言封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.设置行会禁言(P.对象编号, P.禁言状态);
        }
        public void 处理封包(变更会员职位封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.变更会员职位(P.对象编号, P.对象职位);
        }
        public void 处理封包(逐出行会成员封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.逐出行会成员(P.对象编号);
        }
        public void 处理封包(转移会长职位封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.转移会长职位(P.对象编号);
        }
        public void 处理封包(申请行会外交封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请行会外交(P.外交类型, P.外交时间, P.GuildName);
        }
        public void 处理封包(申请行会敌对封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请行会敌对(P.敌对时间, P.行会名称);
        }
        public void 处理封包(处理结盟申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.处理结盟申请(P.处理类型, P.行会编号);
        }
        public void 处理封包(申请解除结盟封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请解除结盟(P.行会编号);
        }
        public void 处理封包(申请解除敌对封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.申请解除敌对(P.行会编号);
        }
        public void 处理封包(处理解除敌对申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.处理解除敌对申请(P.行会编号, P.回应类型);
        }
        public void 处理封包(更改存储权限封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(查看结盟申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查看结盟申请();
        }
        public void 处理封包(更多行会事记封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.更多行会事记();
        }
        public void 处理封包(查询行会成就封包 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(开启行会活动封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(发布通缉榜单封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(同步通缉榜单封包 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(发起行会战争封包 P)
        {
            if (this.CurrentStage != 游戏阶段.加载场景 && this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(查询地图路线封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询地图路线();
        }
        public void 处理封包(切换地图路线封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.切换地图路线();
        }
        public void 处理封包(跳过剧情动画封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(更改收徒推送封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.更改收徒推送(P.收徒推送);
        }
        public void 处理封包(查询师门成员封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询师门成员();
        }
        public void 处理封包(查询师门奖励封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询师门奖励();
        }
        public void 处理封包(查询拜师名册 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询拜师名册();
        }
        public void 处理封包(查询收徒名册 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询收徒名册();
        }
        public void 处理封包(祝贺徒弟升级封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(玩家申请拜师封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家申请拜师(P.对象编号);
        }
        public void 处理封包(同意拜师申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.同意拜师申请(P.对象编号);
        }
        public void 处理封包(拒绝拜师申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.拒绝拜师申请(P.对象编号);
        }
        public void 处理封包(玩家申请收徒封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.玩家申请收徒(P.对象编号);
        }
        public void 处理封包(同意收徒申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.同意收徒申请(P.对象编号);
        }
        public void 处理封包(拒绝收徒申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.RejectionApprenticeshipAppPacket(P.对象编号);
        }
        public void 处理封包(逐出师门申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.逐出师门申请(P.对象编号);
        }
        public void 处理封包(离开师门申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.离开师门申请();
        }
        public void 处理封包(提交出师申请封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.提交出师申请();
        }
        public void 处理封包(查询排名榜单封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询排名榜单(P.榜单类型, P.起始位置);
        }
        public void 处理封包(查看演武排名封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(刷新演武挑战封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(开始战场演武封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(进入演武战场封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(跨服武道排名封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(登录寄售平台封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.发送封包(new 社交错误提示
            {
                错误编号 = 12804
            });
        }
        public void 处理封包(查询平台商品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.发送封包(new 社交错误提示
            {
                错误编号 = 12804
            });
        }
        public void 处理封包(查询指定商品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.发送封包(new 社交错误提示
            {
                错误编号 = 12804
            });
        }
        public void 处理封包(上架平台商品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.发送封包(new 社交错误提示
            {
                错误编号 = 12804
            });
        }
        public void 处理封包(查询珍宝商店封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询珍宝商店(P.数据版本);
        }
        public void 处理封包(查询出售信息封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.查询出售信息();
        }
        public void 处理封包(购买珍宝商品封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.购买珍宝商品(P.Id, P.购买数量);
        }
        public void 处理封包(购买每周特惠封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.购买每周特惠(P.礼包编号);
        }
        public void 处理封包(购买玛法特权 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.购买玛法特权(P.特权类型, P.购买数量);
        }
        public void 处理封包(预定玛法特权封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.预定玛法特权(P.特权类型);
        }
        public void 处理封包(领取特权礼包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.玩家实例.领取特权礼包(P.特权类型, P.礼包位置);
        }
        public void 处理封包(玩家每日签到封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在游戏)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(玩家账号登陆封包 P)
        {
            if (this.CurrentStage != 游戏阶段.正在登陆)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
            else if (SystemData.Data.网卡封禁.TryGetValue(P.MacAddress, out DateTime t) && t > MainProcess.CurrentTime)
            {
                this.尝试断开连接(new Exception("网卡封禁，限制登陆。"));
            }
            else if (!NetworkServiceGateway.门票DataSheet.TryGetValue(P.登陆门票, out 门票信息 TicketInformation))
            {
                this.尝试断开连接(new Exception("登录的门票不存在."));
            }
            else if (MainProcess.CurrentTime > TicketInformation.EffectiveTime)
            {
                this.尝试断开连接(new Exception("登录门票已经过期."));
            }
            else
            {
                AccountData AccountData2;
                if (GameDataGateway.AccountData表.Keyword.TryGetValue(TicketInformation.登录账号, out GameData GameData))
                {
                    AccountData AccountData = GameData as AccountData;
                    if (AccountData != null)
                    {
                        AccountData2 = AccountData;
                        goto IL_EF;
                    }
                }
                AccountData2 = new AccountData(TicketInformation.登录账号);
            IL_EF:
                AccountData AccountData3 = AccountData2;
                if (AccountData3.网络连接 != null)
                {
                    AccountData3.网络连接.发送封包(new 登陆错误提示
                    {
                        错误代码 = 260U
                    });
                    AccountData3.网络连接.尝试断开连接(new Exception("账号重复登录, 被踢下线."));
                    this.尝试断开连接(new Exception("账号已经在线, 无法登录."));
                }
                else
                {
                    AccountData3.账号登录(this, P.MacAddress);
                }
            }
            NetworkServiceGateway.门票DataSheet.Remove(P.登陆门票);
        }
        public void 处理封包(玩家创建角色封包 P)
        {
            if (this.CurrentStage != 游戏阶段.选择角色)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.账号数据.创建角色(this, P);
        }
        public void 处理封包(玩家删除角色封包 P)
        {
            if (this.CurrentStage != 游戏阶段.选择角色)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.账号数据.删除角色(this, P);
        }
        public void 处理封包(彻底删除角色封包 P)
        {
            if (this.CurrentStage != 游戏阶段.选择角色)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.账号数据.永久删除(this, P);
        }
        public void 处理封包(玩家进入游戏封包 P)
        {
            if (this.CurrentStage != 游戏阶段.选择角色)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.账号数据.进入游戏(this, P);
        }
        public void 处理封包(玩家找回角色封包 P)
        {
            if (this.CurrentStage != 游戏阶段.选择角色)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.账号数据.找回角色(this, P);
        }
    }
}
