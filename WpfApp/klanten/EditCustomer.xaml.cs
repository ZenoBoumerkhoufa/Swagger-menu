using BusinessLayer.Model;
using Newtonsoft.Json;
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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        private Customer selectedCustomer;

        public EditCustomer(Customer selectedCustomer)
        {
            InitializeComponent();

            this.selectedCustomer = selectedCustomer;

            txt_voornaam.Text = selectedCustomer.Voornaam;
            txt_achternaam.Text = selectedCustomer.Achternaam;
            txt_straat.Text = selectedCustomer.Straat;
            txt_huisnummer.Text = Convert.ToString(selectedCustomer.Huisnummer);
            txt_busnummer.Text = selectedCustomer.Busnummer;
            txt_stad.Text = selectedCustomer.Stad;
            txt_postcode.Text = selectedCustomer.Postcode;
            txt_land.Text = selectedCustomer.Land;
            txt_telefoonnummer.Text = selectedCustomer.Telefoonnummer;
            txt_email.Text = selectedCustomer.Email;
            pwb_paswoord.Password = selectedCustomer.Paswoord;

        }

        private async void btn_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();

            string apiUrl = "https://localhost:7138/api/Customers";

            Customer updatedCustomer = new Customer
            {
                Id = selectedCustomer.Id,
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
                Paswoord = pwb_paswoord.Password,

            };

            string json = JsonConvert.SerializeObject(updatedCustomer);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(apiUrl, content);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Customer data updated successfully.");

                Customers c = new Customers();
                c.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update customer data.");
            }
        }

        private void btn_terug_Click(object sender, RoutedEventArgs e)
        {
            Customers c = new Customers();
            c.Show();
            this.Close();
        }
    }
}
