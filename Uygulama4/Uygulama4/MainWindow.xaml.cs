using System;
using System.Collections.Generic;
using System.Windows;
namespace Uygulama4
{
    public partial class MainWindow : Window
    {
        Bilgi bilgi;
        public MainWindow()
        {
            InitializeComponent();
            bilgi = new Bilgi();
        }

        private void BtnKelimeCikar_Click(object sender, RoutedEventArgs e)
        {
            if (TbMetin.Text!=string.Empty)
            {
                bilgi.KelimeCikar(TbMetin.Text);
                LbKelimeler.ItemsSource = bilgi.KelimeAl(); 
            }
        }

        private void BtnHarfCikar_Click(object sender, RoutedEventArgs e)
        {
            if(TbMetin.Text != string.Empty)
            {
                bilgi.HarfCikar(TbMetin.Text);
                LbHarfler.ItemsSource = bilgi.HarfAl();
            }
        }

        private void BtnKelimeAra_Click(object sender, RoutedEventArgs e)
        {
            if(TbMetin.Text != string.Empty)
            {
                LbKelimeler.ItemsSource = bilgi.KelimeAra(TbMetin.Text);
            }
            else
            {
                LbKelimeler.ItemsSource = bilgi.KelimeAl();
            }
        }

        private void BtnHarfAra_Click(object sender, RoutedEventArgs e)
        {
            if (TbMetin.Text.Length == 1)
            {
                char aranan = Convert.ToChar(TbMetin.Text);
                LbHarfler.ItemsSource = null;
                LbHarfler.Items.Add(bilgi.HarfAra(aranan));
            }
            else if (TbMetin.Text.Length > 1)
            {
                MessageBox.Show("Arama için tek harf girilmesi gerekmektedir.");
            }
            else
            {
                LbHarfler.Items.Clear();
                LbHarfler.ItemsSource = bilgi.HarfAl();
            }
        }
    }
}
