using Model.Contracts.Observers;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class HandModel : ISubject
    {
        [NotMapped]
        private List<CardModel>? _cards;
        public List<CardModel>? Cards
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

        public void Add(params CardModel[] cards) => Cards.AddRange(cards);

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
    }
}