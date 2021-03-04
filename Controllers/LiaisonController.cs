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
    public class LiaisonController : ControllerBase
    {
        private readonly ILogger<LiaisonController> _logger;

        public LiaisonController(ILogger<LiaisonController> logger)
        {
            _logger = logger;
        }

        [HttpGet("projet/{id}")]
        public IEnumerable<Exigences> GetExigencesByProject(int id)
        {
            var liaison = new ModelLiaison().GetExigencesByProjet(id);
            return liaison.ToArray();
        }

        [HttpPost("projet")]
        public void InsertExigenceForProjet(Liaison liaison)
        {
            new ModelLiaison().InsertExigenceForProjet(liaison);
        }
    }
}
