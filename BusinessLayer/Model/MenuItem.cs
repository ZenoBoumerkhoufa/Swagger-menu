using System;

namespace BusinessLayer.Model
{
    public class MenuItem
    {
        private int menuItemId;
        private string menuItemName;

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public decimal Prijs { get; set; }
        public int Voorraad { get; set; }

        public MenuItem() { }

        public MenuItem(int id, string nm, string bsch, decimal prs, int vrd)
        {
            Id = id;
            Naam = nm;
            Beschrijving = bsch;
            Prijs = prs;
            Voorraad = vrd;
        }

        public MenuItem(string naam, string beschrijving, decimal prijs, int voorraad)
        {
            Naam = naam;
            Beschrijving = beschrijving;
            Prijs = prijs;
            Voorraad = voorraad;
        }

        public MenuItem(int menuItemId, string menuItemName)
        {
            this.menuItemId = menuItemId;
            this.menuItemName = menuItemName;
        }
    }
}
