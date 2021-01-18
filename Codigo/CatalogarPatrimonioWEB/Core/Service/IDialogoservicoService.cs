using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IDialogoservicoService
    {
        void Editar(Dialogoservico dialogoservico);
        int Inserir(Dialogoservico dialogoservico);
        Almoxarifado Obter(int idDialogoservico);
        IEnumerable<Almoxarifado> ObterPorNome(string nome);
        IEnumerable<Almoxarifado> ObterTodos();
        void Remover(int idDialogoservico);
        IEnumerable<AlmoxarifadoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}