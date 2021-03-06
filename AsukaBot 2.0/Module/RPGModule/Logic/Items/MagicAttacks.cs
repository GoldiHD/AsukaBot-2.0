﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsukaBot_2._0.Module.RPGModule.Logic.Items
{
    public class MagicAttacks : BaseItem
    {
        private int Damage;
        private MagicDamgeType AttackType;
        private SpellTier SpellLvl;
        private int MagicLvlReqiurement;

        public MagicAttacks(string name, string spelldescribe, int damage, MagicDamgeType attackType, SpellTier spellLvl, int magiclvlrequrements, int price, bool buyable, List<ItemType> itemTags, int itemvalue, bool questitem, Rarity rare)
        {
            Name = name;
            ItemDescribe = spelldescribe;
            Damage = damage;
            AttackType = attackType;
            SpellLvl = spellLvl;
            Price = price;
            Buyable = buyable;
            MyItemType = itemTags;
            ItemValue = itemvalue;
            QuestItem = questitem;
            MyRare = rare;
            MagicLvlReqiurement = magiclvlrequrements;
        }


        public Attack attack()
        {
            return new Attack();
        }

        public int GetDamage()
        {
            return Damage;
        }

    }

    public enum SpellTier
    {
        I, II, III, IV, V, VI, VII, VIII, IX, X
    }
}
