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
using MatInfo.Model;

namespace MatInfo
{
    /// <summary>
    /// Logique d'interaction pour WindowCM_Personnel.xaml
    /// </summary>
    public partial class WindowCM_Personnel : Window
    {
        public WindowCM_Personnel(Personnel perso,Mode mode)
        {
            this.DataContext = perso;
            InitializeComponent();
            if (mode == Mode.Update)
            {
                btCreer.Content = "Modifier";
                this.Title = "Modification personnel";
            }
            else if (mode == Mode.Insert)
            {
                btCreer.Content = "Ajouter";
                this.Title = "Ajout personnel";
            }
        }

        private void BtCreer_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbPrenomPerso.Text) || String.IsNullOrEmpty(tbNomPerso.Text) || String.IsNullOrEmpty(tbMailPerso.Text))
            {
                MessageBox.Show("Erreur : Le nom, le prenom et le mail sont attendus !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // on doit déclencher la mise à jour du binding
                

                if (Validation.GetHasError((DependencyObject)tbPrenomPerso) || Validation.GetHasError((DependencyObject)tbNomPerso) || Validation.GetHasError((DependencyObject)tbMailPerso))
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
