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

namespace WpfApp08
{
    /// <summary>
    /// Logique d'interaction pour Window4_Admin.xaml
    /// </summary>
    public partial class Administrateur : Window
    {
        public Administrateur()
        {
            InitializeComponent();
            // Centrer la fenêtre
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Rendre la fenêtre non redimensionnable
            ResizeMode = ResizeMode.NoResize;
        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 PageAcceuil = new Window1();
            PageAcceuil.Show();
            this.Close();
        }
        private void Button_site(object sender, RoutedEventArgs e)
        {
            CRUDSite Pagesite = new CRUDSite();
            Pagesite.Show();
            this.Close();
        }
        private void Button_service(object sender, RoutedEventArgs e)
        {
            CRUDService Pagesite = new CRUDService();
            Pagesite.Show();
            this.Close();
        }
        private void Button_utilisateur(object sender, RoutedEventArgs e)
        {
            CRUDEmploye PageEmploye = new CRUDEmploye();
            PageEmploye.Show();
            this.Close();
        }

       
    }
}