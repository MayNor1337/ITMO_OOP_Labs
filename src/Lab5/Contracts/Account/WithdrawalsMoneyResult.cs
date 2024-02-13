namespace Contracts.Account;

public abstract record WithdrawalsMoneyResult
{
    private WithdrawalsMoneyResult() { }

    public sealed record Success : WithdrawalsMoneyResult;

    public sealed record NotEnoughMoney : WithdrawalsMoneyResult;

    public sealed record AccessError : WithdrawalsMoneyResult;
}