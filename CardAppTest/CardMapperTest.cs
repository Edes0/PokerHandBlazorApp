using Entities;
using Enums;
using Model.Contracts;
using Models.Cards;
using Models.ModelMapping;

namespace CardAppTest
{
    public class CardMapperTest
    {

        [Fact]
        public void ToEntity_ShouldMapCard_FromCardModel()
        {
            //Arrange
            HeartsCardModel cardModel = new(8);
            List<CardBaseModel> cardModelList = new() { cardModel };

            Card cardEntity = new(8, Entities.Suit.Hearts);

            //Act
            List<Card> cardsReturned = CardMapper.ToEntity(cardModelList);

            Card cardMapped = cardsReturned.First();

            //Assert
            Assert.Equal(cardEntity.Id, cardMapped.Id);
            Assert.Equal(cardEntity.Suit, cardMapped.Suit);
            Assert.Equal(cardEntity.Rank, cardMapped.Rank);
            Assert.Equal(cardEntity.SuitChar, cardMapped.SuitChar);
            Assert.Equal(cardEntity.RankChar, cardMapped.RankChar);
        }

        [Fact]
        public void ToModel_ShouldMapCardModel_FromCard()
        {
            //Arrange
            Card cardEntity = new(5, Entities.Suit.Spades);
            List<Card> cardEntityList = new() { cardEntity };

            SpadesCardModel cardModel = new(5);

            //Act
            List<CardBaseModel> cardsReturned = CardMapper.ToModel(cardEntityList);

            CardBaseModel cardMapped = cardsReturned.First();

            //Assert
            Assert.Equal(cardModel.Suit, cardMapped.Suit);
            Assert.Equal(cardModel.Rank, cardMapped.Rank);
            Assert.Equal(cardModel.SuitChar, cardMapped.SuitChar);
            Assert.Equal(cardModel.RankChar, cardMapped.RankChar);
        }
    }
}
