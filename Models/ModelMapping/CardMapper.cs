using Entities;
using Enums;
using Models.Cards;
using Models.Factories;

namespace Models.ModelMapping
{
    public static class CardMapper
    {
        /// <summary>
        /// Maps card from any card model to card entity
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
        public static List<Card> ToEntity(this List<CardBaseModel> cardList)
        {
            if (cardList == null) return null;
            List<Card> cardsToReturn = new();

            foreach (var card in cardList)
            {
                cardsToReturn.Add(new Card(card.Rank, (Suit)card.Suit));
            }
            return cardsToReturn;
        }

        /// <summary>
        /// Maps card from card entity to any card model
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
        public static List<CardBaseModel> ToModel(this List<Card> cardList)
        {
            if (cardList == null) return null;
            List<CardBaseModel> cardsToReturn = new();

            foreach (var card in cardList)
            {
                cardsToReturn.Add(CardFactory.CreateCard(card.Rank, (CardSuit)card.Suit));
            }
            return cardsToReturn;
        }
    }
}
