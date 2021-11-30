using Volo.Abp.Application.Dtos;

namespace Washyn.Application
{
    public class PruebaDto : EntityDto<long>
    {
        public string Nombre { get; set; }
    }
}