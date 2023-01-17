using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObslugaBazyDanychZSqlite
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
    #region opis_bazy_danych
    class BazaDanychOpis
    {

        public static string BAZADANYCH_TABELA_wartosciCyfrowe = "wartosciCyfrowe"; //nazwa tabeli
        public static string WARTOSCI_CRYFROWE_IdwartosciCyfrowe = "idwartosciCyfrowe"; //nazwa kolumny
        public static string WARTOSCI_CRYFROWEK_wartosci = "wartosc"; //nazwa kolumny
    }
    #endregion
    #region polaczenie_z_baza_danych
    class BazaLaczkaRozlaczka
    {
        public static SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        public static string BAZA_DANYCH_KSIAZKA_NAD_PLIK = "pomiary.db"; //pomiary.db to nazwa bazy, wymien ja na inna
        public static string BAZA_DANYCH_KSIAZKA_NAD_LACZKA = "Data Source= " + BAZA_DANYCH_KSIAZKA_NAD_PLIK + ";Version=3;New=False;Compress=True;"; //to zostaw w spokoju

        public SQLiteCommand Polacz()
        {
            try
            {
                sql_con = new SQLiteConnection(BAZA_DANYCH_KSIAZKA_NAD_LACZKA);
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
            }
            catch
            {
                MessageBox.Show("Nie mozna polaczyc sie z baza danych");
            }
            return sql_cmd;
        }

        public void Rozlacz()
        {
            try
            {
                sql_con.Close();
            }
            catch
            {
                MessageBox.Show("Nie mozna polaczyc sie z baza danych");
            }
        }
    }
    #endregion
    #region insertSQL
    class InsertSql
    {
        public string dodajRekord_1_pole(string nazwaTabeli, string nazwaPola, string wartoscPola)
        {
            string sqlString = null;

            sqlString = "INSERT INTO " + nazwaTabeli + " (" + nazwaPola + ") VALUES ('" + wartoscPola + "');";

            return sqlString;
        }
    }
    private void textBoxWartoscDoZapisu_TextChanged(object sender, EventArgs e)
    {
        if (checkBoxZapis.Checked == true)
        {
            BazaLaczkaRozlaczka bazaLaczkaRozlaczka = new BazaLaczkaRozlaczka();
            InsertSql insertSql = new InsertSql();
            SQLiteCommand sql_cmd = bazaLaczkaRozlaczka.Polacz();

            sql_cmd.CommandText = insertSql.dodajRekord_1_pole(BazaDanychOpis.BAZADANYCH_TABELA_wartosciCyfrowe, BazaDanychOpis.WARTOSCI_CRYFROWEK_wartosci, textBoxWartoscDoZapisu.Text);
            SQLiteDataReader kursor1 = sql_cmd.ExecuteReader();
            bazaLaczkaRozlaczka.Rozlacz();
        }
    }
    #endregion
    #region selectSQL
    class BazaDanychSqlSelect
    {
        public string wczytajTabeleCala(string nazwaTabeli)
        {
            string sqlString = null;

            sqlString = "SELECT * FROM " + nazwaTabeli + ";";

            return sqlString;
        }

        public string wczytaj_1_Pole(string nazwaTabeli, string nazwaPola)
        {
            string sqlString = null;

            sqlString = "SELECT " + nazwaPola + " FROM " + nazwaTabeli + ";";

            return sqlString;
        }
        public string wczytaj_2_Pole(string nazwaTabeli, string nazwaPola1, string nazwaPola2)
        {
            string sqlString = null;

            sqlString = "SELECT " + nazwaPola1 + ", " + nazwaPola2 + " FROM " + nazwaTabeli + ";";

            return sqlString;
        }

    }
    private void buttonWczytajTestdane_Click(object sender, EventArgs e)
    {
        BazaLaczkaRozlaczka bazaLaczkaRozlaczka = new BazaLaczkaRozlaczka();
        BazaDanychSqlSelect bazaDanychSqlSelect = new BazaDanychSqlSelect();
        SQLiteCommand sql_cmd = bazaLaczkaRozlaczka.Polacz();
        string nazwaMiasta = "";
        sql_cmd.CommandText = bazaDanychSqlSelect.wczytaj_1_Pole(BazaDanychOpis.BAZADANYCH_TABELA_MIASTA_SLOWNIK, BazaDanychOpis.MIASTA_SLOWNIK_NAZWA_MIASTA);

        SQLiteDataReader kursor1 = sql_cmd.ExecuteReader();
        while (kursor1.Read())
        {
            nazwaMiasta = kursor1.GetString(0);
        }

        bazaLaczkaRozlaczka.Rozlacz();
        MessageBox.Show(nazwaMiasta);

    }
    #endregion
}
