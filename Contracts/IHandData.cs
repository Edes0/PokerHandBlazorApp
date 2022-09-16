using Entities;

namespace Contracts
{
    public interface IHandData
    {
        Task<List<Hand>> GetHands();
        Task<Hand> GetHandById(Guid Id);
        Task InsertHand(Hand hand);
        Task RemoveHand(Hand hand);
    }
}