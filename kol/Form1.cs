using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zaliczenie.BazaDanych;
using Zaliczenie.ModelDanych;
using Zaliczenie.ObslugaKontrolek;

namespace Zaliczenie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> idMiast;
        private void Form1_Load(object sender, EventArgs e)
        {
            idMiast = ObslugaComboBox.WczytajComboBoxa(comboBoxWyborMiasta);
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            var dodajNadawce = new BazaDanychObsluga();

            int id = idMiast[comboBoxWyborMiasta.SelectedIndex ];
            Nadawca nadawca = new Nadawca() { nazwa1 = textBoxNadawcaNazwa1.Text, nazwa2 = textBoxNadawcaNazwa2.Text, nazwa3 = textBoxNadawcaNazwa3.Text, adres = textBoxNadawcaAdres.Text, Miasta_idMiasta = id };
            dodajNadawce.Add(nadawca);
            dodajNadawce.SaveChanges();
        }

        private void buttonWyswietl_Click(object sender, EventArgs e)
        {
            BazaDanychObsluga bazaDanychObsluga = new BazaDanychObsluga();
            var wczytajNadawce = from BazaDanychObsluga in bazaDanychObsluga.Nadawca select BazaDanychObsluga;
            var wczytajMiasta = from BazaDanychObsluga in bazaDanychObsluga.Miasta select BazaDanychObsluga;
            ObslugaDataGridView.PrzygotujKontrolke(dataGridViewDane);
            foreach (var kursor in wczytajMiasta)
            {


                foreach (var kursor2 in wczytajNadawce.Where(a=>a.Miasta_idMiasta==kursor.miastaId))
                {
                    dataGridViewDane.Rows.Add(kursor2.Nadawcaid, kursor2.nazwa1, kursor2.nazwa2, kursor2.nazwa3, kursor2.adres, kursor.nazwa);
                }
            }
           
        }

        private void comboBoxWyborMiasta_SelectedIndexChanged(object sender, EventArgs e)
        {
          
         
        }
    }
}
