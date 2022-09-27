using Entities;
using Enums;
using Model.Contracts;
using Models.Cards;
using Models.Factories;

namespace Models.ModelMapping
{
    public static class CardMapper
    {
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
