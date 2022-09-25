using System.Collections;

namespace Entities
{
    public class Hand
    {
        public Guid Id { get; set; }
        public string StringOfCards { get; set; }
        public DateTime TimeCreated { get; set; } 
        public Hand()
        {
            Id = Guid.NewGuid();
            TimeCreated = DateTime.Now;
        }
    }
}