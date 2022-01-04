using BankApplication.Interfaces;
using BankApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Views.AccountViewMenus
{
    internal class CheckBalancesScreen
    {
        DataManager _dataManager;
        public CheckBalancesScreen(IUser user, DataManager dataManager)
        {
            _dataManager = dataManager;
        }
    }
}
