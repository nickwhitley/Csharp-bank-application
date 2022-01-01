using BankApplication.ConsoleView;
using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Views
{
    internal class InitialView : IView
    {
        IViewManager _viewManager;
        public InitialView(IViewManager viewManager)
        {
            _viewManager = viewManager;
            DisplayView();
        }
        public void DisplayView()
        {
            PrintWelcomeMessage();

            uint choice = GetUserChoice(2);

            switch (choice)
            {
                case 1:
                    _viewManager.ChangeView(ViewManager.View.LoginView);
                    break;
                case 2:
                    _viewManager.ChangeView(ViewManager.View.SignUpView);
                    break;
            }

        }

        private void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome!\n" +
                "Please select an option below:\n" +
                "1. Login\n" +
                "2. Sign Up");
        }

        private uint GetUserChoice(int choiceMax)
        {
            uint choice;
            if(uint.TryParse(Console.ReadLine(), out choice))
            {
                if(choice <= choiceMax)
                {
                    return choice;
                }

                Console.WriteLine($"selection must be between 0 and { choiceMax }. Please try again.");
                return GetUserChoice(choiceMax);
            }
            Console.WriteLine($"please enter the number of your selection.");
            return GetUserChoice(choiceMax);
        }


    }
}
