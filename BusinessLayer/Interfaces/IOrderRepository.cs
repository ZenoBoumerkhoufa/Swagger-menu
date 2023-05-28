using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
    }
}
