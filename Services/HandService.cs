﻿using AutoMapper;
using Contracts;
using Entities;
using Models;
using Service.Contracts;
using SharedObjects.DataTransferObjects;

namespace Services
{
    internal sealed class HandService : IHandService
    {
        private readonly IDataAccessManager _dataAccessManager;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public HandService(IDataAccessManager dataAccessManager,
        IMapper mapper)
        {
            _dataAccessManager = dataAccessManager;
            //_logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HandDto>> GetAllHandsAsync()
        {
            var hands = await _dataAccessManager.Hand.GetHands();
            var handDto = _mapper.Map<IEnumerable<HandDto>>(hands);
            return handDto;
        }
        public async Task<HandDto> GetHandAsync(Guid id)
        {
            var hand = await GetHandAndCheckIfItExists(id);
            var handModel = _mapper.Map<HandDto>(hand);
            return handModel;
        }
        public async Task<HandModel> CreateHandAsync(HandModel handModel)
        
        {
            var handEntity = _mapper.Map<Hand>(handModel);
            await _dataAccessManager.Hand.InsertHand(handEntity);
            await _dataAccessManager.SaveAsync();
            var handToReturn = _mapper.Map<HandModel>(handEntity);
            return handToReturn;
        }

        public async Task DeleteHandAsync(Guid handId)
        {
            var hand = await GetHandAndCheckIfItExists(handId);

            _dataAccessManager.Hand.RemoveHand(hand);
            await _dataAccessManager.SaveAsync();
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
