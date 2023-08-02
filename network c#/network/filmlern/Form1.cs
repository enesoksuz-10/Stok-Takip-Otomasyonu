using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections;
using static Urunler.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Urunler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void temiz()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

        }

            SqlConnection baglan = new SqlConnection("Data Source=ENES\\MSSQLSERVER2; Initial Catalog = networkLoginDatabase; Integrated Security = True");
            DataTable tablo = new DataTable();
            IDataAdapter adtr = new OleDbDataAdapter();

            OleDbCommand komut = new OleDbCommand();
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["urunNo"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["urunAdi"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["kategori"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["kullaniciAdi"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["yuklenmeTarihi"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["urunFiyati"].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells["urunNo"].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells["urunNo"].Value.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (baglan.State == ConnectionState.Closed)
            datagrid("Select * from Urunler");
        }

        private void datagrid(string veriler)
        {
            dataGridView1.DataSource = null;
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button15_Click(object sender, EventArgs e)
        {
            baglan.Open();

            string sql = "SELECT TOP 5 * FROM Urunler ORDER BY urunNo ASC";

            // Veritabanından verileri seçin
            SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
            DataTable table = new DataTable();
            adapter.Fill(table);

            // Verileri DataGridView'e aktarın
            dataGridView1.DataSource = table;

            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datagrid("Select * from Urunler");
        }

        
        //***********************************************************************
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Urunler (urunNo, urunAdi, kategori, kullaniciAdi, yuklenmeTarihi, urunFiyati)values(@urunNo, @urunAdi, @kategori, @kullaniciAdi, @yuklenmeTarihi, @urunFiyati)", baglan);

            komut.Parameters.AddWithValue("@urunNo", textBox1.Text);
            komut.Parameters.AddWithValue("@urunAdi", textBox2.Text);
            komut.Parameters.AddWithValue("@kategori", textBox3.Text);
            komut.Parameters.AddWithValue("@kullaniciAdi", textBox4.Text);
            komut.Parameters.AddWithValue("@yuklenmeTarihi", textBox6.Text);
            komut.Parameters.AddWithValue("@urunFiyati", textBox8.Text);

            komut.ExecuteNonQuery();

            baglan.Close();

            temiz();
            datagrid("Select * from Urunler");
        }


        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from Urunler where urunNo=@urunNo", baglan);
            komut.Parameters.AddWithValue("@urunNo", textBox9.Text);
            komut.ExecuteNonQuery();
            datagrid("Select * From Urunler");
            baglan.Close();
            temiz();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (baglan.State == ConnectionState.Closed)
                baglan.Open();

            SqlCommand komut = new SqlCommand("update Urunler set urunNo=@urunNo, urunAdi=@urunAdi,kategori=@kategori,kullaniciAdi=@kullaniciAdi,yuklenmeTarihi=@yuklenmeTarihi,urunFiyati=@urunFiyati where urunNo=@urunNo", baglan);


            komut.Parameters.AddWithValue("@urunNo", textBox1.Text);
            komut.Parameters.AddWithValue("@urunAdi", textBox2.Text);
            komut.Parameters.AddWithValue("@kategori", textBox3.Text);
            komut.Parameters.AddWithValue("@kullaniciAdi", textBox4.Text);
            komut.Parameters.AddWithValue("@yuklenmeTarihi", textBox6.Text);
            komut.Parameters.AddWithValue("@urunFiyati", textBox8.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            datagrid("Select * from Urunler");
            temiz();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            // Verileri urun sıralamasına göre azalan şekilde sırala
            dataGridView1.Sort(dataGridView1.Columns["urunNo"], ListSortDirection.Descending);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Verileri urun sıralamasına göre artan şekilde sırala
            dataGridView1.Sort(dataGridView1.Columns["urunNo"], ListSortDirection.Ascending);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Verileri fiyatına göre azalan şekilde sırala
            dataGridView1.Sort(dataGridView1.Columns["urunFiyatı"], ListSortDirection.Descending);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Verileri fiyatına göre artan şekilde sırala
            dataGridView1.Sort(dataGridView1.Columns["urunFiyatı"], ListSortDirection.Ascending);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            datagrid("Select * from Urunler");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            baglan.Open();

            string sql = "SELECT TOP 1 * FROM Urunler ORDER BY urunNo ASC";

            // Veritabanından verileri seçin
            SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
            DataTable table = new DataTable();
            adapter.Fill(table);

            // Verileri DataGridView'e aktarın
            dataGridView1.DataSource = table;

            baglan.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            baglan.Open();

            string sql = "SELECT TOP 1 * FROM Urunler ORDER BY urunNo DESC";

            // Veritabanından verileri seçin
            SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
            DataTable table = new DataTable();
            adapter.Fill(table);

            // Verileri DataGridView'e aktarın
            dataGridView1.DataSource = table;

            baglan.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.ForeColor = Color.Black;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string selectedValue = selectedCell.Value.ToString();

                if (!string.IsNullOrEmpty(selectedValue))
                {
                    // İlgili sütunların değerlerini alın
                    string urunNo = dataGridView1.CurrentRow.Cells["urunNo"].Value.ToString();
                    string urunAdi = dataGridView1.CurrentRow.Cells["urunAdi"].Value.ToString();
                    string kategori = dataGridView1.CurrentRow.Cells["kategori"].Value.ToString();
                    string kullaniciAdi = dataGridView1.CurrentRow.Cells["kullaniciAdi"].Value.ToString();
                    string yuklenmeTarihi = dataGridView1.CurrentRow.Cells["yuklenmeTarihi"].Value.ToString();
                    string urunFiyati = dataGridView1.CurrentRow.Cells["urunFiyati"].Value.ToString();

                    // TextBox'lara değerleri aktar
                    textBox1.Text = urunNo;
                    textBox2.Text = urunAdi;
                    textBox3.Text = kategori;
                    textBox4.Text = kullaniciAdi;
                    textBox6.Text = yuklenmeTarihi;
                    textBox8.Text = urunFiyati;
                }
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
