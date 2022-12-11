using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
    /// <summary>
    /// 珍宝商品
    /// </summary>
    public sealed class 珍宝商品
    {
        public static byte[] 珍宝商店数据;
        public static int 珍宝商店效验;
        public static int 珍宝商品数量;
        public static Dictionary<int, 珍宝商品> DataSheet;

        public int 物品编号;
        public int 单位数量;
        public byte 商品分类;
        public byte 商品标签;
        public byte 补充参数;
        public int 商品原价;
        public int 商品现价;
        public byte 买入绑定;

        public static void LoadData()
        {
            DataSheet = new Dictionary<int, 珍宝商品>();
            string text = Config.GameDataPath + "\\System\\物品数据\\珍宝商品\\";
            if (Directory.Exists(text))
            {
                foreach (var obj in Serializer.Deserialize<珍宝商品>(text))
                    DataSheet.Add(obj.物品编号, obj);
            }

            using var memoryStream = new MemoryStream();
            using var binaryWriter = new BinaryWriter(memoryStream);

            var sortedTreasures = (from X in DataSheet.Values.ToList()
                                   orderby X.物品编号
                                   select X).ToList();

            foreach (珍宝商品 treasure in sortedTreasures)
            {
                binaryWriter.Write(treasure.物品编号);
                binaryWriter.Write(treasure.单位数量);
                binaryWriter.Write(treasure.商品分类);
                binaryWriter.Write(treasure.商品标签);
                binaryWriter.Write(treasure.补充参数);
                binaryWriter.Write(treasure.商品原价);
                binaryWriter.Write(treasure.商品现价);
                binaryWriter.Write(new byte[48]);
            }

            珍宝商品数量 = DataSheet.Count;
            珍宝商店数据 = memoryStream.ToArray();
            珍宝商店效验 = 0;

            foreach (byte b in 珍宝商店数据)
                珍宝商店效验 += b;
        }
    }
}
