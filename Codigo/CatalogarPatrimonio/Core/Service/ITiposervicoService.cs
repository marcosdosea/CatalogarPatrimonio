using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ITipoServicoService
    {
        public void Editar(TipoServico tiposervico);
        public int Inserir(TipoServico tiposervico);
        public void Remover(int idTipoServico);
        public TipoServico Obter(int idTipoServico);
        public IEnumerable<TipoServico> ObterPorNome(string nome);
        public IEnumerable<TipoServico> ObterTodos();
    }
}
