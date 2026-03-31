using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Accounts
    {
        protected int Account_no;
        protected string cus_name, AccountType;
        protected float balance;

        public Accounts(int Account_no, string cus_name, string AccountType, float balance)
        {
            this.Account_no = Account_no;
            this.cus_name = cus_name;
            this.AccountType = AccountType;
            this.balance = balance;
        }

        public void credit(float amount)
        {
            balance += amount;
            Console.WriteLine("Balance after deposit: " + balance);
        }

        public void debit(float amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance!");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Balance after withdrawal: " + balance);
            }
        }

        public void UpdateBalance(char tType, float amt)
        {
            if (tType == 'D' || tType == 'd')
            {
                credit(amt);
            }
            else if (tType == 'W' || tType == 'w')
            {
                debit(amt);
            }
            else
            {
                Console.WriteLine("Invalid transaction type");
            }
        }
    }

    public class AccountDetails : Accounts
    {
        public AccountDetails(int accNo, string name, string acctype, float bal)
            : base(accNo, name, acctype, bal)
        {
        }

        public void showdata()
        {
            Console.WriteLine("Account No: " + Account_no);
            Console.WriteLine("Customer Name: " + cus_name);
            Console.WriteLine("Account Type: " + AccountType);
            Console.WriteLine("Balance: " + balance);
        }
    }
}
