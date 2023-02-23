using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ObslugaComboBox obslugaComboBox = new ObslugaComboBox();
            List<string> idWlascicielCombo;
            idWlascicielCombo = obslugaComboBox.WczytajComboBoxa(comboBoxIdWlasciciel);
            zaladujDataGrid();
        }

        public void zaladujDataGrid()
        {
            BazaDanychObsluga bazaDanychObsluga = new BazaDanychObsluga();
            var DaneWczytane = from BazaDanychObsluga in bazaDanychObsluga.Zwierzak select BazaDanychObsluga;
            dataGridViewZwierzak.Rows.Clear();
            dataGridViewZwierzak.Columns.Clear();
            dataGridViewZwierzak.Columns.Add("idZwierzak", "Id Zwierzaka");
            dataGridViewZwierzak.Columns.Add("imieZwierzaka", "Imie");
            dataGridViewZwierzak.Columns.Add("rasa", "Rasa");
            dataGridViewZwierzak.Columns.Add("idWlasciciel", "ID Wlasciciela");

            foreach (var kursor in DaneWczytane)
            {
                dataGridViewZwierzak.Rows.Add(kursor.idZwierzak, kursor.imieZwierzak, kursor.rasa, kursor.idWlasciciel);
            }
        }

        private void buttonDodajDane_Click(object sender, EventArgs e)
        {
            using (var strukturaDanych = new BazaDanychObsluga())
            {

                strukturaDanych.Zwierzak.Add(new Zwierzak() { imieZwierzak = textBoxImie.Text.ToString(), rasa = textBoxRasa.Text.ToString(), idWlasciciel = comboBoxIdWlasciciel.SelectedIndex });
                strukturaDanych.SaveChanges();
                zaladujDataGrid();
            }
        }
    }
}
