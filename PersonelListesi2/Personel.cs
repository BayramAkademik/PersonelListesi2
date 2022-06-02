using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelListesi2
{
    public class Personel
    {
        public Guid ID { get; set; }
        public string TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AdSoyad { get { return Ad + " " + Soyad; } }
        public DateTime DoğumTarihi { get; set; }

        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }

        public string Birim { get; set; }
        public DateTime GirişTarihi { get; set; }
        public decimal Maaş { get; set; }

        public string Bilgi { get; set; }
        public Image Resim { get; set; }

        public string Detay
        {
            get
            {
                return
                    $"ID        :{ID}\r\n" +
                    $"TC        :{TC}\r\n" +
                    $"Ad Soyad  :{AdSoyad}\r\n" +
                    $"Doğum Tar :{DoğumTarihi}\r\n" +
                    $"Telefon   :{Telefon}\r\n" +
                    $"Mail      :{Mail}\r\n" +
                    $"Adres     :{Adres}" +
                    $"*****************************\r\n" +
                    $"Birim     :{Birim}\r\n" +
                    $"Giriş Tar :{GirişTarihi}\r\n" +
                    $"Maaş      :{Maaş:C2}\r\n" +
                    $"*****************************\r\n" +
                    $"Bigi      :{Bilgi}"+
                    "\r\n**********************+++";
            }
        }

    }
}
