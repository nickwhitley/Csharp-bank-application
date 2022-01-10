using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Enums;

namespace BankApplication.BankAccounts
{
    internal class BankAccount : IBankAccount
    {
        #region properties
        private int _accountNumber;
        private decimal _accountBalance;
        private BankAccountType _bankAccountType;

        public int AccountNumber => _accountNumber;

        public decimal AccountBalance => _accountBalance;

        IAccountNumberManager _accountNumberManager;
        #endregion

        public BankAccount(IAccountNumberManager accountNumberManager, decimal intialDeposit, BankAccountType accountType)
        {
            _accountNumberManager = accountNumberManager;
            _accountNumber = _accountNumberManager.GenerateAccountNumber();
            _bankAccountType = accountType;
            _accountBalance = intialDeposit;

        }
        
        public void CloseAccount()
        {
            throw new NotImplementedException();
        }

        public void DepositFunds(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void TransferFunds(decimal amount, IBankAccount recipientAccount)
        {
            throw new NotImplementedException();
        }

        public void WithdrawFunds(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
