using Store.Calculator.Infrastructure;
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

        //public void Execute(CadastraTarefa comando)
        //{
        //    try
        //    {
        //        var tarefa = new Tarefa
        //        (
        //            id: 0,
        //            titulo: comando.Titulo,
        //            prazo: comando.Prazo,
        //            categoria: comando.Categoria,
        //            concluidaEm: null,
        //            status: StatusTarefa.Criada
        //        );
        //        _logger.LogDebug("Persistindo a tarefa...");
        //        _repo.IncluirTarefas(tarefa);
        //        return new CommandResult(true);

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        return new CommandResult(false);
        //    }

        //}
    }
}
