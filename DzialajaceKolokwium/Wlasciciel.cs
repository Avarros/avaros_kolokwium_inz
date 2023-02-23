using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Wlasciciel
    {
        [Key]
        public int idWlasciciel { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
    }
}
