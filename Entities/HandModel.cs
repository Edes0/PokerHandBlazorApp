//using Entities;
using System.Text;

namespace Entities //Shared.Models TODO: FIX THIS BUGG
{
    public class HandModel
    {
        public Guid Id { get; set; }
        public List<Card>? Cards { get; set; }
        public string StringOfCards { get; set; }

        public HandModel()
        {
        }

        public void Add(params Card[] cards) => Cards.AddRange(cards);

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var c in Cards)
                builder.Append($"{c} ");

            return builder.ToString().Trim();
        }
    }
}
