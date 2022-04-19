using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyswlEfCoreDemo.Data
{
    [Table("Person")]

    public class Person
    {
        public int Id { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
    }
}
