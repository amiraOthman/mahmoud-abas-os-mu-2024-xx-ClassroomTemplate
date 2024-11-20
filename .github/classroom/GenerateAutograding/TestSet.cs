namespace GenerateAutograding;

internal sealed class TestSet
{
    private readonly string _startupProject;

    public TestSet(string startupProject) => _startupProject = startupProject;

    public IReadOnlyList<Test> Tests => new Test[]
    {
        new DotnetTestGroup("Deposit_ShouldIncreaseBalance")
        {
            Points = 1
        },
        new DotnetTestGroup("Withdraw_ShouldDecreaseBalance_WhenSufficientFunds")
        {
            Points = 1
        },
        new DotnetTestGroup("Withdraw_ShouldNotAllowOverdraft")
        {
            Points = 1
        },
        new DotnetTestGroup("ConcurrentDepositsAndWithdrawals_ShouldMaintainCorrectBalance")
        {
            Points = 1
        },
        new DotnetTestGroup("ConcurrentOperations_ShouldBeThreadSafe")
        {
            Points = 1
        },
    };
}