using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext : DbContext //entityframeworkcore ile beraber geliyor
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {               //hangi veri tabanına bağlanacağımızı yazacağız
                        //sqlserverda ne yaıyorsa oraya yazdık
            optionsBuilder.UseSqlServer(@"Server=(Localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }
        //hangi tablo neye karşılık geliyor
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; } //bunu da ekledik
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}