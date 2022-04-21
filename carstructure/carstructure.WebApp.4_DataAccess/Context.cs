using carstructure.Common.Model;
using carstructure.WebApp._4_DataAccess.Entity;
using carstructure.WebApp._4_DataAccess.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carstructure.WebApp._4_DataAccess
{
    public class Context : DbContext
    {
        public DbSet<CarEntity>? CarDbSet { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntity>().ToTable("CarTable");
            ModelBuilder modelBuilder1 = modelBuilder.ApplyConfiguration(new CarConfiguration());
        }

        
    }
}
