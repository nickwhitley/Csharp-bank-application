using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BankApplication.Interfaces;
using BankApplication.Factories;
using BankApplication.Utilities;
using BankApplication.Data;

namespace BankApplication.Tests
{
    public class DataManagerTests
    {

        [Fact]
        public void SaveUserAccount_ShouldSave()
        {
            // Arrange data to test
            Factory factory = new Factory();
            IUser user = factory.CreateUser("testFirstName", "testLastName", "testemail@test.com", 111111111, "usernameTest", "passwordTest");
            IBankAccount bankAccount = factory.CreateBankAccount(500.00m, Enums.BankAccountType.Checking);
            DataManager dataManager = new DataManager();

            // Act on the data for testing
            bool result = dataManager.SaveUserAccount(user, bankAccount);

            // Assert what should be expected of the test
            Assert.True(result);
        }

        [Fact]
        public void VerifyUserLogin_ShouldPass()
        {
            Factory factory = new Factory();
            DataManager dataManager = new DataManager();
            IUser user = factory.CreateUser("testFirstName", "testLastName", "test@email.com", 111111111, "testUsername", "testPassword");

            dataManager.SaveUser(user);
            var result = dataManager.VerifyUserLogin("testUsername", "testPassword");

            Assert.True(result);
        }

        [Fact]
        public void SaveUser_ShouldPass()
        {
            Factory factory = new Factory();
            DataManager dataManager = new DataManager();
            IUser user = factory.CreateUser("testFirstName", "testLastName", "test@email.com", 111111111, "testUsername", "testPassword");

            dataManager.SaveUser(user);
            var returnedUser = dataManager.GetUser("testUsername");

            Assert.NotNull(returnedUser);
        }

        [Fact]
        public void RemoveUser_ShouldRemove()
        {
            Factory factory = new Factory();
            DataManager dataManager = new DataManager();
            IUser user = factory.CreateUser("testFirstName", "testLastName", "test@email.com", 111111111, "testUsername", "testPassword");

            dataManager.SaveUser(user);
            dataManager.RemoveUser(user);

            Assert.Throws<Exception>(() => dataManager.GetUser("testUsername"));
        }

        [Fact]
        public void GetUserBankAccounts_ShouldNotBeNull()
        {
            Factory factory = new Factory();
            DataManager dataManager = new DataManager();
            IUser user = factory.CreateUser("testName", "testName", "test@email.com", 111111111, "testUsername", "testPassword");
            IBankAccount account = factory.CreateBankAccount(500m, Enums.BankAccountType.Checking);

            dataManager.SaveUser(user);
            dataManager.SaveUserAccount(user, account);
            var userAccounts = dataManager.GetUserBankAccounts(user);

            Assert.NotNull(userAccounts);
        }

        [Fact]
        public void GetUserBankAccounts_ShouldBeNull()
        {
            Factory factory = new Factory();
            DataManager dataManager = new DataManager();
            IUser user = factory.CreateUser("testName", "testName", "test@email.com", 111111111, "testUsername", "testPassword");

            dataManager.SaveUser(user);
            var userAccounts = dataManager.GetUserBankAccounts(user);

            Assert.Null(userAccounts);
        }

        [Fact]
        public void TryLogTransaction_ShouldLogDeposit()
        {
            Factory factory = new Factory();
            DataManager dataManager = new DataManager();
            UserAccountsData userAccountsData = new UserAccountsData();
            IUser user = factory.CreateUser("testName", "testName", "test@email.com", 111111111, "testUsername", "testPassword");
            IBankAccount bankAccount = factory.CreateBankAccount(500.00m, Enums.BankAccountType.Checking);
            ITransaction transaction = factory.CreateTransaction(500.00m, Enums.TransactionType.Deposit, bankAccount, null);

            dataManager.SaveUser(user);
            dataManager.SaveUserAccount(user, bankAccount);

            Assert.True(dataManager.VerifyLoggedTransaction(transaction, bankAccount));
        }
    }


}
