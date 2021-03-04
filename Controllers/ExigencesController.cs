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

            [HttpGet("lastid")]
            public int GetLastId()
            {
                return new ModelExigences().GetLastId();
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

            [HttpPost]
            public void Insert(Exigences exigences)
            {
                new ModelExigences().Insert(exigences);
            }

            [HttpPut]
            public void Update(Exigences exigences)
            {
                new ModelExigences().Update(exigences);
            }

            [HttpDelete]
            public void Delete(Exigences exigences)
            {
                new ModelExigences().Delete(exigences);
            }
    }
}
