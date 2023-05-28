using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        #region attrib
        private string _connectionString;
        #endregion

        #region ctor
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region POST
        public void AddCustomer(Customer customer)
        {
            MySqlConnection conn;
            MySqlCommand cmd;
            try
            {
                using (conn = new(_connectionString))
                {
                    conn.Open();

                    string sql = ("INSERT INTO customer (Voornaam, Achternaam, Straat, Huisnummer, Busnummer, Stad, Postcode, Land, Telefoonnummer, Email, Paswoord) VALUES (@vn, @an, @str, @hn, @bn, @std, @pc, @lnd, @tn, @em, @pw);");

                    cmd = new(sql, conn);
                    cmd.Parameters.AddWithValue("@vn", customer.Voornaam);
                    cmd.Parameters.AddWithValue("@an", customer.Achternaam);
                    cmd.Parameters.AddWithValue("@str", customer.Straat);
                    cmd.Parameters.AddWithValue("@hn", customer.Huisnummer);
                    cmd.Parameters.AddWithValue("@bn", customer.Busnummer);
                    cmd.Parameters.AddWithValue("@std", customer.Stad);
                    cmd.Parameters.AddWithValue("@pc", customer.Postcode);
                    cmd.Parameters.AddWithValue("@lnd", customer.Land);
                    cmd.Parameters.AddWithValue("@tn", customer.Telefoonnummer);
                    cmd.Parameters.AddWithValue("@em", customer.Email);
                    cmd.Parameters.AddWithValue("@pw", customer.Paswoord);

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DataException("CustomerRepo-AddCustomer", ex);
            }
        }
        #endregion

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new();
            MySqlConnection conn;
            MySqlDataReader reader;
            MySqlCommand cmd;
            try
            {
                using (conn = new(_connectionString))
                {
                    conn.Open();

                    cmd = new("SELECT * FROM customer ;", conn);

                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string vn = (string)reader["Voornaam"];
                            string an = (string)reader["Achternaam"];
                            string str = (string)reader["Straat"];
                            int hn = (int)reader["Huisnummer"];
                            string bn = (string)reader["Busnummer"];
                            string std = (string)reader["Stad"];
                            string pc = (string)reader["Postcode"];
                            string lnd = (string)reader["Land"];
                            string tn = (string)reader["Telefoonnummer"];
                            string em = (string)reader["Email"];
                            string pw = (string)reader["Paswoord"];

                            Customer c = new Customer(vn, an, str, hn, bn, std, pc, lnd, tn, em, pw);

                            customers.Add(c);
                        }
                        reader.Close();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Customerepo-GetAllCustomers", ex);
            }
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
