using IMC.Product.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMC.Product.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Model.Product> Products { get; set; }
        public DbSet<Flag> Flags { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);          
        }
    }
}
