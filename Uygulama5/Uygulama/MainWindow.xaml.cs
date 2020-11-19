using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Uygulama
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ResimTarih> resimler;
        public MainWindow()
        {
            InitializeComponent();
            resimler = new List<ResimTarih>();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TcTab.SelectedIndex == 1)
            {
                //LbListe.ItemsSource = resimler.Select(x => x.Tarih);
                
                List<DateTime> tarihler = TarihleriAl();
                LbListe.ItemsSource = tarihler;
                
            }
        }

        private List<DateTime> TarihleriAl()
        {
            List<DateTime> liste = new List<DateTime>();
            foreach (ResimTarih eleman in resimler)
                liste.Add(eleman.Tarih);
            return liste;
        }

        private void BtnYukle_Click(object sender, RoutedEventArgs e)
        {
            if (DpTarih.SelectedDate.HasValue)
            {
                if (ImgResim.Source != null)
                {
                    ResimTarih resimTarih = new ResimTarih(DpTarih.SelectedDate.Value,(BitmapImage)ImgResim.Source);
                    resimler.Add(resimTarih);
                    MessageBox.Show("Yüklendi", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Resim Yüklenemedi", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Tarih Seçilmedi", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TbYol_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string yol = TbYol.Text;
                Uri uri = new Uri(yol);
                ImgResim.Source = new BitmapImage(uri);

            }
            catch{ }        
        }

        private void LbListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ImgSecilen.Source = resimler.Where(x => x.Tarih == secilenTarih).Select(x => x.Resim).FirstOrDefault();
            DateTime secilenTarih = DateTime.Parse(LbListe.SelectedItem.ToString());
            BitmapImage sonuc = ResimBul(secilenTarih);
        }

        private BitmapImage ResimBul(DateTime secilen)
        {
            foreach(ResimTarih eleman in resimler)
            {
                if (eleman.Tarih == secilen)
                    return eleman.Resim;
            }
            return null;
        }
    }
}
