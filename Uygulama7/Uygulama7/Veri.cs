using System;
using System.Collections.Generic;
using System.Text;

namespace Uygulama7
{
    class Veri
    {
        public static List<Kayit> ListeAl()
        {
            List<Kayit> kayitListesi = new List<Kayit>()
            {
                new Kayit(1, "Emir Öztürk", 40),
                new Kayit(2, "Bilge Kızgındere", 20),
                new Kayit(3, "Emre Şimşek", 25),
                new Kayit(4, "Eyüp Pastırmacı", 20),
                new Kayit(5, "Gamze Zeren", 20),
                new Kayit(6, "Hakan Niğiz", 30),
                new Kayit(7, "Mehmet Efe Gösterici", 17),
                new Kayit(8, "Murat Kerem Serttaş", 17),
                new Kayit(9, "Mutlucan Karınca", 35)
            };
            return kayitListesi;
        }
    }
}
