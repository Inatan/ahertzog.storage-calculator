using Microsoft.Extensions.Logging;
using Store.Calculator.Infrastructure.Repository;
using Store.Calculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Calculator.Services.Handlers
{


    public class ValorServicoHandler : IValorServicoHandler
    {
        IRepositoryValorServico _repo;
        ILogger<ValorServicoHandler> _logger;

        public ValorServicoHandler(IRepositoryValorServico repo)
        {

            _repo = repo;
            _logger = new LoggerFactory().CreateLogger<ValorServicoHandler>();
        }

        public void Cadastra(ValorServico comando)
        {
            try
            {
                _logger.LogDebug("Persistindo a tarefa...");
                _repo.IncluirValorServico(comando);

            }
            catch (Exception ex)
            {
               _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public void CadastraLista(List<ValorServico> comando)
        {
            try
            {
                _repo.IncluirValorServico(comando.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }


        public void Altera(ValorServico comando)
        {
            try
            {
                _logger.LogDebug("Persistindo a tarefa...");
                _repo.AtualizarValorServico(comando);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public void Deleta(ValorServico comando)
        {
            try
            {
                _logger.LogDebug("Persistindo a tarefa...");
                _repo.ExcluirValorServico(comando);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public void LimpaTable()
        {
            try
            {
                _logger.LogDebug("Persistindo a tarefa...");
                _repo.LimpaTabelaMateriaEstoque();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public List<ValorServico> Listar()
        {
            try
            {
                _logger.LogDebug("Persistindo a tarefa...");
                return _repo.ObtemValorServico().ToList() ?? new List<ValorServico>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

        }
    }
}
