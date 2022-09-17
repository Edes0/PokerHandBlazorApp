using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public enum Suit { Clubs, Diamonds, Hearts, Spades }

    //TODO: Make abstract
    [NotMapped]
    public class Card
    {
        //TODO: MOVE LATER
        private const int Jack = 11;
        private const int Queen = 12;
        private const int King = 13;
        private const int Ace = 14;

        public int Rank { get; }
        public Suit Suit { get; }
        public bool IsChecked { get; set; } = false;

        public Card()
        {
        }

        public Card(int rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public char SuitChar => "\u2663\u2666\u2665\u2660"[(int)Suit];
        public char RankChar => "23456789TJQKA"[Rank];

        public override string ToString() => $"{RankChar}{SuitChar}";
    }
}