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

namespace Uygulama7
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTikla_Click(object sender, RoutedEventArgs e)
        {
            var liste = Veri.ListeAl();
            var sonuc = liste.Where(kayit => kayit.Yas >= 18 && kayit.Yas <= 35)
                             .OrderBy(kayit => kayit.AdSoyad)
                             .Select(k => $"{k.Id}-{k.AdSoyad}-{k.Yas}")
                             .Skip(2)
                             .Take(3);
            lbListe.ItemsSource = sonuc;
        }
    }
}
