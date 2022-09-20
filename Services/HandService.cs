using Contracts;
using Entities;
using Models;
using Models.ModelMapping;
using Service.Contracts;

namespace Services
{
    internal sealed class HandService : IHandService
    {
        private readonly IDataAccessManager _dataAccessManager;
        private readonly ISqlDataAccess _sqlDataAccess;

        //private readonly ILoggerManager _logger;
        public HandService(IDataAccessManager dataAccessManager, ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
            _dataAccessManager = dataAccessManager;
            //_logger = logger;
        }
        public async Task<IEnumerable<HandModel>> GetAllHandsAsync()
        {
            var hands = await _dataAccessManager.Hand.GetHands();
            var handModel = HandMapper.ToModels(hands);
            return handModel;
        }
        public async Task<HandModel> GetHandAsync(Guid id)
        {
            var hand = await GetHandAndCheckIfItExists(id);
            var handModel = HandMapper.ToModel(hand);
            return handModel;
        }
        public async Task<HandModel> CreateHandAsync(HandModel handModel)
        {
            var handEntity = HandMapper.ToEntity(handModel);
            await _dataAccessManager.Hand.InsertHand(handEntity);
            return handModel;
        }

        public async Task DeleteHandAsync(Guid handId)
        {
            var hand = await GetHandAndCheckIfItExists(handId);

            await _dataAccessManager.Hand.RemoveHand(hand);
            //await _dataAccessManager.SaveAsync();
        }

        private async Task<Hand> GetHandAndCheckIfItExists(Guid id)
        {
            var hand = await _dataAccessManager.Hand.GetHandById(id);

            //if (hand is null)
            //    throw new BattleNotFoundException(id);

            return hand;
        }
    }
}
