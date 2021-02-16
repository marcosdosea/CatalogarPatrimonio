using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ITipopatrimonioService
    {
        public void Editar(Tipopatrimonio empresa);
        public int Inserir(Tipopatrimonio empresa);
        public void Remover(int idTipopatrimonio);
        public Tipopatrimonio Obter(int idTipopatrimonio);
        public IEnumerable<Tipopatrimonio> ObterPorNome(string nome);
        public IEnumerable<Tipopatrimonio> ObterTodos();
    }
}
