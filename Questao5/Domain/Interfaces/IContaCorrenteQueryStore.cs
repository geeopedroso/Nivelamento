using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IContaCorrenteQueryStore
    {
        Task<ContaCorrenteEntity> BuscarContaAtiva(string idConta);
    }
}
