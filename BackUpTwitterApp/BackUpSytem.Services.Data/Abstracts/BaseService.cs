using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Utilities.Contracts;
using Bytes2you.Validation;

namespace BackUpSytem.Services.Data.Abstracts
{
    public abstract class BaseService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingProvider mappingProvider;
        private readonly IUserRepository userRepository;

        public BaseService(
            IUnitOfWork unitOfWork, 
            IMappingProvider mappingProvider,
            IUserRepository userRepository)
        {
            Guard.WhenArgument(unitOfWork, "Unit of Work").IsNull().Throw();
            Guard.WhenArgument(mappingProvider, "Mapping Provider").IsNull().Throw();
            Guard.WhenArgument(userRepository, "User Repository").IsNull().Throw();

            this.unitOfWork = unitOfWork;
            this.mappingProvider = mappingProvider;
            this.userRepository = userRepository;
        }

        protected IUnitOfWork UnitOfWork => this.unitOfWork;

        protected IMappingProvider MappingProvider => this.mappingProvider;

        protected IUserRepository UserRepository => this.userRepository;
    }
}
