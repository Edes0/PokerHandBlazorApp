using Entities;

namespace Models.ModelMapping
{
    public static class CardMapper
    {
        public static List<Card> ToEntity(this List<CardModel> cardList)
        {
            if (cardList == null) return null;
            List<Card> cardsToReturn = new();

            foreach (var card in cardList)
            {
                cardsToReturn.Add(new Card(card.Rank, (Entities.Suit)card.Suit));
            }
            return cardsToReturn;
        }
        public static List<CardModel> ToModel(this List<Card> cardList)
        {
            if (cardList == null) return null;
            List<CardModel> cardsToReturn = new();

            foreach (var card in cardList)
            {
                cardsToReturn.Add(new CardModel(card.Rank, (Models.Suit)card.Suit));
            }
            return cardsToReturn;
        }
    }
}
