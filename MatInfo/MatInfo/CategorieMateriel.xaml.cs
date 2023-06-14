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
using MatInfo;

namespace MatInfo
{
    /// <summary>
    /// Logique d'interaction pour CategorieMateriel.xaml
    /// </summary>
    public partial class WCategorieMateriel : Window
    {
        public WCategorieMateriel()
        {
            InitializeComponent();
            lvCategorie.SelectedIndex = 0;
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
            WindowCM_Categorie winAjoutCategorie = new WindowCM_Categorie(new CategorieMateriel(), Mode.Insert);
            winAjoutCategorie.Owner = this;

            bool reponse = (bool)winAjoutCategorie.ShowDialog();
            if (reponse == true && winAjoutCategorie.DataContext is CategorieMateriel)
            {
                CategorieMateriel c = (CategorieMateriel)winAjoutCategorie.DataContext;
                c.Create();
            }
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {

                WindowCM_Categorie winAjoutCategorie = new WindowCM_Categorie((CategorieMateriel)lvCategorie.SelectedItem, Mode.Update);
                winAjoutCategorie.Owner = this;

                bool reponse = (bool)winAjoutCategorie.ShowDialog();
                if (reponse == true)
                {
                    CategorieMateriel c = (CategorieMateriel)winAjoutCategorie.DataContext;
                    c.Update();
                }
            
            

        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(" Vous êtes sur de vouloir suprimer " + ((CategorieMateriel)lvCategorie.SelectedItem).NomCategorie, "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                CategorieMateriel c = (CategorieMateriel)lvCategorie.SelectedItem;
                c.Delete();
                lvCategorie.SelectedIndex = 0;
            }
        }
    }   
}
