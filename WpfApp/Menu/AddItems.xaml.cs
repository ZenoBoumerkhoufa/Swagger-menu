using BusinessLayer.Model;
using System;
using System.Collections.Generic;
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
using MenuItem = BusinessLayer.Model.MenuItem;

namespace WpfApp.Menu
{
    /// <summary>
    /// Interaction logic for AddItems.xaml
    /// </summary>
    public partial class AddItems : Window
    {
        private const string apiUrl = "https://localhost:7138/api/MenuItems";
        public AddItems()
        {
            InitializeComponent();
        }

        private async void btn_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create an instance of the model and set its properties
                MenuItem item = new MenuItem
                {
                    Naam = txt_naam.Text,
                    Beschrijving = txt_beschrijving.Text,
                    Prijs = Convert.ToDecimal(txt_prijs.Text),
                    Voorraad = Convert.ToInt32(txt_voorraad.Text),
                };

                // Convert the model to JSON
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(item);

                using (HttpClient client = new HttpClient())
                {
                    // Send the POST request with the JSON data
                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                    // Check the response status
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Data sent successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                        Items i = new Items();
                        i.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to send data. Status Code: {response.StatusCode}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_terug_Click(object sender, RoutedEventArgs e)
        {
            Items items = new Items();
            items.Show();
            this.Close();
        }
    }
}
