using BusinessLayer.DTOS;
using BusinessLayer.Exceptions;
using BusinessLayer.Managers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("api/[controller]s")] // wordt .../Customer
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> logger;
        private IConfiguration iConfig;
        private CustomerManager _CustomerManager;

        public CustomerController(ILogger<CustomerController> logger, IConfiguration iconfig)
        {
            this.logger = logger;
            this.iConfig = iconfig;
            _CustomerManager = new CustomerManager(new CustomerRepository(iConfig.GetValue<string>("ConnectionStrings:database")));
        }

        [HttpGet(Name = "GetAllCustomers")]
        public ActionResult<List<Customer>> Get()
        {
            try
            {
                List<Customer> customers = _CustomerManager.GetAllCustomers();
                if (customers == null)
                    return NotFound();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex);
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
                return StatusCode(500, "An unexpected error occurred: " + ex);
            }
        }

        [HttpPost(Name = "AddCustomer")]
        public ActionResult Add([FromBody] CustomerDTO c)
        {
            try
            {
                _CustomerManager.AddCustomer(c);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex);
            }
        }

        [HttpPut(Name = "UpdateCustomer")]
        public ActionResult Put([FromBody] Customer customer)
        {
            try
            {
                _CustomerManager.UpdateCustomer(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex);
            }
        }
    }
}
