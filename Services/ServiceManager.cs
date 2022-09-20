using Contracts;
using Service.Contracts;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHandService> _handService;
        public ServiceManager(IDataAccessManager dataAccessManager, ISqlDataAccess sqlDataAccess)
        {
            _handService = new Lazy<IHandService>(() =>
            new HandService(dataAccessManager, sqlDataAccess));
        }
        public IHandService HandService => _handService.Value;
    }
}
