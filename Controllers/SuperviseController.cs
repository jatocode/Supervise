using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SuperviseService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperviseController : ControllerBase
    {
        private readonly ILogger<SuperviseController> _logger;

        public SuperviseController(ILogger<SuperviseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Service> Get()
        {
            var services = ServiceService.GetAll();
            return services;
        }

        [HttpGet("{id}")]
        public ActionResult<Service> Get(int id)
        {
            var s = ServiceService.Get(id);

            if (s == null)
                return NotFound();

            return s;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Service Service)
        {
            if (id != Service.Id)
                return BadRequest();

            var existingService = ServiceService.Get(id);
            if (existingService is null)
                return NotFound();

            try
            {
                ServiceService.Update(Service);
            } catch (Exception e)
            {
                //Console.Writ('Unable to stop' + e.Message);
                return Forbid();
            }

            return NoContent();
        }
    }
}
