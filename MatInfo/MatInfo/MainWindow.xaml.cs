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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            seConnecter connecter = new seConnecter();
            connecter.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            CategorieMaterielW categorieMateriel = new CategorieMaterielW();
            categorieMateriel.ShowDialog();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Materiel materiel = new Materiel();
            materiel.ShowDialog();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            Attribution attribution = new Attribution();
            attribution.ShowDialog();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            Personnel personnel = new Personnel();
            personnel.ShowDialog();
            this.Close();
        }
    }
}
