﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IEntradamaterialService
    {
        void Editar(Entradamaterial entradamaterial);
        int Inserir(Entradamaterial entradamaterial);
        void Remover(int idEntradamaterial);
        public Entradamaterial Obter(int idEntradamaterial);
        IEnumerable<Entradamaterial> ObterTodos();
    }
}
