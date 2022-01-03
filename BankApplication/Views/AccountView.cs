using BankApplication.ConsoleView;
using BankApplication.Interfaces;
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
        public AccountView(IViewManager viewManager, IUser user)
        {
            _viewManager = viewManager;
            _user = user;

            DisplayView();
        }
        public void DisplayView()
        {
            Console.WriteLine($"Hello { _user.FullName }");
        }
    }
}
