using Questao5.Application.Queries.Requests.Saldo;
using Questao5.Application.Queries.Responses.Saldo;

namespace Questao5.Domain.Interfaces
{
    public interface ISaldoQueryStore
    {
        public Task<Double> BuscarSaldo(string tipoMovimento);
    }
}
