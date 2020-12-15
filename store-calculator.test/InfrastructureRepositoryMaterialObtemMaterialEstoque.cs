using Microsoft.EntityFrameworkCore;
using Store.Calculator.Infrastructure;
using Store.Calculator.Model;
using Store.Calculator.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Calculator.Tests
{
    public class ServicesCadastroMaterialHandlerHandlerExecute
    {
        [Fact]
        void DadoItensParaCadastroDeveSerAdicionadosEmBanco()
        {
            var materiais = new List<EstoqueMateriaPrima>
            {
                new EstoqueMateriaPrima("Navalha","UN",1,1,10.5M,10.5M),
                new EstoqueMateriaPrima("Linha","UN",12,1,1.5M,0.5M),
                new EstoqueMateriaPrima("Papel","g",300,1,10M,4M),
            };

            var options = new DbContextOptionsBuilder<DbEstoqueContext>()
                .UseInMemoryDatabase("DbEstoqueContext")
                .Options;

            var contexto = new DbEstoqueContext(options);
            var repo = new RepositoryMaterial(contexto);

            //act
            repo.IncluirMaterialEstoque(materiais.ToArray());
            var handler = new CadastroMaterialHandler(repo);

            //assert
            var lista = handler.Lista();
            Assert.Equal(3, lista.Count);
        }

    }
}
