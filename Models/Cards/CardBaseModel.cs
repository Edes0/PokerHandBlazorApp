using Enums;
using Model.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Cards
{
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

        public char SuitChar => "\u2663\u2666\u2665\u2660"[(int)Suit];
        public char RankChar => "23456789TJQKA"[Rank];
        public override string ToString() => $"{RankChar}{SuitChar}";
    }
}