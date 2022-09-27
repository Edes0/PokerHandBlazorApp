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

        public HandService(IDataAccessManager dataAccessManager)
        {
            _dataAccessManager = dataAccessManager;
        }

        /// <summary>
        /// Returns all hands from db as List<HandModel>
        /// </summary>
        public async Task<List<HandModel>> GetAllHandsAsync()
        {
            var hands = await _dataAccessManager.Hand.GetHands();
            var handModel = HandMapper.ToModels(hands);
            return handModel;
        }

        /// <summary>
        /// Returns a specific hand from db as HandModel
        /// </summary>
        /// <param name="id"></param>
        public async Task<HandModel> GetHandAsync(Guid id)
        {
            var hand = await GetHandAndCheckIfItExists(id);
            var handModel = HandMapper.ToModel(hand);
            return handModel;
        }

        /// <summary>
        /// Creates a hand in db and returns the created entity as a HandModel
        /// </summary>
        /// <param name="handModel"></param>
        public async Task<HandModel> CreateHandAsync(HandModel handModel)
        {
            var handEntity = HandMapper.ToEntity(handModel);
            await _dataAccessManager.Hand.InsertHand(handEntity);
            return handModel;
        }

        /// <summary>
        /// Deletes a specific hand in the db
        /// </summary>
        /// <param name="handId"></param>
        public async Task DeleteHandAsync(Guid handId)
        {
            var hand = await GetHandAndCheckIfItExists(handId);

            await _dataAccessManager.Hand.RemoveHand(hand);
        }

        /// <summary>
        /// Gets a specific hand from db and checks if it exists.
        /// Can also add new services in the future.
        /// </summary>
        /// <param name="id"></param>
        private async Task<Hand> GetHandAndCheckIfItExists(Guid id)
        {
            var hand = await _dataAccessManager.Hand.GetHandById(id);

            if (hand == null) throw new NotImplementedException();

            return hand;
        }
    }
}
