using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Model
{
    public class Customer
    {
        public int Id { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string Straat { get; set; }

        public int Huisnummer { get; set; }

        public string Busnummer { get; set; }

        public string Stad { get; set; }

        public string Postcode { get; set; }

        public string Land { get; set; }

        public string Telefoonnummer { get; set; }

        public string Email { get; set; }

        public string Paswoord { get; set; }
        public Customer() { }

        public Customer(int id, string voornaam, string achternaam, string straat, int huisnummer, string busnummer, string stad, string postcode, string land, string telefoonnummer, string email, string paswoord)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Straat = straat;
            Huisnummer = huisnummer;
            Busnummer = busnummer;
            Stad = stad;
            Postcode = postcode;
            Land = land;
            Telefoonnummer = telefoonnummer;
            Email = email;
            Paswoord = paswoord;
        }

        public Customer(string voornaam, string achternaam, string straat, int huisnummer, string busnummer, string stad, string postcode, string land, string telefoonnummer, string email, string paswoord)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Straat = straat;
            Huisnummer = huisnummer;
            Busnummer = busnummer;
            Stad = stad;
            Postcode = postcode;
            Land = land;
            Telefoonnummer = telefoonnummer;
            Email = email;
            Paswoord = paswoord;
        }
    }
}
