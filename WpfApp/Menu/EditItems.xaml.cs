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
    /// Interaction logic for EditItems.xaml
    /// </summary>
    public partial class EditItems : Window
    {
        private const string apiUrl = "https://localhost:7138/api/MenuItems";
        private MenuItem selectedItem;
        public EditItems(MenuItem selectedItem)
        {
            InitializeComponent();

            this.selectedItem = selectedItem;

            txt_naam.Text = selectedItem.Naam;
            txt_beschrijving.Text = selectedItem.Beschrijving;
            txt_prijs.Text = Convert.ToString(selectedItem.Prijs);
            txt_voorraad.Text = Convert.ToString(selectedItem.Voorraad);
        }

        private async void btn_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();

            MenuItem updateItem = new MenuItem
            {
                Id = selectedItem.Id,
                Naam = txt_naam.Text,
                Beschrijving = txt_beschrijving.Text,
                Prijs = Convert.ToDecimal(txt_prijs.Text),
                Voorraad = Convert.ToInt32(txt_voorraad.Text),
            };

            string json = JsonConvert.SerializeObject(updateItem);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(apiUrl, content);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("MenuItem data updated successfully.");

                Items i = new Items();
                i.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update MenuItem data.");
            }
        }

        private void btn_terug_Click(object sender, RoutedEventArgs e)
        {
            Items i = new Items();
            i.Show();
            this.Close();
        }
    }
}
