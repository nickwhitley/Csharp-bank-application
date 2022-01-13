using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Factories;
using BankApplication.Utilities;
using Xunit;

namespace BankApplication.Tests
{
    public class FactoryTests
    {
        [Fact]
        public void CreateAccount_ShouldCreate()
        {
            var factory = new Factory();
            var account = factory.CreateBankAccount(500.00m, Enums.BankAccountType.Checking);

            Assert.NotNull(account);
        }

        [Fact]
        public void CreateUser_ShouldCreate()
        {
            var factory = new Factory();
            var user = factory.CreateUser("testName", "testName", "test@email.com", 111111111, "testUsername", "testPassword");

            Assert.NotNull(user);
        }
    }
}
