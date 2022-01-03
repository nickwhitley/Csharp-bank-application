using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public string FirstName => _firstName;

        public string LastName => _lastName;

        public string Email => _email;

        public int SSN => _SSN;

        public string Username => _userName;

        public string Password => _password;
        public string FullName => _firstName + " " + _lastName;

        public User(string firstName, string lastName, string email, int SSN, string username, string password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _SSN = SSN;
            _userName = username;
            _password = password;
            
        }
    }
}
