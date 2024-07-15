using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Interfaces.Services;

namespace Questao5.Application.Handlers.Movimento
{
    public class MovimentoContaHandler : IRequestHandler<MovimentoCommandRequest, MovimentoCommandResult>
    {
        public readonly IMovimentoService _movimentoService;
        public MovimentoContaHandler(IMovimentoService movimentoService)
        {
            _movimentoService = movimentoService;
        }

        public async Task<MovimentoCommandResult> Handle(MovimentoCommandRequest request, CancellationToken cancellationToken)
        {
            var retorno = await _movimentoService.InserirMovimento(request);

            return retorno;
        }
    }
}
