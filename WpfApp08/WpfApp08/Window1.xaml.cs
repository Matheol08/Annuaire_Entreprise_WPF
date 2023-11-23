
using System.Windows;
namespace WpfApp08
{
        public partial class Window1 : Window
        {
          public Window1()
          {
                InitializeComponent();
            // Centrer la fenêtre
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

                // Rendre la fenêtre non redimensionnable
                ResizeMode = ResizeMode.NoResize;
                


        }

        private void OuvrirNouvelleFenetre_Click(object sender, RoutedEventArgs e)
        {
           
            Utilisateur nouvelleFenetre = new Utilisateur();

            nouvelleFenetre.Show();
            this.Close();
        }

        
            private void OuvrirFenetre_Admin_Click(object sender, RoutedEventArgs e)
        {

            AdminMDP nouvelleFenetre = new AdminMDP();

            nouvelleFenetre.Show();
            this.Close();
        }
    }

}