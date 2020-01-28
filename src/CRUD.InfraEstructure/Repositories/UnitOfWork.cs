using CRUD.ApplicationCore.Interfaces;
using CRUD.InfraEstructure.Data.Contexts;
using System.Threading.Tasks;

namespace CRUD.InfraEstructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
