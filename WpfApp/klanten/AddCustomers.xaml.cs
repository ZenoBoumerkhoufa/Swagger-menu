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

namespace WpfApp.klanten
{
    /// <summary>
    /// Interaction logic for AddCustomers.xaml
    /// </summary>
    public partial class AddCustomers : Window
    {
        private const string apiUrl = "https://localhost:7138/api/Customers";
        public AddCustomers()
        {
            InitializeComponent();
        }

        private void btn_terug_Click(object sender, RoutedEventArgs e)
        {
            Customers c = new Customers();
            c.Show();
            this.Close();
        }

        private async void btn_toevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create an instance of the model and set its properties
                Customer customer = new Customer
                {
                    Voornaam = txt_voornaam.Text,
                    Achternaam = txt_achternaam.Text,
                    Straat = txt_straat.Text,
                    Huisnummer = Convert.ToInt32(txt_huisnummer.Text),
                    Busnummer = txt_busnummer.Text,
                    Stad = txt_stad.Text,
                    Postcode = txt_postcode.Text,
                    Land = txt_land.Text,
                    Telefoonnummer = txt_telefoonnummer.Text,
                    Email = txt_email.Text,
                    Paswoord = pwb_paswoord.Password
                };

                // Convert the model to JSON
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(customer);

                using (HttpClient client = new HttpClient())
                {
                    // Send the POST request with the JSON data
                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                    // Check the response status
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Data sent successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                        Customers c = new Customers();
                        c.Show();
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
    }
}
