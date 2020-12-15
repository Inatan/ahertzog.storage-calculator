using Store.Calculator.Infrastructure;
using Store.Calculator.Model;
using System;

namespace Store.Calculator.Services.Handlers
{


    public class CadastroMaterialHandler
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
    }
}
