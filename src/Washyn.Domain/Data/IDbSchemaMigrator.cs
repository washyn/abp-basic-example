using System.Threading.Tasks;

namespace Washyn.Domain.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}