using BankApplication.Enums;
using BankApplication.Interfaces;
using BankApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.BankAccounts
{
    internal class Transaction : ITransaction
    {
        decimal _transactionAmount;
        TransactionType _transactionType;
        IBankAccount? _fromAccount;
        IBankAccount? _toAccount;
        DateTime _transactionDateTime;

        public decimal TransactionAmount => _transactionAmount;

        public IBankAccount? FromAccount => _fromAccount;

        public IBankAccount? ToAccount => _toAccount;

        public TransactionType TransactionType => _transactionType;

        public DateTime TransactionDateTime => _transactionDateTime;

        DataManager dataManager = new DataManager();

        public Transaction(decimal transactionAmount, TransactionType transactionType, IBankAccount account)
        {
            _transactionAmount = transactionAmount;
            _transactionType = transactionType;
            if(_transactionType == TransactionType.Deposit)
            {
                _toAccount = account;
            } else if(( _transactionType == TransactionType.Withdrawal ) || ( _transactionType == TransactionType.ClosingWithdrawal ))
            {
                _fromAccount = account;
            }
            _transactionDateTime = DateTime.Now;
            LogTransaction(this);
            
        }


        public Transaction(decimal transactionAmount, TransactionType transactionType, IBankAccount fromAccount,
            IBankAccount toAccount)
        {
            _transactionAmount = transactionAmount;
            _transactionType = transactionType;
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _transactionDateTime = DateTime.Now;
            LogTransaction(this);
        }

        

        public void LogTransaction(ITransaction transaction)
        {
            bool transactionLogged = dataManager.TryLogTransaction(this);
            if (!transactionLogged)
            {
                throw new Exception("error when logging new transaction");
            }
        }

    }
}
