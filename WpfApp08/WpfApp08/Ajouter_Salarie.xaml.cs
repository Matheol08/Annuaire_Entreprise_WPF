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
using WPF_Salaries;
using WpfApp08.Models2;
using WpfApp08.Models3;


namespace WpfApp08
{
    public partial class Ajouter_Salarie : Window
    {
        public ObservableCollection<Salaries> Salaries { get; set; }
        public Ajouter_Salarie()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ResizeMode = ResizeMode.NoResize;
            InitializeComponent();
            ChargerLesServices();
            ChargerLesSites();
            Salaries = new ObservableCollection<Salaries>();
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

                        
                        Combo2.ItemsSource = sites;
                        Combo2.DisplayMemberPath = "Ville";
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
                        Combo1.ItemsSource = services;
                        Combo1.DisplayMemberPath = "Nom_Service";
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

        private async void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (string.IsNullOrEmpty(Text1.Text) ||
                    string.IsNullOrEmpty(Text2.Text) ||
                    string.IsNullOrEmpty(Text3.Text) ||
                    string.IsNullOrEmpty(Text4.Text) )
                    //string.IsNullOrEmpty(Text5.Text) ||
                    //Combo1.SelectedItem == null || // Vérifier si un élément est sélectionné dans Combo1
                    //Combo2.SelectedItem == null)  // Vérifier si un élément est sélectionné dans Combo2
                {
                    // Afficher un message à l'utilisateur
                    MessageBox.Show("Veuillez remplir tous les champs requis.");
                }
                else
                {
                    
                    // Créer un nouvel objet Salaries
                    Salaries nouveauSalarie = new Salaries
                    {
                        // Assigner les valeurs des champs
                        Nom = Text1.Text,
                        Prenom = Text2.Text,
                        Telephone_fixe = Text3.Text,
                        Telephone_portable = Text4.Text,
                        Email = Text5.Text
                    };

                    // Ajouter le nouvel objet à votre collection ou liste (Salaries.Add)
                    // Assurez-vous que Salaries est votre collection de Salaries
                    Salaries.Add(nouveauSalarie);

                    // Envoyer les données à l'API
                    bool updateSuccess = await EnvoyerDonneesAvecAPI(nouveauSalarie);

                    if (updateSuccess)
                    {
                        // Mise à jour réussie
                        MessageBox.Show("Mise à jour réussie !");
                        CRUDEmploye pageAcceuil = new CRUDEmploye();
                        pageAcceuil.Show();
                        this.Close();
                    }
                    else
                    {
                        // Échec de la mise à jour
                        MessageBox.Show("Échec de la mise à jour.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}");
            }
        }

        private async Task<bool> EnvoyerDonneesAvecAPI(Salaries Salaries)
        {
            try
            {

                string apiUrl = "https://localhost:7152/api/salaries";


                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(Salaries);

                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content);
                    
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
            CRUDEmploye pageAcceuil = new CRUDEmploye();
            pageAcceuil.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
