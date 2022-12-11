using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleProject.Entities;
using SimpleProject.Interfaces;
using System.Diagnostics;

namespace SimpleProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMainService _service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMainService service, ILogger<HomeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> GetAllAsync() =>  View(await _service.GetAll());

        public async Task<IActionResult> Create(Product product)
            => product.ProductId == 0 ? View() : View(await _service.Create(product));

        public IActionResult Edit(Product product)
        {
            _service.Update(product);
            return View();
        }
        

        

    }
}