using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Washyn.Domain.Data;

namespace Washyn.EntityFrameworkCore
{
    public class EfCoreDbSchemaMigrator : IDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EfCoreDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task MigrateAsync()
        {
            await _serviceProvider
                .GetRequiredService<EntityFrameworkCoreDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}