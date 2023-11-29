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
   
    public partial class AdminMDP : Window
    {
        public AdminMDP()
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
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValiderMotDePasse();
        }

        private void ValiderMotDePasse()
        {

            // Vérifier le mot de passe (remplacez "votreMotDePasse" par le mot de passe réel)
            string motDePasseAttendu = "3XFAhF!5";
                string motDePasseSaisi = passwordBox.Password;

                if (motDePasseSaisi == motDePasseAttendu)
                {
                Administrateur pageadmin = new Administrateur();
                pageadmin.Show();
                this.Close();

                }
                else
                {
                passwordBox.Password = "";
                MessageBox.Show("Mot de passe incorrect. Veuillez réessayer.");
                    
                }
        }
        
    }
}
