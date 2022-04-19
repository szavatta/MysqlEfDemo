using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Context.Data
{
    [Table("Prodotti")]
    public class Prodotti
    {
        [Key]
        public int id { get; set; }
        public string Descrizione { get; set; }
    }
}
