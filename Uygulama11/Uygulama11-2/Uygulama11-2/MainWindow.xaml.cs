using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Uygulama11_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KriterOku();
        }

        private void KriterOku()
        {
            Dictionary<string,int> kriterler = DosyadanOku();
            BileşenOluştur(kriterler);
        }

        private void BileşenOluştur(Dictionary<string, int> kriterler)
        {
            foreach(var anahtar in kriterler.Keys)
            {
                Button btn = new Button()
                {
                    Content = anahtar,
                    Width=500,
                    Height=50,
                    Tag = kriterler[anahtar]
                };
                btn.Click += Btn_Click;
                WpBilesenler.Children.Add(btn);
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            int deger = 0;
            if(TbToplam.Text != "")
                deger = Convert.ToInt32(TbToplam.Text);
            deger += Convert.ToInt32((sender as Button).Tag);
            TbToplam.Text = deger.ToString();
        }

        private Dictionary<string, int> DosyadanOku()
        {
            //var sozluk = new Dictionary<string, int>(File.ReadAllLines("kriterler.txt")
            //                                         .Select(x => new KeyValuePair<string, int>(x.Split("-")[0], Convert.ToInt32(x.Split("-")[1]))));

            var sozluk = new Dictionary<string, int>();
            var satirlar = File.ReadAllLines("kriterler.txt");
            foreach (var satir in satirlar)
            {
                string[] parcalar = satir.Split("-");
                string kriter = parcalar[0];
                int deger = Convert.ToInt32(parcalar[1]);
                sozluk.Add(kriter, deger);
            }
            return sozluk;
        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            TbToplam.Clear();
        }
    }
}
