using MediatR;
using Questao5.Application.Queries.Responses.Saldo;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Queries.Requests.Saldo
{
    public sealed class BuscarSaldoQueryRequest: IRequest<BuscarSaldoQueryResult>
    {
        public string IdContaCorrente { get; set; }
    }
}
