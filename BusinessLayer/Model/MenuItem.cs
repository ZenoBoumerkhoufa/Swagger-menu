using System;

namespace BusinessLayer.Model
{
    public class MenuItem
    {
        public int Id { get; private set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public decimal Prijs { get; set; }
        public int Voorraad { get; set; }

        public MenuItem(string naam, string beschrijving, decimal prijs, int voorraad)
        {
            Naam = naam;
            Beschrijving = beschrijving;
            Prijs = prijs;
            Voorraad = voorraad;
        }
    }
}
