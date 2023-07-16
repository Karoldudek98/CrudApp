using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CrudApp.Models
{
    public class Model : DbContext
    {
        public DbSet<Klienci> Klienci { get; set; }
        public DbSet<Produkty> Produkty { get; set; }
        public DbSet<SzczegolyZamowienia> SzczegolyZamowienia { get; set; }
        public DbSet<Zamowienia> Zamowienia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder    )
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=testdb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}