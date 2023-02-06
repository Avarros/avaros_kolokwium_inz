using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaliczenie.ObslugaKontrolek
{
    class ObslugaDataGridView
    {
        public static  void PrzygotujKontrolke(DataGridView nazwa)
        {
            nazwa.Rows.Clear();
            nazwa.Columns.Clear();
            nazwa.Columns.Add("id", " ID Nadawcy");
            nazwa.Columns.Add("nazwa", "Nazwa1");
            nazwa.Columns.Add("nazwa2", "Nazwa2");
            nazwa.Columns.Add("nazwa3", "Nazwa3");
            nazwa.Columns.Add("addres", "Adress");
            nazwa.Columns.Add(" Miasta", "Nazwa Miasta");
           
        }
    }
}
