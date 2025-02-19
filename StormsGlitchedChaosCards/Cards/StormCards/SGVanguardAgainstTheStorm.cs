using ClassesManagerReborn;
using ClassesManagerReborn.Util;
using RarityLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.Utils;
using UnityEngine;


namespace StormsGlitchedChaosCards.Cards.StormCards
{
    class SGVanguardAgainstTheStorm : CustomCard
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
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been setup.");
            //block.forceToAdd = -10f;
            //statModifiers.health = 1.2f;
            //block.cdAdd = 0.25f;
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            player.gameObject.GetOrAddComponent<SGLivingStormMono>();
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
            //Edits values on player when card is selected

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {

            Destroy(player.gameObject.GetOrAddComponent<SGLivingStormMono>());
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
            //Run when the card is removed from the player
        }


        protected override string GetTitle()
        {
            return "Vanguard Against The Storm";
        }
        protected override string GetDescription()
        {
            return "";
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
                    stat = "Undecided Buffs ",
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
