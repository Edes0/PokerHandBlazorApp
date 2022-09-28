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

        /// <summary>
        /// Will create a full deck depending on NumberOfDecks. 1 will create 1 deck and two will create two etc.
        /// </summary>
        /// <param name="NumberOfDecks"></param>
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
        /// <summary>
        /// This method makes it possible to add cards seperate into the carddeck when created.
        /// </summary>
        /// <param name="cards"></param>
        public void Add(params CardBaseModel[] cards) => Cards.AddRange(cards);

        /// <summary>
        /// This writes out all the cards into a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var c in Cards)
                builder.Append($"{c} ");

            return builder.ToString().Trim();
        }

        /// <summary>
        /// Needed to make this class inte an IEnumerable.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<CardBaseModel> GetEnumerator() => Cards.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Cards.GetEnumerator();

        /// <summary>
        /// A method to shuffle the cardlist property Cards.
        /// </summary>
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

        /// <summary>
        /// This returns cards depending on amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
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
