using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using StormsGlitchedChaosCards.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using Photon.Pun;
using System.Collections.Generic;
using UnboundLib.Utils;
using System.Linq;
using StormsGlitchedChaosCards.Cards.StormCards;
using ModdingUtils.Utils;
using RarityLib.Utils;
using UnityEngine;
using ClassesManagerReborn;
using ClassesManagerReborn.Util;



namespace StormsGlitchedChaosCards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]

    [BepInDependency("root.classes.manager.reborn", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.willis.rounds.modsplus", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("root.rarity.lib", BepInDependency.DependencyFlags.HardDependency)]

    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class SGCC : BaseUnityPlugin
    {
        //Basic Mod info
        private const string ModId = "com.Stormprime.rounds.StormsGlitchChaosCards";
        private const string ModName = "Storms Glitched Chaos Cards";
        public const string Version = "1.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "SGCC";
        public static SGCC instance { get; private set; }
        public const string Gambit = "Storms Gambit Cards";
        private bool debug = true; 

        public List<CardCategory> categories = new List<CardCategory>();
        public static CardCategory gambitCategory;
        public static CardCategory SGCCCards;

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            //RarityUtils.AddRarity("CommonClass", 1.5f, new Color(0.0978f, 0.1088f, 0.1321f), new Color(0.0978f, 0.1088f, 0.1321f));
            new Harmony(ModId).PatchAll();
        }
        void Start()
        {
            instance = this;
            SGCCCards = CustomCardCategories.instance.CardCategory("SGCCCards");
            gambitCategory = CustomCardCategories.instance.CardCategory("gambitCategory");
            //CustomCard.BuildCard<StormsGambit>();
            //CustomCard.BuildCard<SGStormsVitality>();
            //CustomCard.BuildCard<SGVanguardAgainstTheStorm>();
            //CustomCard.BuildCard<SGLivingStorm>();
            //CustomCard.BuildCard<SG4>();
            //CustomCard.BuildCard<SG5>();
            //CustomCard.BuildCard<SeedofaStorm>();
            //CustomCard.BuildCard<StormRavaged>();

            CustomCard.BuildCard<SeedofaStorm>((card) => SeedofaStorm.Card = card);
            //SGCC.instance.DebugLog($"Built: {SeedofaStorm.Card}");
            CustomCard.BuildCard<StormsGambit>((card) => StormsGambit.Card = card);
            CustomCard.BuildCard<StormRavaged>((card) => StormRavaged.Card = card);
            CustomCard.BuildCard<SGLivingStorm>((card) => SGLivingStorm.Card = card);
            CustomCard.BuildCard<SGStormsVitality>((card) => SGStormsVitality.Card = card);
            CustomCard.BuildCard<SGVanguardAgainstTheStorm>((card) => SGVanguardAgainstTheStorm.Card = card);
        }

        public void DebugLog(object message)
        {
            if (debug)
            {
                UnityEngine.Debug.Log(message);
            }
        }
    }
}
