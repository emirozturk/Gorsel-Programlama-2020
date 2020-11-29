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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnIslemYap_Click(object sender, RoutedEventArgs e)
        {
            //Ekrandan cümleyi bir şekilde elde et
            string cumle = TbCumle.Text;
            //Ekrandan temizlenecek string'i bir şekilde elde et
            string temizlenecek = TbKelime.Text;
            //alınan cümle içerisinden temizlenecek karakteri ya da stringi temizle
            string sonuc = cumle.Replace(temizlenecek, "");
            //sonuç metnini 3gram'lara böl
            List<string> liste = new List<string>();
            for (int i = 0; i < sonuc.Length; i += 3)
                if (i + 3 < sonuc.Length)
                    liste.Add(sonuc.Substring(i, 3));
                else
                    liste.Add(sonuc.Substring(i, sonuc.Length - i));
            //elde edilen 3gram listesini ekrandaki listbox içerisinde göster
            LbListe.ItemsSource = liste;
        }
    }
}
