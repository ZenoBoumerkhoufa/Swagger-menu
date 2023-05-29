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

namespace WpfApp.Bestellingen
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        private const string apiUrl = "https://localhost:7138/api/Orders";
        public Orders()
        {
            InitializeComponent();
            LoadOrders();
        }

        private async void LoadOrders()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();
                    List<Order> it = JsonConvert.DeserializeObject<List<Order>>(json);
                    dg_orders.ItemsSource = it;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void dg_Order_DoubleClicked(object sender, RoutedEventArgs e)
        {
            // Get the selected customer from the DataGrid
            Order selected = (Order)dg_orders.SelectedItem;

            // Open the new window for editing the customer data
            EditOrder ec = new EditOrder(selected);
            ec.Show();
            this.Close();
        }
    }
}
