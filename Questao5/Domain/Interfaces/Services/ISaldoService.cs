using Questao5.Application.Queries.Requests.Saldo;
using Questao5.Application.Queries.Responses.Saldo;

namespace Questao5.Domain.Interfaces.Services
{
    public interface ISaldoService
    {
        Task<BuscarSaldoQueryResult> BuscarSaldo(BuscarSaldoQueryRequest request);
    }
}
