using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private string _connectionString;

        public MenuItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region POST
        public void AddMenuItem(MenuItem menuItem)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO MenuItems (Naam, Beschrijving, Prijs, Voorraad) VALUES (@nm, @bsch, @prs, @vrd);", conn))
                {
                    cmd.Parameters.AddWithValue("@nm", menuItem.Naam);
                    cmd.Parameters.AddWithValue("@bsch", menuItem.Beschrijving);
                    cmd.Parameters.AddWithValue("@prs", menuItem.Prijs);
                    cmd.Parameters.AddWithValue("@vrd", menuItem.Voorraad);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        #endregion

        #region GET
        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> items = new List<MenuItem>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MenuItems", conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                string nm = reader.GetString(reader.GetOrdinal("Naam"));
                                string bsch = reader.GetString(reader.GetOrdinal("Beschrijving"));
                                decimal prs = reader.GetDecimal(reader.GetOrdinal("Prijs"));
                                int vrd = reader.GetInt32(reader.GetOrdinal("Voorraad"));

                                MenuItem c = new MenuItem(id, nm, bsch, prs, vrd);
                                items.Add(c);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new DataException("MenuItemRepo-GetAllMenuItems", ex);
                    }
                }
            }

            return items;
        }

        public MenuItem GetMenuItemById(int id)
        {
            MenuItem mi = null;
            SqlConnection conn;
            SqlDataReader reader;
            SqlCommand cmd;
            try
            {
                using (conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    cmd = new SqlCommand("SELECT * FROM MenuItems WHERE Id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nm = reader.GetString(reader.GetOrdinal("Naam"));
                            string bsch = reader.GetString(reader.GetOrdinal("Beschrijving"));
                            decimal prs = reader.GetDecimal(reader.GetOrdinal("Prijs"));
                            int vrd = reader.GetInt32(reader.GetOrdinal("Voorraad"));

                            mi = new MenuItem(id, nm, bsch, prs, vrd);
                        }
                        reader.Close();
                    }

                    conn.Close();
                }
                return mi;
            }
            catch (Exception ex)
            {
                throw new DataException("Customerepo-GetCustomerById", ex);
            }
        }
        #endregion

        #region PUT
        public void UpdateMenuItem(MenuItem menuItem)
        {
            SqlConnection conn;
            SqlCommand cmd;
            try
            {
                using (conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    cmd = new SqlCommand("UPDATE MenuItems SET Naam=@naam, Beschrijving=@beschrijving, Prijs=@prijs, Voorraad=@voorraad WHERE Id=@id;", conn);

                    cmd.Parameters.AddWithValue("@id", menuItem.Id);
                    cmd.Parameters.AddWithValue("@naam", menuItem.Naam);
                    cmd.Parameters.AddWithValue("@beschrijving", menuItem.Beschrijving);
                    cmd.Parameters.AddWithValue("@prijs", menuItem.Prijs);
                    cmd.Parameters.AddWithValue("@voorraad", menuItem.Voorraad);

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DataException("MenuItemRepo-UpdateMenuItem", ex);
            }

        }
        #endregion
    }
}
