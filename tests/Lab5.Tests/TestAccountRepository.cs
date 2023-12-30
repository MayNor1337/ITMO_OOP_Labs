using System.Threading.Tasks;
using Abstractions.Account;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TestAccountRepository : IAccountRepository
{
    public Task<bool> IsAccountNotFound(int accountId)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> GetAccountPin(int accountId)
    {
        throw new System.NotImplementedException();
    }
}