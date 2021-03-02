﻿using Microsoft.AspNetCore.Mvc;
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
    public class JalonsController : ControllerBase
    {
        private readonly ILogger<JalonsController> _logger;

        public JalonsController(ILogger<JalonsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Jalons> Get()
        {
            var jalons = new ModelJalons().GetAll();
            return jalons.ToArray();
        }

        [HttpGet("{id}")]
        public Jalons GetById(int id)
        {
            var jalon = new ModelJalons().GetById(id);
            return jalon;
        }
    }
}