﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using NETCore_Back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class ProjetsController : ControllerBase
        {
        

        private readonly ILogger<ProjetsController> _logger;

            public ProjetsController(ILogger<ProjetsController> logger)
            {
                _logger = logger;
            }

            [HttpGet]
            public IEnumerable<Projets> Get()
            {
                var projets = new ModelProjets().GetAll();
                return projets.ToArray();
            }

            [HttpGet("{id}")]
            public Projets GetById(int id)
            {
                var projet = new ModelProjets().GetById(id);
                return projet;
            }

            [HttpPost("add")]
            public void Insert(Projets projets)
            {
                new ModelProjets().Insert(projets);
            }

            [HttpPut("edit/{id}")]
            public void Update(int id, Projets projets)
            {
                new ModelProjets().Update(id, projets);
            }

            [HttpDelete("delete/{id}")]
            public void Delete(int id)
            {
                new ModelProjets().Delete(id);
            }
    }
}
