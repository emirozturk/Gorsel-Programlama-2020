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

namespace Uygulama12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> liste;
        public MainWindow()
        {
            InitializeComponent();
            liste = new List<string>() { "Eleman 1", "Eleman 2", "Eleman 3", "Eleman 4", "Eleman 5" };
            ListeleriDoldur();
        }

        private void ListeleriDoldur()
        {
            foreach (var deger in liste)
            {
                Eleman eleman = new Eleman(deger);
                LbEklenecek.Items.Add(eleman);
            }
        }

        private void LbEklenecek_Click(object sender, RoutedEventArgs e)
        {
            Eleman eleman = e.Source as Eleman;
            LbEklenecek.Items.Remove(eleman);
            eleman.YerDegistir();
            LbEklenen.Items.Add(eleman);
        }

        private void LbEklenen_Click(object sender, RoutedEventArgs e)
        {
            Eleman eleman = e.Source as Eleman;
            LbEklenen.Items.Remove(eleman);
            eleman.YerDegistir();
            LbEklenecek.Items.Add(eleman);
        }
    }
}
