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

        [HttpGet("{login}/{password}")]
        public User Authenticate(string login, string password)
        {
            var user = new ModelUser().Authenticate(login, password);
            return user;
        }

        [HttpPost]
        public void Insert(User user)
        {
            new ModelUser().Insert(user);
        }

        [HttpPut]
        public void Update(User user)
        {
            new ModelUser().Update(user);
        }

        [HttpDelete]
        public void Delete(User user)
        {
            new ModelUser().Delete(user);        
        }
    }
}
