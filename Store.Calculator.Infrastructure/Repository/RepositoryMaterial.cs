using Store.Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Calculator.Infrastructure.Repository
{
    public class RepositoryMaterial : IRepositoryMaterial
    {
        DbEstoqueContext _ctx;

        public RepositoryMaterial(DbEstoqueContext ctx)
        {
            _ctx = ctx;
        }

        public void AtualizarMaterialEstoque(params Material[] materias)
        {
            _ctx.EstoqueMaterias.UpdateRange(materias);
            _ctx.SaveChanges();
        }

        public void ExcluirMaterialEstoque(params Material[] materias)
        {
            _ctx.EstoqueMaterias.RemoveRange(materias);
            _ctx.SaveChanges();
        }

        public void IncluirMaterialEstoque(params Material[] materias)
        {
            _ctx.EstoqueMaterias.AddRange(materias);
            _ctx.SaveChanges();
        }

        public IEnumerable<Material> ObtemMaterialEstoque(Func<Material, bool> filtro)
        {
            return _ctx.EstoqueMaterias.Where(filtro);
        }

        public IEnumerable<Material> ObtemMaterialEstoque()
        {
            return _ctx.EstoqueMaterias;
        }
    }
}
