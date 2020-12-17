using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dosyalama2
{
    public partial class IcerikWindow : Window
    {
        private string dosyaYolu;
        public IcerikWindow(string dosyaYolu)
        {
            InitializeComponent();
            this.dosyaYolu = dosyaYolu;
            TbIcerik.Text = File.ReadAllText(dosyaYolu);
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(dosyaYolu, TbIcerik.Text);
        }
    }
}
