using Models;

namespace Service.Contracts
{
    public interface IHandService
    {
        Task<HandModel> CreateHandAsync(HandModel handDto);
        Task DeleteHandAsync(Guid handId);
        Task<List<HandModel>> GetAllHandsAsync();
        Task<HandModel> GetHandAsync(Guid id);
    }
}