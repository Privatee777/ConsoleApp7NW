using ConsoleApp7.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7.DataAccess
{
    public class FakeApiDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
         "Data Source=DESKTOP-021AOAL;" +
         "Initial Catalog=FakeApiDB;" +
         "Integrated Security=False;" +
         "User Id=admin;" +
         "Password=admin;" +
         "TrustServerCertificate=True;" +
         "Encrypt=True;");
        }
    }
}
