using BusinessLayer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;

namespace WpfApp.Bestellingen
{
    public partial class Orders : Window
    {
        private const string apiUrl = "https://localhost:7138/api/Orders";

        public List<Order> orderList { get; set; }

        public Orders()
        {
            InitializeComponent();
            DataContext = this;
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
                    List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(json);
                    orderList = orders;
                    treeViewOrders.ItemsSource = orderList;
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
            Close();
        }

        private void btn_toevoegen_Click(object sender, RoutedEventArgs e)
        {
            AddOrders ao = new AddOrders();
            ao.Show();
            Close();
        }

        private void treeViewOrders_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Order selectedOrder = treeViewOrders.SelectedItem as Order;

            if (selectedOrder != null)
            {
                EditOrder editOrderWindow = new EditOrder(selectedOrder);
                editOrderWindow.Show();
                this.Close();
            }
        }
    }
}
