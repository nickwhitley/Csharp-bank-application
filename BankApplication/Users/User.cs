using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Users
{
    internal class User : IUser
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _SSN;
        private string _userName;
        private string _password;
        public string FirstName => throw new NotImplementedException();

        public string LastName => throw new NotImplementedException();

        public string Email => throw new NotImplementedException();

        public int SSN => throw new NotImplementedException();

        public string Username => throw new NotImplementedException();

        public string Password => throw new NotImplementedException();

        public User(string firstName, string lastName, string email, int SSN, string username, string password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _SSN = SSN;
            _userName = username;
            _password = password;
            Console.WriteLine("USER CREATED!!!!");
        }
    }
}
