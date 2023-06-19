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
            WindowCM_Personnel winAjoutPersonnel = new WindowCM_Personnel(new Personnel(), Mode.Insert,this);
            winAjoutPersonnel.Owner = this;

            bool reponse = (bool)winAjoutPersonnel.ShowDialog();
            if (reponse == true && winAjoutPersonnel.DataContext is Personnel)
            {
                Personnel p = (Personnel)winAjoutPersonnel.DataContext;
                p.Create();
                applicationData.LesPersonnels.Insert(applicationData.LesPersonnels.Count, p);

            }
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            WindowCM_Personnel winAjoutPersonnel = new WindowCM_Personnel((Personnel)lvPersonnel.SelectedItem, Mode.Update,this);
            winAjoutPersonnel.Owner = this;

            bool reponse = (bool)winAjoutPersonnel.ShowDialog();
            if (reponse == true)
            {
                Personnel p = (Personnel)winAjoutPersonnel.DataContext;
                p.Update();
            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(" Vous êtes sur de vouloir suprimer " + ((Personnel)lvPersonnel.SelectedItem), "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

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
