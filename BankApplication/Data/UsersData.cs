using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Data
{
    internal class UsersData : IUsersData
    {
        private List<IUser> _users = new List<IUser>();
        public List<IUser> Users => _users;

        public void AddUser(IUser user)
        {
            _users.Add(user);
        }

        public void RemoveUser(IUser user)
        {
            _users.Remove(user);
        }

        public Tuple<bool, IUser?> VerifyUsernameAndPassword(string username, string password)
        {
            bool usernameCheck = false;
            bool passwordCheck = false;
            Tuple<bool, IUser>? exisitngUser = new Tuple<bool, IUser>(false, null);

            foreach (var user in _users)
            {
                if (user.Username.Equals(username.ToLower()))
                {
                    usernameCheck = true;
                }
                if (user.Password.Equals(password))
                {
                    passwordCheck = true;
                }
                if(usernameCheck && passwordCheck)
                {
                    Tuple<bool, IUser> existingUser = new Tuple<bool, IUser>(true, user);
                    return existingUser;
                }
            }

            return exisitngUser;
        }
    }
}
