using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOS
{
    public class MenuItemDTO
    {
        public MenuItemDTO(string naam, string beschrijving, decimal prijs, int voorraad)
        {
            Naam = naam;
            Beschrijving = beschrijving;
            Prijs = prijs;
            Voorraad = voorraad;
        }

        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public decimal Prijs { get; set; }
        public int Voorraad { get; set; }
    }
}
