using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.ConfigSettings;
using AccountManagement.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AccountManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        Config config;
        Manager manager;
        public UserController(IOptions<Config> config, Manager manager)
        {
            this.config = config.Value;
            this.manager = manager;
        }

        [HttpPost]
        public User CreateUser([FromBody]User user)
        {
            return manager.AddUser(user);
        }

        [HttpPut]
        public User UpdateUser([FromBody]User user)
        {
            return manager.AddUser(user);
        }
    }
}
