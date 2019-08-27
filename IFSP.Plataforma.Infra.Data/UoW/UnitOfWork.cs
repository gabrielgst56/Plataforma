using IFSP.Plataforma.Domain.Interfaces;
using IFSP.Plataforma.Infra.Data.Context;

namespace IFSP.Plataforma.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
