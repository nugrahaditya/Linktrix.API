using System.Threading.Tasks;

namespace Linktrix.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
