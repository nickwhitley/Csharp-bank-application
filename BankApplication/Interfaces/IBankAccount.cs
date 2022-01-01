using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Interfaces
{
    internal interface IBankAccount
    {
        int AccountNumber { get; }
        Decimal AccountBalance { get; }
        void WithdrawFunds(Decimal amount);
        void DepositFunds(Decimal amount);
        void TransferFunds(Decimal amount, IBankAccount recipientAccount);
        void CloseAccount();
    }
}
