using AutoMapper;
using Contracts;
using Entities;
using Moq;
using Service;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CardAppTest
{
    public class HandServiceTest
    {
        private readonly IHandService _sut;
        private readonly ServiceManager _serviceManager;
        private readonly Mock<IDataAccessManager> _dataAccessManager = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly IMapper _mapper;

        public HandServiceTest(IMapper mapper)
        {
            _serviceManager = new ServiceManager(_dataAccessManager.Object, _mapperMock.Object);
            _sut = _serviceManager.HandService;
            _mapper = mapper;
        }

        [Fact]
        public async Task GetHandAsync_ShouldReturnHand_WhenHandExists()
        {
            //Arrange
            Card card1 = new(8, Suit.Hearts);
            Card card2 = new(9, Suit.Hearts);
            Card card3 = new(10, Suit.Hearts);
            Card card4 = new(11, Suit.Hearts);
            Card card5 = new(12, Suit.Hearts);

            Guid id = Guid.NewGuid();

            Hand handEntity = new() { card1, card2, card3, card4, card5 };
            handEntity.Id = id;

            HandDto handDto = _mapper.Map<HandDto>(handEntity);

            _dataAccessManager.Setup(x => x.Hand.GetHandById(id))
                .ReturnsAsync(handEntity);

            _mapperMock.Setup(x => x.Map<HandDto>(handEntity))
                .Returns(handDto);

            //Act
            HandDto foundHand = await _sut.GetHandAsync(id);

            //Assert
            Assert.Equal(handDto, foundHand);
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