using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Order
    {
        public int id { get; private set; }
        public Customer customer { get; set; }
        public Dictionary<MenuItem, int> items { get; set; } //menuitem, aantal

        public Order(Customer customer, Dictionary<MenuItem, int> items)
        {
            this.customer = customer;
            this.items = items;
        }
    }
}
