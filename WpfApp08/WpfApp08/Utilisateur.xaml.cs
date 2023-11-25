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
            Chargerlessites();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 PageAcceuil = new Window1();
            PageAcceuil.Show();
            this.Close();
        }
        private async void Chargerlessites()
        { 
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:7152/api/sites"; // Remplacez par l'URL correcte de votre API.

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var sites = JsonConvert.DeserializeObject<Sites[]>(json);


                        DataGrid2.ItemsSource = sites;
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

        private async void ChargerSalaries()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:7152/api/Salaries"; // Remplacez par l'URL correcte de votre API.

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var salaries = JsonConvert.DeserializeObject<Salaries[]>(json);


                        DataGrid1.ItemsSource = salaries;
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