using System;
using System.IO;
using System.Linq;

namespace Dosyalama
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileStream fileStream = new FileStream(@"C:\Users\emirozturk\Desktop\Ornek.txt", FileMode.Open);
            //StreamReader streamReader = new StreamReader(fileStream);
            //string sonuc = streamReader.ReadLine();
            //string sonuc = streamReader.ReadToEnd();
            //long sonuc = streamReader.BaseStream.Length;
            //Console.WriteLine(sonuc);

            //FileStream fileStream = new FileStream(@"C:\Users\emirozturk\Desktop\yazilan.txt", FileMode.Create);
            //using(StreamWriter sw = new StreamWriter(fileStream))
            //{
            //    sw.WriteLine(10);
            //    sw.WriteLine("string");
            //    sw.WriteLine(23.3);
            //    sw.WriteLine(true);
            //}

            string dosyaYolu = @"C:\Users\emirozturk\Desktop\yazilan.txt";
            //Console.WriteLine(File.Exists(@"C:\Users\emirozturk\Desktop\yazilen.txt"));
            //Console.WriteLine(File.Exists(dosyaYolu));
            //string sonuc = File.ReadAllText(dosyaYolu);
            //string[] sonucListesi = File.ReadAllLines(dosyaYolu);
            //Console.WriteLine(sonuc);

            //Dosyadan okunan değerleri bir diziye atıp, dizinin ortalamasını bulduktan sonra her değeri bu ortalamaya bölüp elde edilen sonuç dizisini
            //Yeni bir dosyaya yazan uygulama

            double[] dizi = File.ReadLines(dosyaYolu).Select(x => Convert.ToDouble(x)).ToArray();
            double ortalama = dizi.Average();
            dizi = dizi.Select(x => Math.Round(x / ortalama,2)).ToArray();
            string yol = Path.GetDirectoryName(dosyaYolu);
            string dosyaAdi = "sonuc.txt";
            string birlestirilen = Path.Combine(yol, dosyaAdi);
            File.WriteAllLines(birlestirilen, dizi.Select(x=>x.ToString()));
        }
    }
}
