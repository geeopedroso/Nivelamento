using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Domain.Interfaces.Services;

namespace Questao5.Domain.Service.ContaCorrenteService
{
    public class ContaCorrenteService: IContaCorrenteService
    {
        public readonly IContaCorrenteQueryStore _contaCorrenteQueryStore;

        public ContaCorrenteService(IContaCorrenteQueryStore contaCorrenteQueryStore)
        {
            _contaCorrenteQueryStore = contaCorrenteQueryStore;
        }

        public async Task<ContaCorrenteEntity> BuscarContaAtiva(string idConta)
        {
            var conta = await _contaCorrenteQueryStore.BuscarContaAtiva(idConta);

            if (conta == null)
                throw new Exception("INVALID_ACCOUNT");

            if (conta.Ativo == 0)
                throw new Exception("INACTIVE_ACCOUNT");

            return conta;
        }
    }
}
