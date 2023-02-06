using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokwium_sb
{
    class MiastaSlownik
    {
        [Key]
        public int idMasta { get; set; }
        public string NazwaMiasta { get; set; }
    }
}
