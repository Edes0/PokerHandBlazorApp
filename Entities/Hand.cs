using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Hand
    {
        public Guid Id { get; set; }
        [NotMapped]
        public List<Card>? Cards { get; set; }
        public string? StringOfCards { get; set; }
    }
}