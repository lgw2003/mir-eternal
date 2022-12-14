﻿using System;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer
{

  public sealed class AddItems : GMCommand
  {

    public override ExecutionWay ExecutionWay
    {
      get
      {
        return ExecutionWay.优先后台执行;
      }
    }


    public override void Execute()
    {
      GameData GameData;
      if (GameDataGateway.角色数据表.Keyword.TryGetValue(this.CharName, out GameData))
      {
        CharacterData CharacterData = GameData as CharacterData;
        if (CharacterData != null)
        {
          游戏物品 游戏物品;
          if (!游戏物品.DataSheetByName.TryGetValue(this.Name, out 游戏物品))
          {
            MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, item does not exist");
            return;
          }
          if (CharacterData.Backpack.Count >= (int)CharacterData.BackpackSize.V)
          {
            MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, character's bag is full");
            return;
          }
          if (游戏物品.物品持久 == 0)
          {
            MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, cannot AddItemsCommand");
            return;
          }

          if (CharacterData.TryGetFreeSpaceAtInventory(out byte b))
          {
            装备物品 游戏装备 = 游戏物品 as 装备物品;
            if (游戏装备 != null)
            {
              CharacterData.Backpack[b] = new EquipmentData(游戏装备, CharacterData, 1, b, true);
            }
            else if (游戏物品.持久类型 == PersistentItemType.容器)
            {
              CharacterData.Backpack[b] = new ItemData(游戏物品, CharacterData, 1, b, 0);
            }
            else if (游戏物品.持久类型 == PersistentItemType.堆叠)
            {
              CharacterData.Backpack[b] = new ItemData(游戏物品, CharacterData, 1, b, 1);
            }
            else
            {
              CharacterData.Backpack[b] = new ItemData(游戏物品, CharacterData, 1, b, 游戏物品.物品持久);
            }

            if (Quantity > 1)
              CharacterData.Backpack[b].当前持久.V = Quantity;

            客户网络 网络连接 = CharacterData.ActiveConnection;
            if (网络连接 != null)
            {
              网络连接.发送封包(new 玩家物品变动
              {
                物品描述 = CharacterData.Backpack[b].字节描述()
              });
            }
            MainForm.AddCommandLog("<= @" + base.GetType().Name + " The command has been executed and the item has been added to the character's bag");
            return;
          }
          //goto IL_F4;
        }
      }
      MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
    }


    public AddItems()
    {


    }


    [Field(0)]
    public string CharName;


    [Field(1)]
    public string Name;

    [Field(2, IsOptional = true)]
    public short Quantity;
  }
}
