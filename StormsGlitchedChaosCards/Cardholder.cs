using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using ModdingUtils.Utils;
//using RSClasses.Cards;
/*using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnboundLib.Cards;
using UnboundLib.Utils;
using UnityEngine;
using StormsGlitchedChaosCards;

namespace StormsGlitchedChaosCards
{
    public class CardHolder : MonoBehaviour // Loads cards
    {
        public List<GameObject> Cards;
        public List<GameObject> HiddenCards;
        public static Dictionary<string, CardInfo> cards = new Dictionary<string, CardInfo>();

        internal void RegisterCards()
        {
            foreach (var Card in Cards)
            {
                CustomCard.RegisterUnityCard(Card, SGCC.ModInitials, Card.GetComponent<CardInfo>().cardName, true, null);
                CustomCardCategories.instance.UpdateAndPullCategoriesFromCard(Card.GetComponent<CardInfo>());
                cards.Add(Card.GetComponent<CardInfo>().cardName, Card.GetComponent<CardInfo>());
            }
            foreach (var Card in HiddenCards)
            {
                CustomCard.RegisterUnityCard(Card, SGCC.ModInitials, Card.GetComponent<CardInfo>().cardName, false, null);
                CustomCardCategories.instance.UpdateAndPullCategoriesFromCard(Card.GetComponent<CardInfo>());
                ModdingUtils.Utils.Cards.instance.AddHiddenCard(Card.GetComponent<CardInfo>());
                cards.Add(Card.GetComponent<CardInfo>().cardName, Card.GetComponent<CardInfo>());
            }
        }
    }
}
*/