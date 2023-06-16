using MatInfo.Model;
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
            lvPersonnel.SelectedIndex = 0;
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

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            WindowCM_Personnel winAjoutPersonnel = new WindowCM_Personnel(new Personnel(), Mode.Insert);
            winAjoutPersonnel.Owner = this;

            bool reponse = (bool)winAjoutPersonnel.ShowDialog();
            if (reponse == true && winAjoutPersonnel.DataContext is Personnel)
            {
                Personnel p = (Personnel)winAjoutPersonnel.DataContext;
                applicationData.LesPersonnels.Insert(0, p);
                p.Create();
            }
        }

        private void btModif_Click(object sender, RoutedEventArgs e)
        {
            WindowCM_Personnel winAjoutPersonnel = new WindowCM_Personnel((Personnel)lvPersonnel.SelectedItem, Mode.Update);
            winAjoutPersonnel.Owner = this;

            bool reponse = (bool)winAjoutPersonnel.ShowDialog();
            if (reponse == true)
            {
                Personnel p = (Personnel)winAjoutPersonnel.DataContext;
                p.Update();
            }
        }

        private void btSupr_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(" Vous êtes sur de vouloir suprimer " + ((Personnel)lvPersonnel.SelectedItem).NomPersonnel+" "+ ((Personnel)lvPersonnel.SelectedItem).PrenomPersonnel, "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Personnel p = (Personnel)lvPersonnel.SelectedItem;
                p.Delete();
                applicationData.LesPersonnels.Remove(p);
                lvPersonnel.SelectedIndex = 0;
            }
        }
    }
}
