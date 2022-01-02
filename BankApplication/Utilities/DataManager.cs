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
    }
}
