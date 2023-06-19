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

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            WindowCM_Materiel winAjoutMateriel = new WindowCM_Materiel(new Materiel(), Mode.Insert,this);
          

            bool reponse = (bool)winAjoutMateriel.ShowDialog();
            if (reponse == true && winAjoutMateriel.DataContext is Materiel)
            {
                Materiel m = (Materiel)winAjoutMateriel.DataContext;
                m.Create();
                applicationData.LesMateriaux.Insert(applicationData.LesMateriaux.Count , m);
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
            MessageBoxResult result = MessageBox.Show(" Vous êtes sur de vouloir suprimer " + ((Materiel)lvMateriel.SelectedItem), "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Materiel m= (Materiel)lvMateriel.SelectedItem;
                m.Delete();
                applicationData.LesMateriaux.Remove(m);
                lvMateriel.SelectedIndex = 0;
            }
        }


    }
}
