﻿using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces.Services
{
    public interface IContaCorrenteService
    {
        Task<ContaCorrenteEntity> BuscarContaAtiva(string idConta);
    }
}
