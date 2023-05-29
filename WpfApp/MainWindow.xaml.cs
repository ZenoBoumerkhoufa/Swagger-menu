using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Bestellingen;
using WpfApp.klanten;
using WpfApp.Menu;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Customers_Click(object sender, RoutedEventArgs e)
        {
            Customers c = new Customers();
            c.Show();
            this.Close();
        }

        private void btn_MenuItems_Click(object sender, RoutedEventArgs e)
        {
            Items items = new Items();
            items.Show();
            this.Close();
        }

        private void btn_Orders_Click(object sender, RoutedEventArgs e)
        {
            Orders order = new Orders();
            order.Show();
            this.Close();
        }
    }
}
