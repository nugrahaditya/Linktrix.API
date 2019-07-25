using Linktrix.API.Persistence.Contexts;

namespace Linktrix.API.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            this._context = context;
        }
    }
}
