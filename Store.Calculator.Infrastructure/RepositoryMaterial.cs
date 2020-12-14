using Store.Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Calculator.Infrastructure
{
    public class RepositoryMaterial : IRepositoryMaterial
    {
        DbEstoqueContext _ctx;

        public RepositoryMaterial(DbEstoqueContext ctx)
        {
            _ctx = ctx;
        }

        public void AtualizarMaterialEstoque(params EstoqueMateriaPrima[] materias)
        {
            _ctx.EstoqueMaterias.UpdateRange(materias);
            _ctx.SaveChanges();
        }

        public void ExcluirMaterialEstoque(params EstoqueMateriaPrima[] materias)
        {
            _ctx.EstoqueMaterias.RemoveRange(materias);
            _ctx.SaveChanges();
        }

        public void IncluirMaterialEstoque(params EstoqueMateriaPrima[] materias)
        {
            _ctx.EstoqueMaterias.AddRange(materias);
            _ctx.SaveChanges();
        }

        public IEnumerable<EstoqueMateriaPrima> ObtemMaterialEstoque(Func<EstoqueMateriaPrima, bool> filtro)
        {
            return _ctx.EstoqueMaterias.Where(filtro);
        }
    }
}
