using filmlern;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urunler
{
    public partial class Giris : Form
    {
        SqlConnection baglanti = new SqlConnection();
        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Cursor = Cursors.Help;
        }
        //exe hareket
        bool move;
        int mouse_x;
        int mouse_y;
        private void Giris_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Giris_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Giris_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
        //--exe hareket--
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "Kullanıcı Adı")
                txtKullaniciAdi.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "")
                txtKullaniciAdi.Text = "Kullanıcı Adı";
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
                txtSifre.Text = "";
        }

        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (txtSifre.Text == "")
                txtSifre.Text = "Şifre";
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;
            baglanti.ConnectionString = "Data Source=ENES\\MSSQLSERVER2;Initial Catalog = networkLoginDatabase;Integrated Security=true";
            SqlCommand sorgula = new SqlCommand("SELECT * FROM Users WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre", baglanti);
            sorgula.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
            sorgula.Parameters.AddWithValue("@Sifre", sifre);
            baglanti.Open();
            SqlDataReader oku = sorgula.ExecuteReader();
            if (oku.Read())
            {
                //Sayfa yönlendirme
                Form1 anaSayfa = new Form1();
                anaSayfa.Show();
                this.Hide();
            }
            else
            {
                label1.Text = "Kullanıcı adı ya da şifre hatalı.";
            }
            oku.Close();
            baglanti.Close();
        }
        //enter basınca butonu tetikle
        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGiris.PerformClick();
                e.SuppressKeyPress = true; // Enter tuşunun varsayılan işleme devam etmesini engeller
            }
        }
        kayitOl a = new kayitOl();
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            a.ShowDialog();
        }
    }
}
