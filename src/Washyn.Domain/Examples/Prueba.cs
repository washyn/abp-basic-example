using Volo.Abp.Domain.Entities;

namespace Washyn.Domain
{
    public class Prueba : Entity<long>
    {
        public string Nombre { get; set; }

        protected Prueba()
        {
            
        }

        public Prueba(long id, string nombre)
        : base(id: id)
        {
            Nombre = nombre;
        }
    }
}