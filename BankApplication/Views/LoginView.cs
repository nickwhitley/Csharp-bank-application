using BankApplication.ConsoleView;
using BankApplication.Interfaces;
using BankApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Views
{
    internal class LoginView : IView
    {
        IViewManager _viewManager;
        IInputValidator _inputValidator;
        DataManager _dataManager;

        public LoginView(IViewManager viewManager, IInputValidator inputValidator, DataManager dataManager)
        {
            _viewManager = viewManager;
            _inputValidator = inputValidator;
            _dataManager = dataManager;
            DisplayView();
        }

        public void DisplayView()
        {
            PrintLoginForm();
        }

        private void PrintLoginForm()
        {
            Console.WriteLine("Please enter the following:");
            var username = AskForUsername();
            var password = AskForPassword();
            
            VerifyLoginInfo(username, password);
        }

        private string AskForUsername()
        {
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            return username;
        }

        private string AskForPassword()
        {
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            return password;
        }

        private void VerifyLoginInfo(string username, string password)
        {
            if(!(_dataManager.VerifyUserLogin(username, password)))
            {
                Console.WriteLine("Incorrect username or password, please try again.");
                PrintLoginForm();
            } else
            {
                _viewManager.ChangeToAccountView(_dataManager.GetUser(username));
            }
        }
    }
}
