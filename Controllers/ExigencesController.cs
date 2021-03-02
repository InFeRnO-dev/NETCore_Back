using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCore_Back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Controllers
{

        [ApiController]
        [Route("[controller]")]
        public class ExigencesController : ControllerBase
        {
            private readonly ILogger<ExigencesController> _logger;

            public ExigencesController(ILogger<ExigencesController> logger)
            {
                _logger = logger;
            }

            [HttpGet]
            public IEnumerable<Exigences> Get()
            {
                var exigences = new ModelExigences().GetAll();
                return exigences.ToArray();
            }

            [HttpGet("{id}")]
            public Exigences GetById(int id)
            {
                var exigence = new ModelExigences().GetById(id);
                return exigence;
            }

            [HttpPost("add")]
            public void Insert(Exigences exigences)
            {
                new ModelExigences().Insert(exigences);
            }

            [HttpPut("edit/{id}")]
            public void Update(int id, Exigences exigences)
            {
                new ModelExigences().Update(id, exigences);
            }

            [HttpDelete("delete/{id}")]
            public void Delete(int id)
            {
                new ModelExigences().Delete(id);
            }
    }
}
