using Application.Extensions;
using Console.States.AccountStates;
using Console.States.AdminStates;
using Console.States.MainMenuStates;
using Contracts.Account;
using Contracts.BankSystem;
using DataAccess.Extension;
using Microsoft.Extensions.DependencyInjection;

namespace Console.States.Factory;

public class StandardStatesFactory : IStateFactory
{
    public IState CreateStateMachine()
    {
        var collection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

        collection
            .AddApplication()
            .AddInfrastructureDataAccess(configuration =>
            {
                configuration.Host = "localhost";
                configuration.Port = 5432;
                configuration.Username = "postgres";
                configuration.Password = "postgres";
                configuration.Database = "postgres";
                configuration.SslMode = "prefer";
            });

        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        IAccountsService accountService = scope.ServiceProvider.GetRequiredService<IAccountsService>();
        IBankService bankService = scope.ServiceProvider.GetRequiredService<IBankService>();

        var accountMenu = new AccountMenuState(
            new IState[]
            {
                new ViewAccountBalanceState(accountService),
                new AddMoneyState(accountService),
                new WithdrawMoneyState(accountService),
                new AccountHistory(accountService),
            });

        var adminMenu = new AdminMenuState(new[] { new ExitState() });

        return new MainMenuState(
            new IState[]
            {
                new LoginState(accountService, accountMenu),
                new AdminLogin(bankService, adminMenu),
                new CreateAccountState(bankService),
                new ExitState(),
            });
    }
}