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
    /// Logique d'interaction pour WindowCM_Materiel.xaml
    /// </summary>
    public partial class WindowCM_Materiel : Window
    {
        private Mode mode;
        public WindowCM_Materiel(Materiel mat, Mode mode, Window owner  )
        {
            this.mode = mode;
            this.Owner = owner;
            this.DataContext = mat;
            InitializeComponent();
            this.cbCategorie.ItemsSource = ((ApplicationData)this.Owner.DataContext).LesCategories;
            if (mode == Mode.Update)
            {
                btCreer.Content = "Modifier";
                this.Title = "Modification catégorie";
                this.cbCategorie.SelectedItem = mat.UneCategorie;
            }
            else if (mode == Mode.Insert)
            {
                btCreer.Content = "Ajouter";
                this.Title = "Ajout catégorie";
              
            }

        }

        private void BtCreer_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbNomMat.Text) || String.IsNullOrEmpty(tbRefMat.Text) || String.IsNullOrEmpty(tbCodeBarMat.Text) || cbCategorie.SelectedIndex ==-1)
            {
                MessageBox.Show("Erreur : Le nom, le ref et codebarre sont attendus !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
               

                if (Validation.GetHasError((DependencyObject)tbRefMat) || Validation.GetHasError((DependencyObject)tbCodeBarMat) || Validation.GetHasError((DependencyObject)tbNomMat)|| Validation.GetHasError((DependencyObject)cbCategorie))
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
