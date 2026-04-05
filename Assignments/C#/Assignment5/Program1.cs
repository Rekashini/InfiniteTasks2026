using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class BankAccount
    {
        private double balance;
        public BankAccount(double initialBalance)
        {
            balance = initialBalance;
        }
        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be greater than zero.");

            balance += amount;
            Console.WriteLine("Deposited: " + amount);
        }
        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be greater than zero.");

            if (amount > balance)
                throw new InsufficientBalanceException("Not enough balance to withdraw.");

            balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }
        public double GetBalance()
        {
            return balance;
        }
    }

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException()
            : base("Insufficient balance in the account.") { }

        public InsufficientBalanceException(string message)
            : base(message) { }
    }
}
