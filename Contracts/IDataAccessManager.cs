namespace Contracts
{
    public interface IDataAccessManager
    {
        IHandData Hand { get; }

        Task SaveAsync();
    }
}