using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Washyn.Domain;
using Washyn.Domain.Identity;

namespace Washyn.EntityFrameworkCore
{
    // [ConnectionStringName("Default")]
    public class EntityFrameworkCoreDbContext : AbpDbContext<EntityFrameworkCoreDbContext>
    {
        public DbSet<Prueba> Pruebas { get; set; }
        public DbSet<User> Users { get; set; }
        
        public EntityFrameworkCoreDbContext(DbContextOptions<EntityFrameworkCoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureModels();
        }
    }
}