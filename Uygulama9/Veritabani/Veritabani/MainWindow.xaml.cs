using System;
using System.Linq;
using System.Windows;
using Veritabani.Models;

namespace Veritabani
{
    public partial class MainWindow : Window
    {
        SongsDbContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new SongsDbContext();
            Listele();
        }



        private void BtnSanatciEkle_Click(object sender, RoutedEventArgs e)
        {
            if (LbSanatcilar.SelectedIndex == -1)//Yeni ekleme durumu
            {
                Sanatci yeniSanatci = new Sanatci() { Adi = TbSanatciAdi.Text };
                context.Sanatcis.Add(yeniSanatci);
                context.SaveChanges();
                TbSanatciAdi.Clear();
            }
            else //Seçili bir kayıt var güncellenecek
            {
                Sanatci s = context.Sanatcis.Where(x => x.Adi == LbSanatcilar.SelectedItem.ToString()).FirstOrDefault();
                if (s != null)
                {
                    s.Adi = TbSanatciAdi.Text;
                    context.Update(s);
                    context.SaveChanges();
                }
            }
            Listele();
        }

        private void BtnSil_Click(object sender, RoutedEventArgs e)
        {
            if (LbSanatcilar.SelectedIndex != -1) //Silme işlemi
            {
                var sonuc = context.Sanatcis.Where(kayit => kayit.Adi == LbSanatcilar.SelectedItem.ToString()).FirstOrDefault();
                if(sonuc != null)
                {
                    context.Sanatcis.Remove(sonuc);
                    context.SaveChanges();
                    Listele();
                }
            }
        }
        private void Listele()
        {
            LbSanatcilar.ItemsSource = context.Sanatcis.Select(x=>x.Adi).ToList();
        }

        private void LbSanatcilar_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (LbSanatcilar.SelectedIndex != -1)
                TbSanatciAdi.Text = LbSanatcilar.SelectedItem.ToString();
        }
    }
}
