using Microsoft.EntityFrameworkCore;
using SyncStammdaten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncStammdaten.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<BaseEntityDiff> BaseEntityDiffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
