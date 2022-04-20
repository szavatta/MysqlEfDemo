using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Context.Data
{
    [Table("Localita")]
    public class Localita
    {
        [Key]
        public int id { get; set; }
        public string Nome { get; set; }
        public string SiglaProvincia { get; set; }

        public virtual ICollection<Utente> ListaUtenti { get; set; }

    }
}
