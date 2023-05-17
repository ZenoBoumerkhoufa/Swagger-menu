using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class OrderManager
    {
        private IOrderRepository _repo;
        public OrderManager(IOrderRepository repo)
        {
            _repo = repo;
        }
        #region GET
        public List<Order> GetAllOrders()
        {
            List<Order> items = new List<Order>();
            foreach (Order o in _repo.GetAllOrders())
            {
                items.Add(o);
            }
            return items;
        }
        public Order GetOrderById(int id)
        {
            return _repo.GetOrderById(id);
        }
        #endregion

        #region ADD
        public void AddOrder(Order order)
        {
            _repo.AddOrder(order);
        }
        #endregion

        #region UPDATE
        public void UpdateOrder(Order order)
        {
            _repo.UpdateOrder(order);
        }
        #endregion

        #region DELETE
        public void RemoveOrder(Order order)
        {
            _repo.RemoveOrder(order);
        }
        #endregion
    }
}
