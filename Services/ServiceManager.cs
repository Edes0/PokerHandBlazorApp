using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHandService> _handService;
        public ServiceManager(IDataAccessManager dataAccessManager, IMapper mapper)
        {
            _handService = new Lazy<IHandService>(() =>
            new HandService(dataAccessManager, mapper));
        }
        public IHandService HandService => _handService.Value;
    }
}
