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

namespace WpfApp.Menu
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Window
    {
        private const string apiUrl = "https://localhost:7138/api/MenuItems";
        public Items()
        {
            InitializeComponent();
            LoadItems();
        }

        private async void LoadItems()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<MenuItem> it = JsonConvert.DeserializeObject<List<MenuItem>>(json);
                        dg_Items.ItemsSource = it;
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

        private void dg_Items_DoubleClicked(object sender, RoutedEventArgs e)
        {
            MenuItem selectedItem = (MenuItem)dg_Items.SelectedItem;

            // Open the new window for editing the customer data
            EditItems ei = new EditItems(selectedItem);
            ei.Show();
            this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btn_toevoegen_Click(object sender, RoutedEventArgs e)
        {
            AddItems ai = new AddItems();
            ai.Show();
            this.Close();
        }
    }
}
