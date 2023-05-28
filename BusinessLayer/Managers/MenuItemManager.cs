using BusinessLayer.DTOS;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class MenuItemManager
    {
        private IMenuItemRepository _repo;
        public MenuItemManager(IMenuItemRepository repo)
        {
            _repo = repo;
        }
        #region GET
        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> items = new List<MenuItem>();
            foreach (MenuItem i in _repo.GetAllMenuItems())
            {
                items.Add(i);
            }
            return items;
        }

        public MenuItem GetMenuItemById(int id)
        {
            return _repo.GetMenuItemById(id);
        }
        #endregion
        #region ADD
        public void AddMenuItem(MenuItemDTO item)
        {
            _repo.AddMenuItem(MenuItemMapper.MapToEntity(item));
        }
        #endregion

        #region UPDATE
        public void UpdateMenuItem(MenuItem item)
        {
            _repo.UpdateMenuItem(item);
        }
        #endregion
    }
}
