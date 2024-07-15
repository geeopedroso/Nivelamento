
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Domain.Interfaces
{
    public interface IMovimentoCommandStore
    {
        public Task<MovimentoCommandResult> InserirMovimento(MovimentoCommandRequest request);
    }
}
