using BankApplication.Data;
using BankApplication.Enums;
using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.BankAccounts;

namespace BankApplication.Utilities
{
    //should this be static so it doesn't have to be initialized?

    internal class DataManager
    {
        IUsersData usersData = new UsersData();
        IUserAccountsData userAccountsData = new UserAccountsData();

        public void SaveUser(IUser user)
        {
            usersData.AddUser(user);
            Console.WriteLine($"user saved: { user.FirstName }, { user.LastName }, {user.Email}");
        }

        public void RemoveUser(IUser user)
        {
            usersData.RemoveUser(user);
        }

        public IUser GetUser(string username)
        {
            return usersData.TryGetUser(username);
        }

        public bool VerifyUserLogin(string username, string password)
        {
            return usersData.VerifyUsernameAndPassword(username, password);
        }

        public bool SaveUserAccount(IUser user, IBankAccount bankAccount)
        {
            
            return userAccountsData.AddUserBankAccount(user, bankAccount);
        }

        public List<IBankAccount> GetUserBankAccounts(IUser user)
        {
            return userAccountsData.GetUserBankAccounts(user);
        }

        public bool TryLogTransaction(ITransaction transaction)
        {
            /// TODO: Not logging transaction according to unit tests.
            return userAccountsData.TryLogTransaction(transaction);
        }

        public bool VerifyLoggedTransaction(ITransaction transaction, IBankAccount account)
        {
            return userAccountsData.TransactionLogVerify(transaction, account);
        }
    }
}
