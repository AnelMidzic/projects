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
using WpfVideoKlub.Views.Clanovi;
using WpfVideoKlub.Views.Filmovi;

namespace WpfVideoKlub
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

        private void ButtonClanovi_Click(object sender, RoutedEventArgs e)
        {
            WindowClan w1 = new WindowClan();
            w1.Owner = this;
            w1.ShowDialog();
        }

        private void ButtonFilmovi_Click(object sender, RoutedEventArgs e)
        {
            WindowFilm w1 = new WindowFilm();
            w1.Owner = this;
            w1.ShowDialog();
        }
    }
}
