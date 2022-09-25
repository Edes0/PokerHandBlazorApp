using Entities;
using Models;
using Models.ModelMapping;

namespace CardAppTest
{
    public class HandMapperTest
    {
        [Fact]
        public void ToModel_ShouldMapHandModel_FromHand()
        {
            //Arrange
            Hand handEntity = new() {StringOfCards = "test"};

            HandModel handModel = new() { StringOfCards = "test"};

            //Act
            HandModel handReturned = HandMapper.ToModel(handEntity);

            //Assert
            Assert.Equal(handModel.StringOfCards, handReturned.StringOfCards);
        }

        [Fact]
        public void ToEntity_ShouldMapHand_FromHandModel()
        {
            //Arrange
            HandModel handModel = new() { StringOfCards = "test" };

            Hand handEntity = new() { StringOfCards = "test" };

            //Act
            Hand handReturned = HandMapper.ToEntity(handModel);

            //Assert
            Assert.Equal(handEntity.StringOfCards, handReturned.StringOfCards);
        }
    }
}
