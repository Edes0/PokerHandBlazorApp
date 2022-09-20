using AutoMapper;
using Contracts;
using Entities;
using Models;
using Models.ModelMapping;
using Moq;
using Service.Contracts;
using Services;
using SharedObjects.DataTransferObjects;

namespace CardAppTest
{
    public class HandServiceTest
    {
        private readonly IHandService _sut;
        private readonly ServiceManager _serviceManager;
        private readonly Mock<IDataAccessManager> _dataAccessManager = new();

        public HandServiceTest()
        {
            _serviceManager = new ServiceManager(_dataAccessManager.Object);
            _sut = _serviceManager.HandService;
        }

        [Fact]
        public async Task GetHandAsync_ShouldReturnHand_WhenHandExists()
        {
            //Arrange
            CardModel card1 = new(8, Models.Suit.Hearts);
            CardModel card2 = new(9, Models.Suit.Hearts);
            CardModel card3 = new(10, Models.Suit.Hearts);
            CardModel card4 = new(11, Models.Suit.Hearts);
            CardModel card5 = new(12, Models.Suit.Hearts);

            Guid id = Guid.NewGuid();

            HandModel handModel = new() { card1, card2, card3, card4, card5 };
            handModel.Id = id;

            Hand handEntity = HandMapper.ToEntity(handModel);

            _dataAccessManager.Setup(x => x.Hand.GetHandById(id))
                .ReturnsAsync(handEntity);

            //Act
            HandModel foundHand = await _sut.GetHandAsync(id);

            //Assert
            Assert.Equal(handModel, foundHand);
        }

        //[Fact]
        //public async Task CreateHandAsync_ShouldReturnHand()
        //{
        //    //Arrange
        //    Card card1 = new(8, Suit.Hearts);
        //    Card card2 = new(9, Suit.Hearts);
        //    Card card3 = new(10, Suit.Hearts);
        //    Card card4 = new(11, Suit.Hearts);
        //    Card card5 = new(12, Suit.Hearts);
        //    Guid id = Guid.NewGuid();

        //    HandModel handToCreate = new() { card1, card2, card3, card4, card5 };
        //    Hand hand = new() { card1, card2, card3, card4, card5 };
        //    hand.Id = id;

        //    _dataAccessManager.Setup(x => x.Hand.InsertHand(hand))
        //        .Returns();

        //    //Act
        //    HandModel handCreated = await _sut.CreateHandAsync(handToCreate);

        //    //Assert
        //    Assert.Equal(handToCreate, handCreated);
        //}
    }
}


//using Entities;
//using Service.Contracts;

//public class TestingShit
//{
//    private readonly IServiceManager _service;

//    public TestingShit(IServiceManager service) => _service = service;


//    public void InsertHamster()
//    {
//        Card card1 = new(8, Suit.Hearts);
//        Card card2 = new(9, Suit.Hearts);
//        Card card3 = new(10, Suit.Hearts);
//        Card card4 = new(11, Suit.Hearts);
//        Card card5 = new(12, Suit.Hearts);

//        HandModel hand = new() { card1, card2, card3, card4, card5 };



//        _service.HandService.CreateHandAsync(hand);

//        Console.WriteLine(hand);
//        Console.ReadLine();
//    }
//}