using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1
{
    public class Class1
    {

    }
}
namespace Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("PersonsDb");
        }


    }
}