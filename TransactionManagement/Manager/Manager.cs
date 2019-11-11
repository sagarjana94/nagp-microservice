using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionManagement.DTO;

namespace TransactionManagement
{
    public class Manager
    {
        List<Transaction> transactions;
        List<Account> accounts;
        public Manager()
        {
            accounts = new List<Account> 
            { 
                new Account{ Number = "1234567890", Balance = 10000 },
                new Account{ Number = "0987654321", Balance = 10000 }
            };
            transactions = new List<Transaction>();
        }
        public Transaction Withdraw(Transaction transaction)
        {
            var acc = accounts.Where(a => a.Number == transaction.AccountNumber).Single();
            if(acc.Balance > transaction.Amount)
            {
                acc.Balance -= transaction.Amount; 
            }
            else
            {
                throw new InvalidOperationException("Not suffiecient balance");
            }
            transaction.Id = transactions.Count + 1;
            transaction.TransactionDate = DateTime.Now;
            transactions.Add(transaction);
            return transaction;
        }

        public Transaction Deposit(Transaction transaction)
        {
            var acc = accounts.Where(a => a.Number == transaction.AccountNumber).Single();
            acc.Balance += transaction.Amount;
            transaction.Id = transactions.Count + 1;
            transaction.TransactionDate = DateTime.Now;
            transactions.Add(transaction);
            return transaction;
        }

        public bool Transfer(string destAccountNum, Transaction transaction)
        {
            var destAccount = accounts.Where(a => a.Number == destAccountNum).Single();
            Withdraw(transaction);
            Deposit(new Transaction { AccountNumber = destAccountNum, Amount = transaction.Amount });
            return true;
        }

        public IList<Transaction> GetTransactions(string accountNumber)
        {
            return transactions.Where(t => t.AccountNumber == accountNumber).ToList();
        }

    }
}
