using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Customers (Voornaam, Achternaam, Straat, Huisnummer, Busnummer, Stad, Postcode, Land, Telefoonnummer, Email, Paswoord) VALUES (@vn, @an, @str, @hn, @bn, @std, @pc, @lnd, @tn, @em, @pw);", conn))
                {
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

                    // Hash the password
                    string hashedPassword = HashPassword(customer.Paswoord);
                    cmd.Parameters.AddWithValue("@pw", hashedPassword);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        #endregion

        #region GET
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                string vn = reader.GetString(reader.GetOrdinal("Voornaam"));
                                string an = reader.GetString(reader.GetOrdinal("Achternaam"));
                                string str = reader.GetString(reader.GetOrdinal("Straat"));
                                int hn = reader.GetInt32(reader.GetOrdinal("Huisnummer"));
                                string bn = reader.GetString(reader.GetOrdinal("Busnummer"));
                                string std = reader.GetString(reader.GetOrdinal("Stad"));
                                string pc = reader.GetString(reader.GetOrdinal("Postcode"));
                                string lnd = reader.GetString(reader.GetOrdinal("Land"));
                                string tn = reader.GetString(reader.GetOrdinal("Telefoonnummer"));
                                string em = reader.GetString(reader.GetOrdinal("Email"));
                                string pw = reader.GetString(reader.GetOrdinal("Paswoord"));

                                Customer c = new Customer(id, vn, an, str, hn, bn, std, pc, lnd, tn, em, pw);
                                customers.Add(c);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new DataException("Customerepo-GetAllCustomers", ex);
                    }
                }
            }

            return customers;
        }



        public Customer GetCustomerById(int id)
        {
            Customer c = null;
            SqlConnection conn;
            SqlDataReader reader;
            SqlCommand cmd;
            try
            {
                using (conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    cmd = new SqlCommand("SELECT * FROM Customers WHERE Id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string vn = reader.GetString(reader.GetOrdinal("Voornaam"));
                            string an = reader.GetString(reader.GetOrdinal("Achternaam"));
                            string str = reader.GetString(reader.GetOrdinal("Straat"));
                            int hn = reader.GetInt32(reader.GetOrdinal("Huisnummer"));
                            string bn = reader.GetString(reader.GetOrdinal("Busnummer"));
                            string std = reader.GetString(reader.GetOrdinal("Stad"));
                            string pc = reader.GetString(reader.GetOrdinal("Postcode"));
                            string lnd = reader.GetString(reader.GetOrdinal("Land"));
                            string tn = reader.GetString(reader.GetOrdinal("Telefoonnummer"));
                            string em = reader.GetString(reader.GetOrdinal("Email"));
                            string pw = reader.GetString(reader.GetOrdinal("Paswoord"));

                            c = new Customer(id, vn, an, str, hn, bn, std, pc, lnd, tn, em, pw);
                        }
                        reader.Close();
                    }

                    conn.Close();
                }
                return c;
            }
            catch (Exception ex)
            {
                throw new DataException("Customerepo-GetCustomerById", ex);
            }
        }
        #endregion

        #region PUT
        public void UpdateCustomer(Customer customer)
        {
            SqlConnection conn;
            SqlCommand cmd;
            try
            {
                using (conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    cmd = new SqlCommand("UPDATE Customers SET Voornaam=@vn, Achternaam=@an, Straat=@str, Huisnummer=@hn, Busnummer=@bn, Stad=@std, Postcode=@pc, Land=@lnd, Telefoonnummer=@tn, Email=@em, Paswoord=@pw WHERE Id=@id;", conn);


                    cmd.Parameters.AddWithValue("@id", customer.Id);
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

                    // Hash the password
                    string hashedPassword = HashPassword(customer.Paswoord);
                    cmd.Parameters.AddWithValue("@pw", hashedPassword);

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DataException("CustomerRepo-UpdateCustomer", ex);
            }
        }
        #endregion
    }
}
