using Store.Calculator.Model;
using System;
using System.Collections.Generic;

namespace Store.Calculator.Infrastructure
{
    public interface IRepositoryMaterial
    {
        void IncluirMaterialEstoque(params EstoqueMateriaPrima[] materias);
        void AtualizarMaterialEstoque(params EstoqueMateriaPrima[] materias);
        void ExcluirMaterialEstoque(params EstoqueMateriaPrima[] materias);

        //Categoria ObtemMaterialPorId(int id);
        IEnumerable<EstoqueMateriaPrima> ObtemMaterialEstoque(Func<EstoqueMateriaPrima, bool> filtro);
        IEnumerable<EstoqueMateriaPrima> ObtemMaterialEstoque();
    }
}
