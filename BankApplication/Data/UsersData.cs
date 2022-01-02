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
    }
}
