using Enums;

namespace Models.Cards
{
    public class SpadesCardModel : CardBaseModel
    {
        public SpadesCardModel(int rank) : base(rank)
        {
            Suit = CardSuit.Spades;
        }
    }
}
