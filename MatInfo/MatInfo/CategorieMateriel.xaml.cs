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



        private void miAcceuil_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();

            this.Close();
            mainwindow.ShowDialog();
        }

        private void miCategorie_Click(object sender, RoutedEventArgs e)
        {
            WCategorieMateriel categorieMateriel = new WCategorieMateriel();

            this.Close();
            categorieMateriel.ShowDialog();
        }

        private void miPersonnel_Click(object sender, RoutedEventArgs e)
        {
            WPersonnel personnel = new WPersonnel();

            this.Close();
            personnel.ShowDialog();
        }

        private void miMateriel_Click(object sender, RoutedEventArgs e)
        {
            WMateriel materiel = new WMateriel();

            this.Close();
            materiel.ShowDialog();
        }

        private void miAttribution_Click(object sender, RoutedEventArgs e)
        {
            WAttribution attribution = new WAttribution();

            this.Close();
            attribution.ShowDialog();
        }

        private void miQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                applicationData.LesCategories.Insert(applicationData.LesPersonnels.Count, c);
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
            MessageBoxResult result = MessageBox.Show(" Vous êtes sur de vouloir suprimer " + ((CategorieMateriel)lvCategorie.SelectedItem), "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                CategorieMateriel c = (CategorieMateriel)lvCategorie.SelectedItem;
                c.Delete();
                applicationData.LesCategories.Remove(c);
                lvCategorie.SelectedIndex = 0;
            }
        }


    }   
}
