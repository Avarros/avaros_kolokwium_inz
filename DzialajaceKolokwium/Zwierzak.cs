using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Zwierzak
    {
        [Key]
        public int idZwierzak { get; set; }
        public string imieZwierzak { get; set; }
        public string rasa { get; set; }
        public int idWlasciciel { get; set; }
    }
}
