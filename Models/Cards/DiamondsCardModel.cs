using Enums;

namespace Models.Cards
{
    public class DiamondsCardModel : CardBaseModel
    {
        public DiamondsCardModel(int rank) : base(rank)
        {
            Suit = CardSuit.Diamonds;
        }
    }
}
