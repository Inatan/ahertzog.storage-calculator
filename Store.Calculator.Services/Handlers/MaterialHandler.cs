using Microsoft.Extensions.Logging;
using Store.Calculator.Infrastructure.Repository;
using Store.Calculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Calculator.Services.Handlers
{
    public class MaterialHandler : IMaterialHandler
    {
        IRepositoryMaterial _repo;

        public MaterialHandler(IRepositoryMaterial repo)
        {
            _repo = repo;
        }

        public void Cadastra(Material comando)
        {
            _repo.IncluirMaterialEstoque(comando);
        }

        public void CadastraLista(List<Material> comando)
        {
            _repo.IncluirMaterialEstoque(comando.ToArray());
        }

        public List<Material> Listar()
        {
            return _repo.ObtemMaterialEstoque().ToList();
        }

        public void Altera(Material comando)
        {
            _repo.AtualizarMaterialEstoque(comando);
        }

        public void LimpaTable()
        {
            _repo.LimpaTabelaMateriaEstoque();
        }

        public void Deleta(Material comando)
        {
            _repo.ExcluirMaterialEstoque(comando);
        }
    }
}
