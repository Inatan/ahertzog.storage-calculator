using Store.Calculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Calculator.Infrastructure.Repository
{
    public class RepositoryValorServico : IRepositoryValorServico
    {
        DbEstoqueContext _ctx;

        public RepositoryValorServico(DbEstoqueContext ctx)
        {
            _ctx = ctx;
        }

        public void AtualizarValorServico(params ValorServico[] valores)
        {
            _ctx.ValorServico.UpdateRange(valores);
            _ctx.SaveChanges();
        }

        public void ExcluirValorServico(params ValorServico[] valores)
        {
            _ctx.ValorServico.RemoveRange(valores);
            _ctx.SaveChanges();
        }

        public void IncluirValorServico(params ValorServico[] valores)
        {
            _ctx.ValorServico.AddRange(valores);
            _ctx.SaveChanges();
        }

        public void LimpaTabelaMateriaEstoque()
        {
            foreach (var servico in _ctx.ValorServico)
                _ctx.ValorServico.Remove(servico);
            _ctx.SaveChanges();
        }

        public IEnumerable<ValorServico> ObtemValorServico(Func<ValorServico, bool> filtro)
        {
            return _ctx.ValorServico.Where(filtro);
        }

        public IEnumerable<ValorServico> ObtemValorServico()
        {
            return _ctx.ValorServico;
        }
    }
}
