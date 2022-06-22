using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Washyn.Application;
using Washyn.Domain;
using Washyn.Web.Models;

namespace Washyn.Web.Controllers
{
    public class HomeController : AbpController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Prueba, long> _pruebaRepository;
        private readonly IPruebaAppService _pruebaAppService;

        public HomeController(ILogger<HomeController> logger,
            IRepository<Prueba, long> pruebaRepository,
            IPruebaAppService pruebaAppService)
        {
            _logger = logger;
            _pruebaRepository = pruebaRepository;
            _pruebaAppService = pruebaAppService;
        }

        public async Task<IActionResult> Index()
        {
            var obs = await _pruebaAppService.GetListAsync(new PagedAndSortedResultRequestDto()
            {
                Sorting = "Nombre asc",
                SkipCount = 0,
                MaxResultCount = 100,
            });
            return View(obs.Items.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PruebaDto prueba)
        {
            await _pruebaAppService.CreateAsync(new PruebaDto()
            {
                Nombre = prueba.Nombre
            });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AdminLte()
        {
            return View();
        }
    }
}