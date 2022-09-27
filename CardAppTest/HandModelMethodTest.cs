using Models;

namespace CardAppTest
{
    public class HandModelMethodTest
    {
        [Fact]
        public void ThrowCheckedCardsAndRemoveThemFromHandTest_ShouldOutAmountToThrow()
        {
            //Arrange
            CardModel cardModel1 = new(1, Suit.Clubs);
            CardModel cardModel2 = new(2, Suit.Clubs);
            CardModel cardModel3 = new(3, Suit.Clubs);
            CardModel cardModel4 = new(4, Suit.Clubs);
            CardModel cardModel5 = new(5, Suit.Clubs);

            List<CardModel> cardList = new() { cardModel1, cardModel2, cardModel3, cardModel4, cardModel5 };

            HandModel handModel = new();

            handModel.Cards.AddRange(cardList);

            //Act
            List<CardModel> cardsToThrow = handModel.ThrowCheckedCardsAndRemoveThemFromHand(out int amountToThrow);


            //Assert
            Assert.Equal(cardsToThrow.Count, amountToThrow);

            if (cardsToThrow.Count != 0)
            {
                foreach (var card in cardsToThrow)
                {
                    Assert.True(card.IsChecked);
                }
            }
            if (handModel.Cards.Count() != 0)
            {
                foreach (var card in handModel.Cards)
                {
                    Assert.False(card.IsChecked);
                }
            }
            Assert.Equal(cardsToThrow.Count() + handModel.Cards.Count(), cardList.Count());
        }
    }
}
