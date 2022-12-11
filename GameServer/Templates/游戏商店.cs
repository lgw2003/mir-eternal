using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameServer.Data;

namespace GameServer.Templates
{
    /// <summary>
    /// 游戏商店
    /// </summary>
    public sealed class 游戏商店
    {
        public static byte[] 商店文件数据;
        public static int 商店文件效验;
        public static int 商店物品数量;
        public static int 商店回购排序;
        public static Dictionary<int, 游戏商店> DataSheet;

        public int 商店编号;
        public string 商店名字;
        public ItemsForSale 回收类型;
        public List<GameStoreItem> 商品列表;
        public SortedSet<ItemData> 回购列表 = new SortedSet<ItemData>(new 回购排序());

        public static void LoadData()
        {
            DataSheet = new Dictionary<int, 游戏商店>();
            string text = Config.GameDataPath + "\\System\\物品数据\\游戏商店\\";
            if (Directory.Exists(text))
            {
                foreach (var obj in Serializer.Deserialize<游戏商店>(text))
                    DataSheet.Add(obj.商店编号, obj);
            }

            using (MemoryStream memoryStream = new MemoryStream())
            using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
            {
                var items = (from X in DataSheet.Values.ToList()
                             orderby X.商店编号
                             select X).ToList();

                foreach (游戏商店 store in items)
                {
                    foreach (GameStoreItem product in store.商品列表)
                    {
                        var name = Encoding.UTF8.GetBytes(store.商店名字);

                        binaryWriter.Write(store.商店编号);
                        binaryWriter.Write(name);
                        binaryWriter.Write(new byte[64 - name.Length]);
                        binaryWriter.Write(product.商品编号);
                        binaryWriter.Write(product.单位数量);
                        binaryWriter.Write(product.货币类型);
                        binaryWriter.Write(product.商品价格);
                        binaryWriter.Write(-1);
                        binaryWriter.Write(0);
                        binaryWriter.Write(-1);
                        binaryWriter.Write(0);
                        binaryWriter.Write(0);
                        binaryWriter.Write(0);
                        binaryWriter.Write((int)store.回收类型);
                        binaryWriter.Write(0);
                        binaryWriter.Write(0);
                        binaryWriter.Write((ushort)0);
                        binaryWriter.Write(-1);
                        binaryWriter.Write(-1);
                        商店物品数量++;
                    }
                }

                var buffer = memoryStream.ToArray();

                商店文件数据 = Serializer.Compress(buffer);

                商店文件效验 = 0;

                foreach (byte b in 游戏商店.商店文件数据)
                    商店文件效验 += (int)b;
            }
        }

        public bool BuyItem(ItemData item)
        {
            return this.回购列表.Remove(item);
        }

        public void SellItem(ItemData item)
        {
            item.PurchaseId = ++商店回购排序;
            if (this.回购列表.Add(item) && this.回购列表.Count > 50)
            {
                ItemData ItemData = this.回购列表.Last<ItemData>();
                this.回购列表.Remove(ItemData);
                ItemData.Delete();
            }
        }
    }
}
