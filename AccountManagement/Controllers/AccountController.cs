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
    public class AccountController : ControllerBase
    {
        Config config;
        Manager manager;
        public AccountController(IOptions<Config> config,Manager manager)
        {
            this.config = config.Value;
            this.manager = manager;
        }

        [HttpPost("user/{userId}")]
        public Account CreateAccount(long userId, [FromBody]Account account)
        {
            return manager.CreateAccount(userId, account);
        }

        [HttpPut]
        public Account UpdateAccount([FromBody]Account account)
        {
            return manager.UpdateAccount(account);
        }

        [HttpPut("close/{number}")]
        public bool CloseAccount(string number)
        {
            return manager.CloseAccount(number);
        }

        [HttpGet("accounts/info/user/{userId}")]
        public List<Account> GetAccountsByUser(long userId)
        {
            return manager.GetAccountsByUser(userId);
        }

        [HttpPut("branch/update")]
        public Account ChangeBranch([FromBody]Account account)
        {
            return manager.UpdateAccount(account);
        }
    }
}