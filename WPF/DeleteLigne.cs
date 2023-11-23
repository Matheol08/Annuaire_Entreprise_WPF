using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

//namespace WPF_Delete
//{
//    public partial class MainWindow : Window
//    {
//            public DataGrid MyDataGrid { get; private set; }
        
//        private int selectedIndex = -1;

//        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            // Capture la ligne sélectionnée
//            if (myDataGrid.SelectedItem != null)
//            {
//                selectedIndex = myDataGrid.SelectedIndex;
//            }
//        }

//        private void SelectionnerLigneButton_Click(object sender, RoutedEventArgs e)
//        {

//            if (selectedIndex >= 0)
//            {

//                MessageBox.Show($"Ligne sélectionnée : {selectedIndex}");
//            }
//            else
//            {

//                MessageBox.Show("Aucune ligne sélectionnée.");
//            }
//        }

//        private void SupprimerLigneButton_Click(object sender, RoutedEventArgs e)
//        {
//            // Vérifiez si une ligne est sélectionnée
//            if (selectedIndex >= 0)
//            {
//                // Obtenez la vue de collection liée au DataGrid (supposons une liaison à une ObservableCollection)
//                ObservableCollection<myDataGrid> dataSource = myDataGrid.ItemsSource as ObservableCollection<>;

//                // Assurez-vous que la vue de collection n'est pas null et que l'index est valide
//                if (dataSource != null && selectedIndex < dataSource.Count)
//                {
//                    // Supprimez la ligne du jeu de données
//                    dataSource.RemoveAt(selectedIndex);

//                    // Rafraîchissez l'affichage
//                    myDataGrid.Items.Refresh();
//                }

//                // Réinitialisez l'index après la suppression
//                selectedIndex = -1;
//            }
//            else
//            {
//                // Affichez un message indiquant qu'aucune ligne n'est sélectionnée
//                MessageBox.Show("Aucune ligne sélectionnée.");
//            }
//        }
//    }
//}