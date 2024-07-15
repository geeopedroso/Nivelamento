using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests.Saldo;
using Questao5.Application.Queries.Responses.Saldo;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly ILogger<MovimentacaoController> _logger;

        public MovimentacaoController(ILogger<MovimentacaoController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Movimento")]
        public Task<MovimentoCommandResult> InserirMovimentacao([FromServices] IMediator mediator, [FromBody] MovimentoCommandRequest request)
        {
            return mediator.Send(request);
        }
    }
}
