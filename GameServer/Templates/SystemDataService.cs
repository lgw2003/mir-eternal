using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameServer.Templates
{
    public static class SystemDataService
    {

        public static void LoadData()
        {
            var types = new Type[]
            {
                typeof(随机属性),
                typeof(游戏怪物),
                typeof(地图守卫),
                typeof(对话数据),
                typeof(游戏地图),
                typeof(地形数据),
                typeof(地图区域),
                typeof(传送法阵),
                typeof(怪物刷新),
                typeof(守卫刷新),
                typeof(游戏物品),
                typeof(游戏商店),
                typeof(珍宝商品),
                typeof(游戏称号),
                typeof(铭文技能),
                typeof(游戏技能),
                typeof(技能陷阱),
                typeof(游戏Buff),
                typeof(出生物品),
                typeof(宝箱数据),
                typeof(宝箱刷新),
                typeof(游戏任务),
                typeof(游戏坐骑),
                typeof(游戏成就),
                typeof(GameMasters),
                typeof(装备属性)
                
            };

            Parallel.ForEach(types, (type) =>
            {
                LoadDataType(type);
            });
        }

        public static void ReloadData()
        {
            var types = new Type[]
           {
                typeof(随机属性),
                typeof(游戏怪物),
                typeof(地图守卫),
                typeof(对话数据),
                typeof(传送法阵),
                typeof(怪物刷新),
                typeof(守卫刷新),
                typeof(游戏物品),
                typeof(游戏商店),
                typeof(珍宝商品),
                typeof(游戏称号),
                typeof(铭文技能),
                typeof(游戏技能),
                typeof(技能陷阱),
                typeof(游戏Buff),
                typeof(出生物品),
                typeof(宝箱数据),
                typeof(宝箱刷新),
                typeof(游戏任务),
                typeof(游戏坐骑),
                typeof(游戏成就),
                typeof(GameMasters),
                typeof(装备属性)
           };

            foreach (var type in types)
                MainProcess.ReloadTasks.Enqueue(() => LoadDataType(type));
        }

        public static void LoadDataType(Type type)
        {
            var watcher = new Stopwatch();

            MethodInfo method = type.GetMethod("LoadData", BindingFlags.Static | BindingFlags.Public);

            if (method != null)
            {
                watcher.Start();
                method.Invoke(null, null);
                watcher.Stop();
            }
            else
            {
                MainForm.添加系统日志(type.Name + " Failed to find 'LoadData' method, Failed to load");
                return;
            }

            FieldInfo field = type.GetField("DataSheet", BindingFlags.Static | BindingFlags.Public);
            if (field == null)
            {
                MainForm.添加系统日志(type.Name + " Failed to find 'DataSheet' property, Failed to load");
                return;
            }

            object obj = field.GetValue(null);
            if (obj == null)
            {
                MainForm.添加系统日志(type.Name + " Failed to load content, Check data directory");
                return;
            }

            PropertyInfo property = obj.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public);
            if (property == null)
            {
                MainForm.添加系统日志(type.Name + " Failed to find 'Count' property, Failed to load");
                return;
            }

            int num = (int)property.GetValue(obj);
            MainForm.添加系统日志(string.Format("{0} 数据加载完成, 总计: {1}条, 用时: {2}毫秒", type.Name, num, watcher.ElapsedMilliseconds));
        }
    }
}
