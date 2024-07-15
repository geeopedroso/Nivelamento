using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries.Requests.Saldo;
using Questao5.Application.Queries.Responses.Saldo;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaldoController : ControllerBase
    {
        private readonly ILogger<SaldoController> _logger;

        public SaldoController(ILogger<SaldoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Saldo")]
        public Task<BuscarSaldoQueryResult> BuscarSaldo([FromServices]IMediator mediator, [FromQuery] BuscarSaldoQueryRequest request)
        {
            return mediator.Send(request);
        }
    }
}
