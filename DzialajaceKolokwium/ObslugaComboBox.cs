using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    class ObslugaComboBox
    {
        public List<string> WczytajComboBoxa(ComboBox nazwa)
        {
            BazaDanychObsluga bazaDanychObsluga = new BazaDanychObsluga();
            var wczytajDaneDzialy = from BazaDanychObsluga in bazaDanychObsluga.Wlasciciel select BazaDanychObsluga;
            List<string> listaId = new List<string>();
            foreach (var kursor in wczytajDaneDzialy)
            {
                nazwa.Items.Add(kursor.imie);
                listaId.Add(kursor.idWlasciciel.ToString());

            }

            return listaId;
        }
    }
}
