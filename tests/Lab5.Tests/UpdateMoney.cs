using System;
using Application.Account;
using Contracts.Account;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class UpdateMoney
{
    [Fact]
    private void WithdrawalsMoneyResult_CorrectUpdateBalance_NewBalanceIsCorrect()
    {
        // Arrange
        var repository = new TestAccountRepository();
        var manager = new TestAccountManager
        {
            Balance = 120,
        };

        var with = new AccountService(repository, manager);

        // Act
        with.WithdrawMoney(100);
        ViewBalanceResult result = with.ViewAccountBalance();

        // Assert
        if (result is ViewBalanceResult.Success success)
            Assert.True(Math.Abs(success.Balance - 20) < 0.001);
        else
            Assert.True(false);
    }

    [Fact]
    private void WithdrawalsMoneyResult_Error_WithdrawalIsNotPossible()
    {
        // Arrange
        var repository = new TestAccountRepository();
        var manager = new TestAccountManager
        {
            Balance = 20,
        };

        var with = new AccountService(repository, manager);

        // Act
        WithdrawalsMoneyResult result = with.WithdrawMoney(100);

        // Assert
        Assert.True(result is WithdrawalsMoneyResult.NotEnoughMoney);
    }

    [Fact]
    private void AddAccountBalance_CorrectUpdateBalance()
    {
        // Arrange
        var repository = new TestAccountRepository();
        var manager = new TestAccountManager
        {
            Balance = 20,
        };

        var with = new AccountService(repository, manager);

        // Act
        with.AddAccountBalance(100);
        ViewBalanceResult result = with.ViewAccountBalance();

        // Assert
        if (result is ViewBalanceResult.Success success)
            Assert.True(Math.Abs(success.Balance - 120) < 0.001);
        else
            Assert.True(false);
    }
}