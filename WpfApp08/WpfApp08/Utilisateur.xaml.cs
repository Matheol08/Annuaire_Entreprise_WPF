using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
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
using WpfApp08.Models2;
using WpfApp08.Models3;
using static Azure.Core.HttpHeader;
using System.Threading.Tasks;

namespace WpfApp08
{
    public partial class Utilisateur : Window
    {
        private AnnuaireContext dbContext;
        public Utilisateur()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Rendre la fenêtre non redimensionnable
            ResizeMode = ResizeMode.NoResize;
            ChargerLesSites();
            ChargerSalaries();
            ChargerLesServices();
            dbContext = new AnnuaireContext(new DbContextOptions<AnnuaireContext>());

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 PageAcceuil = new Window1();
            PageAcceuil.Show();
            this.Close();
        }
        private void Actualiser(object sender, RoutedEventArgs e)
        {
            ChargerSalaries();
        }

        private async void Bouton_Rechercher(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Si les deux ComboBox sont sélectionnés
                if (ComboVille.SelectedItem != null && ComboService.SelectedItem != null)
                {
                    var selectedSite = (Sites)ComboVille.SelectedItem;
                    var selectedService = (Service)ComboService.SelectedItem;

                    string selectedVille = selectedSite.Ville;
                    string selectedNomService = selectedService.Nom_Service;

                    // Ajustez l'URL pour inclure les paramètres ville et nomService
                    string apiUrl = $"https://localhost:7152/api/salaries/rechercheSiteEtService?ville={selectedVille}&nomService={selectedNomService}";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    HandleApiResponse(response);
                }
                // Si seulement ComboVille est sélectionné
                else if (ComboVille.SelectedItem != null)
                {
                    var selectedSite = (Sites)ComboVille.SelectedItem;
                    string selectedVille = selectedSite.Ville;

                    // Ajustez l'URL pour inclure le paramètre ville
                    string apiUrl = $"https://localhost:7152/api/salaries/rechercheSite?ville={selectedVille}";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    HandleApiResponse(response);
                }
                // Si seulement ComboService est sélectionné
                else if (ComboService.SelectedItem != null)
                {
                    var selectedService = (Service)ComboService.SelectedItem;
                    string selectedNomService = selectedService.Nom_Service;

                    // Ajustez l'URL pour inclure le paramètre nomService
                    string apiUrl = $"https://localhost:7152/api/salaries/rechercheService?Nom_Service={selectedNomService}";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    HandleApiResponse(response);
                }
              
                
                    string searchTerm = RechercherText.Text;

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        string apiUrl = $"https://localhost:7152/api/salaries/rechercheByNameORFirstName?searchTerm={searchTerm}";

                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        HandleApiResponse(response);
                    }
                
            }
        }
    

        private async Task HandleApiResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                // Utilisez Newtonsoft.Json pour désérialiser le JSON en une liste de Salaries
                var results = JsonConvert.DeserializeObject<List<Salaries>>(json);

                // Faites quelque chose avec la liste de Salaries (results)
                DataGrid1.ItemsSource = results;
            }
            else
            {
                MessageBox.Show("Erreur lors de la requête API.");
            }

            // Remettez à null les ComboBox après la requête
            ComboVille.SelectedItem = null;
            ComboService.SelectedItem = null;
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
                        DataGrid1.Columns.Add(new DataGridTextColumn { Header = "Nom_Service", Binding = new Binding("Service_Employe.Nom_Service") });

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
        private async void ChargerLesSites()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:7152/api/sites";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var sites = JsonConvert.DeserializeObject<Sites[]>(json);


                        ComboVille.ItemsSource = sites;
                        ComboVille.DisplayMemberPath = "Ville";
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
        private async void ChargerLesServices()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:7152/api/services";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var services = JsonConvert.DeserializeObject<Service[]>(json);

                        // Assigner la liste des services au ComboBox
                        ComboService.ItemsSource = services;
                        ComboService.DisplayMemberPath = "Nom_Service";
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