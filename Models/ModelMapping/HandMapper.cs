using Entities;

namespace Models.ModelMapping
{
    public static class HandMapper
    {
        /// <summary>
        /// Maps hand from hand model to hand entity
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
        public static Hand ToEntity(this HandModel hand)
        {
            if (hand == null) return null;
            return new Hand
            {
                StringOfCards = hand.StringOfCards
            };
        }

        /// <summary>
        /// Maps hand from hand entity to hand model
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
        public static HandModel ToModel(this Hand hand)
        {
            if (hand == null) return null;
            return new HandModel
            {
                StringOfCards = hand.StringOfCards
            };
        }

        /// <summary>
        /// Maps handlist from hand entitys to hand models
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Maps handlist from hand models to hand entities
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
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
