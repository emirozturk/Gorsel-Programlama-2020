using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SpeedTest
{
    class Program
    {
        static List<int> liste = new List<int>();
        static Dictionary<int, int> sozluk = new Dictionary<int, int>();
        static HashSet<int> set = new HashSet<int>();
        static void Main(string[] args)
        {
            var result = Enumerable.Range(0, 1000000);
            int lookupSayisi = 10000;
            
            liste = result.ToList();
            set = result.ToHashSet();
            sozluk = new Dictionary<int, int>(result.Select((x => new KeyValuePair<int, int>(x, x))));
            
            var aranan = liste[result.Count() - 1];

            Console.WriteLine("Lookup Sayısı:"+lookupSayisi);
            Console.WriteLine("Eleman Sayısı:"+result.Count());
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for(int i=0;i<lookupSayisi;i++)
                liste.Contains(aranan);
            sw.Stop();
            Console.WriteLine("Liste (Ticks):" + sw.ElapsedTicks);

            sw.Reset();
            sw.Start();
            for (int i = 0; i < lookupSayisi; i++)
                sozluk.ContainsKey(aranan);
            sw.Stop();
            Console.WriteLine("Sozluk (Ticks):" + sw.ElapsedTicks);

            sw.Reset();
            sw.Start();
            for(int i=0;i<lookupSayisi;i++)
                set.Contains(aranan);
            sw.Stop();
            Console.WriteLine("Set: (Ticks)" + sw.ElapsedTicks);
        }
    }
}
