using Linktrix.API.Domain.Repositories;
using Linktrix.API.Persistence.Contexts;
using System.Threading.Tasks;

namespace Linktrix.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
