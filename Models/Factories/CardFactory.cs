using Enums;
using Models.Cards;

namespace Models.Factories
{
    public static class CardFactory
    {
        /// <summary>
        /// Factory will return CardModel depending on what CardSuit is put in into the factory method
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="cardSuit"></param>
        /// <returns></returns>
        public static CardBaseModel CreateCard(int rank, CardSuit cardSuit)
        {
            CardBaseModel cardModel = null;

            switch (cardSuit)
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
