using System;
using System.Collections.Generic;
using System.Text;

namespace Uygulama7
{
    class Kayit
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public int Yas { get; set; }
        public Kayit(int Id, string AdSoyad, int Yas)
        {
            this.Id = Id;
            this.AdSoyad = AdSoyad;
            this.Yas = Yas;
        }
    }
}
