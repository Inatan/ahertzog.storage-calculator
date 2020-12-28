using Microsoft.EntityFrameworkCore;
using Store.Calculator.Infrastructure;
using Store.Calculator.Infrastructure.Repository;
using Store.Calculator.Model;
using Store.Calculator.Services.Handlers;
using System.Collections.Generic;
using Xunit;

namespace Store.Calculator.Tests
{
    public class ServicesCadastroMaterialHandlerHandlerExecute
    {
        [Fact]
        void DadoItensParaCadastroDeveSerAdicionadosEmBanco()
        {
            var materiais = new List<Material>
            {
                new Material("Navalha","UN",1,1,10.5M,10.5M),
                new Material("Linha","UN",12,1,1.5M,0.5M),
                new Material("Papel","g",300,1,10M,4M),
            };

            var options = new DbContextOptionsBuilder<DbEstoqueContext>()
                .UseInMemoryDatabase("DbEstoqueContext")
                .Options;

            var contexto = new DbEstoqueContext(options);
            var repo = new RepositoryMaterial(contexto);

            //act
            repo.IncluirMaterialEstoque(materiais.ToArray());
            var handler = new MaterialHandler(repo);

            //assert
            var lista = handler.Listar();
            Assert.Equal(3, lista.Count);
        }

    }
}
