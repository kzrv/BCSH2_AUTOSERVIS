using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.CustomControls
{
    public class AppDBContext : DbContext
    {

        public DbSet<Adresa> Adresa { get; set; }
        public DbSet<Zakaznik> Zakaznik { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<Zamestnanec> Zamestnanec { get; set; }
        public DbSet<BinaryContent> BinaryContent { get; set; }

        public AppDBContext()
        {

            Database.SetInitializer<AppDBContext>(null);
            // this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Add(new UppercaseColumnAndTableNamesConvention());
            modelBuilder.HasDefaultSchema("ST67034");

            //Database.Log = Console.WriteLine;

        }


    }
    public class UppercaseColumnAndTableNamesConvention : Convention
    {
        public UppercaseColumnAndTableNamesConvention()
        {
            Properties()
                .Configure(c => c.HasColumnName(c.ClrPropertyInfo.Name.ToUpper()));

            Types()
                .Configure(c => c.ToTable(c.ClrType.Name.ToUpper()));
        }
    }
}
