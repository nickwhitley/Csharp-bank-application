using BankApplication.ConsoleView;
using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Views
{
    internal class SignUpView : IView
    {
        IViewManager _viewManager;
        public SignUpView(IViewManager viewManager)
        {
            _viewManager = viewManager;
        }

        public void DisplayView()
        {
            throw new NotImplementedException();
        }
    }
}
