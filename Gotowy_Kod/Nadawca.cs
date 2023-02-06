using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokwium_sb
{
    class Nadawca
    {
        [Key]
        public int idNadawca { get; set; }
        public string nazwa1 { get; set; }
        public string nazwa2 { get; set; }
        public string nazwa3 { get; set; }
        public string adres { get; set; }
        public int Miasta_idMiasta { get; set; }
    }
}
