using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;



namespace WPF_Annuaire
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Obtenez les données de la base de données
            List<Personne> personnes = GetPersonnesFromDatabase();

            // Lier la liste de personnes au DataGrid
            myDataGrid.ItemsSource = personnes;
        }
        public List<Personne> GetPersonnesFromDatabase()
        {
            List<Personne> personnes = new List<Personne>();

            // Chaîne de connexion à votre base de données
            string connectionString = "Server=localhost;Database=Ryzen;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT Nom, Prenom, Ville, NumeroTel, NumeroFix, Email FROM Annuaire";

                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Personne personne = new Personne
                            {
                                Nom = reader["Nom"].ToString(),
                                Prénom = reader["Prenom"].ToString(),
                                Ville = reader["Ville"].ToString(),
                                NumeroTel = reader["NumeroTel"].ToString(),
                                NumeroFix = reader["NumeroFix"].ToString(),
                                Email = reader["Email"].ToString()
                            };

                            personnes.Add(personne);


                        }
                    }
                }
            }

            return personnes;
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }


    // Classe de modèle de données pour une personne
    public class Personne
    {
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string Ville { get; set; }
        public string Service { get; set; }
        public string NumeroTel { get; set; }
        public string NumeroFix { get; set; }

        public string Email { get; set; }

    }
}



