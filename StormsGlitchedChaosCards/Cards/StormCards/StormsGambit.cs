using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using ModdingUtils.Extensions;
using ModdingUtils.Utils;
using Photon.Pun.Simple;
using StormsGlitchedChaosCards;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.Networking;
using UnboundLib.Utils;
using UnityEngine;


using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using BepInEx;
using UnboundLib.GameModes;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;
using ModdingUtils.MonoBehaviours;
using ModsPlus;
using StormsGlitchedChaosCards.Cards;
using ModdingUtils;
using Photon.Realtime;
using System.ComponentModel.Design;
using ClassesManagerReborn;
using ClassesManagerReborn.Util;
using RarityLib.Utils;


namespace StormsGlitchedChaosCards.Cards.StormCards
{
    class StormsGambit : CustomCard
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
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} Built");

            ModdingUtils.Extensions.CardInfoExtension.GetAdditionalData(cardInfo).canBeReassigned = false;

            
            cardInfo.categories = (CardCategory[])(object)new CardCategory[1] { SGCC.SGCCCards };
            //cardInfo.categories = (CardCategory[])(object)new CardCategory[1] { SGCC.gambitCategory };
            

            //block.forceToAdd = -10f;
            //statModifiers.health = 1.2f;
            //block.cdAdd = 0.25f;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
            SGCC.instance.ExecuteAfterFrames(5, () =>
            {
                StormsGambit_mono.Picked(player);
            });
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {

           
            //Run when the card is removed from the player
            SGCC.instance.DebugLog($"[{SGCC.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }
        protected override string GetTitle()
        {
            return "Storm's Gambit";
        }
        protected override string GetDescription()
        {
            return "Have you ever tried gambling before? No? Good! Because this totally is not that!";
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
                //left blank
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
        public class StormsGambit_mono : MonoBehaviour
        {
            public static void Picked(Player player)
            {
                CardInfo[] availableCards = UnboundLib.Utils.CardManager.cards.Values.Where(card => card.enabled).Select(card => card.cardInfo).Where(cardInfo => ModdingUtils.Utils.Cards.instance.PlayerIsAllowedCard(player, cardInfo) && (cardInfo != StormsGambit.card) && (cardInfo.categories.Contains(SGCC.gambitCategory))).ToArray();
                List<CardInfo> newCards = new List<CardInfo>();
                SGCC.instance.DebugLog($"Player {player.playerID} has a total of {availableCards.Length} available cards");


                for (int i = 0; i < 1; i++)
                {
                    CardInfo newCard = null;
                    SGCC.instance.DebugLog($"Player {player.playerID} has a total of {availableCards.Length} valid cards");

                    if (availableCards.Length > 0)
                    {
                        newCard = availableCards[UnityEngine.Random.Range(0, availableCards.Length)];
                        //SGCC.instance.DebugLog($"new cards: {newCard}");
                        SGCC.instance.DebugLog($"{newCard.cardName} ({newCard.gameObject.name}) was chosen.");

                        //Checks if Seed of a Storm was selected and decides if the users body accepts The Seed 75-25 
                        if (newCard == (SeedofaStorm.card))
                        {
                            int chance = UnityEngine.Random.Range(0, 100);
                            SGCC.instance.DebugLog($"{player.playerID} rolled the a {chance}%");
                            if (chance >= 75)
                            {
                                //SGCC.instance.DebugLog($"Player has been Storm Ravaged");
                                newCards.Add((SeedofaStorm.card));
                                SGCC.instance.DebugLog($"Due to being Storm Ravaged player now gets the card {newCards}");
                            }
                            else
                            {
                                newCard = availableCards[UnityEngine.Random.Range(0, availableCards.Length)];
                                //SGCC.instance.DebugLog($" pre assigning: Due to succesfully aquiring seed of a Storm {player.playerID} gets {newCards}");
                                newCards.Add(newCard);
                                SGCC.instance.DebugLog($"Due to succesfully aquiring seed of a Storm {player.playerID}  {newCards}");
                            }
                        }
                        //SGCC.instance.DebugLog($"pre assigning: Normal Gambit roll leads to {player.playerID} getting {newCards}");
                        newCards.Add(newCard);
                        SGCC.instance.DebugLog($"Normal Gambit roll leads to {player.playerID} getting {newCards}");

                    }
                    ModdingUtils.Utils.Cards.instance.AddCardsToPlayer(player, newCards.ToArray(), false, null, null, null);
                }  
            }
        }
    }
}

