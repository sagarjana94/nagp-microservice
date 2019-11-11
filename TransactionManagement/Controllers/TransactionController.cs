using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionManagement;
using TransactionManagement.DTO;

namespace TransactionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        Manager manager;
        public TransactionController(Manager manager)
        {
            this.manager = manager;
        }

        [HttpPost("withdraw")]
        public Transaction Withdraw(Transaction transaction)
        {
            return manager.Withdraw(transaction);
        }

        [HttpPost("deposit")]
        public Transaction Deposit(Transaction transaction)
        {
            return manager.Deposit(transaction);
        }

        [HttpPost("transfer/destacc/{destAccountNum}")]
        public bool Transfer(string destAccountNum, Transaction transaction)
        {
            return manager.Transfer(destAccountNum, transaction);
        }

        [HttpGet("history/{accountNum}")]
        public IList<Transaction> GetTransactions(string accountNumber)
        {
            return manager.GetTransactions(accountNumber);
        }
    }
}