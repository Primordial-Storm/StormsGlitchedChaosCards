﻿using ClassesManagerReborn;
using ClassesManagerReborn.Util;
using RarityLib.Utils;
using StormsGlitchedChaosCards.Cards.StormCards;
using StormsGlitchedChaosCards;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.Utils;
using UnityEngine;


namespace StormsGlitchedChaosCards.Cards.StormCards
{
    class SGLivingStorm : CustomCard
    {
        internal static CardInfo card;
        public static CardInfo Card = null;
        public override void Callback()
        {
            // Declares this card as part of the Seed of a Storm class
            gameObject.GetOrAddComponent<ClassNameMono>().className = SeedofaStormClass.name;
        }
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.categories = (CardCategory[])(object)new CardCategory[1] { SGCC.SGCCCards };
            cardInfo.categories = (CardCategory[])(object)new CardCategory[1] { SGCC.gambitCategory };
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been setup.");
           // block.forceToAdd = -10f;
            //statModifiers.health = 1.2f;
            //block.cdAdd = 0.25f;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player

            
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }


        protected override string GetTitle()
        {
            return "Living Storm";
        }
        protected override string GetDescription()
        {
            return "Your body has become like that of storm";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                //Undecided Buffs
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Undecided Buffs",
                    amount = "+20%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return SGCC.ModInitials;
        }
    }
}


    
   