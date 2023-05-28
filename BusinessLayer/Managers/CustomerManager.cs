using BusinessLayer.DTOS;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using BusinessLayer.Model;

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
        public void AddCustomer(CustomerDTO customer)
        {
            _repo.AddCustomer(CustomerMapper.MapToEntity(customer));
        }
        #endregion

        #region UPDATE
        public void UpdateCustomer(Customer customer)
        {
            _repo.UpdateCustomer(customer);
        }
        #endregion
    }
}
