using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public enum Suit { Clubs, Diamonds, Hearts, Spades }

    //TODO: Make abstract
    [NotMapped]
    public class Card
    {
        public Guid Id { get; set; }
        public int Rank { get; set; }
        public Suit Suit { get; set; }

        public Card()
        {
        }

        public Card(int rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }
        /// <summary>
        /// Puts chars and symbols instead of original Rank and Suit 
        /// </summary>
        public char SuitChar => "\u2663\u2666\u2665\u2660"[(int)Suit];
        public char RankChar => "23456789TJQKA"[Rank];
    }
}