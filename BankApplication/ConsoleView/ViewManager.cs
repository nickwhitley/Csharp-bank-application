using BankApplication.Interfaces;
using BankApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.ConsoleView
{
    internal class ViewManager : IViewManager
    {
        /// <summary>
        /// ENUM of views: AccountView, InitialView, LoginView, SignUpView.
        /// </summary>
        public enum View
        {
            AccountView,
            InitialView,
            LoginView,
            SignUpView
        }
        public void ChangeView(View view)
        {
            ClearScreen();
            switch (view)
            {
                case View.InitialView:
                    new InitialView(this);
                    break;
                case View.AccountView:
                    new AccountView(this);
                    break;
                case View.LoginView:
                    new LoginView(this);
                    break;
                case View.SignUpView:
                    new SignUpView(this);
                    break;

            }
                

        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
