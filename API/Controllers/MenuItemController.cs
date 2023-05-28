using BusinessLayer.DTOS;
using BusinessLayer.Managers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("api/[controller]s")] // wordt .../MenuItem
    public class MenuItemController : Controller
    {
        private readonly ILogger<MenuItemController> logger;
        private IConfiguration iConfig;
        private MenuItemManager _MenuItemManager;

        public MenuItemController(ILogger<MenuItemController> logger, IConfiguration iConfig)
        {
            this.logger = logger;
            this.iConfig = iConfig;
            _MenuItemManager = new MenuItemManager(new MenuItemRepository(iConfig.GetValue<string>("ConnectionStrings:database")));

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
                return StatusCode(500, "An unexpected error occurred: " + ex);
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
                return StatusCode(500, "An unexpected error occurred: " + ex);
            }
        }

        [HttpPost(Name = "AddMenuItem")]
        public ActionResult Add([FromBody] MenuItemDTO mi)
        {
            try
            {
                _MenuItemManager.AddMenuItem(mi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex);
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
                return StatusCode(500, "An unexpected error occurred: " + ex);
            }
        }
    }
}
