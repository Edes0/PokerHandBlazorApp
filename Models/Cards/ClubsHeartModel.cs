using Enums;

namespace Models.Cards
{
    public class ClubsCardModel : CardBaseModel
    {
        /// <summary>
        /// Constructor will set suit depending on what card is created
        /// </summary>
        /// <param name="rank"></param>
        public ClubsCardModel(int rank) : base(rank)
        {
            Suit = CardSuit.Clubs;
        }
    }
}
