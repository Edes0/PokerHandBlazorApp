namespace Model.Contracts.Observers
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Notify();
    }
}
