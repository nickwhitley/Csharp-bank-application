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
        internal readonly int accountNumberMin = 111111111;
        internal readonly int accountNumberMax = 999999999;

        private List<int> _accountNumbers = new List<int>();
        public List<int> AccountNumbers => _accountNumbers;

        public void AddAccountNumber(int accountNumber)
        {
            AccountNumbers.Add(accountNumber);
        }

        public int GenerateAccountNumber()
        {
            Random random = new Random();
            int accountNumber = random.Next(accountNumberMin, accountNumberMax);
            if (AccountNumbers.Contains(accountNumber))
            {
                return GenerateAccountNumber();
            }
            AddAccountNumber(accountNumber);
            return accountNumber;

        }

        public void RemoveAccountNumber(int accountNumber)
        {
            AccountNumbers?.Remove(accountNumber);
        }
    }
}
