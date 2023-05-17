using BusinessLayer.Managers;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("api/[controller]s")] // wordt .../Order
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> logger;
        private OrderManager _OrderManager;

        public OrderController(ILogger<OrderController> logger)
        {
            this.logger = logger;
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
                return StatusCode(500);
                // throw new OrderException("OrderController: GetAllOrders", ex);
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
                return StatusCode(500);
                //throw new OrderException("OrderController: GetOrderById", ex);
            }
        }

        [HttpPost(Name = "AddOrder")]
        public ActionResult Add([FromBody] Order o)
        {
            try
            {
                _OrderManager.AddOrder(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                // throw new OrderException("OrderController: AddOrder", ex);
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
                return StatusCode(500);
                // throw new OrderException("OrderController: UpdateOrder", ex);
            }
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        public ActionResult Delete(int id)
        {
            try
            {
                Order o = _OrderManager.GetOrderById(id);
                if (o == null) return NotFound();
                _OrderManager.RemoveOrder(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                //throw new OrderException("OrderController: DeleteOrder", ex);
            }
        }
    }
}
