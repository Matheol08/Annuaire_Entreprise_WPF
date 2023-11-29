using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using WPF_Salaries;
using WpfApp08.Models3;
namespace WpfApp08
{
    public partial class Utilisateur : Window
    {
        public Utilisateur()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Rendre la fenêtre non redimensionnable
            ResizeMode = ResizeMode.NoResize;
            ChargerSalaries();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 PageAcceuil = new Window1();
            PageAcceuil.Show();
            this.Close();
        }


        private async void ChargerSalaries()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:7152/api/salaries";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var salaries = JsonConvert.DeserializeObject<List<Salaries>>(json);

                        // Supprimez les colonnes existantes si nécessaire
                        DataGrid1.Columns.Clear();

                        // Définissez manuellement les colonnes que vous souhaitez afficher
                        DataGrid1.ItemsSource = salaries;
                        DataGrid1.Columns.Add(new DataGridTextColumn { Header = "Nom", Binding = new Binding("Nom") });
                        DataGrid1.Columns.Add(new DataGridTextColumn { Header = "Prenom", Binding = new Binding("Prenom") });
                        DataGrid1.Columns.Add(new DataGridTextColumn { Header = "Ville", Binding = new Binding("Sites.Ville") });
                        DataGrid1.Columns.Add(new DataGridTextColumn { Header = "TelephoneFixe", Binding = new Binding("Telephone_fixe") });
                        DataGrid1.Columns.Add(new DataGridTextColumn { Header = "TelephonePortable", Binding = new Binding("Telephone_portable") });
                        DataGrid1.Columns.Add(new DataGridTextColumn { Header = "Email", Binding = new Binding("Email") });
                    }
                    else
                    {
                        MessageBox.Show($"Erreur lors de la récupération des données : {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}");
            }
        }













    }
}