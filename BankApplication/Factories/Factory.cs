using BankApplication.Interfaces;
using BankApplication.Utilities;
using BankApplication.BankAccount;
using BankApplication.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Factories
{
    internal class Factory
    {
        IAccountNumberManager _accountNumberManager = new AccountNumberManager();
        //public IBankAccount createBankAccount() => new BankAccount();

        //public IUser createUser() => new User();

    }
}
