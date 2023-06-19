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
using MatInfo.Model;

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
            //seConnecter connecter = new seConnecter();
            //connecter.ShowDialog();
            
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

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string requete = $" join personnel p on est_attribue.idpersonnel = p.idpersonnel join materiel m on est_attribue.idmateriel = m.idmateriel join categorie_materiel c on m.idcategorie = c.idcategorie";
            if (lvCategorie.SelectedIndex != -1)
            {
                lvMateriaux.ItemsSource = ((CategorieMateriel)lvCategorie.SelectedItem).LesMateriaux;
                lvMateriaux.Items.Refresh();

                if (lvMateriaux.SelectedIndex != -1)
                    requete = $" join personnel p on est_attribue.idpersonnel = p.idpersonnel join materiel m on est_attribue.idmateriel = m.idmateriel join categorie_materiel c on m.idcategorie = c.idcategorie where est_attribue.idmateriel = {((Materiel)lvMateriaux.SelectedItem).IdMateriel}";

            }
            if (lvPersonnel.SelectedIndex != -1)
            {
                requete = $" join personnel p on est_attribue.idpersonnel = p.idpersonnel join materiel m on est_attribue.idmateriel = m.idmateriel join categorie_materiel c on m.idcategorie = c.idcategorie where est_attribue.idpersonnel = {((Personnel)lvPersonnel.SelectedItem).IdPersonnel} ";
                 if (lvMateriaux.SelectedIndex != -1)
                    requete = $" join personnel p on est_attribue.idpersonnel = p.idpersonnel join materiel m on est_attribue.idmateriel = m.idmateriel join categorie_materiel c on m.idcategorie = c.idcategorie where est_attribue.idpersonnel = {((Personnel)lvPersonnel.SelectedItem).IdPersonnel} and est_attribue.idmateriel = {((Materiel)lvMateriaux.SelectedItem).IdMateriel}";
            }
            EstAttribue a = new EstAttribue();
            lvAttributions.ItemsSource = a.FindBySelection(requete);
            lvAttributions.Items.Refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            lvCategorie.SelectedIndex = -1;
            lvMateriaux.SelectedIndex = -1;
            lvPersonnel.SelectedIndex = -1;
            lvAttributions.ItemsSource = applicationData.LesAttributions;
            lvMateriaux.ItemsSource = applicationData.LesMateriaux;
        }
    }
}
