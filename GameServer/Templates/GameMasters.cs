using Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    /// <summary>
    /// 游戏管理员
    /// </summary>
    public class GameMasters
    {
        public static Dictionary<string, GameMasters> DataSheet;

        public string CharacterName { get; set; }
        public GameMasterLevel Level { get; set; }


        public static void LoadData()
        {
            DataSheet = new Dictionary<string, GameMasters>();
            string text = Config.GameDataPath + "\\System\\GameMasters.json";
            if (File.Exists(text))
            {
                var content = File.ReadAllText(text, Encoding.UTF8);
                var data = JsonConvert.DeserializeObject<GameMasters[]>(content);

                foreach (var gm in data)
                    DataSheet.Add(gm.CharacterName.ToLowerInvariant(), gm);
            }
        }

        /// <summary>
        /// 根据角色名称获取GM等级
        /// </summary>
        /// <param name="characterName">角色名称</param>
        /// <returns></returns>
        public static GameMasterLevel GetGMLevel(string characterName)
        {
            if (DataSheet.TryGetValue(characterName.ToLowerInvariant(), out var gm))
                return gm.Level;

            return GameMasterLevel.Player;
        }
    }
}
