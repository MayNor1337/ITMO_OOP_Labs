using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create table admins
        (
            admin_id bigint primary key generated always as identity,
            password text not null
        );

        create table bank_accounts
        (
            account_number bigint primary key GENERATED ALWAYS AS IDENTITY,
            account_pincode bigint not null,
            account_balance money not null
        );

        create table transactions
        (
            transaction_id bigint primary key generated always as identity,
            account_number bigint not null references bank_accounts(account_number),
            account_transaction bigint not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table if exists admins;
        drop table if exists bank_accounts;
        drop table if exists transactions;
        """;
}