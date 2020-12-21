using Store.Calculator.Model;
using System;
using System.Collections.Generic;

namespace Store.Calculator.Infrastructure.Repository
{
    public interface IRepositoryMaterial
    {
        void IncluirMaterialEstoque(params Material[] materias);
        void AtualizarMaterialEstoque(params Material[] materias);
        void ExcluirMaterialEstoque(params Material[] materias);

        IEnumerable<Material> ObtemMaterialEstoque(Func<Material, bool> filtro);
        IEnumerable<Material> ObtemMaterialEstoque();
    }
}
