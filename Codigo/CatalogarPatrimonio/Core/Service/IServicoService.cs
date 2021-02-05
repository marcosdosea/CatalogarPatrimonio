using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IServicoService
    {
        void Editar(Servico servico);
        int Inserir(Servico servico);
        void Remover(int idServico);
        public Servico Obter(int idServico);
        IEnumerable<Servico> ObterPorDataOrdenadoDescending(string nome);
        IEnumerable<Servico> ObterTodos();
    }
}
