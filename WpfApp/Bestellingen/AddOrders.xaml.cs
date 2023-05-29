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
using WpfApp.klanten;
using MenuItem = BusinessLayer.Model.MenuItem;

namespace WpfApp.Bestellingen
{
    /// <summary>
    /// Interaction logic for AddOrders.xaml
    /// </summary>
    public partial class AddOrders : Window
    {
        private const string apiUrl = "https://localhost:7138/api/Orders";
        public AddOrders()
        {
            InitializeComponent();
        }

        private void btn_terug_Click(object sender, RoutedEventArgs e)
        {
            Orders o = new Orders();
            o.Show();
            this.Close();
        }

        private async void btn_toevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a new order
                Order newOrder = new Order
                {
                    CustomerId = Convert.ToInt32(txt_klantId.Text),
                    OrderPlaatsing = DateTime.Now,
                    OrderBetaling = DateTime.Now,
                };

                // Create a list of order items
                List<OrderItem> orderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        MenuItemId = Convert.ToInt32(txt_MenuItemId.Text),
                        Aantal = Convert.ToInt32(txt_aantal.Text),
                    },
                    // Add more order items if needed
                };

                // Associate the list of order items with the order
                newOrder.Items = orderItems;

                // Serialize the order object to JSON
                string json = JsonConvert.SerializeObject(newOrder);

                // Define the API endpoint URL
                string apiUrl = "https://localhost:7138/api/Orders";

                // Create an HttpClient instance
                HttpClient client = new HttpClient();

                // Create the HttpContent with the JSON payload
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the POST request to the API endpoint
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Order created successfully
                    // Handle the successful response
                    MessageBox.Show("Order created successfully.");
                    Orders o = new Orders();
                    o.Show();
                    this.Close();
                }
                else
                {
                    // Failed to create the order
                    // Handle the failure
                    MessageBox.Show("Failed to create the order.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
