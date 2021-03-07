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

        [HttpGet("exigence/jalons/{id}")]
        public IEnumerable<Jalons> GetJalonsByIdExigence(int id)
        {
            var jalons = new ModelLiaison().GetJalonsByIdExigence(id);
            return jalons.ToArray();
        }

        [HttpGet("exigence/taches/{id}")]
        public IEnumerable<Taches> GetTachesByIdExigence(int id)
        {
            var taches = new ModelLiaison().GetTachesByIdExigence(id);
            return taches.ToArray();
        }

        [HttpGet("jalon/taches/{id}")]
        public IEnumerable<Taches> GetTachesByIdJalon(int id)
        {
            var taches = new ModelLiaison().GetTachesByIdJalon(id);
            return taches.ToArray();
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

        [HttpPost("jalon/exigence/tache")]
        public void InsertTacheIntoJalonExigence(Liaison liaison)
        {
            new ModelLiaison().InsertTacheIntoJalonExigence(liaison);
        }
        [HttpPost("exigence/jalon")]
        public void InsertJalonForExigence(Liaison liaison)
        {
            new ModelLiaison().InsertJalonForExigence(liaison);
        }
    }
}
