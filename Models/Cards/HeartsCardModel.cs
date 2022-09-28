using Enums;

namespace Models.Cards
{
    public class HeartsCardModel : CardBaseModel
    {
        /// <summary>
        /// Constructor will set suit depending on what card is created
        /// </summary>
        /// <param name="rank"></param>
        public HeartsCardModel(int rank) : base(rank)
        {
            Suit = CardSuit.Hearts;
        }
    }
}
