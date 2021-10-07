using Volo.Abp.Domain.Entities;

namespace Washyn.Domain
{
    public class Prueba : Entity<long>
    {
        public string Nombre { get; set; }
    }
}