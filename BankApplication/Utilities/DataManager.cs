using BankApplication.Data;
using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
