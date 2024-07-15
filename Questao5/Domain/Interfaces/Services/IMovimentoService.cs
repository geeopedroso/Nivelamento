using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Domain.Interfaces.Services
{
    public interface IMovimentoService
    {
        public Task<MovimentoCommandResult> InserirMovimento(MovimentoCommandRequest request);
    }
}
