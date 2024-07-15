using Microsoft.Data.Sqlite;
using Dapper;

using Questao5.Application.Queries.Responses.Saldo;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Sqlite;
using System.Data;

namespace Questao5.Infrastructure.Database.QueryStore.ContaCorrente
{
    public class ContaCorrenteQueryStore : IContaCorrenteQueryStore
    {
        private readonly DatabaseConfig databaseConfig;

        public ContaCorrenteQueryStore(DatabaseConfig databaseConfig)
        {
            this.databaseConfig=databaseConfig;
        }

        public async Task<ContaCorrenteEntity>? BuscarContaAtiva(string idConta)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            var sql = @"SELECT idcontacorrente, numero, nome, ativo FROM contacorrente WHERE idcontacorrente = @id;";

            var parametros = new DynamicParameters();
            parametros.Add("@id", idConta, DbType.String);

            var response = await connection.QueryFirstOrDefaultAsync<ContaCorrenteEntity>(sql, parametros);

            return response;
        }
    }
}
