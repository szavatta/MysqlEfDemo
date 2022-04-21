using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Context.Data;
using Microsoft.EntityFrameworkCore;

namespace WindowsFormApp
{
    public partial class Form1 : Form
    {
        private static string connectionString;

        public Form1()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (MyDbContext ctx = new MyDbContext(connectionString))
            {
                dataGridView1.DataSource = ctx.Utente
                    .Select(q => new { Id = q.id, Nome = q.Nome, Cognome = q.Cognome, Tipo = q.Tipo, Localita = q.Localita.Nome }).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LeggeUtente();
            LeggeLocalita();

            LeggeLista();
            LeggeUnElemento();
            ModificaUnElemento();
            ModificaGlobale();
            Inserimento();
            Cancellazione();
        }

        private void LeggeLista()
        {
            using (MyDbContext ctx = new MyDbContext(connectionString))
            {
                var lista = ctx.Prodotto.Where(q => q.Descrizione.Substring(0, 1) == "r").ToList();
            }
        }

        private void LeggeUnElemento()
        {
            using (MyDbContext ctx = new MyDbContext(connectionString))
            {
                var item = ctx.Prodotto.Where(q => q.Descrizione.Substring(0, 1) == "r").FirstOrDefault();
            }
        }

        private void LeggeUtente()
        {
            using (MyDbContext ctx = new MyDbContext(connectionString))
            {
                Utente utente = ctx.Utente.Include(q => q.Localita).Where(q => q.Nome == "Stefano").FirstOrDefault();
            }
        }

        private void LeggeLocalita()
        {
            using (MyDbContext ctx = new MyDbContext(connectionString))
            {
                Localita localita = ctx.Localita.Where(q => q.Nome == "Roma").FirstOrDefault();
            }
        }

        private void ModificaUnElemento()
        {
            using (MyDbContext ctx = new MyDbContext(connectionString))
            {
                var item = ctx.Prodotto.Where(q => q.Descrizione.Substring(0, 1) == "r").FirstOrDefault();
                item.Descrizione = "elemento modificato";
                ctx.SaveChanges();
            }
        }

        private void ModificaGlobale()
        {
            using (MyDbContext ctx = new MyDbContext(connectionString))
            {
                ctx.Prodotto.Where(q => q.Descrizione.Substring(0, 1) == "r").ToList().ForEach(q => q.Tipo = 1);
                ctx.SaveChanges();
            }
        }

        private void Inserimento()
        {
            using (MyDbContext ctx = new MyDbContext(connectionString))
            {
                Prodotto p = new Prodotto();
                p.Descrizione = "Nuovo prodotto";
                p.Tipo = 3;
                ctx.Prodotto.Add(p);
                ctx.SaveChanges();
            }
        }

        private void Cancellazione()
        {
            using (MyDbContext ctx = new MyDbContext(connectionString))
            {
                var item = ctx.Prodotto.Where(q => q.Descrizione == "Nuovo prodotto").FirstOrDefault();
                if (item != null)
                {
                    ctx.Prodotto.Remove(item);
                    ctx.SaveChanges();
                }
            }
        }

    }
}
