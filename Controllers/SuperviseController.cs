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
    }
}
