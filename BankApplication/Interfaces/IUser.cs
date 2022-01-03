using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Interfaces
{
    internal interface IUser
    {
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        int SSN { get; }
        string Username { get; }
        string Password { get; }
        string FullName { get; }

    }
}
