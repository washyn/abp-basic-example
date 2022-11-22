using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Washyn.Domain;

namespace Washyn.EntityFrameworkCore
{
    // [ConnectionStringName("Default")]
    public class EntityFrameworkCoreDbContext : AbpDbContext<EntityFrameworkCoreDbContext>
    {
        public DbSet<Prueba> Pruebas { get; set; }
        
        public EntityFrameworkCoreDbContext(DbContextOptions<EntityFrameworkCoreDbContext> options) : base(options)
        {
            
        }
    }
}