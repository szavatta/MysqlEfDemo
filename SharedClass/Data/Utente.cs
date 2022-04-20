using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Context.Data
{
    [Table("Utenti")]
    public class Utente
    {
        [Key]
        public int id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Tipo { get; set; }
        [Display(Name = "Localita")]
        public int IdLocalita { get; set; }

        [ForeignKey("IdLocalita")]
        public virtual Localita Localita { get; set; }

    }
}
