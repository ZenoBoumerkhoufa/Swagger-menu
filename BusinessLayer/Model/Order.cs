using System;
using System.Collections.Generic;

namespace BusinessLayer.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } // List of OrderItem
        public DateTime OrderPlaatsing { get; set; }
        public DateTime OrderBetaling { get; set; }

        public Order() { }

        public Order(int id, int customerId, List<OrderItem> items, DateTime orderPlaatsing, DateTime orderBetaling)
        {
            Id = id;
            CustomerId = customerId;
            Items = items;
            OrderPlaatsing = orderPlaatsing;
            OrderBetaling = orderBetaling;
        }

        public Order(int customerId, List<OrderItem> items, DateTime orderPlaatsing, DateTime orderBetaling)
        {
            CustomerId = customerId;
            Items = items;
            OrderPlaatsing = orderPlaatsing;
            OrderBetaling = orderBetaling;
        }
    }
}
