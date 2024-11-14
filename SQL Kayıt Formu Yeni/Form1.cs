using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL_Kayıt_Formu_Yeni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-LATR9CC\\SQLEXPRESS;Initial Catalog=eyyubıxkayit;Integrated Security=True";
        SqlConnection connect = new SqlConnection(constring);

        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, connect);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster("SELECT * FROM eyyubixkisiler");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_soyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_memleket_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO eyyubixkisiler (tc, ad, soyad, dogumtarihi, memleket) VALUES (@tc, @ad, @soyad, @dogumtarihi, @memleket)", connect);
            komut.Parameters.AddWithValue("@tc", txt_tc.Text);
            komut.Parameters.AddWithValue("@ad", txt_ad.Text);
            komut.Parameters.AddWithValue("@soyad", txt_soyad.Text);
            komut.Parameters.AddWithValue("@dogumtarihi", txt_dogumtarihi.Text);
            komut.Parameters.AddWithValue("@memleket", txt_memleket.Text);
            komut.ExecuteNonQuery();
            verilerigoster("SELECT * FROM eyyubixkisiler");
            connect.Close();

            txt_tc.Clear();
            txt_ad.Clear();
            txt_soyad.Clear();
            txt_dogumtarihi.Clear();
            txt_memleket.Clear();
            txt_ad.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_basvurusil_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
