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
      NetworkServiceGateway.Stop();
    }

    public static void AddSystemLog(string text)
    {
      MainForm.AddSystemLog(text);
    }

    public static void AddChatLog(string preffix, byte[] text)
    {
      MainForm.AddChatLog(preffix, text);
    }

    private static void MainLoop()
    {
      CommandsQueue = new ConcurrentQueue<GMCommand>();
      MainForm.AddSystemLog("正在生成游戏地图...");
      MapGatewayProcess.Start();
      MainForm.AddSystemLog("正在启动网络服务...");
      NetworkServiceGateway.Start();
      MainForm.AddSystemLog("服务器已成功启动...");
      Running = true;
      MainForm.ServerStartedCallback();
      var sw = new Stopwatch();

      while (true)
      {
        if (!Running)
        {
          if (NetworkServiceGateway.网络连接表.Count == 0)
            break;
        }
        try
        {
          sw.Reset();

          CurrentTime = DateTime.Now;
          自动保存数据();
          ProcessServerStats();
          ProcessGMCommands();
          NetworkServiceGateway.处理数据();
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
          MainForm.AddSystemLog("A fatal error has occurred and the server is about to stop");
          if (!Directory.Exists(".\\Log\\Error"))
            Directory.CreateDirectory(".\\Log\\Error");
          File.WriteAllText(string.Format(".\\Log\\Error\\{0:yyyy-MM-dd--HH-mm-ss}.txt", DateTime.Now), "Error message:\r\n" + ex.Message + "\r\nStack information:\r\n" + ex.StackTrace);
          MainForm.AddSystemLog("Error has been saved to the log, please note");
          ClearConnections();
          break;
        }
      }

      MainForm.AddSystemLog("清理游戏临时物品数据...");
      MapGatewayProcess.CleanUp();
      MainForm.AddSystemLog("保存用户数据并备份...");
      GameDataGateway.CleanUp();
      MainForm.Stop();
      MainThread = null;
      MainForm.AddSystemLog("服务器已经关闭成功");
    }

    private static void ProcessReloadTasks()
    {
      if (CurrentTime > NextReloadTaskTime && ReloadTasks.TryDequeue(out var action))
      {
        action();

        if (ReloadTasks.Count == 0)
        {
          NetworkServiceGateway.SendAnnouncement("服务器数据重载成功！！！", true);
        }
        else
        {
          NextReloadTaskTime = CurrentTime.AddMilliseconds(500);
        }
      }
    }

    private static void ClearConnections()
    {
      foreach (客户网络 connection in NetworkServiceGateway.网络连接表)
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
        MainForm.UpdateTotalConnections((uint)NetworkServiceGateway.网络连接表.Count);
        MainForm.UpdateAlreadyLogged(NetworkServiceGateway.ActiveConnections);
        MainForm.UpdateConnectionsOnline(NetworkServiceGateway.ConnectionsOnline);
        MainForm.UpdateSendedBytes(NetworkServiceGateway.SendedBytes);
        MainForm.UpdateReceivedBytes(NetworkServiceGateway.ReceivedBytes);
        MainForm.UpdateObjectStatistics(MapGatewayProcess.ActiveObjects.Count, MapGatewayProcess.SecondaryObjects.Count, MapGatewayProcess.Objects.Count);
        MainForm.UpdateLoopCount(LoopCount);
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
      MainForm.AddSystemLog("玩家数据保存成功!");
    }
  }
}
