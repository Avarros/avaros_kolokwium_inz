using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zaliczenie.BazaDanych;
namespace Zaliczenie.ObslugaKontrolek
{
    class ObslugaComboBox
    {

       

        public  static List<int> WczytajComboBoxa(ComboBox nazwa)
        {
            BazaDanychObsluga bazaDanychObsluga = new BazaDanychObsluga();
            var wczytajDaneDzialy = from BazaDanychObsluga in bazaDanychObsluga.Miasta select BazaDanychObsluga;
            List<int> listaId = new List<int>();
            foreach (var kursor in wczytajDaneDzialy)
            {
                nazwa.Items.Add(kursor.nazwa);
                listaId.Add(kursor.miastaId);

            }

            return listaId;
        }
    }
}
