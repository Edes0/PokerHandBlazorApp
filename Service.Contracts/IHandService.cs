using Models;
using SharedObjects.DataTransferObjects;

namespace Service.Contracts
{
    public interface IHandService
    {
        Task<HandModel> CreateHandAsync(HandModel handDto);
        Task DeleteHandAsync(Guid handId);
        Task<IEnumerable<HandModel>> GetAllHandsAsync();
        Task<HandModel> GetHandAsync(Guid id);
    }
}