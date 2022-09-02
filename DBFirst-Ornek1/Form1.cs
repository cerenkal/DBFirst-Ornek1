using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFirst_Ornek1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OkulDBEntities db = new OkulDBEntities();

        void doldur()
        {
            dgvListele.DataSource = db.Ogrencilers.ToList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ogrenciler yeniogrenci = new Ogrenciler();
            yeniogrenci.Numara = txtNumara.Text;
            yeniogrenci.Ad = txtAd.Text;
            yeniogrenci.Soyad = txtSoyad.Text;
            db.Ogrencilers.Add(yeniogrenci);
            db.SaveChanges();
            doldur();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int guncelle = Convert.ToInt32(txtID.Text);

            var guncellenecekOgrenci = db.Ogrencilers.Where(x => x.OgrenciID == guncelle).FirstOrDefault();

            guncellenecekOgrenci.Numara = txtNumara.Text;
            guncellenecekOgrenci.Ad = txtAd.Text;
            guncellenecekOgrenci.Soyad = txtSoyad.Text;

            db.SaveChanges();
            doldur();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int silinecek = Convert.ToInt32(txtID.Text);

            var silinecekOgrenci = db.Ogrencilers.Where(x => x.OgrenciID == silinecek).FirstOrDefault();

            db.Ogrencilers.Remove(silinecekOgrenci);
            db.SaveChanges();
            doldur();

        }
    }
}
