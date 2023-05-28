using BusinessLayer.DTOS;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public class CustomerMapper
    {
        public static Customer MapToEntity(CustomerDTO customerDTO)
        {
            return new Customer(customerDTO.Voornaam, customerDTO.Achternaam, customerDTO.Straat, customerDTO.Huisnummer, customerDTO.Busnummer, customerDTO.Stad, customerDTO.Postcode, customerDTO.Land, customerDTO.Telefoonnummer, customerDTO.Email, customerDTO.Paswoord);
        }

        public static CustomerDTO MapToDTO(Customer customer)
        {
            return new CustomerDTO(customer.Voornaam, customer.Achternaam, customer.Straat, customer.Huisnummer, customer.Busnummer, customer.Stad,customer.Postcode, customer.Land, customer.Telefoonnummer, customer.Email, customer.Paswoord);
        }
    }
}
