using System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace api.IFTool.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        IDbConnection _connection;
        private readonly IConfiguration _config;
        IHostingEnvironment environment;
        private IMasterRepository _masterRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(IHostingEnvironment environment, IConfiguration config)
        {
            _config = config;
        }
        
        public IMasterRepository MasterRepository
        {
            get
            {
                return _masterRepository = _masterRepository ?? new MasterRepository(environment, _config);
            }
        }
    }
}
