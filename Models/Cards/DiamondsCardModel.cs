using Enums;

namespace Models.Cards
{
    public class DiamondsCardModel : CardBaseModel
    {
        /// <summary>
        /// Constructor will set suit depending on what card is created
        /// </summary>
        /// <param name="rank"></param>
        public DiamondsCardModel(int rank) : base(rank)
        {
            Suit = CardSuit.Diamonds;
        }
    }
}
