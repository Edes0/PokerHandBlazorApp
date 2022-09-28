using Enums;
using Model.Contracts;
using Models.Cards;
using Models.Factories;
using System.Collections;
using System.Text;

namespace Models
{
    public class CardDeckModel : IEnumerable<CardBaseModel>, IShuffle
    {
        public List<CardBaseModel> Cards = new();
        public readonly int CardsInDeck = 52;
        private readonly int DifferentRanks = 12;

        public CardDeckModel(int NumberOfDecks)
        {
            for (int i = 1; i <= NumberOfDecks; i++)
            {
                for (int u = 0; u <= DifferentRanks; u++)
                {
                    Cards.Add(CardFactory.CreateCard(u, CardSuit.Clubs));
                    Cards.Add(CardFactory.CreateCard(u, CardSuit.Diamonds));
                    Cards.Add(CardFactory.CreateCard(u, CardSuit.Hearts));
                    Cards.Add(CardFactory.CreateCard(u, CardSuit.Spades));
                }
            }
        }
        public void Add(params CardBaseModel[] cards) => Cards.AddRange(cards);

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var c in Cards)
                builder.Append($"{c} ");

            return builder.ToString().Trim();
        }

        public IEnumerator<CardBaseModel> GetEnumerator() => Cards.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Cards.GetEnumerator();

        public void Shuffle()
        {
            Random rng = new();

            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                CardBaseModel card = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = card;
            }
        }

        public List<CardBaseModel> TakeCardsFromDeck(int amount)
        {
            List<CardBaseModel> cardsToReturn = new();

            if (amount < 0) return cardsToReturn;
            if (amount > Cards.Count) return cardsToReturn;

            cardsToReturn = Cards.Take(amount).ToList();
            Cards.RemoveRange(0, amount);
            return cardsToReturn;
        }
    }
}
