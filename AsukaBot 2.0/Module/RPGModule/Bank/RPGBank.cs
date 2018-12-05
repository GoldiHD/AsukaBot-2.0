using AsukaBot_2._0.Module.RPGModule.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsukaBot_2._0.Module.RPGModule.Bank
{
    class RPGBank
    {

        private static List<RPGBankAccount> accounts;

        public RPGBank()
        {
            if (accounts == null)
            {
                accounts = new List<RPGBankAccount>();
            }
        }

        public void CreateAccount()
        {

        }
    }

    class RPGBankAccount
    {
        private int CurrentBalance = 0;

        public bool AddToBalance(int amount, Player user)
        {
            if (user.GetInventory().GetGold() > amount)
            {
                CurrentBalance += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Withdraw(int amount)
        {
            if (amount <= CurrentBalance)
            {
                CurrentBalance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ViewAccount()
        {
            return CurrentBalance;
        }
    }
}
