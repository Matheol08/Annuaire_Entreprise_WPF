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
    /// Logique d'interaction pour CrudSite.xaml
    /// </summary>
    public partial class CRUDSite : Window
    {
        public CRUDSite()
        {
            InitializeComponent();
            // Centrer la fenêtre
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Rendre la fenêtre non redimensionnable
            ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // si le texbox != "" alors ajouter le site a la bdd 
            //si dans la combo un site est selectionné et qui existe dans la bdd alors le supprimer
        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            Administrateur Pagesite = new Administrateur();
            Pagesite.Show();
            this.Close();
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
