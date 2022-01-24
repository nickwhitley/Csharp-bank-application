using BankApplication.ConsoleView;
using BankApplication.Interfaces;
using BankApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Views.AccountViewMenus
{
    internal class CheckBalancesScreen
    {
        DataManager _dataManager;
        IUser _user;
        IViewManager _viewManager;
        public CheckBalancesScreen(IUser user, DataManager dataManager, IViewManager viewManager)
        {
            _dataManager = dataManager;
            _user = user;
            _viewManager = viewManager;
            DisplayBalances();
        }

        private void DisplayBalances()
        {
            if (GetAccounts() == null)
            {
                Console.WriteLine("You don't have any accounts open. Returning to main menu.");
                Thread.Sleep(2000);
                _viewManager.ChangeToAccountView(_user);
            }

            var userAccounts = GetAccounts();
            foreach (var account in userAccounts)
            {
                PrintAccountBalanceLine(account);
            }

            DisplayQuitOption();
        }

        private void DisplayQuitOption()
        {
            Console.WriteLine("Press 'q' to go back to account menu.");
            var quitKey = Console.ReadKey();
            if (quitKey.Key == ConsoleKey.Q)
            {
                _viewManager.ChangeToAccountView(_user);
            }
        }

        private void PrintAccountBalanceLine(IBankAccount account)
        {
            string accountNumberLastFour = FormatAccountNumberLastFour(account.AccountNumber);
            string accountType = account.BankAccountType.ToString();
            string accountBalance = account.AccountBalance.ToString("C", CultureInfo.CurrentCulture);

            Console.WriteLine($"{ accountType }({ accountNumberLastFour }):  { accountBalance }");
        }

        private string FormatAccountNumberLastFour(int accountNum)
        {
            string accountNumString = accountNum.ToString();
            return accountNumString.Substring(accountNumString.Length - 4, 4);
        }

        private List<IBankAccount>? GetAccounts()
        {
            return _dataManager.GetUserBankAccounts(_user);
        }
    }
}
