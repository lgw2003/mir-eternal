﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using GameServer.Data;

namespace GameServer.Networking
{

    public static class NetworkServiceGateway
    {

        public static void Start()
        {
            网络服务停止 = false;
            网络连接表 = new HashSet<客户网络>();
            等待添加表 = new ConcurrentQueue<客户网络>();
            等待移除表 = new ConcurrentQueue<客户网络>();
            全服公告表 = new ConcurrentQueue<GamePacket>();
            网络监听器 = new TcpListener(IPAddress.Any, (int)Config.GSPort);
            网络监听器.Start();
            网络监听器.BeginAcceptTcpClient(new AsyncCallback(异步连接), null);
            门票DataSheet = new Dictionary<string, 门票信息>();
            门票接收器 = new UdpClient(new IPEndPoint(IPAddress.Any, (int)Config.TSPort));
        }


        public static void Stop()
        {
            网络服务停止 = true;
            TcpListener tcpListener = 网络监听器;
            if (tcpListener != null)
            {
                tcpListener.Stop();
            }
            网络监听器 = null;
            UdpClient udpClient = 门票接收器;
            if (udpClient != null)
            {
                udpClient.Close();
            }
            门票接收器 = null;
        }


        public static void 处理数据()
        {
            try
            {
                while (true)
                {
                    if (门票接收器 == null || 门票接收器.Available == 0)
                        break;

                    byte[] bytes = 门票接收器.Receive(ref 门票发送端);
                    string[] array = Encoding.UTF8.GetString(bytes).Split(';');
                    if (array.Length == 2)
                    {
                        门票DataSheet[array[0]] = new 门票信息
                        {
                            登录账号 = array[1],
                            EffectiveTime = MainProcess.CurrentTime.AddMinutes(5.0)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MainProcess.AddSystemLog("接收登录门票时发生错误. " + ex.Message);
            }

            foreach (var 客户网络 in 网络连接表)
            {
                if (!客户网络.正在断开 && 客户网络.账号数据 == null && MainProcess.CurrentTime.Subtract(客户网络.接入时间).TotalSeconds > 30.0)
                {
                    客户网络.尝试断开连接(new Exception("Login timeout, disconnect!"));
                }
                else
                {
                    客户网络.处理数据();
                }
            }

            while (等待移除表.TryDequeue(out var item))
                网络连接表.Remove(item);

            while (等待添加表.TryDequeue(out 客户网络 item2))
                网络连接表.Add(item2);

            while (全服公告表.TryDequeue(out GamePacket 封包))
            {
                foreach (客户网络 客户网络2 in 网络连接表)
                {
                    if (客户网络2.玩家实例 != null)
                    {
                        客户网络2.发送封包(封包);
                    }
                }
            }
        }


        public static void 异步连接(IAsyncResult 异步参数)
        {
            try
            {
                if (网络服务停止)
                {
                    return;
                }
                TcpClient tcpClient = 网络监听器.EndAcceptTcpClient(异步参数);
                string text = tcpClient.Client.RemoteEndPoint.ToString().Split(new char[]
                {
                    ':'
                })[0];
                if (SystemData.Data.网络封禁.ContainsKey(text) && !(SystemData.Data.网络封禁[text] < MainProcess.CurrentTime))
                {
                    tcpClient.Client.Close();
                }
                else if (网络连接表.Count < 10000)
                {
                    ConcurrentQueue<客户网络> concurrentQueue = 等待添加表;
                    if (concurrentQueue != null)
                    {
                        concurrentQueue.Enqueue(new 客户网络(tcpClient));
                    }
                }
                goto IL_CA;
            }
            catch (Exception ex)
            {
                MainProcess.AddSystemLog("异步连接异常: " + ex.ToString());
                goto IL_CA;
            }
        IL_B6:
            if (网络连接表.Count <= 100)
            {
                goto IL_D1;
            }
            Thread.Sleep(1);
        IL_CA:
            if (!网络服务停止)
            {
                goto IL_B6;
            }
        IL_D1:
            if (!网络服务停止)
            {
                网络监听器.BeginAcceptTcpClient(new AsyncCallback(异步连接), null);
            }
        }


        public static void 断网回调(object sender, Exception e)
        {
            客户网络 客户网络 = sender as 客户网络;
            string text = "IP: " + 客户网络.网络地址;
            if (客户网络.账号数据 != null)
            {
                text = text + " Account: " + 客户网络.账号数据.Account.V;
            }
            if (客户网络.玩家实例 != null)
            {
                text = text + " Character: " + 客户网络.玩家实例.ObjectName;
            }
            text = text + " Info: " + e.Message;
            MainProcess.AddSystemLog(text);
        }


        public static void 屏蔽网络(string 地址)
        {
            SystemData.Data.BanIPCommand(地址, MainProcess.CurrentTime.AddMinutes((double)Config.AbnormalBlockTime));
        }


        public static void SendAnnouncement(string 内容, bool 滚动播报 = false)
        {
            using (MemoryStream memoryStream = new())
            {
                using BinaryWriter binaryWriter = new(memoryStream);
                binaryWriter.Write(0);
                binaryWriter.Write(滚动播报 ? 2415919106U : 2415919107U);
                binaryWriter.Write(滚动播报 ? 2 : 3);
                binaryWriter.Write(0);
                binaryWriter.Write(Encoding.UTF8.GetBytes(内容 + "\0"));
                发送封包(new 接收聊天消息
                {
                    字节描述 = memoryStream.ToArray()
                });
            }
            MainForm.AddSystemLog(内容);
        }


        public static void 发送封包(GamePacket 封包)
        {
            if (封包 != null)
            {
                ConcurrentQueue<GamePacket> concurrentQueue = 全服公告表;
                if (concurrentQueue == null)
                {
                    return;
                }
                concurrentQueue.Enqueue(封包);
            }
        }


        public static void 添加网络(客户网络 网络)
        {
            if (网络 != null)
            {
                等待添加表.Enqueue(网络);
            }
        }


        public static void Disconnected(客户网络 网络)
        {
            if (网络 != null)
            {
                等待移除表.Enqueue(网络);
            }
        }


        private static IPEndPoint 门票发送端;


        private static UdpClient 门票接收器;


        private static TcpListener 网络监听器;


        public static bool 网络服务停止;


        public static bool 未登录连接数;


        public static uint ActiveConnections;


        public static uint ConnectionsOnline;


        public static long SendedBytes;


        public static long ReceivedBytes;


        public static HashSet<客户网络> 网络连接表;


        public static ConcurrentQueue<客户网络> 等待移除表;


        public static ConcurrentQueue<客户网络> 等待添加表;


        public static ConcurrentQueue<GamePacket> 全服公告表;


        public static Dictionary<string, 门票信息> 门票DataSheet;
    }
}
