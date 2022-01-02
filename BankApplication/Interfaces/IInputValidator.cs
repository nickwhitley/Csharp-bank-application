using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Interfaces
{
    internal interface IInputValidator
    {
        bool ValidateName(string name);
        bool ValidateUsername(string username);
        bool ValidateEmail(string email);
        bool ValidatePassword(string password, string passwordVerify);
        bool ValidateSSN(int ssn);
        

    }
}
