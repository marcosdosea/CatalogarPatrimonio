using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;
using Core;


namespace Core.Service
{
    public interface IPatrimonioService
    {
        void Editar(Patrimonio patrimonio);
        int Inserir(Patrimonio patrimonio);
        void Remover(int idPatrimonio);
        public Patrimonio Obter(int idPatrimonio);
        IEnumerable<Patrimonio> ObterPorNome(string nome);
        IEnumerable<Patrimonio> ObterTodos();
        IEnumerable<PatrimonioDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
