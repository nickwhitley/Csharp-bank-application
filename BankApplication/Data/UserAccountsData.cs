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
        public Dictionary<IUser, IBankAccount> UserBankAccounts => throw new NotImplementedException();

        public void AddUserBankAccount(IUser user, IBankAccount bankAccount)
        {
            throw new NotImplementedException();
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
