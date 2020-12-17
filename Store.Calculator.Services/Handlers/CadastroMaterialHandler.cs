using Store.Calculator.Infrastructure;
using Store.Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Calculator.Services.Handlers
{


    public class CadastroMaterialHandler : ICadastroMaterialHandler
    {
        IRepositoryMaterial _repo;

        public CadastroMaterialHandler(IRepositoryMaterial repo)
        {
            _repo = repo;
        }

        public void Execute(EstoqueMateriaPrima comando)
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

        public List<EstoqueMateriaPrima> Listar()
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
