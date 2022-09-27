using Enums;
using Model.Contracts;
using Models.Cards;

namespace Models.Factories
{
    public static class CardFactory
    {
        public static CardBaseModel CreateCard(int rank, CardSuit cardSuit)
        {
            CardBaseModel cardModel = null;

            switch(cardSuit)
            {
                case CardSuit.Diamonds:
                    cardModel = new DiamondsCardModel(rank);
                    break;

                case CardSuit.Clubs:
                    cardModel = new ClubsCardModel(rank);
                    break;

                case CardSuit.Spades:
                    cardModel = new SpadesCardModel(rank);
                    break;

                case CardSuit.Hearts:
                    cardModel = new HeartsCardModel(rank);
                    break;
            }
            return cardModel;
        }
    }
}
