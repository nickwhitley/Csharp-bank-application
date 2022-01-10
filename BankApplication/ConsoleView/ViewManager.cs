using BankApplication.Factories;
using BankApplication.Interfaces;
using BankApplication.Utilities;
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

        IInputValidator inputValidator = new InputValidator();
        Factory factory = new Factory();
        DataManager dataManager = new DataManager();
        public void ChangeView(View view)
        {
            ClearScreen();
            switch (view)
            {
                case View.InitialView:
                    new InitialView(this);
                    break;
                case View.LoginView:
                    new LoginView(this, inputValidator, dataManager);
                    break;
                case View.SignUpView:
                    new SignUpView(this, inputValidator, factory, dataManager);
                    
                    break;

            }
                

        }

        public void ChangeToAccountView(IUser user)
        {
            ClearScreen();
            new AccountView(this, user, dataManager, factory);
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
