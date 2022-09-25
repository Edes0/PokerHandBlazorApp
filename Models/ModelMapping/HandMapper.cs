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
                StringOfCards = hand.StringOfCards
            };
        }

        public static HandModel ToModel(this Hand hand)
        {
            if (hand == null) return null;
            return new HandModel
            {
                StringOfCards = hand.StringOfCards
            };
        }

        public static List<HandModel> ToModels(this List<Hand> hands)
        {
            if (hands == null) return null;

            List<HandModel> handsToReturn = new();

            foreach (var hand in hands)
            {
                handsToReturn.Add(ToModel(hand));
            }
            return handsToReturn;
        }

        public static List<Hand> ToEntities(this List<HandModel> hands)
        {
            if (hands == null) return null;

            List<Hand> handsToReturn = new();

            foreach (var hand in hands)
            {
                handsToReturn.Add(ToEntity(hand));
            }
            return handsToReturn;
        }
    }
}
