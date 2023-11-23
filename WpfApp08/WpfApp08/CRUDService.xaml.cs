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
    /// Logique d'interaction pour CRUDService.xaml
    /// </summary>
    public partial class CRUDService : Window
    {
        public CRUDService()
        {
            InitializeComponent();
            // Centrer la fenêtre
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Rendre la fenêtre non redimensionnable
            ResizeMode = ResizeMode.NoResize;
        }
        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            Administrateur pageAcceuil = new Administrateur();
            pageAcceuil.Show();
            this.Close();
        }
    }
}
