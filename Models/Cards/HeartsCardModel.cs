using Enums;

namespace Models.Cards
{
    public class HeartsCardModel : CardBaseModel
    {
        public HeartsCardModel(int rank) : base(rank)
        {
            Suit = CardSuit.Hearts;
        }
    }
}
