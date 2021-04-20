using System.Threading.Tasks;

namespace backend.Domains.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}