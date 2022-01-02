using BankApplication.ConsoleView;
using BankApplication.Factories;
using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Views
{
    internal class SignUpView : IView
    {
        IViewManager _viewManager;
        IInputValidator _inputValidator;
        Factory _factory;
        public SignUpView(IViewManager viewManager, IInputValidator inputValidator, Factory factory)
        {
            _viewManager = viewManager;
            _inputValidator = inputValidator;
            _factory = factory;
            DisplayView();
        }

        public void DisplayView()
        {
            PrintSignUpForm();
        }

        private void PrintSignUpForm()
        {
            Console.WriteLine("SIGN UP:\n" +
                "Please enter the following information:");
            var firstName = AskForName("first");
            var lastName = AskForName("last");
            var email = AskForEmail();
            var SSN = AskForSSN();
            var username = AskForUsername();
            var password = AskForPassword();
            _factory.createUser(firstName, lastName, email, SSN, username, password);
            
            
        }


        private string AskForName(string nameType)
        {
            Console.WriteLine($"{ nameType } Name:");
            string name = Console.ReadLine().Trim();

            if (!_inputValidator.ValidateName(name))
            {
                return AskForName(nameType);
            }
            return name;

        }

        private string AskForEmail()
        {
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            if (!_inputValidator.ValidateEmail(email))
            {
                return AskForEmail();
            }
            return email;
        }

        private int AskForSSN()
        {
            Console.WriteLine("SSN:");
            if(int.TryParse(Console.ReadLine(), out int SSN))
            {
                if (!_inputValidator.ValidateSSN(SSN))
                {
                    return AskForSSN();
                }
            }
            return SSN;
        }

        private string AskForUsername()
        {
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            if (!_inputValidator.ValidateUsername(username))
            {
                return AskForUsername();
            }
            return username;
        }

        private string AskForPassword()
        {
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            Console.WriteLine("Verify Password:");
            string passwordVerify = Console.ReadLine();
            if(!_inputValidator.ValidatePassword(password, passwordVerify))
            {
                return AskForPassword();
            }
            return password;
        }

    }
}
