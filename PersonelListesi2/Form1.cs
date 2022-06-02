using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelListesi2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void KişiEkle(object sender, EventArgs e)
        {
            FrmPersonel form = new FrmPersonel() { Text = "Kişi Ekle" };

            if(form.ShowDialog()== DialogResult.OK)
            {
                KişiEkle(form.Kişi);
            }
        }

        private void KişiEkle(Personel kişi)
        {
            ListViewItem k = new ListViewItem(new string[]
            {
                kişi.AdSoyad, 
                kişi.Telefon,
                kişi.Birim
            });

            k.Tag = kişi;
            k.ToolTipText = kişi.Detay;

            listView1.Items.Add(k);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                pictureBox1.Image = null;
                textBox1.Text = "";
                return;
            }

            Personel kişi =listView1.SelectedItems[0].Tag as Personel;
            pictureBox1.Image = kişi.Resim;
            textBox1.Text = kişi.Detay;
        }
    }
}
