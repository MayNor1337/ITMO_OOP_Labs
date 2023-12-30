using Abstractions.Account;
using Itmo.Dev.Platform.Postgres.Connection;
using Models.Accounts;
using Npgsql;

namespace DataAccess.Managers;

public class AccountManager : IAccountManager
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountManager(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<double> GetAccountBalance(Account account)
    {
        const string sql = """
                           SELECT account_balance
                           FROM bank_accounts
                           WHERE account_number = :accountId;
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand();
        command.Connection = connection;
        command.CommandText = sql;
        command.Parameters.AddWithValue(":accountId", account.Id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        double result = reader.GetDouble(0);
        return result;
    }

    public async void SetAccountBalance(Account account, double newBalance)
    {
        const string sql = """
                           UPDATE bank_account
                           SET account_balance = :newBalance
                           WHERE account_number = :accountId;
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand();
        command.Connection = connection;
        command.CommandText = sql;
        command.Parameters.AddWithValue(":newBalance", newBalance);
        command.Parameters.AddWithValue(":accountId", account.Id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
    }

    public async Task<IEnumerable<string>> GetAccountHistory(Account account)
    {
        const string sql = """
                           SELECT transaction_id
                           FROM transactions
                           WHERE account_number = :accountId;
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand();
        command.Connection = connection;
        command.CommandText = sql;
        command.Parameters.AddWithValue(":accountId", account.Id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        var result = new List<string>();

        while (await reader.ReadAsync())
            result.Add(reader.GetString(0));

        return result;
    }
}