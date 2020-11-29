using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class Sayilar
    {
        public List<int> Liste { get; }
        public int AltSinir { get; set; }
        public int UstSinir { get; set; }
        private int Aralik;
        public Sayilar(int altSinir,int ustSinir,int aralik)
        {
            AltSinir = altSinir;
            UstSinir = ustSinir;
            Aralik = aralik;
            Liste = new List<int>();
            Hesapla();
        }
        private void Hesapla()
        {
            for (int i = AltSinir; i < UstSinir; i += Aralik)
                Liste.Add(i);
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button tus = sender as Button;
            object icerik = tus.Content;
            string icerikString = icerik.ToString();
            int aralik = Convert.ToInt32(icerikString);

            string tbIcerigi = tbUstSinir.Text;
            int ustSinir = Convert.ToInt32(tbIcerigi);

            Sayilar sayilar = new Sayilar(0,ustSinir,aralik);
            StringBuilder sb = new StringBuilder();
            foreach (var eleman in sayilar.Liste)
                sb.Append(eleman + " ");
            MessageBox.Show(sb.ToString());
        }
    }
}