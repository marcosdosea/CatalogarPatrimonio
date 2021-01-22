using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IAlmoxarifadoService
    {
        void Editar(Almoxarifado almoxarifado);
        int Inserir(Almoxarifado almoxarifado);
        void Remover(int idAlmoxarifado);
        public Almoxarifado Obter(int idAlmoxarifado);
        IEnumerable<Almoxarifado> ObterPorNome(string nome);
        IEnumerable<Almoxarifado> ObterTodos();
        IEnumerable<AlmoxarifadoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}