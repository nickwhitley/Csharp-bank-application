using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Interfaces
{
    internal interface IUser
    {
        string firstName { get; }
        string lastName { get; }
        string email { get; }
        string ssn { get; }
        string username { get; }
        string password { get; }

    }
}
