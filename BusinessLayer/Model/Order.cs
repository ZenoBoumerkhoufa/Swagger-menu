using System;
using System.Collections.Generic;

namespace BusinessLayer.Model
{
    public class Order
    {
        public int Id { get; private set; }
        public int CustomerId { get; set; }
        public Dictionary<MenuItem, int> Items { get; set; } // MenuItem, aantal
        public DateTime OrderPlaatsing { get; private set; }
        public DateTime OrderBetaling { get; private set; }

        public Order(int customerId, Dictionary<MenuItem, int> items, DateTime orderPlaatsing, DateTime orderBetaling)
        {
            CustomerId = customerId;
            Items = items;
            OrderPlaatsing = orderPlaatsing;
            OrderBetaling = orderBetaling;
        }
    }
}
