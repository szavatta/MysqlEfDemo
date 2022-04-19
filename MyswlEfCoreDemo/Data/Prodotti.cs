using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyswlEfCoreDemo.Data
{
    public class Prodotti
    {
        [Key]
        public int IDProdotto { get; set; }
        public string Descrizione { get; set; }
    }
}
