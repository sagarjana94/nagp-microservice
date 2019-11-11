using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionManagement.DTO
{
    public class Transaction
    {
        public long Id { get; set; }
        public float Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string AccountNumber { get; set; }
    }
}
