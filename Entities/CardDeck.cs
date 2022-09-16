using System.Collections;
using System.Text;

namespace Entities
{
    public class CardDeck : IEnumerable<Card>
    {
        public List<Card> Cards = new();
        private int CardsInDeck = 52;
        private int ColorsInDeck = 4;

        public CardDeck(int NumberOfDecks)
        {
            for (int i = 0; i <= NumberOfDecks; i++)
            {
                for (int u = 0; u < (CardsInDeck / ColorsInDeck); u++)
                {
                    Cards.Add(new Card(u, Suit.Hearts));
                    Cards.Add(new Card(u, Suit.Diamonds));
                    Cards.Add(new Card(u, Suit.Spades));
                    Cards.Add(new Card(u, Suit.Clubs));
                }
            }
        }
        public void Add(params Card[] cards) => Cards.AddRange(cards);

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var c in Cards)
                builder.Append($"{c} ");

            return builder.ToString().Trim();
        }

        public IEnumerator<Card> GetEnumerator() => Cards.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Cards.GetEnumerator();

        public void Shuffle()
        {
            Random rng = new();

            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card card = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = card;
            }
        }
    }
}
