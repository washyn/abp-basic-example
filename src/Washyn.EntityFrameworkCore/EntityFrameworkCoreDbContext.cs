using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Washyn.Domain;

namespace Washyn.EntityFrameworkCore
{
    public class EntityFrameworkCoreDbContext : AbpDbContext<EntityFrameworkCoreDbContext>
    {
        public DbSet<Prueba> Pruebas { get; set; }
        
        public EntityFrameworkCoreDbContext(DbContextOptions<EntityFrameworkCoreDbContext> options) : base(options)
        {
            
        }
    }
}