using ModdingUtils.Utils;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.Utils;
using UnityEngine;
using ClassesManagerReborn.Util;
using RarityLib.Utils;


namespace StormsGlitchedChaosCards.Cards.StormCards
{
    class SeedofaStorm : CustomCard
    {
        public static CardInfo? Card = null;
        internal static CardInfo card = null!;
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>();
        }
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //cardInfo.allowMultiple = false;
            //statModifiers.movementSpeed = 1.35f;
            //gun.damage = 0.9f;
            cardInfo.allowMultiple = false;
            cardInfo.categories = (CardCategory[])(object)new CardCategory[1] { SGCC.SGCCCards };
            cardInfo.categories = (CardCategory[])(object)new CardCategory[1] { SGCC.gambitCategory };
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {

            
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been removed to player {player.playerID}.");
        }
        protected override string GetTitle()
        {
            return "Seed of a Storm";
        }
        protected override string GetDescription()
        {
            return "Should you take this, a Seed of a Storm will become part of your very being. Beware, your body could reject The Seed yet, the path ahead is lies The Heart...";
        }
        protected override GameObject? GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common; ;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                   new CardInfoStat()
                    {
                        positive = true,
                        stat = "Health",
                        amount = "+20%",
                        simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                    },
                    new CardInfoStat()
                    {
                        positive = false,
                        stat = "Block Cooldown",
                        amount = "+0.25s",
                        simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                    }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.PoisonGreen;
        }
        public override string GetModName()
        {
            return SGCC.ModInitials;
        }
    }
}


        