using Microsoft.Data.Sqlite;
using Dapper;
using Questao5.Infrastructure.Sqlite;
using Questao5.Domain.Interfaces;
using Questao5.Application.Queries.Requests.Saldo;
using Questao5.Application.Queries.Responses.Saldo;
using Questao5.Domain.Entities;
using System.Data;

namespace Questao5.Infrastructure.Database.QueryStore.Saldo
{
    public class SaldoQueryStore : ISaldoQueryStore
    {
        private readonly DatabaseConfig databaseConfig;

        public SaldoQueryStore(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<Double> BuscarSaldo(string tipoMovimento)
        {
            var sql = @"SELECT SUM(valor) from movimento m WHERE m.tipomovimento = @tipo;";

            using var connection = new SqliteConnection(databaseConfig.Name);

            var parametros = new DynamicParameters();
            parametros.Add("@tipo", tipoMovimento, DbType.String);

            var response = await connection.QueryFirstAsync<double>(sql, parametros);

            return response != null ? response : 0;
        }
    }
}
