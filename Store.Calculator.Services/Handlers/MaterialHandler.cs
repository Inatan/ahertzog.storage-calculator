using Microsoft.Extensions.Logging;
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
        ILogger<MaterialHandler> _logger;

        public MaterialHandler(IRepositoryMaterial repo)
        {
            _repo = repo;
            _logger = new LoggerFactory().CreateLogger<MaterialHandler>();
        }

        public void Cadastra(Material comando)
        {
            try
            {
                _logger.LogDebug("Persistindo a tarefa...");
                _repo.IncluirMaterialEstoque(comando);

            }
            catch (Exception ex)
            {
               _logger.LogError(ex, ex.Message);
            }

        }

        public void CadastraLista(List<Material> comando)
        {
            try
            {
                _logger.LogDebug("Persistindo a tarefa...");
                _repo.IncluirMaterialEstoque(comando.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public List<Material> Listar()
        {
            try
            {
                _logger.LogDebug("Persistindo a tarefa...");
                return _repo.ObtemMaterialEstoque().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            
        }

        public void Altera(Material comando)
        {
            try
            {
                _logger.LogDebug("Persistindo a tarefa...");
                _repo.AtualizarMaterialEstoque(comando);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public void LimpaTable()
        {
            try
            {
                _repo.LimpaTabelaMateriaEstoque();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public void Deleta(Material comando)
        {
            try
            {
                _logger.LogDebug("Persistindo a tarefa...");
                _repo.ExcluirMaterialEstoque(comando);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
