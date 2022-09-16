using System.Collections;
using System.Text;

namespace Entities
{
    public class Hand : IEnumerable<Card>
    {
        public Guid Id { get; set; }
        public List<Card>? Cards { get; set; }  
        public string StringOfCards
        {
            get
            {
                if (Cards is null)
                {
                    throw new NotImplementedException();
                }

                return Cards.ToString();
            }
            set
            {
                StringOfCards = value;
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
    }
}