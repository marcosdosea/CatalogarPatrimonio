using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IRoleService
    {
        public string Editar(Aspnetroles aspnetroles);
        public void Inserir(Aspnetroles aspnetroles);
        public void Remover(string Id);
        public Aspnetroles Obter(string Id);
        public IEnumerable<Aspnetroles> ObterPorNome(string Name);
        public IEnumerable<Aspnetroles> ObterTodos();
    }
}
