using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Utilities
{
    internal class AccountNumberManager : IAccountNumberManager
    {
        private readonly int accountNumberLength = 12;
        public List<int> AccountNumbers => throw new NotImplementedException();

        public void AddAccountNumber(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public int GenerateAccountNumber()
        {
            throw new NotImplementedException();
        }

        public void RemoveAccountNumber(int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
