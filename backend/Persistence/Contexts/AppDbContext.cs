using System;
using Microsoft.EntityFrameworkCore;
using backend.Domains.Models;

namespace backend.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        
         public DbSet<Company> Companys {get;set;}
         public DbSet<Product> Products {get;set;}
         public DbSet<Purchase> Purchases {get;set;}
         public DbSet<User> Users {get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


    }
}