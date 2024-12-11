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
        SqlCommand komut = new SqlCommand(constring);

        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, connect);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        public void verileriSil(string veriler)
        {
            string sorgu = "DELETE * FROM eyyubixkisiler WHERE tc=@tc";
            komut = new SqlCommand(sorgu, connect);
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

        private void Button3_Click(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {

        }



        private void button3_Click_2(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                long idToDelete = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["tc"].Value);
                DeleteItemFromDatabase(idToDelete);
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir öğe seçin.");
            }
        }

        private void DeleteItemFromDatabase(long tc)
        {
            string connectionString = "Data Source=DESKTOP-LATR9CC\\SQLEXPRESS;Initial Catalog=eyyubıxkayit;Integrated Security=True";
            string Query = "DELETE FROM eyyubıxkayit.dbo.eyyubixkisiler WHERE tc = @tc";

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Query, connect);
                command.Parameters.AddWithValue("@tc", tc);

                try
                {
                    connect.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected > 0)
                    {
                        MessageBox.Show("Öğe başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Öğe bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}