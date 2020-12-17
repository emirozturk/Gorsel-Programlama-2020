using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dosyalama2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string surucu;
        string klasor;
        string dosya;
        public MainWindow()
        {
            InitializeComponent();
            CmbSuruculer.ItemsSource = Directory.GetLogicalDrives();
        }

        private void LbKlasorler_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LbKlasorler.SelectedItem != null)
            {
                klasor = LbKlasorler.SelectedItem.ToString();
                LbKlasorler.ItemsSource = Directory.GetDirectories(klasor);
            }
        }

        private void LbKlasorler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbKlasorler.SelectedItem != null)
            {
                klasor = LbKlasorler.SelectedItem.ToString();
                LbDosyalar.ItemsSource = Directory.GetFiles(klasor);
            }
        }

        private void LbDosyalar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string dosyaAdi = LbDosyalar.SelectedItem.ToString();
            string dosyaYolu = Path.Combine(klasor, dosyaAdi);
            IcerikWindow yeniPencere = new IcerikWindow(dosyaYolu);
            this.Visibility = Visibility.Hidden;
            yeniPencere.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void CmbSuruculer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            surucu = CmbSuruculer.SelectedItem.ToString();
            LbKlasorler.ItemsSource = Directory.GetDirectories(surucu);
        }
    }
}
