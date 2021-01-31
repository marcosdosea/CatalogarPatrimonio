using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Core.Service;

namespace Service
{
    public class MaterialService : IMaterialService
    {
        private readonly CatalogarPatrimonioContext _context;

        public MaterialService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Material material)
        {
            _context.Add(material);
            _context.SaveChanges();
            return material.Id;
        }

        public void Editar(Material material)
        {
            _context.Update(material);
            _context.SaveChanges();
        }

        public void Remover(int idMaterial)
        {
            var _material = _context.Material.Find(idMaterial);
            _context.Material.Remove(_material);
            _context.SaveChanges();
        }

        public int GetNumeroMaterials()
        {
            return _context.Material.Count();
        }

        private IQueryable<Material> GetQuery()
        {
            IQueryable<Material> tb_material = _context.Material;
            var query = from Material in tb_material
                        select Material;
            return query;
        }

        public IEnumerable<Material> ObterPorNome(string nome)
        {
            IEnumerable<Material> materials = GetQuery()
                .Where(materialModel => materialModel.Nome.
                StartsWith(nome));
            return materials;
        }

        public IEnumerable<MaterialDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Material> tb_material = _context.Material;
            var query = from material in tb_material
                        where nome.StartsWith(nome)
                        orderby material.Nome descending
                        select new MaterialDTO
                        {
                            Nome = material.Nome
                        };
            return query;
        }

        public IEnumerable<Material> ObterTodos()
        {
            return GetQuery();
        }

        public Material Obter(int idMaterial)
        {
            IEnumerable<Material> materials = GetQuery().Where(materialModel => materialModel.Id.Equals(idMaterial));

            return materials.ElementAtOrDefault(0);
        }
    }
}
