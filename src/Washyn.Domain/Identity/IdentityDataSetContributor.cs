using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Security.Encryption;

namespace Washyn.Domain.Identity
{
    public class IdentityDataSetContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<User, int> _userRepository;
        private readonly IStringEncryptionService _stringEncryptionService;

        public IdentityDataSetContributor(IRepository<User, int> userRepository,
            IStringEncryptionService stringEncryptionService)
        {
            _userRepository = userRepository;
            _stringEncryptionService = stringEncryptionService;
        }
        
        public async Task SeedAsync(DataSeedContext context)
        {
            var passwordHashed = _stringEncryptionService.Encrypt("chester");
            var admin = new User("chester", passwordHashed, RolConsts.Admin)
            {
                Email = "chester@gmail.com",
                Name = "Chester",
                Surname = "Surname",
            };
            
            // if (!await _userRepository.AnyAsync(user => user.UserName == admin.UserName))
            {
                await _userRepository.InsertAsync(admin, true);
            }
        }
    }
}