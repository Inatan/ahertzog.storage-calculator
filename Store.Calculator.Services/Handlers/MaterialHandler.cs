using Store.Calculator.Infrastructure.Repository;
using Store.Calculator.Model;
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
            try
            {
                //_logger.LogDebug("Persistindo a tarefa...");
                _repo.IncluirMaterialEstoque(comando);

            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, ex.Message);
            }

        }

        public List<Material> Listar()
        {
            try
            {
                //_logger.LogDebug("Persistindo a tarefa...");
                return _repo.ObtemMaterialEstoque().ToList();
            }
            catch (Exception ex)
            {
                return null;
                // _logger.LogError(ex, ex.Message);
            }

        }
    }
}
