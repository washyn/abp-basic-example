using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Washyn.Domain;
using Washyn.Domain.Identity;

namespace Washyn.EntityFrameworkCore
{
    public static class DbContextModelCreatingExtensions
    {
        public static void ConfigureModels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.ConfigureByConvention(); //auto configure for the base class props
                
                b.Property(x => x.UserName)
                    .IsRequired()
                    .HasMaxLength(UserConsts.MaxLength);
                b.Property(a => a.Email)
                    .HasMaxLength(UserConsts.MaxLength);
                b.Property(a => a.Name)
                    .HasMaxLength(UserConsts.MaxLength);
                b.Property(a => a.Surname)
                    .HasMaxLength(UserConsts.MaxLength);
                b.Property(a => a.IsActive)
                    .IsRequired()
                    .HasDefaultValue(true);
                b.Property(a => a.PhoneNumber)
                    .HasMaxLength(UserConsts.MaxLength);
                b.Property(a => a.PasswordHash)
                    .HasMaxLength(UserConsts.MaxLength);
                b.Property(a => a.RolName)
                    .HasMaxLength(UserConsts.MaxLength);
                
                // b.HasKey(f => f.Id);
                // set IsUnique
                b.HasIndex(f => f.UserName);
                
                b.HasKey(ent => ent.Id);
                b.Property(ent => ent.Id).ValueGeneratedNever();
            });
            
            modelBuilder.Entity<Prueba>(b =>
            {
                b.ConfigureByConvention(); //auto configure for the base class props
                
                b.HasKey(ent => ent.Id);
                b.Property(ent => ent.Id).ValueGeneratedNever();
            });
        }
    }
}