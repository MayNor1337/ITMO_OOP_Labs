using System.Data;
using Abstractions.Account;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<bool> IsAccountNotFound(int accountId)
    {
        const string sql = """
                        SELECT user_id
                        FROM users
                        WHERE user_id = :accountId;
                        """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        {
            await using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandText = sql;
                command.Parameters.AddWithValue("accountId", accountId);

                await using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    return !await reader.ReadAsync();
                }
            }
        }
    }

    public async Task<int> GetAccountPin(int accountId)
    {
        const string sql = """
                           SELECT account_pincode
                           FROM bank_accounts
                           WHERE user_id = :accountId;
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        {
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync(); // Открываем соединение явно, только если оно еще не открыто
            }

            await using var command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = sql;
            command.Parameters.AddWithValue("accountId", accountId);

            await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            await reader.ReadAsync();
            {
                return reader.GetInt32(0);
            }
        }
    }
}