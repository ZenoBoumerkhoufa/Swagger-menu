using BusinessLayer.Managers;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("api/[controller]s")] // wordt .../MenuItem
    public class MenuItemController : Controller
    {
        private readonly ILogger<MenuItemController> logger;
        private MenuItemManager _MenuItemManager;

        public MenuItemController(ILogger<MenuItemController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "GetAllMenuItems")]
        public ActionResult<List<MenuItem>> Get()
        {
            try
            {
                List<MenuItem> list = _MenuItemManager.GetAllMenuItems();
                if (list == null) return NotFound();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                // throw new MenuItemException("MenuItemController: GetAllMenuItems", ex);
            }
        }

        [HttpGet("{id}", Name = "GetMenuItemById")]
        public ActionResult<MenuItem> GetAction(int id)
        {
            try
            {
                MenuItem mi = _MenuItemManager.GetMenuItemById(id);
                if (mi == null) return NotFound();
                return Ok(mi);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                //throw new MenuItemException("MenuItemController: GetMenuItemById", ex);
            }
        }

        [HttpPost(Name = "AddMenuItem")]
        public ActionResult Add([FromBody] MenuItem mi)
        {
            try
            {
                _MenuItemManager.AddMenuItem(mi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                // throw new MenuItemException("MenuItemController: AddMenuItem", ex);
            }
        }

        [HttpPut(Name = "UpdateMenuItem")]
        public ActionResult Put([FromBody] MenuItem mi)
        {
            try
            {
                _MenuItemManager.UpdateMenuItem(mi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                // throw new MenuItemException("MenuItemController: UpdateMenuItem", ex);
            }
        }

        [HttpDelete("{id}", Name = "DeleteMenuItem")]
        public ActionResult Delete(int id)
        {
            try
            {
                MenuItem mi = _MenuItemManager.GetMenuItemById(id);
                if (mi == null) return NotFound();
                _MenuItemManager.RemoveMenuItem(mi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                //throw new MenuItemException("MenuItemController: DeleteMenuItem", ex);
            }
        }
    }
}
