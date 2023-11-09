using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.CustomControls
{
    public class AppDBContext : DbContext
    {
       // public DbSet<Zakaznik> Zakaznik { get; set; }
        public DbSet<Users> Users { get; set; }
       // public DbSet<CountTest> CountTest { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("ST67034");
        }
    }
}
