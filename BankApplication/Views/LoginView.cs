using BankApplication.ConsoleView;
using BankApplication.Interfaces;
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

        public LoginView(IViewManager viewManager)
        {
            _viewManager = viewManager;
            DisplayView();
        }

        public void DisplayView()
        {
            Console.WriteLine("siiiiiick");
        }
    }
}
