using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Washyn.Application;

namespace Washyn.Web
{
    [DependsOn(typeof(ApplicationModule))]
    public class WebModule :AbpModule
    {
    }
}
