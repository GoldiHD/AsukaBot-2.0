﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsukaBot_2._0.Module.RPGModule.Logic.Items
{
    public class CraftingItem : BaseItem
    {
        private string Location;
        public CraftingItem(string name, string itemdescribe, int price, bool buyable, Rarity rare, List<ItemType> itemDefine)
        {
            Name = name;
            ItemDescribe = itemdescribe;
            Price = price;
            Buyable = buyable;
            MyRare = rare;
            MyItemType = itemDefine;
        }

        public CraftingItem(CraftingItem me)
        {

        }
    }

    public class CraftingItemInItem
    {
        private CraftingItem Item;
        private int Amount;

        public CraftingItemInItem(CraftingItem item, int amount)
        {
            Item = item;
            Amount = amount;
        }

        public int GetAmount()
        {
            return Amount;
        }

        public CraftingItem GetItem()
        {
            return Item;
        }
    }

}
