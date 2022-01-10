using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Enums;
using BankApplication.Factories;
using BankApplication.Utilities;
using BankApplication.Data;
using BankApplication.ConsoleView;

namespace BankApplication.Views.AccountViewMenus
{
    internal class OpenAccountScreen : IView
    {
        Factory _factory;
        DataManager _dataManager;
        IUser _user;
        IViewManager _viewManager;
        public OpenAccountScreen(IUser user, IViewManager viewManager, Factory factory, DataManager dataManager)
        {
            _user = user;
            _viewManager = viewManager;
            _factory = factory;
            _dataManager = dataManager;
            DisplayView();
        }

        public void DisplayView()
        {
            Console.WriteLine("Open Account:");
            PrintAccountChoiceMenu();
            GetAccountSelection();
            Console.ReadKey();
        }

        private void PrintAccountChoiceMenu()
        {
           foreach(int enumValue in Enum.GetValues(typeof(BankAccountType)))
            {
                Console.WriteLine($"{ enumValue }. { Enum.GetName(typeof(BankAccountType), enumValue) }");
            }
        }

        private void GetAccountSelection()
        {
            Console.WriteLine("Enter your selection below: ");
            if(int.TryParse(Console.ReadLine(), out int accountSelection))
            {
                if (!Enum.IsDefined((BankAccountType)accountSelection))
                {
                    Console.WriteLine("Incorrect selection, please try again.");
                    GetAccountSelection();
                }

                OpenAccount((BankAccountType)accountSelection);
            }
        }

        private void OpenAccount(BankAccountType accountSelection)
        {
            Console.WriteLine($"How much would you like to deposit in your { accountSelection.ToString() } account? Please enter amount below:");
            decimal deposit = GetInitialDeposit();
            IBankAccount bankAccount = _factory.CreateBankAccount(deposit, accountSelection);
            if(_dataManager.SaveUserAccount(_user, bankAccount))
            {
                Console.WriteLine("Your account has been created.");

            } else
            {
                Console.WriteLine("Something went wrong, please try again.");
            }
            ReturnToAccountScreen();
            
        }

        private decimal GetInitialDeposit()
        {
            decimal returnDeposit;
            if(decimal.TryParse(Console.ReadLine(),out returnDeposit))
            {
                return returnDeposit;
            }
            Console.WriteLine("Incorrect input, please try again");
            return GetInitialDeposit();
        }

        private void ReturnToAccountScreen()
        {
            _viewManager.ChangeToAccountView(_user);
        }
    }
}
