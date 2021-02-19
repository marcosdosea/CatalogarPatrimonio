using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class TipomaterialService : ITipomaterialService
    {
        private readonly CatalogarPatrimonioContext _context;

        public TipomaterialService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Tipomaterial tipoMaterial)
        {
            _context.Add(tipoMaterial);
            _context.SaveChanges();
            return tipoMaterial.Id;
        }

        public void Editar(Tipomaterial tipoMaterial)
        {
            _context.Update(tipoMaterial);
            _context.SaveChanges();
        }

        public void Remover(int idTipomaterial)
        {
            var _tipoMaterial = _context.Tipomaterial.Find(idTipomaterial);
            _context.Tipomaterial.Remove(_tipoMaterial);
            _context.SaveChanges();
        }

        public int GetNumeroTipomaterial()
        {
            return _context.Tipomaterial.Count();
        }

        private IQueryable<Tipomaterial> GetQuery()
        {
            IQueryable<Tipomaterial> tb_tipoMaterial = _context.Tipomaterial;
            var query = from tipoMaterial in tb_tipoMaterial
                        select tipoMaterial;
            return query;
        }

        public IEnumerable<Tipomaterial> ObterPorNome(string nome)
        {
            IEnumerable<Tipomaterial> tipoMaterial = GetQuery()
                .Where(tipoMaterialModel => tipoMaterialModel.Nome.
                StartsWith(nome));
            return tipoMaterial;
        }

        public IEnumerable<Tipomaterial> ObterTodos()
        {
            return GetQuery();
        }

        public Tipomaterial Obter(int idTipomaterial)
        {
            IEnumerable<Tipomaterial> tipoMaterial = GetQuery().Where(tipoMaterialModel => tipoMaterialModel.Id.Equals(idTipomaterial));

            return tipoMaterial.ElementAtOrDefault(0);
        }
    }
}
