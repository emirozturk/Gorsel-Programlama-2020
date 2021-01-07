using System;
using System.Collections.Generic;
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

namespace Uygulama11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int sayac;
        public MainWindow()
        {
            InitializeComponent();
            WpBilesenler.VerticalAlignment = VerticalAlignment.Top;
            sayac = 0;
        }
        public void YeniTusEkle()
        {
            Button yeniTus = new Button()
            {
                Name = "BtnTus"+sayac,
                Width = 100,
                Height = 50,
                Content = "Tuş "+sayac,
                Margin = new Thickness(3)
            };
            sayac++;
            yeniTus.Click += YeniTus_Click;
            WpBilesenler.Children.Add(yeniTus);
        }

        private void YeniTus_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Name + " Tıklandı.");
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            YeniTusEkle();
        }

        private void BtnDegistir_Click(object sender, RoutedEventArgs e)
        {
            string tusIsmi = "BtnTus" + TbBoyut.Text;
            foreach(var eleman in WpBilesenler.Children)
                if(eleman is Button)
                {
                    Button btn = eleman as Button;
                    if(btn.Name == tusIsmi)
                    {
                        btn.Width = 200;
                        btn.Height = 200;
                    }
                }
        }

        private void BtnSil_Click(object sender, RoutedEventArgs e)
        {
            string tusIsmi = "BtnTus" + TbBoyut.Text;
            Button bulunan= new Button();
            foreach (var eleman in WpBilesenler.Children)
                if (eleman is Button)
                    if ((eleman as Button).Name == tusIsmi)
                        bulunan = eleman as Button;
            WpBilesenler.Children.Remove(bulunan);
        }
    }
}
