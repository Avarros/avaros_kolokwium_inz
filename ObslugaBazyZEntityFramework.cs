using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObslugaBazyZEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    #region obslugaBazyDanych
    class BazaDanychObsluga : DbContext
    {
        public DbSet<pomiar /*<--nazwa klasy*/> pomiar/*<--dowolna logiczna nazwa*/ { get; set; }
        public DbSet<sensor> sensor { get; set; }
        //nic na dole nie zmieniac oprocz nazwy bazy
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=pomiary.db");
            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
    #endregion
    #region opis_tabeli_przyklad
    class pomiar
    {
        //kolumny, te same typy danych musza byc
        public int pomiarId { get; set; }
        public string wartosc1 { get; set; }
        public string wartosc2 { get; set; }
        public string wartosc3 { get; set; }
        public int sensorid { get; set; }
    }
    #endregion
    #region zapis_danych
    private void buttonZapiszDb_Click(object sender, EventArgs e)
    {
        using (var strukturaDanych = new BazaDanychObsluga())
        {
            strukturaDanych.pomiar.Add(new pomiar() { wartosc1 = "123", wartosc2 = "98", wartosc3 = "101" });
            strukturaDanych.SaveChanges();
        }
    }
    #endregion
    #region odswiez_grid_view
    private void buttonOdswiez_Click(object sender, EventArgs e)
    {
        BazaDanychObsluga bazaDanychObsluga = new BazaDanychObsluga();
        var DaneWczytane = from BazaDanychObsluga in bazaDanychObsluga.pomiar select BazaDanychObsluga;
        dataGridViewPomiary.Rows.Clear();
        dataGridViewPomiary.Columns.Clear();
        dataGridViewPomiary.Columns.Add("pomiarId", "Identyfikator");
        dataGridViewPomiary.Columns.Add("wartosc1", "Pomiar1");
        dataGridViewPomiary.Columns.Add("wartosc2", "Pomiar2");
        dataGridViewPomiary.Columns.Add("wartosc3", "Pomiar3");

        foreach (var kursor in DaneWczytane)
        {
            dataGridViewPomiary.Rows.Add(kursor.pomiarId, kursor.wartosc1, kursor.wartosc2, kursor.wartosc3);
        }
    }
    #endregion
    #region aktualizuj_dane
    private void buttonAktualizuje_Click(object sender, EventArgs e)
    {
        using (var daneAktualizacja = new BazaDanychObsluga())
        {
            int idSensor = Int32.Parse(textBoxIdPomiar.Text.ToString());
            pomiar _pomiar = new pomiar() { pomiarId = idSensor, wartosc1 = textBoxWartosc1.Text.ToString() };
            daneAktualizacja.Entry(_pomiar).State = EntityState.Modified;
            daneAktualizacja.SaveChanges();
        }
    }
    #endregion
    #region usun_dane
    private void buttonUsun_Click(object sender, EventArgs e)
    {
        using (var daneAktualizacja = new BazaDanychObsluga())
        {
            int idSensor = Int32.Parse(textBoxIdPomiar.Text.ToString());
            pomiar _pomiar = new pomiar() { pomiarId = idSensor };
            daneAktualizacja.Entry(_pomiar).State = EntityState.Deleted;
            daneAktualizacja.SaveChanges();
        }
    }
    #endregion
    #region cell_click_grid_view
    private void dataGridViewPomiary_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        string wybraneIdPomia = dataGridViewPomiary.CurrentCell.Value.ToString();
        textBoxIdPomiar.Text = wybraneIdPomia.ToString();
    }
    #endregion
}
