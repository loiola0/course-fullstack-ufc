using System;
using Microsoft.EntityFrameworkCore;
using backend.Domains.Models;

namespace backend.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired();
            builder.Entity<Product>().Property(p => p.Note).IsRequired();
            builder.Entity<Product>().Property(p => p.Value).IsRequired();
            builder.Entity<Product>().Property(p => p.Description).IsRequired();
            //TODO: Fazer o relacionamento.

            builder.Entity<Company>().ToTable("Companys");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.FantasyName).IsRequired();
            builder.Entity<Company>().Property(p => p.CompanyName).IsRequired();
            builder.Entity<Company>().Property(p => p.Cnpj).IsRequired();
            //TODO: Fazer o relacionamento.

            builder.Entity<Purchase>().ToTable("Purchases");
            builder.Entity<Purchase>().HasKey(p => p.Id);
            builder.Entity<Purchase>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Purchase>().Property(p => p.Value).IsRequired();
            builder.Entity<Purchase>().Property(p => p.Note).IsRequired();
            builder.Entity<Purchase>().Property(p => p.PaymentFormat).IsRequired();
            builder.Entity<Purchase>().Property(p => p.Status).IsRequired();
            builder.Entity<Purchase>().Property(p => p.Date).IsRequired();
            builder.Entity<Purchase>().Property(p => p.Cep).IsRequired();
            builder.Entity<Purchase>().Property(p => p.Address).IsRequired();
            //TODO: Fazer o relacionamento.

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Name).IsRequired();
            builder.Entity<User>().Property(p => p.Password).IsRequired();
            builder.Entity<User>().Property(p => p.Email).IsRequired();
            builder.Entity<User>().Property(p => p.Cpf).IsRequired();
            //TODO: Fazer o relacionamento.

        }

    }
}