using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolokwium_sb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonWyswietlNadawca_Click(object sender, EventArgs e)
        {
            BazaLaczkaRozlaczka bazaLaczkaRozlaczka = new BazaLaczkaRozlaczka();
            var DaneWczytane = from BazaLaczkaRozlaczka in bazaLaczkaRozlaczka.Nadawca select BazaLaczkaRozlaczka;
            dataGridViewNadawca.Rows.Clear();
            dataGridViewNadawca.Columns.Clear();
            dataGridViewNadawca.Columns.Add("idNadawca", "Id Nadawcy");
            dataGridViewNadawca.Columns.Add("nazwa1", "Imie");
            dataGridViewNadawca.Columns.Add("nazwa2", "Drugie imie");
            dataGridViewNadawca.Columns.Add("nazwa3", "Nazwisko");
            dataGridViewNadawca.Columns.Add("Miasta_idMiasta", "Id Miasta");

            foreach (var kursor in DaneWczytane)
            {
                dataGridViewNadawca.Rows.Add(kursor.idNadawca, kursor.nazwa1, kursor.nazwa2, kursor.nazwa3,kursor.Miasta_idMiasta);
            }
        }

        private void buttonDodajDane_Click(object sender, EventArgs e)
        {
            using (var strukturaDanych = new BazaLaczkaRozlaczka())
            {
               
                strukturaDanych.Nadawca.Add(new Nadawca() { nazwa1 = textBoxImie.Text.ToString(), nazwa2 = textBoxDrugieImie.Text.ToString(), nazwa3 = textBoxNazwisko.Text.ToString(), adres =textBoxAdres.Text.ToString(), Miasta_idMiasta = comboBoxMiasto.SelectedIndex});
                strukturaDanych.SaveChanges();
            }
        }
        List<int> idMiast;
        private void Form1_Load(object sender, EventArgs e)
        {

            idMiast = WczytajComboBoxa(comboBoxMiasto);
        }
        List<int> WczytajComboBoxa(ComboBox nazwa)
        {
            BazaLaczkaRozlaczka bazaLaczkaRozlaczka = new BazaLaczkaRozlaczka();
            var wczytajDaneDzialy = from BazaLaczkaRozlaczka in bazaLaczkaRozlaczka.MiastaSlownik select BazaLaczkaRozlaczka;
            List<int> listaId = new List<int>();
            foreach (var kursor in wczytajDaneDzialy)
            {
                nazwa.Items.Add(kursor.NazwaMiasta);
                listaId.Add(kursor.idMasta);

            }

            return listaId;
        }
    }
}
