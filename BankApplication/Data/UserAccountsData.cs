using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Data
{
    internal class UserAccountsData : IUserAccountsData
    {
        private Dictionary<IUser, IBankAccount> _accounts = new Dictionary<IUser, IBankAccount>();
        public Dictionary<IUser, IBankAccount> UserBankAccounts => _accounts;

        public bool AddUserBankAccount(IUser user, IBankAccount bankAccount)
        {
            return UserBankAccounts.TryAdd(user, bankAccount);
            
        }

        public List<IBankAccount> GetUserBankAccounts(IUser user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserBankAccount(IUser user, IBankAccount bankAccount)
        {
            throw new NotImplementedException();
        }
    }
}
