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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var user = new ModelUser().GetAll();
            return user.ToArray();
        }

        [HttpGet("{id_user}")]
        public User GetById(string id_user)
        {
            var user = new ModelUser().GetById(id_user);
            return user;

        }
    }
}
