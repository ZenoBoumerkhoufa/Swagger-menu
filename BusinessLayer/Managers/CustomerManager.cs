using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class CustomerManager
    {
        private ICustomerRepository _repo;
        public CustomerManager(ICustomerRepository repo)
        {
            _repo = repo;
        }

        #region GET
        public List<Customer> GetAllCustomers()
        {
            List<Customer> items = new List<Customer>();
            foreach (Customer c in _repo.GetAllCustomers())
            {
                items.Add(c);
            }
            return items;
        }

        public Customer GetCustomerById(int id)
        {
            return _repo.GetCustomerById(id);
        }
        #endregion

        #region ADD
        public void AddCustomer(Customer customer)
        {
            _repo.AddCustomer(customer);
        }
        #endregion

        #region UPDATE
        public void UpdateCustomer(Customer customer)
        {
            _repo.UpdateCustomer(customer);
        }
        #endregion

        #region DELETE
        public void RemoveCustomer(Customer customer)
        {
            _repo.RemoveCustomer(customer);
        }
        #endregion
    }
}
