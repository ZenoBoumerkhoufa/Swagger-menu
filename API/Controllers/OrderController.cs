using BusinessLayer.DTOS;
using BusinessLayer.Managers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("api/[controller]s")] // wordt .../Order
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> logger;
        private IConfiguration iConfig;
        private OrderManager _OrderManager;

        public OrderController(ILogger<OrderController> logger, IConfiguration iconfig)
        {
            this.logger = logger;
            this.iConfig = iconfig;
            _OrderManager = new OrderManager(new OrderRepository(iConfig.GetValue<string>("ConnectionStrings:database")));
        }

        [HttpGet(Name = "GetAllOrders")]
        public ActionResult<List<Order>> Get()
        {
            try
            {
                List<Order> o = _OrderManager.GetAllOrders();
                if (o == null) return NotFound();
                return Ok(o);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex);
            }
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<Order> GetAction(int id)
        {
            try
            {
                Order o = _OrderManager.GetOrderById(id);
                if (o == null) return NotFound();
                return Ok(o);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex);
            }
        }

        [HttpPost(Name = "AddOrder")]
        public ActionResult Add([FromBody] OrderDTO o)
        {
            try
            {
                _OrderManager.AddOrder(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex);
            }
        }

        [HttpPut(Name = "UpdateOrder")]
        public ActionResult Put([FromBody] Order o)
        {
            try
            {
                _OrderManager.UpdateOrder(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex);
            }
        }
    }
}
