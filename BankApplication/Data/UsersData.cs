using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public IUser TryGetUser(string username)
        {
            foreach (var user in _users)
            {
                if (user.Username == username.ToLower())
                {
                    return user;
                }
            }
            throw new Exception("User does not exist");
        }

        public bool VerifyUsernameAndPassword(string username, string password)
        {
            bool usernameCheck = false;
            bool passwordCheck = false;

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
                    return true;
                }
            }

            return false;
        }
    }
}
