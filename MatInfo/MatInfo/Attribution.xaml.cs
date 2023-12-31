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
    /// Logique d'interaction pour Attribution.xaml
    /// </summary>
    public partial class WAttribution : Window
    {
        public WAttribution()
        {
            InitializeComponent();
            lvAttribution.SelectedIndex = 0;
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
                EstAttribue a = (EstAttribue)lvAttribution.SelectedItem; // (Materiel)winAjoutMateriel.DataContext;
                a.Update();
            }



        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(" Vous êtes sur de vouloir suprimer " + ((EstAttribue)lvAttribution.SelectedItem) , "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                EstAttribue a = (EstAttribue)lvAttribution.SelectedItem;
                a.Delete();
                applicationData.LesAttributions.Remove(a);
                lvAttribution.SelectedIndex = 0;
            }
        }
    }
}
