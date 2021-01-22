using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IEntradaService
    {
        public void Editar(Entrada entrada);
        public int Inserir(Entrada entrada);
        public void Remover(int idEmpresa);
        public Entrada Obter(int idEntrada);
        public IEnumerable<Entrada> ObterTodos();
    }
}
