using ServiceRequestManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestManagement
{
    public class Manager
    {
        List<Cheque> cheques;
        public Manager()
        {
            cheques = new List<Cheque>();
        }

        public bool Order(string accountNumber)
        {
            cheques.Add(new Cheque { AccountNumber = accountNumber, IsActive = true, Id = cheques.Count });
            return true;
        }

        public bool Block(int chequeBookId)
        {
            var cheque = cheques.Where(c => c.Id == chequeBookId).Single();
            cheque.IsActive = false;
            return true;
        }
    }
}
