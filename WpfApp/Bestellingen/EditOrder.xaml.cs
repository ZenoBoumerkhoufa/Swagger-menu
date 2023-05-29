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

namespace WpfApp.Bestellingen
{
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        private Order selected;
        public EditOrder(BusinessLayer.Model.Order selected)
        {
            InitializeComponent();

            this.selected = selected;

            OrderItem orderItem = selected.Items.FirstOrDefault();

            txt_klantId.Text = Convert.ToString(selected.CustomerId);
            txt_MenuItemId.Text = Convert.ToString(orderItem.MenuItemId);
            txt_aantal.Text = Convert.ToString(orderItem.Aantal);
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

                Order updatedOrder = new Order
                {
                    Id = selected.CustomerId,
                    CustomerId = Convert.ToInt32(txt_klantId.Text),
                };

                // Serialize the updated order object to JSON
                string json = JsonConvert.SerializeObject(updatedOrder);

                // Define the API endpoint URL for updating the order
                string apiUrl = $"https://localhost:7138/api/Orders";

                // Create an HttpClient instance
                HttpClient client = new HttpClient();

                // Create the HttpContent with the JSON payload
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the PUT request to the API endpoint
                HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Order updated successfully
                    // Handle the successful response
                    MessageBox.Show("Order updated successfully.");
                }
                else
                {
                    // Failed to update the order
                    // Handle the failure
                    MessageBox.Show("Failed to update the order.");
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
