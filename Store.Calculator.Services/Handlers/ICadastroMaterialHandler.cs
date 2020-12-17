﻿using Store.Calculator.Model;
using System.Collections.Generic;

namespace Store.Calculator.Services.Handlers
{
    public interface ICadastroMaterialHandler
    {
        void Execute(EstoqueMateriaPrima comando);

        List<EstoqueMateriaPrima> Listar();
    }
}