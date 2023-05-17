using BusinessLayer.Managers;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("api/[controller]s")] // wordt .../Customer
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> logger;
        private CustomerManager _CustomerManager;

        public CustomerController(ILogger<CustomerController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "GetAllCustomers")]
        public ActionResult<List<Customer>> Get()
        {
            try
            {
                List<Customer> list = _CustomerManager.GetAllCustomers();
                if (list == null) return NotFound();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                // throw new CustomerException("CustomerController: GetAllCustomers", ex);
            }
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        public ActionResult<Customer> GetAction(int id)
        {
            try
            {
                Customer c = _CustomerManager.GetCustomerById(id);
                if (c == null) return NotFound();
                return Ok(c);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                //throw new CustomerException("CustomerController: GetCustomerById", ex);
            }
        }

        [HttpPost(Name = "AddCustomer")]
        public ActionResult Add([FromBody] Customer c)
        {
            try
            {
                _CustomerManager.AddCustomer(c);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                // throw new CustomerException("CustomerController: AddCostumer", ex);
            }
        }

        [HttpPut(Name = "UpdateCustomer")]
        public ActionResult Put([FromBody] Customer c)
        {
            try
            {
                _CustomerManager.UpdateCustomer(c);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                // throw new CustomerException("CustomerController: UpdateCustomer", ex);
            }
        }

        [HttpDelete("{id}", Name = "DeleteCustomer")]
        public ActionResult Delete(int id)
        {
            try
            {
                Customer c = _CustomerManager.GetCustomerById(id);
                if (c == null) return NotFound();
                _CustomerManager.RemoveCustomer(c);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                //throw new CustomerException("CustomerController: DeleteCustomer", ex);
            }
        }
    }
}
