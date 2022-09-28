using Enums;
using Model.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Cards
{
    /// <summary>
    /// The base for all cards.
    /// </summary>
    [NotMapped]
    public abstract class CardBaseModel
    {
        public int Rank { get; }
        public CardSuit Suit { get; set; }
        public bool IsChecked { get; set; } = false;

        public CardBaseModel(int rank)
        {
            Rank = rank;
        }

        /// <summary>
        /// This will put a character instead of the enum type name.
        /// </summary>
        public char SuitChar => "\u2663\u2666\u2665\u2660"[(int)Suit];
        /// <summary>
        /// This will put a a character instead of int in order of the list. From 0 to 12 where int "12" is "A"
        /// </summary>
        public char RankChar => "23456789TJQKA"[Rank];
        /// <summary>
        /// Overrides ToString() method so it writes out Rank and Char together
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{RankChar}{SuitChar}";
    }
}