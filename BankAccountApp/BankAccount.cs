using System;
using System.Threading;

namespace BankAccountApp
{
    public class BankAccount
    {
        private decimal _balance;

        // TODO: Declare a lock object for thread synchronization
        private readonly object _lock = new object();

        // Constructor
        public BankAccount(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        // TODO: Implement the Deposit method
        // This method should:
        // 1. Use a synchronization mechanism (e.g., lock) to protect the shared balance.
        // 2. Add the amount to the balance.
        // 3. Print a message showing the deposit amount and new balance.
        public void Deposit(decimal amount)
        {
            throw new NotImplementedException("Deposit method not implemented");
        }

        // TODO: Implement the Withdraw method
        // This method should:
        // 1. Use a synchronization mechanism (e.g., lock) to protect the shared balance.
        // 2. Check if there are sufficient funds before withdrawing.
        // 3. Subtract the amount from the balance if possible.
        // 4. Print a message showing the withdrawal amount and remaining balance.
        // 5. If insufficient funds, print an appropriate message.
        public void Withdraw(decimal amount)
        {
            throw new NotImplementedException("Withdraw method not implemented");
        }

        // Method to get the current balance
        // This method is already implemented for you.
        public decimal GetBalance()
        {
            lock (_lock)
            {
                return _balance;
            }
        }

        // Main method to test the implementation (optional)
        public static void Main(string[] args)
        {
            Console.WriteLine("BankAccount simulation started.");

            // TODO: Create a BankAccount instance with an initial balance of 1000.
            BankAccount account = null; // Replace null with proper initialization.

            // TODO: Create multiple threads to simulate deposits and withdrawals.
            // For example:
            // 1. Create 5 threads for deposits.
            // 2. Create 5 threads for withdrawals.

            // TODO: Start all threads and wait for them to complete using Join.

            // TODO: Print the final balance.

            Console.WriteLine("BankAccount simulation completed.");
        }
    }
}
