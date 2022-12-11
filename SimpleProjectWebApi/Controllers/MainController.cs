using Microsoft.AspNetCore.Mvc;
using SimpleProject.Entities;
using SimpleProject.Interfaces;

namespace SimpleProjectWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MainController : ControllerBase
    {
        private readonly IMainService service;

        public MainController(IMainService service) => this.service = service;

        [HttpGet]
        public IActionResult GetAll() => Ok(service.GetAll());

        [HttpGet]
        public IActionResult GetById(long Id) => Ok(service.GetById(Id));

        [HttpPost]
        public IActionResult Insert(Product product) => Ok(service.Create(product));

        [HttpPut] 
        public IActionResult Edit(Product product) => Ok(service.Update(product));


    }
}
