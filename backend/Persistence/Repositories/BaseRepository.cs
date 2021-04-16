using System;
using backend.Persistence.Contexts;

namespace backend.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context){
            _context = context;
        }

    }
}