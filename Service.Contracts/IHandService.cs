using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IHandService
    {
        Task<HandForCreationDto> CreateHandAsync(HandForCreationDto handDto);
        Task DeleteHandAsync(Guid handId);
        Task<IEnumerable<HandDto>> GetAllHandsAsync();
        Task<HandDto> GetHandAsync(Guid id);
    }
}