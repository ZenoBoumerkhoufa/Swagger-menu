using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class OrderItem
    {
        public int MenuItemId { get; set; }
        public int Aantal { get; set; }

        public OrderItem() { }

        public OrderItem(int menuItemId, int quantity)
        {
            MenuItemId = menuItemId;
            Aantal = quantity;
        }
    }
}
