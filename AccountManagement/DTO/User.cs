using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagement.DTO
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public float Age { get; set; }

        public string Address { get; set; }

        public IList<Account> Accounts { get; set; }
    }
}
