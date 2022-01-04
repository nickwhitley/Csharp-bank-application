using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApplication.Utilities
{
    internal class InputValidator : IInputValidator
    {
        public bool ValidateEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return mail.Host.Contains(".");
            } catch (Exception e)
            {
                Console.WriteLine("Invalid email. Please try again.");
                return false;
            }

        }

        public bool ValidateName(string name)
        {
            int nameMaxLength = 18;
            if(name.Length > nameMaxLength)
            {
                Console.WriteLine($"Name can be no longer than { nameMaxLength }. Please try again.");
                return false;
            }
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Name must only contain letters, no numbers or special characters.");
                return false;
            }
            return true;
        }


        public bool ValidatePassword(string password, string passwordVerify)
        {
            int passwordMinLength = 8;
            int passwordMaxLength = 15;
            if(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordVerify))
            {
                Console.WriteLine("Passwords can't be empty.");
                return false;
            }
            if (!password.Equals(passwordVerify))
            {
                Console.WriteLine("Passwords must match.");
                return false;
            }
            if(password.Length < passwordMinLength || password.Length > passwordMaxLength)
            {
                Console.WriteLine($"Passwords must be between { passwordMinLength } and { passwordMaxLength } characters in length.");
                return false;
            }
            return true;
        }

        public bool ValidateSSN(int ssn)
        {
            if(!ssn.ToString().Length.Equals(9))
            {
                Console.WriteLine("Please enter your social security number as XXXXXXXXX with 9 numbers");
                return false;
            }
            return true;
            
        }

        public bool ValidateUsername(string username)
        {
            int usernameMaxLength = 15;
            int usernameMinLength = 8;
            if(username.Length > usernameMaxLength)
            {
                Console.WriteLine("Username must be between 8 and 15 characters in length. Please try again.");
                return false;
            }
            if(username.Length < usernameMinLength)
            {
                Console.WriteLine("Username must be between 8 and 15 characters in length. Please try again.");
                return false;
            }
            return true;
        }
    }
}
