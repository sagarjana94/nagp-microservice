using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestManagement.DTO
{
    public class Cheque
    {
        public long Id { get; set; }

        public string AccountNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
