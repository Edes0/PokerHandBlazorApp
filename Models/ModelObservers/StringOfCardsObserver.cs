using Models;

namespace Model.Contracts.Observers
{
    public class StringOfCardsObserver : IObserver
    {
        public StringOfCardsObserver()
        {
        }

        public void Update(ISubject subject)
        {
            if (subject is HandModel handmodel) handmodel.StringOfCards = handmodel.ToString();
        }
    }
}
