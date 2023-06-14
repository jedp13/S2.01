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
using System.Windows.Shapes;

namespace MatInfo
{
    /// <summary>
    /// Logique d'interaction pour Personnel.xaml
    /// </summary>
    public partial class WPersonnel : Window
    {
        public WPersonnel()
        {
            InitializeComponent();
        }

        private void btCM_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            WCategorieMateriel categorieMateriel = new WCategorieMateriel();
            categorieMateriel.ShowDialog();
        }

        private void btM_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            WMateriel materiel = new WMateriel();
            materiel.ShowDialog();
        }

        private void btA_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            WAttribution attribution = new WAttribution();
            attribution.ShowDialog();
        }

        private void btP_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            WPersonnel personnel = new WPersonnel();
            personnel.ShowDialog();
        }

        
    }
}
