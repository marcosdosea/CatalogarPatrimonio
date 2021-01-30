using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IMaterialService
    {
        void Editar(Material material);
        int Inserir(Material material);
        void Remover(int idMaterial);
        public Material Obter(int idMaterial);
        IEnumerable<Material> ObterPorNome(string nome);
        IEnumerable<Material> ObterTodos();
        IEnumerable<MaterialDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
