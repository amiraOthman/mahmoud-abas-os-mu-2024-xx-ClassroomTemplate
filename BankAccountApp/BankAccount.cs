using System;
using System.Diagnostics;
using System.Threading;

namespace BankAccountApp
{
    public class BankAccount
    {
        private decimal _balance;

        // Lock object for thread synchronization
        private readonly object _lock = new object();

        // Constructor
        public BankAccount(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        // Implement the Deposit method
        public void Deposit(decimal amount)
        {
            lock (_lock)
            {
                _balance += amount;
                Console.WriteLine($"Deposited: {amount}, New Balance: {_balance}");
            }
        }

        // Implement the Withdraw method
        public void Withdraw(decimal amount)
        {
            lock (_lock)
            {
                if (_balance >= amount)
                {
                    _balance -= amount;
                    Console.WriteLine($"Withdrawn: {amount}, Remaining Balance: {_balance}");
                }
                else
                {
                    Console.WriteLine($"Insufficient funds. Withdrawal of {amount} failed. Current Balance: {_balance}");
                }
            }
        }

        // Implement the GetBalance method
        public decimal GetBalance()
        {
            lock (_lock)
            {
                return _balance;
            }
        }

        static void Main(string[] args)
        {
            // Example usage
            var account = new BankAccount(1000);

            // Create multiple threads to test thread safety
            Thread t1 = new Thread(() => {
                account.Deposit(500);
                account.Withdraw(300);
                Console.WriteLine($"Balance from Thread 1: {account.GetBalance()}");
            });

            Thread t2 = new Thread(() => {
                account.Deposit(200);
                account.Withdraw(400);
                Console.WriteLine($"Balance from Thread 2: {account.GetBalance()}");
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"Final Balance: {account.GetBalance()}");
        }
    }
}
