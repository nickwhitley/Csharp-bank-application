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
        public SignUpView(IViewManager viewManager)
        {
            _viewManager = viewManager;
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
            var firstName = AskForFirstName();
        }

        private string AskForFirstName()
        {
            Console.WriteLine("First Name:");
            int maxNameLength = 18;
            string firstName = Console.ReadLine().Trim();
           
            if (firstName.Length > maxNameLength)
            {
                Console.WriteLine($"Name is too long, must be at most { maxNameLength } characters. Try again.");
                return AskForFirstName();
            }
            return firstName;

        }
    }
}
