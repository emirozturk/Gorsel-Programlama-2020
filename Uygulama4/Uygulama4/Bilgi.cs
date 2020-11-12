using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Uygulama4
{
    class Bilgi
    {
        private List<string> kelimeler;
        private Dictionary<char, int> harfFrekans;
        public Bilgi()
        {
            kelimeler = new List<string>();
            harfFrekans = new Dictionary<char, int>();
        }
        public void KelimeCikar(string Text)
        {
            string[] parcalar = Text.Split(' ');//Metni boşluklara göre böl
            foreach (string parca in parcalar) //parcalar dizisindeki her eleman için
            {
                //her elemanı listede yoksa ekle
                if (!kelimeler.Contains(parca)) //Eğer parça listede yoksa
                {
                    kelimeler.Add(parca); //Listeye ekle
                }
            }
        }
        public List<string> KelimeAl()
        {
            return kelimeler;
        }
        public void HarfCikar(string Text)
        {
            for (int i = 0; i < Text.Length; i++)//metni döngü ile gez
            {
                char karakter = Text[i];
                if (harfFrekans.ContainsKey(karakter)) //Karakter sözlükte varsa
                {
                    harfFrekans[karakter]++; //harfFrekans[karakter] = harfFrekans[karakter] + 1;
                }
                else //yoksa
                {
                    harfFrekans.Add(karakter, 1); //bir defa geçmiş olduğu için 1 frekansı ile karakteri sözlüğe ekle
                }
            }
        }
        public IEnumerable<string> HarfAl()
        {
            /////SIRALI DÖNDÜRME-DERSİN BU HAFTASI DIŞINDA/////////            
            return harfFrekans.ToList().OrderByDescending(x => x.Value).Select(x => $"'{x.Key}' - {x.Value}");
            /////////////////////////////

            List<string> sonuclar = new List<string>();
            foreach(KeyValuePair<char,int> eleman in harfFrekans) //Sözlüğün tüm elemanları için
            {
                string satir = $"'{eleman.Key}' - {eleman.Value}"; //sözlüğün sıradaki elemanını - karakteri ile birleştir 
                sonuclar.Add(satir); //Listeye ekle
            }
            return sonuclar; //listeyi döndür
        }
        public List<string> KelimeAra(string Aranan)
        {
            List<string> sonucListesi = new List<string>();
            foreach(var siradaki in kelimeler) //Listenin her elemanı için
                if (siradaki.Contains(Aranan)) //Eğer sıradaki kelimem aranan metni içeriyorsa
                    sonucListesi.Add(siradaki);//bulunanları bir listeye ekle
            if (sonucListesi.Count == 0)
                return new List<string>() { "Bulunamadi" };
            else
                return sonucListesi; //listeyi döndür
        }
        public string HarfAra(char aranan)
        {
            if (harfFrekans.ContainsKey(aranan))
                return $"'{aranan}' - {harfFrekans[aranan]}"; //aranan harfi sözlükten döndür
            else
                return "Bulunamadi";
        }
    }
}
