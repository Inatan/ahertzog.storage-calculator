using Store.Calculator.Model;
using System.Collections.Generic;

namespace Store.Calculator.Services.Handlers
{
    public interface IMaterialHandler
    {
        void Cadastra(Material comando);

        List<Material> Listar();

        void Altera(Material comando);

        void Deleta(Material comando);

    }
}