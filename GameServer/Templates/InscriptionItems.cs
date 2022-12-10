using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    /// <summary>
    /// 出生物品
    /// </summary>
    public class InscriptionItems
    {
        public static Dictionary<byte, InscriptionItems> DataSheet;
        public static InscriptionItems[] 所有出生物品;

        public byte Id;
        public ItemBackPack 角色背包;
        public GameObjectRace[] 需要职业 = new GameObjectRace[0];
        public GameObjectGender? 需要性别;
        public ushort? 数量;
        public int 物品编号;

        public static void LoadData()
        {
            DataSheet = new Dictionary<byte, InscriptionItems>();
            string path = Config.GameDataPath + "\\System\\物品数据\\出生物品\\";
            所有出生物品 = Serializer.Deserialize<InscriptionItems>(path);
            foreach (var inscriptionItem in 所有出生物品)
                DataSheet.Add(inscriptionItem.Id, inscriptionItem);
        }
    }
}
