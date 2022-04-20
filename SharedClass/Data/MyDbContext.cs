using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Context.Data
{
    public class MyDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=prova;user=root;password=;port=3306");
        }

        public DbSet<Prodotto> Prodotto { get; set; }
        public DbSet<Utente> Utente { get; set; }
        public DbSet<Localita> Localita { get; set; }

    }
}
