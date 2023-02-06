using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokwium_sb
{
    class BazaLaczkaRozlaczka : DbContext
    {
        public DbSet<Nadawca> Nadawca{ get; set; }
        public DbSet<MiastaSlownik> MiastaSlownik { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=ksiazkaNad.db");
            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
