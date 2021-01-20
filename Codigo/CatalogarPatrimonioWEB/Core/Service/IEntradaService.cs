using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IEntradaService
    {
        public void Editar(EntradaService EntradaService);
        public int Inserir(EntradaService EntradaService);
        public void Remover(int idEmpresaservico);
        public EntradaService Obter(int idEntrada);
        public IEnumerable<EntradaService> ObterTodos();
    }
}
