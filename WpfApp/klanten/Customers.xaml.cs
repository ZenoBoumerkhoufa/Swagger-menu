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
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {
        private const string apiUrl = "https://localhost:7138/api/Customers";
        public Customers()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private async void LoadCustomers()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                        dg_Customers.ItemsSource = customers;
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve customer data from the API.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btn_toevoegen_Click(object sender, RoutedEventArgs e)
        {
            AddCustomers ac = new AddCustomers();
            ac.Show();
            this.Close();
        }

        private void dg_Customer_DoubleClicked(object sender, RoutedEventArgs e)
        {
            // Get the selected customer from the DataGrid
            Customer selectedCustomer = (Customer)dg_Customers.SelectedItem;

            // Open the new window for editing the customer data
            EditCustomer ec = new EditCustomer(selectedCustomer);
            ec.Show();
            this.Close();
        }
    }
}
