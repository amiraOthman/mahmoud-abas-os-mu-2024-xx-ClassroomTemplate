using BankAccountApp;

namespace BankAccountTests;

public class BankAccountTests
{
    [Fact]
    [Trait("TestGroup", "Deposit_ShouldIncreaseBalance")]
    public void Deposit_ShouldIncreaseBalance()
    {
        // Arrange
        var account = new BankAccount(1000);

        // Act
        account.Deposit(500);

        // Assert
        Assert.Equal(1500, account.GetBalance());
    }

    [Fact]
    [Trait("TestGroup", "Withdraw_ShouldDecreaseBalance_WhenSufficientFunds")]
    public void Withdraw_ShouldDecreaseBalance_WhenSufficientFunds()
    {
        // Arrange
        var account = new BankAccount(1000);

        // Act
        account.Withdraw(400);

        // Assert
        Assert.Equal(600, account.GetBalance());
    }

    [Fact]
    [Trait("TestGroup", "Withdraw_ShouldNotAllowOverdraft")]
    public void Withdraw_ShouldNotAllowOverdraft()
    {
        // Arrange
        var account = new BankAccount(500);

        // Act
        account.Withdraw(600);

        // Assert
        Assert.Equal(500, account.GetBalance());
    }

    [Fact]
    [Trait("TestGroup", "ConcurrentDepositsAndWithdrawals_ShouldMaintainCorrectBalance")]
    public void ConcurrentDepositsAndWithdrawals_ShouldMaintainCorrectBalance()
    {
        // Arrange
        var account = new BankAccount(1000);
        var threads = new Thread[10];

        // Act
        for (int i = 0; i < 5; i++)
        {
            threads[i] = new Thread(() => account.Deposit(100));
            threads[i + 5] = new Thread(() => account.Withdraw(50));
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        // Assert
        Assert.Equal(1250, account.GetBalance());
    }

    [Fact]
    [Trait("TestGroup", "ConcurrentOperations_ShouldBeThreadSafe")]
    public void ConcurrentOperations_ShouldBeThreadSafe()
    {
        // Arrange
        var account = new BankAccount(1000);
        var threads = new Thread[100];

        // Act
        for (int i = 0; i < 50; i++)
        {
            threads[i] = new Thread(() => account.Deposit(10));
            threads[i + 50] = new Thread(() => account.Withdraw(10));
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        // Assert
        Assert.Equal(1000, account.GetBalance());
    }
}