using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class MenuItem
    {
        public int id { get; private set; }
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
    }
}
