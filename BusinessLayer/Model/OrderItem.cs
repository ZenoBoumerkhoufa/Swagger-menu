using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class OrderItem
    {
        public MenuItem MenuItem { get; set; }
        public int Aantal { get; set; }

        public OrderItem() { }

        public OrderItem(MenuItem menuItem, int quantity)
        {
            MenuItem = menuItem;
            Aantal = quantity;
        }
    }
}
