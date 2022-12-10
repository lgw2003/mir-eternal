using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    /// <summary>
    /// 游戏地形
    /// </summary>
    public sealed class Terrains
    {
        public static Dictionary<byte, Terrains> DataSheet;

        public byte 地图编号;
        public string 地图名字;
        public Point 地图起点;
        public Point 地图终点;
        public Point 地图大小;
        public Point 地图高度;
        public uint[,] 点阵数据;

        /// <summary>
        /// 加载地形文件数据
        /// </summary>
        /// <param name="fileInfo">地图文件信息</param>
        /// <returns></returns>
        private static Terrains LoadTerrainFromFile(FileSystemInfo fileInfo)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.Name);
            var parts = fileNameWithoutExtension.Split('-');

            var terrain = new Terrains
            {
                地图名字 = parts[1],
                地图编号 = Convert.ToByte(parts[0])
            };

            using (var ms = new MemoryStream(File.ReadAllBytes(fileInfo.FullName)))
            {
                using var br = new BinaryReader(ms);

                terrain.地图起点 = new Point(br.ReadInt32(), br.ReadInt32());
                terrain.地图终点 = new Point(br.ReadInt32(), br.ReadInt32());
                terrain.地图大小 = new Point(terrain.地图终点.X - terrain.地图起点.X, terrain.地图终点.Y - terrain.地图起点.Y);
                terrain.地图高度 = new Point(br.ReadInt32(), br.ReadInt32());
                terrain.点阵数据 = new uint[terrain.地图大小.X, terrain.地图大小.Y];

                for (int i = 0; i < terrain.地图大小.X; i++)
                {
                    for (int j = 0; j < terrain.地图大小.Y; j++)
                    {
                        terrain.点阵数据[i, j] = br.ReadUInt32();
                    }
                }
            }

            return terrain;
        }

        /// <summary>
        /// 加载地形数据
        /// </summary>
        public static void LoadData()
        {
            DataSheet = new Dictionary<byte, Terrains>();
            string path = Config.GameDataPath + "\\System\\游戏地图\\地形数据\\";
            if (Directory.Exists(path))
            {
                var terrains = new ConcurrentBag<Terrains>();
                var terrainFiles = new DirectoryInfo(path).GetFiles("*.terrain");

                Parallel.ForEach(terrainFiles, delegate (FileInfo x)
                {
                    var terrain = LoadTerrainFromFile(x);
                    terrains.Add(terrain);
                });

                foreach (var terrain in terrains)
                    DataSheet.Add(terrain.地图编号, terrain);
            }
        }


        public uint this[Point 坐标]
        {
            get
            {
                return this.点阵数据[坐标.X - this.地图起点.X, 坐标.Y - this.地图起点.Y];
            }
        }
    }
}
