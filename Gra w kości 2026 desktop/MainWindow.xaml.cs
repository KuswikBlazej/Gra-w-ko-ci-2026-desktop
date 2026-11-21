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

namespace Gra_w_kości_2026_desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Kosc[] kosci = new Kosc[5];

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < kosci.Length; i++)
            {
                kosci[i] = new Kosc();
            }

            AktualizujWidok();
        }

        private void Rzut_Click(object sender, RoutedEventArgs e)
        {
            int suma = 0;

            for (int i = 0; i < kosci.Length; i++)
            {
                if (kosci[i].CzyDostepna)
                {
                    kosci[i].Rzuc();
                    suma += kosci[i].LiczbaOczek;
                }
            }

            txtWynik.Content = suma.ToString();

            AktualizujWidok();
        }

        private void Kosc_Click(object sender, RoutedEventArgs e)
        {
            Image obraz = sender as Image;

            if (obraz == null)
                return;

            int numerKosci = int.Parse(obraz.Tag.ToString());

            kosci[numerKosci].ZmienDostepnosc();

            AktualizujWidok();
        }

        private void AktualizujWidok()
        {
            Image[] obrazy =
            {
                K1,
                K2,
                K3,
                K4,
                K5
            };

            for (int i = 0; i < kosci.Length; i++)
            {
                string nazwaPliku =
                    $"Images/kosc{kosci[i].LiczbaOczek}.png";

                obrazy[i].Source = new BitmapImage(
                    new Uri(nazwaPliku, UriKind.Relative)
                );

                obrazy[i].Opacity =
                    kosci[i].CzyDostepna ? 1.0 : 0.5;
            }
        }
    }
}
