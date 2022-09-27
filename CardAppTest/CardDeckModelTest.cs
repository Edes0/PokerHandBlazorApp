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
        public void TakeCardsFromDeckTest(int amount)
        {
            //Arrange
            CardDeckModel cardDeckModel = new(1);

            List<CardBaseModel> cardList = new();

            //Act
            cardList = cardDeckModel.TakeCardsFromDeck(amount);

            //Assert
            Assert.Equal(cardList.Count, amount);
            Assert.Equal(cardDeckModel.CardsInDeck, cardDeckModel.Count() + amount);
        }
    }
}
