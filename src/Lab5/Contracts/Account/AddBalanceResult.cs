namespace Contracts.Account;

public abstract record AddBalanceResult
{
    private AddBalanceResult() { }

    public sealed record IncorrectDepositAmount : AddBalanceResult;

    public sealed record Success : AddBalanceResult;
    public sealed record AccessError : AddBalanceResult;
}