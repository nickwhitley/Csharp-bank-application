using BankApplication.ConsoleView;
using BankApplication.Interfaces;
using BankApplication.Utilities;
using BankApplication.Views.AccountViewMenus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Views
{
    internal class AccountView : IView
    {
        IViewManager _viewManager;
        IUser _user;
        DataManager _dataManager;
        public AccountView(IViewManager viewManager, IUser user, DataManager dataManager)
        {
            _viewManager = viewManager;
            _user = user;
            _dataManager = dataManager;

            DisplayView();
        }
        public void DisplayView()
        {
            PrintWelcome();
        }

        private void PrintWelcome()
        {
            Console.WriteLine($"Hello { _user.FullName }");
            PrintMenu();
            GetMenuChoice();
        }

        private void PrintMenu()
        {
            Console.WriteLine("Please select an option below:\n" +
                "1. Check balances\n" +
                "2. Transfer\n" +
                "3. Deposit\n" +
                "4. Withdraw\n" +
                "5. View/Change information\n" +
                "6. View Transactions\n" +
                "7. Open Account\n" +
                "8. Close Account\n" +
                "9. Logout");
        }

        private void GetMenuChoice()
        {
            int choice;
            Console.WriteLine($"please enter the number of your selection.");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CheckBalancesScreen checkBalances = new CheckBalancesScreen(this._user, _dataManager);
                        break;
                    case 2:
                        TransferScreen transfer = new TransferScreen();
                        break;
                    case 3:
                        DepositScreen deposit = new DepositScreen();
                        break;
                    case 4:
                        WithdrawScreen withdraw = new WithdrawScreen();
                        break;
                    case 5:
                        ViewInformationScreen viewInformation = new ViewInformationScreen();
                        break;
                    case 6:
                        TransactionsScreen transactions = new TransactionsScreen();
                        break;
                    case 7:
                        OpenAccountScreen openAccount = new OpenAccountScreen();
                        break;
                    case 8:
                        CloseAccountScreen closeAccount = new CloseAccountScreen();
                        break;
                    case 9:
                        Logout();
                        break;
                    default:
                        Console.WriteLine("Incorrect input. Please try again.");
                        GetMenuChoice();
                        break;

                }
            }
        }

        private void Logout()
        {
            _viewManager.ChangeView(ViewManager.View.InitialView);
        }
    }
}
