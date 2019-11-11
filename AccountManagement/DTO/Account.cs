using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagement.DTO
{
    public class Account
    {
        public string Number { get; set; }

        public Branch Branch { get; set; }

        public bool IsActive { get; set; }

        public float Balance { get; set; }
    }
}
