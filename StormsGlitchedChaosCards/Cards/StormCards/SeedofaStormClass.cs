using ClassesManagerReborn;
using ClassesManagerReborn.Util;
using System.Collections;
using UnboundLib.Utils;
using UnityEngine.Profiling;


// Handles class setup for Astronomer


namespace StormsGlitchedChaosCards.Cards.StormCards
{
    class SeedofaStormClass : ClassHandler
    {
        public static string name = "Seed of a Storm";
        public override IEnumerator Init()
        {
            SGCC.instance.DebugLog("Registering: " + name);

            //while (SeedofaStorm.Card == null) yield return null;
            while (!(SeedofaStorm.Card)) yield return null;
            ClassesRegistry.Register(SeedofaStorm.Card, CardType.Entry);
            ClassesRegistry.Register(SGStormsVitality.Card, CardType.Card, SeedofaStorm.Card);
            ClassesRegistry.Register(SGLivingStorm.Card, CardType.Card, SeedofaStorm.Card);
            ClassesRegistry.Register(SGVanguardAgainstTheStorm.Card, CardType.Card, SeedofaStorm.Card);
            ClassesRegistry.Register(SG4.Card, CardType.Card, SeedofaStorm.Card);
            ClassesRegistry.Register(SG5.Card, CardType.Card, SeedofaStorm.Card);
            ClassesRegistry.Register(StormRavaged.Card, CardType.Card, SeedofaStorm.Card);
        }
        public override IEnumerator PostInit()
        {
            yield break;
        }
    }
}