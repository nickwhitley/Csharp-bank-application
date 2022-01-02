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
    }
}
