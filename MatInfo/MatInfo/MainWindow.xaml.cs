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
using MatInfo;

namespace MatInfo
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public enum Mode { Insert, Update };

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            seConnecter connecter = new seConnecter();
            connecter.ShowDialog();
        }



        private void miAcceuil_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.ShowDialog();
            this.Close();

        }

        private void miCategorie_Click(object sender, RoutedEventArgs e)
        {
            WCategorieMateriel categorieMateriel = new WCategorieMateriel();
            categorieMateriel.ShowDialog();
            this.Close();
        }

        private void miPersonnel_Click(object sender, RoutedEventArgs e)
        {
            WPersonnel personnel = new WPersonnel();
            personnel.ShowDialog();
            this.Close();
        }

        private void miMateriel_Click(object sender, RoutedEventArgs e)
        {
            WMateriel materiel = new WMateriel();
            materiel.ShowDialog();
            this.Close();
        }

        private void miAttribution_Click(object sender, RoutedEventArgs e)
        {
            WAttribution attribution = new WAttribution();
            attribution.ShowDialog();
            this.Close();
        }

        private void miQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
