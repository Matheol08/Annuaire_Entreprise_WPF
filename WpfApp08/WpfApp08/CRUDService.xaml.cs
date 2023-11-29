using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
using WpfApp08.Models2;

namespace WpfApp08
{
    /// <summary>
    /// Logique d'interaction pour CRUDService.xaml
    /// </summary>
    public partial class CRUDService : Window
    {
         public ObservableCollection<Service> Service { get; set; }
        public CRUDService()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;


            ResizeMode = ResizeMode.NoResize;
            Chargerlesservices();
            Service = new ObservableCollection<Service>();
            DataGrid1.ItemsSource = Service;
        }



        private async void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Nom_Service.Text) )
            {
                // Afficher un message à l'utilisateur
                MessageBox.Show("Veuillez remplir le champ service.");
            }
            else
            {

                string Nouveasite = Nom_Service.Text;

                Service nouveauSite = new Service
                {
                    Nom_Service = Nouveasite,

                };

                Service.Add(nouveauSite);

                bool updateSuccess = await EnvoyerDonneesAvecAPI(nouveauSite);

                if (updateSuccess)
                {
                    // Mise à jour réussie
                    MessageBox.Show("Mise à jour réussie !");
                }
                else
                {
                    // Échec de la mise à jour
                    MessageBox.Show("Échec de la mise à jour.");
                }
            }
        }
        private async Task<bool> EnvoyerDonneesAvecAPI(Service Service)
        {
            try
            {

                string apiUrl = "https://localhost:7152/api/services";


                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(Service);

                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content);
                    CRUDService Pagesite = new CRUDService();
                    Pagesite.Show();
                    this.Close();
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erreur lors de la mise à jour : {ex.Message}");
                return false;
            }
        }
        private async void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            // Obtenez la ligne sélectionnée dans le DataGrid
            Service siteSelectionne = (Service)DataGrid1.SelectedItem;

            if (siteSelectionne != null)
            {

                int serviceId = siteSelectionne.IDService;


                bool deleteSuccess = await SupprimerDonneesAvecAPI(serviceId);

                if (deleteSuccess)
                {

                    MessageBox.Show("Suppression réussie !");

                    Service.Remove(siteSelectionne);
                }
                else
                {

                    MessageBox.Show("Échec de la suppression.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.");
            }
        }

        private async Task<bool> SupprimerDonneesAvecAPI(int serviceId)
        {
            try
            {
                string apiUrl = $"https://localhost:7152/api/services/{serviceId}";

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.DeleteAsync(apiUrl);
                    CRUDService Pagesite = new CRUDService();
                    Pagesite.Show();
                    this.Close();
                    return response.IsSuccessStatusCode;
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}");
                return false;
            }
        }


        private void DataGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            var editedRow = e.Row.Item as Service;


            var nouvelleValeur = (e.EditingElement as TextBox).Text;
        }

        private async void MAJ_Click(object sender, RoutedEventArgs e)
        {

            Service serviceSelectionne = (Service)DataGrid1.SelectedItem;

            if (serviceSelectionne != null)
            {

                int serviceID = serviceSelectionne.IDService;


                bool updateSuccess = await MettreAJourDonneesAvecAPI(serviceID, serviceSelectionne);

                if (updateSuccess)
                {

                    MessageBox.Show("Mise à jour réussie !");
                }
                else
                {

                    MessageBox.Show("Échec de la mise à jour.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à mettre à jour.");
            }
        }


        private async Task<bool> MettreAJourDonneesAvecAPI(int serviceID, Service Service)
        {
            try
            {
                string apiUrl = $"https://localhost:7152/api/services/{serviceID}";

                using (HttpClient client = new HttpClient())
                {
                    var jsonData = JsonConvert.SerializeObject(Service);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(apiUrl, content);
                   
                    return response.IsSuccessStatusCode;
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la mise à jour : {ex.Message}");
                return false;
            }
        }



        private async void Chargerlesservices()
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
                        var sites = JsonConvert.DeserializeObject<Service[]>(json);


                        DataGrid1.ItemsSource = sites;
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
            private void RetourButton_Click(object sender, RoutedEventArgs e)
            {
                Administrateur Pagesite = new Administrateur();
                Pagesite.Show();
                this.Close();
            }

        

    }
}
