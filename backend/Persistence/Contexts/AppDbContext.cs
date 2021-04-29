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
        public DbSet<Cart> Carts {get;set;}


         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}



         protected override void OnModelCreating(ModelBuilder modelBuilder){
             
             base.OnModelCreating(modelBuilder);
             
             modelBuilder.Entity<Company>().ToTable("Companys");
             modelBuilder.Entity<Company>().HasKey(p => p.Id);
             modelBuilder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
             modelBuilder.Entity<Company>().Property(p => p.CompanyName).IsRequired().HasMaxLength(60);
             modelBuilder.Entity<Company>().Property(p => p.FantasyName).IsRequired().HasMaxLength(60);
             modelBuilder.Entity<Company>().Property(p => p.Cnpj).IsRequired().HasMaxLength(26);
             //modelBuilder.Entity<User>().HasMany(p => p.Purchases).WithOne(p => p.User).HasForeignKey(p => p.UserId);

             
             
             modelBuilder.Entity<Product>().ToTable("Products");
             modelBuilder.Entity<Product>().HasKey(p => p.Id);
             modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
             modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(60);
             modelBuilder.Entity<Product>().Property(p => p.Note).IsRequired();
             modelBuilder.Entity<Product>().Property(p => p.Value).IsRequired();
             modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired();


             
             modelBuilder.Entity<Purchase>().ToTable("Purchases");
             modelBuilder.Entity<Purchase>().HasKey(p => p.Id);
             modelBuilder.Entity<Purchase>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
             modelBuilder.Entity<Purchase>().Property(p => p.PaymentFormat).IsRequired().HasMaxLength(60);
             modelBuilder.Entity<Purchase>().Property(p => p.Note).IsRequired();
             modelBuilder.Entity<Purchase>().Property(p => p.Value).IsRequired();
             modelBuilder.Entity<Purchase>().Property(p => p.Status).IsRequired();
             modelBuilder.Entity<Purchase>().Property(p => p.Address).IsRequired();
             modelBuilder.Entity<Purchase>().Property(p => p.Cep).IsRequired();
             modelBuilder.Entity<Purchase>().Property(p => p.Date).IsRequired();



             modelBuilder.Entity<User>().ToTable("Users");
             modelBuilder.Entity<User>().HasKey(p => p.Id);
             modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
             modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(60);
             modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();
             modelBuilder.Entity<User>().Property(p => p.Password).IsRequired();
             modelBuilder.Entity<User>().Property(p => p.Cpf).IsRequired().HasMaxLength(20);

             //model relashionship between product and purchase
             modelBuilder.Entity<Cart>().ToTable("Carts");
             modelBuilder.Entity<Cart>().HasKey(p => new {p.PurchaseId, p.ProductId});
             modelBuilder.Entity<Cart>().Property(p => p.Id).ValueGeneratedOnAdd();
             modelBuilder.Entity<Cart>().Property(p => p.Quantity).IsRequired().HasDefaultValue(0);

         } 


    }
}