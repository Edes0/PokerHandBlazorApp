using Model.Contracts.Observers;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class HandModel : IEnumerable<CardModel>, ISubject
    {
        public Guid Id { get; set; }
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

        public IEnumerator<CardModel> GetEnumerator() => Cards.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Cards.GetEnumerator();

        public HandModel()
        {
            Attach(_stringOfCardsObserver);
            Id = Guid.NewGuid(); // TODO: Giving new guid everytime?
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