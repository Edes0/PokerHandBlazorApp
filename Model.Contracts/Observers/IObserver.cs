namespace Model.Contracts.Observers
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
