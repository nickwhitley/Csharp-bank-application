using BankApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.ConsoleView
{
    internal interface IViewManager
    {

        public void ClearScreen();

        public void ChangeView(ViewManager.View view);

        public void ChangeToAccountView(IUser user);
    }
}
