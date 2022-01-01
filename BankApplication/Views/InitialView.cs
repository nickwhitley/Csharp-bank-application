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
            Console.WriteLine("Welcome!\n" +
                "Please select an option below:\n" +
                "1. Login\n" +
                "2. Sign Up");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    _viewManager.ChangeView(ViewManager.View.LoginView);
                    break;
            }

        }


    }
}
