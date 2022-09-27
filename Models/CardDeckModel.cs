using Model.Contracts;
using System.Collections;
using System.Text;

namespace Models
{
    public class CardDeckModel : IEnumerable<CardModel>, IShuffle
    {
        public List<CardModel> Cards = new();
        private readonly int CardsInDeck = 52;
        private readonly int ColorsInDeck = 4;

        public CardDeckModel(int NumberOfDecks)
        {
            for (int i = 1; i <= NumberOfDecks; i++)
            {
                for (int u = 0; u < (CardsInDeck / ColorsInDeck); u++)
                {
                    Cards.Add(new CardModel(u, Suit.Hearts));
                    Cards.Add(new CardModel(u, Suit.Diamonds));
                    Cards.Add(new CardModel(u, Suit.Spades));
                    Cards.Add(new CardModel(u, Suit.Clubs));
                }
            }
        }
        public void Add(params CardModel[] cards) => Cards.AddRange(cards);

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var c in Cards)
                builder.Append($"{c} ");

            return builder.ToString().Trim();
        }

        public IEnumerator<CardModel> GetEnumerator() => Cards.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Cards.GetEnumerator();

        public void Shuffle()
        {
            Random rng = new();

            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                CardModel card = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = card;
            }
        }

        public List<CardModel> TakeCardsFromDeck(int amount)
        {
            List<CardModel> cardsToReturn = Cards.Take(amount).ToList();
            Cards.RemoveRange(0, amount);
            return cardsToReturn;
        }
    }
}
