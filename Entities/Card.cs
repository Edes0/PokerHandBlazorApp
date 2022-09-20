using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public enum Suit { Clubs, Diamonds, Hearts, Spades }

    //TODO: Make abstract
    [NotMapped]
    public class Card
    {
        public int Rank { get; }
        public Suit Suit { get; }

        public Card()
        {
        }

        public Card(int rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }
    }
}