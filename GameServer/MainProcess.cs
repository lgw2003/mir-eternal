using GameServer.Data;
using GameServer.Maps;
using GameServer.Networking;
using GameServer.Properties;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace GameServer
{
  public static class MainProcess
  {
    public static DateTime CurrentTime;
    public static DateTime NextUpdateLoopCountsTime;
    public static DateTime NextSaveDataTime;
    public static ConcurrentQueue<GMCommand> CommandsQueue;
    public static uint LoopCount;
    public static bool Running;
    public static bool Saving;
    public static Thread MainThread;
    public static Random RandomNumber;

    public static ConcurrentQueue<Action> ReloadTasks = new ConcurrentQueue<Action>();
    public static DateTime NextReloadTaskTime;

    static MainProcess()
    {
      CurrentTime = DateTime.Now;
      NextUpdateLoopCountsTime = DateTime.Now.AddSeconds(1.0);
      RandomNumber = new Random();
    }

    public static void Start()
    {
      if (!Running)
      {
        Thread thread = new(new ThreadStart(MainLoop))
        {
          IsBackground = true
        };
        MainThread = thread;
        thread.Start();
      }
    }

    public static void Stop()
    {
      Running = false;
      网络服务网关.停止服务();
    }

    public static void AddSystemLog(string text)
    {
      MainForm.添加系统日志(text);
    }

    public static void AddChatLog(string preffix, byte[] text)
    {
      MainForm.添加聊天日志(preffix, text);
    }

    private static void MainLoop()
    {
      CommandsQueue = new ConcurrentQueue<GMCommand>();
      MainForm.添加系统日志("正在生成游戏地图...");
      MapGatewayProcess.Start();
      MainForm.添加系统日志("正在启动网络服务...");
      网络服务网关.Start();
      MainForm.添加系统日志("服务器已成功启动...");
      Running = true;
      MainForm.服务启动回调();
      var sw = new Stopwatch();

      while (true)
      {
        if (!Running)
        {
          if (网络服务网关.网络连接表.Count == 0)
            break;
        }
        try
        {
          sw.Reset();

          CurrentTime = DateTime.Now;
          自动保存数据();
          ProcessServerStats();
          ProcessGMCommands();
          网络服务网关.处理数据();
          MapGatewayProcess.Process();
          ProcessReloadTasks();
          sw.Stop();

          if (sw.ElapsedMilliseconds <= 2)
            Thread.Sleep(1);
        }
        catch (Exception ex)
        {
          GameDataGateway.SaveData();
          GameDataGateway.CleanUp();
          MainForm.添加系统日志("发生了致命错误，服务器即将停止");
          if (!Directory.Exists(".\\Log\\Error"))
            Directory.CreateDirectory(".\\Log\\Error");
          File.WriteAllText(string.Format(".\\Log\\Error\\{0:yyyy-MM-dd--HH-mm-ss}.txt", DateTime.Now), "错误信息:\r\n" + ex.Message + "\r\nStack information:\r\n" + ex.StackTrace);
          MainForm.添加系统日志("错误已保存到日志中，请注意");
          ClearConnections();
          break;
        }
      }

      MainForm.添加系统日志("清理游戏临时物品数据...");
      MapGatewayProcess.CleanUp();
      MainForm.添加系统日志("保存用户数据并备份...");
      GameDataGateway.CleanUp();
      MainForm.服务停止回调();
      MainThread = null;
      MainForm.添加系统日志("服务器已经关闭成功");
    }

    private static void ProcessReloadTasks()
    {
      if (CurrentTime > NextReloadTaskTime && ReloadTasks.TryDequeue(out var action))
      {
        action();

        if (ReloadTasks.Count == 0)
        {
          网络服务网关.发送公告("服务器数据重载成功！！！", true);
        }
        else
        {
          NextReloadTaskTime = CurrentTime.AddMilliseconds(500);
        }
      }
    }

    private static void ClearConnections()
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
    }

    private static void ProcessGMCommands()
    {
      while (CommandsQueue.TryDequeue(out GMCommand GMCommand))
        GMCommand.Execute();
    }

    private static void ProcessServerStats()
    {
      if (CurrentTime > NextUpdateLoopCountsTime)
      {
        MainForm.更新连接总数((uint)网络服务网关.网络连接表.Count);
        MainForm.更新已登陆数(网络服务网关.已登陆连接数);
        MainForm.更新已经上线(网络服务网关.已上线连接数);
        MainForm.更新发送字节(网络服务网关.已发送字节数);
        MainForm.更新接收字节(网络服务网关.已接收字节数);
        MainForm.更新对象统计(MapGatewayProcess.ActiveObjects.Count, MapGatewayProcess.SecondaryObjects.Count, MapGatewayProcess.Objects.Count);
        MainForm.更新后台帧数(LoopCount);
        LoopCount = 0U;
        NextUpdateLoopCountsTime = CurrentTime.AddSeconds(1.0);
      }
      else
      {
        LoopCount += 1U;
      }
    }

    private static void 自动保存数据()
    {
      if (NextSaveDataTime > CurrentTime) return;
      GameDataGateway.SaveData();
      GameDataGateway.CleanUp();
      NextSaveDataTime = CurrentTime.AddSeconds(Settings.Default.数据保存间隔);
      MainForm.添加系统日志("玩家数据保存成功!");
    }
  }
}
