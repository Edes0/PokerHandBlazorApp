using Model.Contracts.Observers;
using Models.Cards;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class HandModel : ISubject
    {
        [NotMapped]
        private List<CardBaseModel>? _cards;
        /// <summary>
        /// The setter of Cards will notify the contructor
        /// </summary>
        public List<CardBaseModel>? Cards
        {
            get { return _cards; }
            set
            {
                _cards = value;
                Notify();
            }
        }
        public string StringOfCards { get; set; }
        /// <summary>
        /// This makes it possible to add many observers
        /// </summary>
        private List<IObserver> _observers = new();

        private StringOfCardsObserver _stringOfCardsObserver = new();

        public HandModel()
        {
            Cards = new();
            Attach(_stringOfCardsObserver);
        }

        /// <summary>
        /// This will ovveride the ToString() method so that it writes out a string of cards. The cards also have this method so they print themselves out.
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
        /// Attaching observer to this class
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// Notify method that calles the observer update method.
        /// </summary>
        public void Notify()
        {
            _observers.ForEach(o =>
            {
                o.Update(this);
            });
        }

        /// <summary>
        /// This removes cards from hand depending if cards are checked or not. They outs the amount.
        /// </summary>
        /// <param name="amountToThrow"></param>
        /// <returns></returns>
        public List<CardBaseModel> ThrowCheckedCardsAndRemoveThemFromHand(out int amountToThrow)
        {
            var cardsToThrow = Cards.Where(card => card.IsChecked == true).ToList();
            cardsToThrow.ForEach(card => Cards.Remove(card));
            amountToThrow = cardsToThrow.Count();
            return cardsToThrow;
        }
    }
}