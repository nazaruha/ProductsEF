using Microsoft.EntityFrameworkCore;
using System;
using ProductsView.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsView.Data
{
    public class AppEFContext : DbContext
    {
        public AppEFContext()
        {
            this.Database.EnsureCreated(); // Creates DB if it doesn't exist
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Integrated Security=True;Initial Catalog=ProductsEF");
        }
    }
}
