using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Uygulama
{
    class ResimTarih
    {
        public DateTime Tarih { get; set; }
        public BitmapImage Resim { get; set; }

        public ResimTarih(DateTime Tarih, BitmapImage Resim)
        {
            this.Tarih = Tarih;
            this.Resim = Resim;
        }
    }
}
