using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.Account;
using Models.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TestAccountManager : IAccountManager
{
    public double Balance { get; set; }

    public Task<double> GetAccountBalance(Account account)
    {
        return Task.FromResult(Balance);
    }

    public void SetAccountBalance(Account account, double newBalance)
    {
        Balance = newBalance;
    }

    public Task<IEnumerable<string>> GetAccountHistory(Account account)
    {
        throw new System.NotImplementedException();
    }
}