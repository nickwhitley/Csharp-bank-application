using BankApplication.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Interfaces
{
    internal interface IUserAccountsData
    {
        
        List<IBankAccount> GetUserBankAccounts(IUser user);

        bool AddUserBankAccount(IUser user, IBankAccount bankAccount);

        void RemoveUserBankAccount(IUser user, IBankAccount bankAccount);

        bool TryLogTransaction(ITransaction transaction);

        bool TransactionLogVerify(ITransaction transaction, IBankAccount account);
    }
}
