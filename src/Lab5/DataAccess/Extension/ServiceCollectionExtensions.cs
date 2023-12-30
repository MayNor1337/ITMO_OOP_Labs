using Abstractions.Account;
using Abstractions.Bank;
using DataAccess.Managers;
using DataAccess.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extension;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddScoped<IAccountManager, AccountManager>();
        collection.AddScoped<IBankManager, BankManager>();
        collection.AddScoped<IAccountRepository, AccountRepository>();

        return collection;
    }
}