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
using Urunler;

namespace filmlern
{
    public partial class kayitOl : Form
    {
        SqlConnection baglanti = new SqlConnection();
        public kayitOl()
        {
            InitializeComponent();
        }

        private void kayitOl_Load(object sender, EventArgs e)
        {

        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void kayitOl_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void kayitOl_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void kayitOl_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;
            string Eposta = txtEposta.Text;
            string Adi = txtAdi.Text;
            string Soyadi = txtSoyadi.Text;

            baglanti.ConnectionString = "Data Source=ENES\\MSSQLSERVER2;Initial Catalog=networkLoginDatabase;Integrated Security=true";
            SqlCommand ekleKomutu = new SqlCommand("INSERT INTO Users (Adi, Soyadi, KullaniciAdi, Sifre, Eposta) VALUES (@Adi, @Soyadi, @KullaniciAdi, @Sifre, @Eposta)", baglanti);
            ekleKomutu.Parameters.AddWithValue("@Adi", Adi);
            ekleKomutu.Parameters.AddWithValue("@Soyadi", Soyadi);
            ekleKomutu.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
            ekleKomutu.Parameters.AddWithValue("@Sifre", sifre);
            ekleKomutu.Parameters.AddWithValue("@Eposta", Eposta);

            try
            {

                baglanti.Open();
                int etkilenenSatirSayisi = ekleKomutu.ExecuteNonQuery();
                if (etkilenenSatirSayisi > 0)
                {
                    MessageBox.Show("Kayıt başarıyla oluşturuldu. Giriş sayfasına yönlendiriliyorsunuz...");
                    Giris Giris = new Giris();
                    Giris.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kayıt oluşturulamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Cursor = Cursors.Help;
        }

        private void txtAdi_Enter(object sender, EventArgs e)
        {
            if (txtAdi.Text == "Adı")
                txtAdi.Text = "";
        }

        private void txtAdi_Leave(object sender, EventArgs e)
        {
            if (txtAdi.Text == "")
                txtAdi.Text = "Adı";
        }

        private void txtSoyadi_Enter(object sender, EventArgs e)
        {
            if (txtSoyadi.Text == "Soyadı")
                txtSoyadi.Text = "";
        }

        private void txtSoyadi_Leave(object sender, EventArgs e)
        {
            if (txtSoyadi.Text == "")
                txtSoyadi.Text = "Soyadı";
        }

        private void txtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "Kullanıcı Adı")
                txtKullaniciAdi.Text = "";
        }

        private void txtKullaniciAdi_Leave(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "")
                txtKullaniciAdi.Text = "Kullanıcı Adı";
        }

        private void txtEposta_Enter(object sender, EventArgs e)
        {
            if (txtEposta.Text == "Eposta")
                txtEposta.Text = "";
        }

        private void txtEposta_Leave(object sender, EventArgs e)
        {
            if (txtEposta.Text == "")
                txtEposta.Text = "Eposta";
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Eposta")
                txtSifre.Text = "";
        }

        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Eposta")
                txtSifre.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Giris Giris = new Giris();
            Giris.ShowDialog();
            this.Close();
        }
    }
}
