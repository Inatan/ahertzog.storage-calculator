using Store.Calculator.Model;
using System.Collections.Generic;

namespace Store.Calculator.Services.Handlers
{
    public interface IMaterialHandler
    {
        void Cadastra(Material comando);
        void CadastraLista(List<Material> comando);
        List<Material> Listar();
        void Altera(Material comando);
        void LimpaTable();
        void Deleta(Material comando);

    }
}