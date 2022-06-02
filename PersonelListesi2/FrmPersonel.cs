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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        private void ResimSeç(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pcResim.Load(openFileDialog1.FileName);
            }
        }

        private void ResimKaldır(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pcResim.Image = null;
        }

        public Personel Kişi { get; set; }
        private void btnTamam_Click(object sender, EventArgs e)
        {
            Kişi = new Personel() { ID = Guid.NewGuid() };

            if (!KontrolEt(txtTc)) return;
            if (!KontrolEt(txtAd)) return;
            if (!KontrolEt(txtSoyad)) return;
            if (!KontrolEt(cbBirim)) return;
            if (!KontrolEt(txtTel)) return;

            KişiBilgileriniGüncelle();

            DialogResult = DialogResult.OK;
        }

        private bool KontrolEt(Control c)
        {
            if(c is TextBox)
            {
                if ((c as TextBox).Text == "")
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    return false;
                }
                else
                    errorProvider1.SetError(c, "");
            }
            else if(c is MaskedTextBox)
            {
                if (!(c as MaskedTextBox).MaskCompleted)
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    return false;
                }
                else
                    errorProvider1.SetError(c, "");
            }
            else if(c is ComboBox)
            {
                if ((c as ComboBox).SelectedItem == null)
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    return false;
                }
                else
                    errorProvider1.SetError(c, "");
            }

            return true;
        }

        private void KişiBilgileriniGüncelle()
        {
            Kişi.TC = txtTc.Text;
            Kişi.Ad = txtAd.Text;
            Kişi.Soyad = txtSoyad.Text;
            Kişi.DoğumTarihi = dtDoğumTarihi.Value;
            Kişi.Telefon = txtTel.Text;
            Kişi.Adres = txtAdres.Text;
            Kişi.Mail = txtMail.Text;
            Kişi.GirişTarihi = dtGirişTarihi.Value;
            Kişi.Resim = pcResim.Image;
            Kişi.Bilgi = txtBilgi.Text;
            Kişi.Birim = cbBirim.SelectedItem.ToString();
        }

        private void Yükle(object sender, EventArgs e)
        {
            foreach (var birim in Birimler.Liste)
                cbBirim.Items.Add(birim);
        }
    }
}
