using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SuperviseService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperviceController : ControllerBase
    {
        private readonly ILogger<SuperviceController> _logger;

        public SuperviceController(ILogger<SuperviceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Service> Get()
        {
            return new List<Service>();
        }
    }
}
