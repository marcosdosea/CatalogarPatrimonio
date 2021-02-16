using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Service;
using Core.DTO;

namespace Service
{
    public class TransferenciaMaterialService : ITransferenciamaterialService
    {
        private readonly CatalogarPatrimonioContext _context; 

        public TransferenciaMaterialService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Transferenciamaterial transferenciaMaterial)
        {
            _context.Add(transferenciaMaterial);
            _context.SaveChanges();
            return transferenciaMaterial.IdMaterial;
        }

        public void Editar(Transferenciamaterial transferenciaMaterial)
        {
            _context.Update(transferenciaMaterial);
            _context.SaveChanges();
        }

        public void Remover(int idMaterial, int idTransferencia)
        {
            var _transferenciaMaterial = _context.Transferenciamaterial.Find(idMaterial, idTransferencia);
            _context.Transferenciamaterial.Remove(_transferenciaMaterial);
            _context.SaveChanges();
        }

        //public int GetNumeroTransferenciaMaterials()
        //{
        //    return _context.TransferenciaMaterial.Count();
        //}

        //private IQueryable<TransferenciaMaterial> GetQuery()
        //{
        //    IQueryable<TransferenciaMaterial> tb_transferenciaMaterial = _context.TransferenciaMaterial;
        //    var query = from TransferenciaMaterial in tb_transferenciaMaterial
        //                select TransferenciaMaterial;
        //    return query;
        //}

        //public IEnumerable<TransferenciaMaterial> ObterPorNome(string nome)
        //{
        //    IEnumerable<TransferenciaMaterial> transferenciaMaterials = GetQuery()
        //        .Where(transferenciaMaterialModel => transferenciaMaterialModel.Nome.
        //        StartsWith(nome));
        //    return transferenciaMaterials;
        //}

        //public IEnumerable<TransferenciaMaterialDTO> ObterPorNomeOrdenadoDescending(string nome)
        //{
        //    IQueryable<TransferenciaMaterial> tb_transferenciaMaterial = _context.TransferenciaMaterial;
        //    var query = from transferenciaMaterial in tb_transferenciaMaterial
        //                where nome.StartsWith(nome)
        //                orderby transferenciaMaterial.Nome descending
        //                select new TransferenciaMaterialDTO
        //                {
        //                    Nome = transferenciaMaterial.Nome
        //                };
        //    return query;
        //}

        //public IEnumerable<TransferenciaMaterial> ObterTodos()
        //{
        //    return GetQuery();
        //}

        //public TransferenciaMaterial Obter(int idTransferenciaMaterial)
        //{
        //    IEnumerable<TransferenciaMaterial> transferenciaMaterials = GetQuery().Where(transferenciaMaterialModel => transferenciaMaterialModel.Id.Equals(idTransferenciaMaterial));

        //    return transferenciaMaterials.ElementAtOrDefault(0);
        //}
    }
}
