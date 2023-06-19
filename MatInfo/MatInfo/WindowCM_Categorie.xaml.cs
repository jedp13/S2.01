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
    /// Logique d'interaction pour WindowCM_Categorie.xaml
    /// </summary>
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
            this.tbCategorie.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (String.IsNullOrEmpty(tbCategorie.Text))
            {
                MessageBox.Show("Erreur : Nom de categorie attendu !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // on doit déclencher la mise à jour du binding
                if (Validation.GetHasError((DependencyObject)tbCategorie))
                    MessageBox.Show(this.Owner, "Pas possible!", "Pb", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (((WCategorieMateriel)Owner).applicationData.LesCategories.ToList().Find(p => p.NomCategorie == this.tbCategorie.Text) is not null)
                {
                    MessageBox.Show(this.Owner, "Cette catégorie existe deja, prier utiliser un autre mail", "Nom deja prise", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
