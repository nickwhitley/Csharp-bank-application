using BankApplication.ConsoleView;
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
        public SignUpView(IViewManager viewManager, IInputValidator inputValidator)
        {
            _viewManager = viewManager;
            _inputValidator = inputValidator;
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
                Console.WriteLine("Invalid email");
                return AskForEmail();
            }
            return email;
        }

        private int AskForSSN()
        {
            Console.WriteLine("SSN:");
            if(int.TryParse(Console.ReadLine(), out int SSN))
            {
                if (_inputValidator.ValidateSSN(SSN))
                {
                    return SSN;
                }
            }
            Console.WriteLine("Please enter your social security number as XXXXXXXXX or XXX-XX-XXXX");
            return AskForSSN();
        }


    }
}
