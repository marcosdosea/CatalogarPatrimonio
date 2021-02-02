using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Service;
using Core.DTO;

namespace Service
{
    public class AdicionarGestorService : IAdicionarGestorService
    {
        private readonly CatalogarPatrimonioContext _context;
        public int Inserir(Gestor gestor)
        {
            _context.Add(gestor);
            _context.SaveChanges();
            return gestor.Id;
        }
    }
}
