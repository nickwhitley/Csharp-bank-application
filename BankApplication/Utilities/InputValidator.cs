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

        public bool ValidatePassword(string password)
        {
            throw new NotImplementedException();
        }

        public bool ValidateSSN(int ssn)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
