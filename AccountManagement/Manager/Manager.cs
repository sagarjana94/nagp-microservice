using AccountManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagement
{
    public class Manager
    {
        private List<User> users;
        private List<string> existsAccountNumbers;
        public Manager()
        {
            users = new List<User>();
            existsAccountNumbers = new List<string>();
        }

        public User AddUser(User user)
        {
            user.Id = users.Count + 1;
            foreach(var account in user.Accounts)
            {
                account.Number = GetUniqueAccountNumber();
            }
            users.Add(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            var u = users.Where(x => x.Id == user.Id).Single();
            u.Address = user.Address;
            u.Age = user.Age;
            u.Name = user.Name;
            return u;
        }


        public Account CreateAccount(long userId, Account account)
        {
            var user = users.Where(u => u.Id == userId).Single();
            account.Number = GetUniqueAccountNumber();
            user.Accounts.Add(account);
            return account;
        }

        public Account UpdateAccount(Account acc)
        {
            var account = users.SelectMany(u=>u.Accounts).Where(a => a.Number == acc.Number).Single();
            account.IsActive = account.IsActive;
            account.Branch = account.Branch;
            return account;
        }

        public bool CloseAccount(string number)
        {
            var account = users.SelectMany(u => u.Accounts).Where(acc => acc.Number == number).Single();
            account.IsActive = false;
            return true;
        }

        public List<Account> GetAccountsByUser(long userId)
        {
            return users.Where(u => u.Id == userId).Single().Accounts.ToList();
        }


        private string GetUniqueAccountNumber()
        {
            Random R = new Random();
            var num = (R.Next(0, 100000) * R.Next(0, 100000)).ToString().PadLeft(10, '0');
            while (existsAccountNumbers.Contains(num))
            {
                num = (R.Next(0, 100000) * R.Next(0, 100000)).ToString().PadLeft(10, '0');
            }
            return num;
        }
    }
}
