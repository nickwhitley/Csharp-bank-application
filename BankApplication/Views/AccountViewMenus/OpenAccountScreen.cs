using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Enums;

namespace BankApplication.Views.AccountViewMenus
{
    internal class OpenAccountScreen : IView
    {
        public OpenAccountScreen()
        {
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
            Console.WriteLine(accountSelection.ToString());
        }
    }
}
