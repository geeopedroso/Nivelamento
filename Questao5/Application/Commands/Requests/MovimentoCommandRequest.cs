using Questao5.Application.Commands.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentoCommandRequest : IRequest<MovimentoCommandResult>, IValidatableObject
    {
        [Required]
        public string IdMovimento { get; set; }
        [Required]
        public string idContaCorrente { get; set; }
        [Required]
        public DateTime DataMovimento { get; set; }
        [Required]
        public double  Valor { get; set; }
        [Required]
        public string TipoMovimento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if(Valor < 0)
            {
                results.Add(new ValidationResult("INVALID_VALUE: Valor precisa ser positivo", new[] { nameof(Valor) }));
            }

            if(TipoMovimento != "C" && TipoMovimento != "D")
            {
                results.Add(new ValidationResult("INVALID_TYPE: Tipo movimento invalido", new[] { nameof(TipoMovimento) }));
            }

            return results;
        }
    }
}
