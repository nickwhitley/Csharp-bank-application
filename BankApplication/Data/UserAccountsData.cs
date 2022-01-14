using BankApplication.Enums;
using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Data
{
    internal class UserAccountsData : IUserAccountsData
    {
        private Dictionary<IUser, IBankAccount> userBankAccounts = new Dictionary<IUser, IBankAccount>();
        private Dictionary<IBankAccount, List<ITransaction>> accountTransactions = new Dictionary<IBankAccount, List<ITransaction>>();
       

        public bool AddUserBankAccount(IUser user, IBankAccount bankAccount)
        {
            return userBankAccounts.TryAdd(user, bankAccount);
            
        }

        public List<IBankAccount>? GetUserBankAccounts(IUser user)
        {
            var userAccounts = new List<IBankAccount>();
            foreach (var account in userBankAccounts)
            {
                if(account.Key == user)
                {
                    userAccounts.Add(account.Value);
                }
            }
            if(userAccounts.Count == 0)
            {
                Console.WriteLine("user has no accounts.");
                return null;
            }
            return userAccounts;
        }

        public void RemoveUserBankAccount(IUser user, IBankAccount bankAccount)
        {
            throw new NotImplementedException();
        }

        public bool TryLogTransaction(ITransaction transaction)
        {
            var transactionType = transaction.TransactionType;
            IBankAccount account;
            if(transactionType == TransactionType.Deposit)
            {
                account = transaction.ToAccount;
            } else
            {
                account = transaction.FromAccount;
            }

            var accountTransactionsList = GetAccountTransactionList(account);
            if(accountTransactionsList == null)
            {
                accountTransactionsList = new List<ITransaction>();
                accountTransactionsList.Add(transaction);
                return accountTransactions.TryAdd(account, accountTransactionsList);
            }
            accountTransactionsList.Add(transaction);

            return TransactionLogVerify(transaction, account);
        }

        private List<ITransaction>? GetAccountTransactionList(IBankAccount account)
        {
            foreach (var entry in accountTransactions)
            {
                if(entry.Key == account)
                {
                    return entry.Value;
                }
            }

            return null;
        }

        public bool TransactionLogVerify(ITransaction transaction, IBankAccount account)
        {
            var accountTransactionLog = GetAccountTransactionList(account);
            if(accountTransactionLog == null)
            {
                return false;
            }

            if (!accountTransactionLog.Contains(transaction))
            {
                return false;
            }

            return true;
        }
    }
}
