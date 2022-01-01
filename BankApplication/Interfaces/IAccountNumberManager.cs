using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Interfaces
{
    internal interface IAccountNumberManager : IAccountNumberGenerator
    {
        List<int> AccountNumbers { get; }
        public void AddAccountNumber(int accountNumber);
        public void RemoveAccountNumber(int accountNumber);

    }
}
