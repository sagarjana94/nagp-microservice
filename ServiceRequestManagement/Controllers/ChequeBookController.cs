using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceRequestManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeBookController : ControllerBase
    {
        Manager manager;
        public ChequeBookController(Manager manager)
        {
            this.manager = manager;
        }

        [HttpPost("order/{accountNumber}")]
        public bool Order(string accountNumber)
        {
            return manager.Order(accountNumber);
        }

        [HttpPost("block/{accountNumber}")]
        public bool Block(int chequeBookId)
        {
            return manager.Block(chequeBookId);
        }
    }
}