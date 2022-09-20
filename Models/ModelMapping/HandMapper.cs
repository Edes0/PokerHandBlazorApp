using Entities;

namespace Models.ModelMapping
{
    public static class HandMapper
    {
        public static Hand ToEntity(this HandModel hand)
        {
            if (hand == null) return null;
            return new Hand
            {
                Id = hand.Id,
                Cards = CardMapper.ToEntity(hand.Cards),
                StringOfCards = hand.StringOfCards
            };
        }
        public static HandModel ToModel(this Hand hand)
        {
            if (hand == null) return null;
            return new HandModel
            {
                Id = hand.Id,
                Cards = CardMapper.ToModel(hand.Cards),
                StringOfCards = hand.StringOfCards
            };
        }

        public static List<HandModel> ToModels(this List<Hand> hands)
        {
            if (hands == null) return null;

            List<HandModel> cards = new();

            foreach (var card in hands)
            {
                cards.Add(ToModel(card));
            }
            return cards;
        }

        public static List<Hand> ToEntities(this List<HandModel> hands)
        {
            if (hands == null) return null;

            List<Hand> cards = new();

            foreach (var card in hands)
            {
                cards.Add(ToEntity(card));
            }
            return cards;
        }
    }
}
