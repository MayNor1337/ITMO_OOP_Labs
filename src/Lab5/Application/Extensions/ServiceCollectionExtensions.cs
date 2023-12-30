using Application.Account;
using Application.Bank;
using Contracts.Account;
using Contracts.BankSystem;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountsService, AccountService>();
        collection.AddScoped<IBankService, BankService>();

        return collection;
    }
}