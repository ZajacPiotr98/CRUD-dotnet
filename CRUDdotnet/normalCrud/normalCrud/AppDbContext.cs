using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace normalCrud
{
    public class AppDbContext : DbContext
    {
        public DbSet<ExampleModel> ExampleModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;User ID=postgres;Password=admin;Port=5432;Database=database;");
    }
}
