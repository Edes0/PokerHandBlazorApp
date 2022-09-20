using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Hand : IEnumerable<Card>
    {
        public Guid Id { get; set; }
        public List<Card>? Cards { get; set; }
        public string StringOfCards { get; set; }
        public IEnumerator<Card> GetEnumerator() => Cards.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Cards.GetEnumerator();

        public Hand()
        {
        }
    }
}