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

namespace Uygulama3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); //Ön yüzün çizdirilmesi için.
        }

        private void BtnSayi_Click(object sender, RoutedEventArgs e)
        {
            //Ekrandan tıklanmış herhangi bir tuş object olarak sender'a düşer.
            //daha sonra sender Button türüne dönüştürülür ve content'i string'e çevirilerek içerisindeki sayı değeri elde edilir.
            string tusIcerigi = (sender as Button).Content.ToString(); 
            //Elde edilen sayı değeri tbZiyaretciAdi textbox'ının içerisine eklenir.
            tbZiyaretciAdi.Text += tusIcerigi;
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            string ziyaretciAdi = tbZiyaretciAdi.Text; //Ekrandaki textboxtan adın alınması
            string zaman = "";
            if (RbSabah.IsChecked.Value) zaman = "Sabah"; //eğer ilk radiobutton seçili ise
            else if (RbOglen.IsChecked.Value) zaman = "Oglen";//eğer ikinci radiobutton seçili ise
            else if (RbAksam.IsChecked.Value) zaman = "Aksam"; //eğer üçüncü radiobutton seçili ise
            string vipMi = ""; //vip kısmı seçilirse üzerine eklenecek string değişken
            if (CbVipMi.IsChecked.Value) vipMi = " - (VIP)"; //Bir üst satırda tanımlanan string değişken vip seçili olduğu durumda bu değer ile değiştirilir.
            string eklenecek = ziyaretciAdi + "-" + zaman + vipMi; //Yukarıda tanımlı 3 stringin birleştirilmesi
            LbZiyaretciler.Items.Add(eklenecek); //Birleştirilmiş string'in listeye eklenmesi
        }

        private void TbAra_TextChanged(object sender, TextChangedEventArgs e)
        {
            string aranan = TbAra.Text; //Aranacak text'in textbox'tan elde edilmesi
            for(int i = 0; i<LbZiyaretciler.Items.Count; i++)//Listedeki tüm elemanlar için döngü
            {
                if (LbZiyaretciler.Items[i].ToString().Contains(aranan)) //Eğer listenin i.inci elemanının string'e dönüştürülmüş hali aranan'ı içeriyorsa
                    MessageBox.Show(LbZiyaretciler.Items[i].ToString());//listenin i.inci elemanını stringe dönüştür ve mesaj kutusu olarak kaydı göster.
            }
        }
    }
}
