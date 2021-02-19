using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ITipomaterialService
    {
        public void Editar(Tipomaterial material);
        public int Inserir(Tipomaterial material);
        public void Remover(int idTipomaterial);
        public Tipomaterial Obter(int idTipomaterial);
        public IEnumerable<Tipomaterial> ObterPorNome(string nome);
        public IEnumerable<Tipomaterial> ObterTodos();
    }
}
