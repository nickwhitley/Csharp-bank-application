using BankApplication.Interfaces;
using BankApplication.Utilities;
using BankApplication.BankAccounts;
using BankApplication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Enums;

namespace BankApplication.Factories
{
    internal class Factory
    {
        IAccountNumberManager _accountNumberManager = new AccountNumberManager();
        public IBankAccount CreateBankAccount(decimal initialDeposit, BankAccountType bankAccountType)
        {
            return new BankAccount(_accountNumberManager, initialDeposit, bankAccountType);
        }

        public IUser CreateUser(string firstName, string lastName, string email, int SSN, string username, string password)
        {
            return new User(firstName, lastName, email, SSN, username.ToLower(), password);
        }

    }
}
