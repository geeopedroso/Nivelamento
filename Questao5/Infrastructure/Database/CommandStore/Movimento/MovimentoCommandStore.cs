using Microsoft.Data.Sqlite;
using Dapper;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Sqlite;
using System.Data;

namespace Questao5.Infrastructure.Database.CommandStore.Movimento
{
    public class MovimentoCommandStore : IMovimentoCommandStore
    {
        private readonly DatabaseConfig databaseConfig;

        public MovimentoCommandStore(DatabaseConfig databaseConfig)
        {
            this.databaseConfig=databaseConfig;
        }

        public async Task<MovimentoCommandResult> InserirMovimento(MovimentoCommandRequest request)
        {
            string sql = @"INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) VALUES(@idmovimento, @idcontacorrente, @datamovimento, @tipomovimento, @valor);";
            using var connection = new SqliteConnection(databaseConfig.Name);

            try
            {
                var parametros = new DynamicParameters();
                parametros.Add("@idmovimento", request.IdMovimento, DbType.String);
                parametros.Add("@idcontacorrente", request.idContaCorrente, DbType.String);
                parametros.Add("@datamovimento", request.DataMovimento.ToShortDateString(), DbType.String);
                parametros.Add("@tipomovimento", request.TipoMovimento, DbType.String);
                parametros.Add("@valor", request.Valor, DbType.Double);


                var persist = await connection.ExecuteAsync(sql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var response = new MovimentoCommandResult { IdMovimento = request.IdMovimento };

            return response;
        }
    }
}
