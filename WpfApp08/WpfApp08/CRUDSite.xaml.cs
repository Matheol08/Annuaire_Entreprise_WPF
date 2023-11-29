using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
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
using WpfApp08.Models3;

namespace WpfApp08
{
    /// <summary>
    /// Logique d'interaction pour CrudSite.xaml
    /// </summary>
    public partial class CRUDSite : Window
    {

        public ObservableCollection<Sites> Sites { get; set; }
        public CRUDSite()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;


            ResizeMode = ResizeMode.NoResize;
            Chargerlessites();
            Sites = new ObservableCollection<Sites>();
            DataGrid1.ItemsSource = Sites;
        }



        private async void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Ville.Text) )
            {
                // Afficher un message à l'utilisateur
                MessageBox.Show("Veuillez remplir les champs Ville et Statut_Site.");
            }
            else
            {

                string Nouveasite = Ville.Text;

                Sites nouveauSite = new Sites
                {
                    Ville = Nouveasite,
                };

                Sites.Add(nouveauSite);

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
            private async Task<bool> EnvoyerDonneesAvecAPI(Sites site)
            {
                try
                {

                    string apiUrl = "https://localhost:7152/api/sites";


                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(site);

                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PostAsync(apiUrl, content);
                    CRUDSite Pagesite = new CRUDSite();
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
            Sites siteSelectionne = (Sites)DataGrid1.SelectedItem;

            if (siteSelectionne != null)
            {
            
                int siteId = siteSelectionne.IDSite; 
            
       
                bool deleteSuccess = await SupprimerDonneesAvecAPI(siteId);

                if (deleteSuccess)
                {
         
                    MessageBox.Show("Suppression réussie !");
          
                    Sites.Remove(siteSelectionne);
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

        private async Task<bool> SupprimerDonneesAvecAPI(int siteId)
        {
            try
            {
                string apiUrl = $"https://localhost:7152/api/sites/{siteId}";

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.DeleteAsync(apiUrl);
                    CRUDSite Pagesite = new CRUDSite();
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
      
                var editedRow = e.Row.Item as Sites;


                var nouvelleValeur = (e.EditingElement as TextBox).Text;
            }
        
            private async void MAJ_Click(object sender, RoutedEventArgs e)
            {

                Sites siteSelectionne = (Sites)DataGrid1.SelectedItem;

                if (siteSelectionne != null)
                {
      
                    int siteId = siteSelectionne.IDSite;

             
                    bool updateSuccess = await MettreAJourDonneesAvecAPI(siteId, siteSelectionne);

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
        

            private async Task<bool> MettreAJourDonneesAvecAPI(int siteId, Sites site)
            {
                try
                {
                    string apiUrl = $"https://localhost:7152/api/sites/{siteId}";

                    using (HttpClient client = new HttpClient())
                    {
                        var jsonData = JsonConvert.SerializeObject(site);
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
        

        private void Button_Click(object sender, RoutedEventArgs e)
            {

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
            private async void Chargerlessites()
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


        
    }
}