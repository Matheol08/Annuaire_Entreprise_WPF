using System;
using System.Collections.Generic;
using System.Windows;
using System.Data.SqlClient;
using WPF_Salaries;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfApp08
{
    /// <summary>
    /// Logique d'interaction pour Window3.xaml
    /// </summary>
    public partial class Utilisateur : Window
    {
        public Utilisateur()
        {
            InitializeComponent();
           // ChargerDonnees();
        }

        //private void ChargerDonnees()
        //{
        //    try
        //    {
        //        string chaineConnexion = "Server=.\\SQLExpress;Database=Annuaire;Trusted_Connection=True;TrustServerCertificate=true";
        //        using (SqlConnection connexion = new SqlConnection(chaineConnexion))
        //        {
        //            connexion.Open();

        //            string commandeSql = "SELECT * FROM Salarie"; // Remplacez Salarie par le nom de votre table
        //            using (SqlCommand cmd = new SqlCommand(commandeSql, connexion))
        //            {
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        // Créer un objet Salarie et ajouter à la collection
        //                        Salaries salarie = new Salaries
        //                        {
        //                            ID = reader.GetInt32(0), 
        //                            Nom = reader.GetString(1), 
        //                            Prenom = reader.GetString(2) ,
        //                            Telephone_fixe = reader.GetString(3),
        //                            Telephone_portable = reader.GetString(4),
        //                            Email = reader.GetString(5)
        //                        };

        //                        Salaries.Add(salarie);
        //                    }
        //                }
        //            }
        //        }

        //        // Associer la collection à la DataGrid
        //        MyDataGrid.ItemsSource = Salaries;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Une erreur s'est produite : " + ex.Message);
        //    }
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
            {
                Window1 PageAcceuil = new Window1();
                PageAcceuil.Show();
                this.Close();
            }
    }
}
