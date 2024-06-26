﻿
using System.Windows;
using System.Windows.Input;

namespace WpfApp08
{
        public partial class Window1 : Window
        {
          public Window1()
          {
                InitializeComponent();
            // Centrer la fenêtre
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            
            ResizeMode = ResizeMode.NoResize;

            PreviewKeyDown += MainWindow_PreviewKeyDown;
            Loaded += (sender, e) => Focus();
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Vérifier si la combinaison de touches Ctrl + Shift + A est enfoncée
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.A)
            {
                // Ouvrir la fenêtre d'administration ici
                AdminMDP nouvelleFenetre = new AdminMDP();

                nouvelleFenetre.Show();
                this.Close();
            }
        }
        private void OuvrirNouvelleFenetre_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur nouvelleFenetre = new Utilisateur();

            nouvelleFenetre.Show();
            this.Close();
        }


    }

}