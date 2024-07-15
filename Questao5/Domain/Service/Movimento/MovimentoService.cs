using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Interfaces;
using Questao5.Domain.Interfaces.Services;

namespace Questao5.Domain.Service.Movimento
{
    public class MovimentoService : IMovimentoService
    {
        public readonly IContaCorrenteService _contaCorrenteService;
        public readonly IMovimentoCommandStore _movimentoCommandStore;

        public MovimentoService(IContaCorrenteService contaCorrenteService, IMovimentoCommandStore movimentoCommandStore)
        {
            _contaCorrenteService = contaCorrenteService;
            _movimentoCommandStore = movimentoCommandStore;
        }

        public async Task<MovimentoCommandResult> InserirMovimento(MovimentoCommandRequest request)
        {
            var conta = await _contaCorrenteService.BuscarContaAtiva(request.idContaCorrente);

            var result = await _movimentoCommandStore.InserirMovimento(request);

            return result;
        }
    }
}
