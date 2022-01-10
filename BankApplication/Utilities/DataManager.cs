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
    internal class DataManager
    {
        IUsersData usersData = new UsersData();
        IUserAccountsData userAccountsData = new UserAccountsData();

        public void SaveUser(IUser user)
        {
            usersData.AddUser(user);
            Console.WriteLine($"user saved: { user.FirstName }, { user.LastName }, {user.Email}");
        }

        void RemoveUser(IUser user)
        {
            usersData.RemoveUser(user);
        }

        public Tuple<bool, IUser?> VerifyUserLogin(string username, string password)
        {
            var returnTuple = usersData.VerifyUsernameAndPassword(username, password);
            return returnTuple;
        }

        public bool SaveUserAccount(IUser user, IBankAccount bankAccount)
        {
            
            return userAccountsData.AddUserBankAccount(user, bankAccount);
        }
    }
}
