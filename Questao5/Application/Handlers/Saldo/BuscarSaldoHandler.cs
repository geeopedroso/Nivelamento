using MediatR;
using Questao5.Application.Queries.Requests.Saldo;
using Questao5.Application.Queries.Responses.Saldo;
using Questao5.Domain.Interfaces;
using Questao5.Domain.Interfaces.Services;

namespace Questao5.Application.Handlers.Saldo
{
    public class BuscarSaldoHandler : IRequestHandler<BuscarSaldoQueryRequest, BuscarSaldoQueryResult>
    {
        public readonly ISaldoService _saldoService;
        public BuscarSaldoHandler(ISaldoService saldoService)
        {
            _saldoService = saldoService;
        }

        public async Task<BuscarSaldoQueryResult> Handle(BuscarSaldoQueryRequest request, CancellationToken cancellationToken)
        {
            var saldo = await _saldoService.BuscarSaldo(request);

            return saldo;
        }
    }
}
