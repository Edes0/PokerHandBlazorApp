using Enums;

namespace Models.Cards
{
    public class SpadesCardModel : CardBaseModel
    {
        /// <summary>
        /// Constructor will set suit depending on what card is created
        /// </summary>
        /// <param name="rank"></param>
        public SpadesCardModel(int rank) : base(rank)
        {
            Suit = CardSuit.Spades;
        }
    }
}
