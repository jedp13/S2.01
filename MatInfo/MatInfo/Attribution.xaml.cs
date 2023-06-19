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
    /// Logique d'interaction pour Attribution.xaml
    /// </summary>
    public partial class WAttribution : Window
    {
        public WAttribution()
        {
            InitializeComponent();
            lvAttribution.SelectedIndex = 0;
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
            WindowCM_Attribution winAjoutAttribution = new WindowCM_Attribution(new EstAttribue(), Mode.Insert, this);


            bool reponse = (bool)winAjoutAttribution.ShowDialog();
            if (reponse == true && winAjoutAttribution.DataContext is EstAttribue)
            {
                EstAttribue a = (EstAttribue)winAjoutAttribution.DataContext;
                a.Create();
                applicationData.LesAttributions.Insert(applicationData.LesAttributions.Count , a);
            }
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {

            WindowCM_Attribution winAjoutAttribution = new WindowCM_Attribution((EstAttribue)lvAttribution.SelectedItem, Mode.Update, this);
            winAjoutAttribution.Owner = this;

            bool reponse = (bool)winAjoutAttribution.ShowDialog();
            if (reponse == true)
            {
                Materiel a = (Materiel)lvAttribution.SelectedItem; // (Materiel)winAjoutMateriel.DataContext;
                a.Update();
            }



        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(" Vous êtes sur de vouloir suprimer " + ((EstAttribue)lvAttribution.SelectedItem) , "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Materiel a = (Materiel)lvAttribution.SelectedItem;
                a.Delete();
                applicationData.LesMateriaux.Remove(a);
                lvAttribution.SelectedIndex = 0;
            }
        }
    }
}
