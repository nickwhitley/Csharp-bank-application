using BankApplication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Interfaces
{
    internal interface ITransaction
    {
        public decimal TransactionAmount { get; }
        public IBankAccount? FromAccount { get; }
        public IBankAccount? ToAccount { get; }
        public TransactionType TransactionType { get; }
        public DateTime TransactionDateTime { get; }
        public void LogTransaction(ITransaction transaction);
    }
}
