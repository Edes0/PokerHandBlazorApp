using Models;
using Models.Cards;

namespace CardAppTest
{
    public class CardDeckModelTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(20)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void TakeCardsFromDeckTest(int amount)
        {
            //Arrange
            CardDeckModel cardDeckModel = new(1);

            List<CardBaseModel> cardList = new();

            //Act
            cardList = cardDeckModel.TakeCardsFromDeck(amount);

            //Assert
            if(amount !> cardDeckModel.Count() && amount < 0)
            {
                Assert.Equal(cardList.Count, amount);
                Assert.Equal(cardDeckModel.CardsInDeck, cardDeckModel.Count() + amount);
            }
            if (amount < 0) Assert.Empty(cardList);
            if (amount > cardDeckModel.Count()) Assert.Empty(cardList);
        }
    }
}
