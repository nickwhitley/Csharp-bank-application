using BankApplication.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankApplication.Tests
{
    public class InputValidatorTests
    {
        [Fact]
        public void ValidateEmail_ShouldPass()
        {
            InputValidator validator = new InputValidator();

            Assert.True(validator.ValidateEmail("test@email.com"));

        }

        [Theory]
        [InlineData("test")]
        [InlineData("test.com")]
        [InlineData("test123$email.com")]
        public void ValidateEmail_ShouldFail(string testEmail)
        {
            InputValidator validator = new InputValidator();

            Assert.False(validator.ValidateEmail(testEmail));
        }

        [Fact]
        public void ValidateName_ShouldPass()
        {
            InputValidator validator = new InputValidator();

            Assert.True(validator.ValidateName("testName"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("1testName1")]
        [InlineData("12344525252")]
        [InlineData("testNameLongerThenMaxAllowedChars")]
        public void ValidateName_ShouldFail(string testName)
        {
            InputValidator validator = new InputValidator();

            Assert.False(validator.ValidateName(testName));
        }

        [Theory]
        [InlineData("testPassword")]
        [InlineData("testPass")]
        [InlineData("testPasswordMax")]
        [InlineData("testPassword123")]
        [InlineData("testPassword1.!")]
        public void ValidatePassword_ShouldPass(string testPassword)
        {
            InputValidator validator = new InputValidator();

            Assert.True(validator.ValidatePassword(testPassword, testPassword));
        }

        [Theory]
        [InlineData("testMin", null)]
        [InlineData("testPasswordPastMaxLength", null)]
        [InlineData("", null)]
        [InlineData("testPassword1", "testPassword2")]
        public void ValidatePassword_ShouldFail(string testPassword, string? testPasswordVerify)
        {
            InputValidator validator = new InputValidator();

            if (testPasswordVerify != null)
            {
                Assert.False(validator.ValidatePassword(testPassword, testPasswordVerify));
            } else
            {
                Assert.False(validator.ValidatePassword(testPassword, testPassword));
            }
        }

        [Fact]
        public void ValidateSSN_ShouldPass()
        {
            InputValidator validator = new InputValidator();
            int testSSN = 123456789;

            Assert.True(validator.ValidateSSN(testSSN));
        }

        [Theory]
        [InlineData(12)]
        [InlineData(1234567891)]
        [InlineData(1)]
        public void ValidateSSN_ShouldFail(int testSSN)
        {
            InputValidator validator = new InputValidator();

            Assert.False(validator.ValidateSSN(testSSN));
        }

        [Theory]
        [InlineData("testUsername")]
        public void ValidateUsername_ShouldPass(string testUsername)
        {
            InputValidator validator = new InputValidator();

            Assert.True(validator.ValidateUsername(testUsername));
        }

        [Theory]
        [InlineData("")]
        [InlineData("testUsernameMaxLengthTest")]
        [InlineData("testMin")]
        public void ValidateUsername_ShouldFail(string testUsername)
        {
            InputValidator validator = new InputValidator();

            Assert.False(validator.ValidateUsername(testUsername));
        }
    }
}
