using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Interfaces
{
    internal interface IUsersData
    {
        List<IUser> Users { get; }

        void AddUser(IUser user);

        void RemoveUser(IUser user);

        IUser TryGetUser(string username);

        /// <summary>
        /// Used to check if there's an existing user with given username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns> A Tuple<bool, IUser>, Item1 is true if user exists, Item2 is the user itself.</bool></returns>
        bool VerifyUsernameAndPassword(string username, string password);
    }
}
