using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Questao5.Application.Queries.Responses.Saldo
{
    public sealed class BuscarSaldoQueryResult
    {
        [JsonIgnore]
        public string IdContaCorrente { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public string Data { get; set; }
    }
}
