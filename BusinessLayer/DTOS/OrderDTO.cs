using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOS
{
    public class OrderDTO
    {
        public int CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } // List of OrderItem
        public DateTime OrderPlaatsing { get; set; }
        public DateTime OrderBetaling { get; set; }
    }
}
