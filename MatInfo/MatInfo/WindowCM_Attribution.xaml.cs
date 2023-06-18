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
    /// Logique d'interaction pour WindowCM_Attribution.xaml
    /// </summary>

    public partial class WindowCM_Attribution : Window
    {
        private Mode mode;

        public WindowCM_Attribution(EstAttribue atr,Mode mode, Window owner)
        {
            this.mode = mode;
            this.Owner = owner;
            this.DataContext = atr;
            InitializeComponent();
            this.cbMateriel.ItemsSource = ((ApplicationData)this.Owner.DataContext).LesMateriaux;
            this.cbPersonnel.ItemsSource = ((ApplicationData)this.Owner.DataContext).LesPersonnels;

            if (mode == Mode.Update)
            {
                btCreer.Content = "Modifier";
                this.Title = "Modification catégorie";
                this.cbMateriel.SelectedItem = atr.UnMateriel;
                this.cbPersonnel.SelectedItem = atr.UnPersonnel;

            }
            else if (mode == Mode.Insert)
            {
                btCreer.Content = "Ajouter";
                this.Title = "Ajout catégorie";

            }
        }

        private void BtCreer_Click(object sender, RoutedEventArgs e)
        {
            if ( cbMateriel.SelectedIndex == -1 || cbPersonnel.SelectedIndex == -1/*||dpDate.*/)
            {
                MessageBox.Show("Erreur : Le materiel, le personnel et date sont attendus !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {


                if (Validation.GetHasError((DependencyObject)cbMateriel) || Validation.GetHasError((DependencyObject)cbPersonnel) || Validation.GetHasError((DependencyObject)dpDate) )
                    MessageBox.Show(this.Owner, "Pas possible!", "Pb", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    DialogResult = true;   // ferme automatiquement la fenêtre      
                }
            }

        }

        private void BtAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // ferme automatiquement la fenêtre      
        }


    }
}
