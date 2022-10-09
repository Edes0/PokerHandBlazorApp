using Enums;
using Models.Cards;
using Models.Factories;

namespace CardAppTest
{
    public class CardFactoryTest
    {
        [Fact]
        public void CreateCard_ShouldReturnCardDependingOnSuit()
        {
            //Arrange
            CardBaseModel heartsCardModel = new HeartsCardModel(2);
            CardBaseModel spadesCardModel = new SpadesCardModel(3);
            CardBaseModel clubsCardModel = new ClubsCardModel(4);
            CardBaseModel diamondsCardModel = new DiamondsCardModel(5);

            //Act
            var HeartsCardFromFactory = CardFactory.CreateCard(2, CardSuit.Hearts);
            var SpadesCardFromFactory = CardFactory.CreateCard(3, CardSuit.Spades);
            var ClubsCardFromFactory = CardFactory.CreateCard(4, CardSuit.Clubs);
            var DiamondsCardFromFactory = CardFactory.CreateCard(5, CardSuit.Diamonds);


            //Assert
            Assert.Equal(HeartsCardFromFactory.Suit, heartsCardModel.Suit);
            Assert.Equal(HeartsCardFromFactory.Rank, heartsCardModel.Rank);
            Assert.Equal(HeartsCardFromFactory.SuitChar, heartsCardModel.SuitChar);
            Assert.Equal(HeartsCardFromFactory.RankChar, heartsCardModel.RankChar);

            Assert.Equal(SpadesCardFromFactory.Suit, spadesCardModel.Suit);
            Assert.Equal(SpadesCardFromFactory.Rank, spadesCardModel.Rank);
            Assert.Equal(SpadesCardFromFactory.SuitChar, spadesCardModel.SuitChar);
            Assert.Equal(SpadesCardFromFactory.RankChar, spadesCardModel.RankChar);

            Assert.Equal(ClubsCardFromFactory.Suit, clubsCardModel.Suit);
            Assert.Equal(ClubsCardFromFactory.Rank, clubsCardModel.Rank);
            Assert.Equal(ClubsCardFromFactory.SuitChar, clubsCardModel.SuitChar);
            Assert.Equal(ClubsCardFromFactory.RankChar, clubsCardModel.RankChar);

            Assert.Equal(DiamondsCardFromFactory.Suit, diamondsCardModel.Suit);
            Assert.Equal(DiamondsCardFromFactory.Rank, diamondsCardModel.Rank);
            Assert.Equal(DiamondsCardFromFactory.SuitChar, diamondsCardModel.SuitChar);
            Assert.Equal(DiamondsCardFromFactory.RankChar, diamondsCardModel.RankChar);
        }
    }
}
