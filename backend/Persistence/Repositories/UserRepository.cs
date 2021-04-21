using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Domains.Repositories;
using backend.Persistence.Contexts;
using backend.Domains.Models;


namespace backend.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context){}

        public async Task<IEnumerable<User>> ListAsync(){
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user){
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(int id){
            return await _context.Users.FindAsync(id);
        }

        public void Update(User user){
            _context.Users.Update(user);
        }

        public void Remove(User user){
            _context.Users.Remove(user);
        }

    }
}