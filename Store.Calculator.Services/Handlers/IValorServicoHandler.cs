using Store.Calculator.Model;
using System.Collections.Generic;

namespace Store.Calculator.Services.Handlers
{
    public interface IValorServicoHandler
    {
        void Cadastra(ValorServico comando);

        List<ValorServico> Listar();

        void Altera(ValorServico comando);

        void Deleta(ValorServico comando);
    }
}