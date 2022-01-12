using BankApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankApplication.Tests
{
    public class AccountNumberManagerTests
    {
        [Fact]
        public void GenerateAccountNumber_ShouldGenerate()
        {
            AccountNumberManager manager = new AccountNumberManager();
            int accountNumber = manager.GenerateAccountNumber();


            Assert.InRange(accountNumber, manager.accountNumberMin, manager.accountNumberMax);
        }

        [Fact]
        public void AddAccount_ShouldAdd()
        {
            AccountNumberManager manager = new AccountNumberManager();
            int testAccountNum = manager.accountNumberMax;

            manager.AddAccountNumber(testAccountNum);
            bool listContainsAccountNum = manager.AccountNumbers.Contains(testAccountNum);

            Assert.True(listContainsAccountNum);
        }

        [Fact]
        public void RemoveAccount_ShouldRemove()
        {
            AccountNumberManager manager = new AccountNumberManager();
            int testAccountNum = manager.accountNumberMax;

            manager.AddAccountNumber(testAccountNum);
            manager.RemoveAccountNumber(testAccountNum);
            bool listContainsAccountNum = manager.AccountNumbers.Contains(testAccountNum);

            Assert.False(listContainsAccountNum);
        }
    }
}
