using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class BazaDanychObsluga : DbContext
    {
        public DbSet<Wlasciciel> Wlasciciel { get; set; }
        public DbSet<Zwierzak> Zwierzak { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=BazaKolokwium.db");
            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
