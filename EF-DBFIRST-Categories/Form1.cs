using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_DBFIRST_Categories
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NorthwindEntities db = new NorthwindEntities();

        void doldur()
        {
            //dataGridView1.DataSource = db.Categories.ToList(); //1. yol db içinde kategori oku data
            //ICollection<Category> cList = db.Categories.ToList();//2. yol koleksiyona alarak
            //dataGridView1.DataSource = cList;

            //var cList = db.Categories.Select(x => new  //3. yol
            //{
            //    x.CategoryID,
            //    KategoriAdi = x.CategoryName,
            //    Aciklama = x.Description,
            //    Resim = x.Picture
            //}).Where(x => x.KategoriAdi.Contains(txtAra.Text)).OrderBy(x=>x.KategoriAdi).ToList();

            //dataGridView1.DataSource = cList;
            //dataGridView1.Columns[0].Visible = false;

            dataGridView1.DataSource = (from c in db.Categories //4. yol
                                        select new
                                        {
                                            c.CategoryID,
                                            c.CategoryName,
                                            Aciklama = c.Description,
                                            c.Picture
                                        }

                                      ).ToList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Category yenikategori = new Category();

        }
    }
}
