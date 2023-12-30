using Abstractions.Bank;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace DataAccess.Managers;

public class BankManager : IBankManager
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankManager(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<int> CreateAccount(int pinCode)
    {
        const string sql = """
                        INSERT INTO bank_accounts (account_pincode, account_balance)
                        VALUES (:pinCode, 0)
                        RETURNING account_number;
                        """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        {
            await using var command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = sql;
            command.Parameters.AddWithValue(":pinCode", pinCode);

            await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            await reader.ReadAsync();
            {
                return reader.GetInt32(0);
            }
        }
    }

    public async Task<int> GetAdminPin(int adminLogin)
    {
        const string sql = """
                        SELECT account_pincode
                        FROM bank_accounts
                        WHERE user_id = :accountId;
                        """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand();
        command.Connection = connection;
        command.CommandText = sql;
        command.Parameters.AddWithValue("accountId", adminLogin);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return reader.GetInt32(0);
    }
}