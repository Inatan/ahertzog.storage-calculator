using Store.Calculator.Model;
using System;
using System.Collections.Generic;

namespace Store.Calculator.Infrastructure.Repository
{
    public interface IRepositoryValorServico
    {
        void IncluirValorServico(params ValorServico[] valoresServicos);
        void AtualizarValorServico(params ValorServico[] valoresServicos);
        void ExcluirValorServico(params ValorServico[] valoresServicos);
        void LimpaTabelaMateriaEstoque();

        IEnumerable<ValorServico> ObtemValorServico(Func<ValorServico, bool> filtro);
        IEnumerable<ValorServico> ObtemValorServico();
    }
}
