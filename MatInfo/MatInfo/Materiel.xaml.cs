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
    /// Logique d'interaction pour Materiel.xaml
    /// </summary>
    public partial class WMateriel : Window
    {
        public WMateriel()
        {
            InitializeComponent();
            lvMateriel.SelectedIndex = 0;
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
            WindowCM_Materiel winAjoutMateriel = new WindowCM_Materiel(new Materiel(), Mode.Insert,this);
          

            bool reponse = (bool)winAjoutMateriel.ShowDialog();
            if (reponse == true && winAjoutMateriel.DataContext is Materiel)
            {
                Materiel m = (Materiel)winAjoutMateriel.DataContext;
                m.Create();
            }
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {

            WindowCM_Materiel winAjoutMateriel = new WindowCM_Materiel((Materiel)lvMateriel.SelectedItem, Mode.Update,this);
            winAjoutMateriel.Owner = this;

            bool reponse = (bool)winAjoutMateriel.ShowDialog();
            if (reponse == true)
            {
                Materiel m = (Materiel)lvMateriel.SelectedItem; // (Materiel)winAjoutMateriel.DataContext;
                m.Update();
            }



        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(" Vous êtes sur de vouloir suprimer " + ((Materiel)lvMateriel.SelectedItem).NomMateriel, "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Materiel m= (Materiel)lvMateriel.SelectedItem;
                m.Delete();
                lvMateriel.SelectedIndex = 0;
            }
        }


    }
}
