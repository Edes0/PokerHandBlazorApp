using Enums;
using Models;
using Models.Cards;

namespace CardAppTest
{
    public class HandModelMethodTest
    {
        [Fact]
        public void ThrowCheckedCardsAndRemoveThemFromHandTest_ShouldOutAmountToThrow()
        {
            //Arrange
            ClubsCardModel cardModel1 = new(1);
            ClubsCardModel cardModel2 = new(2);
            ClubsCardModel cardModel3 = new(3);
            ClubsCardModel cardModel4 = new(4);
            ClubsCardModel cardModel5 = new(5);

            List<CardBaseModel> cardList = new() { cardModel1, cardModel2, cardModel3, cardModel4, cardModel5 };

            HandModel handModel = new();

            handModel.Cards.AddRange(cardList);

            //Act
            List<CardBaseModel> cardsToThrow = handModel.ThrowCheckedCardsAndRemoveThemFromHand(out int amountToThrow);


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
