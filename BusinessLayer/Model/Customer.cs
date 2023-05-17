using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Customer
    {
        public int id { get; private set; }
        public string name { get; set; }
        public string address { get; set; }

        public Customer(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
    }
}
