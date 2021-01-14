using System.Windows;
using System.Windows.Controls;

namespace Uygulama12
{
    public partial class Eleman : UserControl
    {
        public string Deger { get; set; }
        public Eleman(string deger)
        {
            InitializeComponent();
            Deger = deger;
            LblIcerik.Content = deger;
            BtnSola.IsEnabled = false;
        }
        public void YerDegistir()
        {
            BtnSola.IsEnabled = !BtnSola.IsEnabled;
            BtnSaga.IsEnabled = !BtnSaga.IsEnabled;
        }
    }
}
