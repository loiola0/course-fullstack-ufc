using System.Threading.Tasks;
using backend.Domains.Repositories;
using backend.Persistence.Contexts;


namespace backend.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context){
            _context = context;
        }
        public async Task CompleteAsync(){
            await _context.SaveChangesAsync();
        }
    }
}