namespace Contracts.Account;

public abstract record ViewBalanceResult
{
    private ViewBalanceResult() { }

    public sealed record Success(double Balance) : ViewBalanceResult;

    public sealed record AccessError : ViewBalanceResult;
}