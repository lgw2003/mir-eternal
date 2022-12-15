using GameServer.Data;
using GameServer.Networking;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandMake : PlayerCommand
    {
        [Field(Position = 0)]
        public string ItemName;

        [Field(Position = 1, IsOptional = true)]
        public int Qty = 1;

        public override void Execute()
        {
            if (!游戏物品.DataSheetByName.TryGetValue(ItemName, out var itemTemplate))
            {
                Player.SendMessage("Item does not exist");
                return;
            }

            if (Qty > Player.BackpackSizeAvailable)
            {
                Player.SendMessage("Your bag is full");
                return;
            }

            if (itemTemplate.物品持久 == 0)
            {
                Player.SendMessage("This item can not be maked");
                return;
            }

            if (!Player.CharacterData.查找背包空位(out byte b))
            {
                Player.SendMessage("Your bag is full");
                return;
            }

            Player.GainItem(itemTemplate, b, Qty);
            MainForm.添加系统日志(string.Format("Player [{0}] @make [{1}] [{2}]", Player.ObjectName, ItemName, Qty));
        }
    }
}
