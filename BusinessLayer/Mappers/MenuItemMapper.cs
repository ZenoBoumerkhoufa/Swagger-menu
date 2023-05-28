using BusinessLayer.DTOS;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public class MenuItemMapper
    {
        public static MenuItem MapToEntity(MenuItemDTO midto)
        {
            return new MenuItem(midto.Naam, midto.Beschrijving, midto.Prijs, midto.Voorraad);
        }

        public static MenuItemDTO MapToDTO(MenuItem menuItem)
        {
            return new MenuItemDTO(menuItem.Naam, menuItem.Beschrijving, menuItem.Prijs, menuItem.Voorraad);
        }
    }
}
