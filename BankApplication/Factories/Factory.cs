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

        public ITransaction CreateTransaction(decimal amount, TransactionType transactionType, 
            IBankAccount bankAccount, IBankAccount? bankAccount2)
        {
            if(bankAccount2 == null)
            {
                return new Transaction(amount, transactionType, bankAccount);
            } else
            {
                return new Transaction(amount, transactionType, bankAccount, bankAccount2);
            }
        }

    }
}
