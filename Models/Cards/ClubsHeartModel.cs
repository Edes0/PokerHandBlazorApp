using Enums;

namespace Models.Cards
{
    public class ClubsCardModel : CardBaseModel
    {
        public ClubsCardModel(int rank) : base(rank)
        {
            Suit = CardSuit.Clubs;
        }
    }
}
