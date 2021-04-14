using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ITiposervicoService
    {
        public void Editar(Tiposervico tiposervico);
        public int Inserir(Tiposervico tiposervico);
        public void Remover(int idTipoServico);
        public Tiposervico Obter(int idTipoServico);
        public IEnumerable<Tiposervico> ObterPorNome(string nome);
        public IEnumerable<Tiposervico> ObterTodos();
    }
}
