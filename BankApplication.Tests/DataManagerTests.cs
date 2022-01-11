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
            UsersData usersData = new UsersData();
            DataManager dataManager = new DataManager();
            IUser user = factory.CreateUser("testFirstName", "testLastName", "test@email.com", 111111111, "testUsername", "testPassword");

            usersData.AddUser(user);
            var returnTuple = dataManager.VerifyUserLogin(user.Username, user.Password);

            Assert.True(returnTuple.Item1);
        }
    }


}
