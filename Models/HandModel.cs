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

        private List<IObserver> _observers = new();

        private StringOfCardsObserver _stringOfCardsObserver = new();

        public HandModel()
        {
            Cards = new();
            Attach(_stringOfCardsObserver);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var c in Cards)
                builder.Append($"{c} ");

            return builder.ToString().Trim();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            _observers.ForEach(o =>
            {
                o.Update(this);
            });
        }

        public List<CardBaseModel> ThrowCheckedCardsAndRemoveThemFromHand(out int amountToThrow)
        {
            var cardsToThrow = Cards.Where(card => card.IsChecked == true).ToList();
            cardsToThrow.ForEach(card => Cards.Remove(card));
            amountToThrow = cardsToThrow.Count();
            return cardsToThrow;
        }
    }
}