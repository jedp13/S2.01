﻿using MatInfo.Model;
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
    /// Logique d'interaction pour CategorieMateriel.xaml
    /// </summary>
    public partial class CategorieMateriel : Window
    {
        public CategorieMateriel()
        {
            InitializeComponent();
        }

       

        private void btCM_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            CategorieMateriel categorieMateriel = new CategorieMateriel();
            categorieMateriel.ShowDialog();
        }

        private void btM_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Materiel materiel = new Materiel();
            materiel.ShowDialog();
        }

        private void btA_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Attribution attribution = new Attribution();
            attribution.ShowDialog();
        }

        private void btP_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Personnel personnel = new Personnel();
            personnel.ShowDialog();
        }

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            WindowCM_Categorie winAjoutCategorie = new WindowCM_Categorie(new CategorieMateriel(), Mode.Insert);
            winAjoutCategorie.Owner = this;

            bool reponse = (bool)winAjoutCategorie.ShowDialog();
            if (reponse == true)
            {
                //winAjoutCategorie.(CategorieMateriel)DataContext.Creer();
            }
        }

        private void butModifier_Click(object sender, RoutedEventArgs e)
        {
            WindowCM_Categorie winAjoutCategorie = new WindowCM_Categorie((CategorieMateriel)lvCategorie.SelectedItem, Mode.Update);
            winAjoutCategorie.Owner = this;

            bool reponse = (bool)winAjoutCategorie.ShowDialog();
            if (reponse == true)
            {
                lvCategorie.Items.Refresh();
            }

        }
    }   
}
