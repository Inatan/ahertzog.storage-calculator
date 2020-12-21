﻿using Store.Calculator.Infrastructure.Repository;
using Store.Calculator.Model;
using System;
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
            try
            {
                //_logger.LogDebug("Persistindo a tarefa...");
                _repo.IncluirValorServico(comando);

            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, ex.Message);
            }
        }

        public void Altera(ValorServico comando)
        {
            try
            {
                //_logger.LogDebug("Persistindo a tarefa...");
                _repo.AtualizarValorServico(comando);

            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, ex.Message);
            }
        }

        public void Deleta(ValorServico comando)
        {
            try
            {
                //_logger.LogDebug("Persistindo a tarefa...");
                _repo.ExcluirValorServico(comando);

            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, ex.Message);
            }
        }

        public List<ValorServico> Listar()
        {
            try
            {
                //_logger.LogDebug("Persistindo a tarefa...");
                return _repo.ObtemValorServico().ToList() ?? new List<ValorServico>();
            }
            catch (Exception ex)
            {
                return new List<ValorServico>();
                // _logger.LogError(ex, ex.Message);
            }

        }
    }
}