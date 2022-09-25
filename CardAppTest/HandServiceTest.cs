//using Contracts;
//using Entities;
//using Models;
//using Models.ModelMapping;
//using Moq;
//using Service.Contracts;
//using Services;

//namespace CardAppTest
//{
//    public class HandServiceTest
//    {
//        private readonly IHandService _sut;
//        private readonly ServiceManager _serviceManager;
//        private readonly Mock<IDataAccessManager> _dataAccessManager = new();

//        public HandServiceTest()
//        {
//            _serviceManager = new ServiceManager(_dataAccessManager.Object);
//            _sut = _serviceManager.HandService;
//        }

//        [Fact]
//        public async Task GetHandAsync_ShouldReturnHand_WhenHandExists()
//        {
//            //Arrange
//            CardModel card1 = new(8, Models.Suit.Hearts);
//            CardModel card2 = new(9, Models.Suit.Hearts);
//            CardModel card3 = new(10, Models.Suit.Hearts);
//            CardModel card4 = new(11, Models.Suit.Hearts);
//            CardModel card5 = new(12, Models.Suit.Hearts);

//            Guid id = Guid.NewGuid();

//            HandModel handModel = new() { card1, card2, card3, card4, card5 };
//            handModel.Id = id;

//            Hand handEntity = HandMapper.ToEntity(handModel);

//            _dataAccessManager.Setup(x => x.Hand.GetHandById(id))
//                .ReturnsAsync(handEntity);

//            //Act
//            HandModel foundHand = await _sut.GetHandAsync(id);

//            //Assert
//            Assert.Equal(handModel, foundHand);
//        }
//    }
//}