using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCore_Back;
using NETCore_Back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class TachesController : ControllerBase
        {
            private readonly ILogger<TachesController> _logger;

            public TachesController(ILogger<TachesController> logger)
            {
                _logger = logger;
            }

            [HttpGet]
            public IEnumerable<Taches> Get()
            {
                var taches = new ModelTaches().GetAll();
                return taches.ToArray();
            }

            [HttpGet("{id}")]
            public Taches GetById(int id)
            {
                var tache = new ModelTaches().GetById(id);
                return tache;
            }

            [HttpPost("add")]
            public void Insert(Taches taches)
            {
                new ModelTaches().Insert(taches);
            }

            [HttpPut("edit/{id}")]
            public void Update(int id, Taches taches)
            {
                new ModelTaches().Update(id, taches);
            }

            [HttpDelete("delete/{id}")]
            public void Delete(int id)
            {
                new ModelTaches().Delete(id);
            }
    }
}
