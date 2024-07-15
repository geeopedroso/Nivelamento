using Questao5.Application.Queries.Requests.Saldo;
using Questao5.Application.Queries.Responses.Saldo;
using Questao5.Domain.Interfaces;
using Questao5.Domain.Interfaces.Services;

namespace Questao5.Domain.Service.Saldo
{
    public class SaldoService : ISaldoService
    {
        public readonly IContaCorrenteService _contaCorrenteService;
        public readonly ISaldoQueryStore _saldoQueryStore;

        public SaldoService(IContaCorrenteService contaCorrenteService, ISaldoQueryStore saldoQueryStore)
        {
            _contaCorrenteService = contaCorrenteService;
            _saldoQueryStore = saldoQueryStore;
        }

        public async Task<BuscarSaldoQueryResult> BuscarSaldo(BuscarSaldoQueryRequest request)
        {
            var conta = await _contaCorrenteService.BuscarContaAtiva(request.IdContaCorrente);

            var saldoDebito = await _saldoQueryStore.BuscarSaldo("D");
            var saldoCredito = await _saldoQueryStore.BuscarSaldo("C");

            double saldo = Math.Round((saldoCredito - saldoDebito), 2);

            return new BuscarSaldoQueryResult
            {
                Nome = conta.Nome,
                Numero = conta.Numero,
                Data = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                Saldo = saldo
            };
        }
    }
}
