using Store.Calculator.Infrastructure.Repository;
using Store.Calculator.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Store.Calculator.Services.Handlers
{
    public class ValorServicoHandler : IValorServicoHandler
    {
        IRepositoryValorServico _repo;

        public ValorServicoHandler(IRepositoryValorServico repo)
        {
            _repo = repo;
        }

        public void Cadastra(ValorServico comando)
        {
           _repo.IncluirValorServico(comando);
        }

        public void CadastraLista(List<ValorServico> comando)
        {
           _repo.IncluirValorServico(comando.ToArray());
        }

        public void Altera(ValorServico comando)
        {
            _repo.AtualizarValorServico(comando);
        }

        public void Deleta(ValorServico comando)
        {
            _repo.ExcluirValorServico(comando);
        }

        public void LimpaTable()
        {
            _repo.LimpaTabelaMateriaEstoque();
        }

        public List<ValorServico> Listar()
        {
            return _repo.ObtemValorServico().ToList() ?? new List<ValorServico>();
        }
    }
}
