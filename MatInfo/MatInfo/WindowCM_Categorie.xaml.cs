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
    /// Logique d'interaction pour WindowCM_Categorie.xaml
    /// </summary>
    public enum Mode { Insert, Update };
    public partial class WindowCM_Categorie : Window
    {
        public WindowCM_Categorie(CategorieMateriel cat, Mode mode)
        {
            this.DataContext = cat;
            InitializeComponent();
            if (mode == Mode.Update)
            {
                btCreer.Content = "Modifier";
                this.Title = "Modification catégorie";
            }
            else if (mode == Mode.Insert)
            {
                btCreer.Content = "Ajouter";
                this.Title = "Ajout catégorie";
            }
        }

        private void BtCreer_Click(object sender, RoutedEventArgs e)
        {
            // on doit déclencher la mise à jour du binding
            this.tbCategorie.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError((DependencyObject)tbCategorie))
                MessageBox.Show(this.Owner, "Pas possible!", "Pb", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                DialogResult = true;   // ferme automatiquement la fenêtre      
            }
        }

        private void BtAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // ferme automatiquement la fenêtre      
        }
    }
}
