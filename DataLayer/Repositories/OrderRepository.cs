using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        #region attrib
        private string _connectionString;
        #endregion

        #region ctor
        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region POST
        public void AddOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Orders (CustomerId, OrderDate, OrderBetaling) VALUES (@CustomerId, @OrderDate, @OrderBetaling); SELECT SCOPE_IDENTITY();", conn))
                {
                    try
                    {
                        conn.Open();

                        // Add parameters to the SqlCommand
                        cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                        cmd.Parameters.AddWithValue("@OrderDate", order.OrderPlaatsing);
                        cmd.Parameters.AddWithValue("@OrderBetaling", order.OrderBetaling);

                        // Execute the insert command and get the newly inserted OrderId
                        int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                        // Insert OrderItem records
                        foreach (OrderItem item in order.Items)
                        {
                            using (SqlCommand itemCmd = new SqlCommand("INSERT INTO OrderItem (OrderId, MenuItemId, Aantal) VALUES (@OrderId, @MenuItemId, @Aantal)", conn))
                            {
                                itemCmd.Parameters.AddWithValue("@OrderId", orderId);
                                itemCmd.Parameters.AddWithValue("@MenuItemId", item.MenuItem.Id);
                                itemCmd.Parameters.AddWithValue("@Aantal", item.Aantal);

                                itemCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new DataException("OrderRepo-AddOrder", ex);
                    }
                }
            }
        }
        #endregion

        #region GET
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT o.Id AS OrderId, o.CustomerId, o.OrderDate, o.OrderBetaling, oi.MenuItemId, oi.Aantal, m.Id, m.Naam, m.Beschrijving, m.Prijs, m.Voorraad FROM Orders o JOIN OrderItem oi ON o.Id = oi.OrderId JOIN MenuItems m ON oi.MenuItemId = m.Id;", conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int orderId = reader.GetInt32(reader.GetOrdinal("OrderId"));
                                int customerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
                                DateTime orderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"));
                                DateTime orderBetaling = reader.GetDateTime(reader.GetOrdinal("OrderBetaling"));

                                int menuItemId = reader.GetInt32(reader.GetOrdinal("Id"));
                                string menuItemNaam = reader.GetString(reader.GetOrdinal("Naam"));
                                string menuItemBeschrijving = reader.GetString(reader.GetOrdinal("Beschrijving"));
                                decimal menuItemPrijs = reader.GetDecimal(reader.GetOrdinal("Prijs"));
                                int menuItemVoorraad = reader.GetInt32(reader.GetOrdinal("Voorraad"));
                                MenuItem menuItem = new MenuItem(menuItemId, menuItemNaam, menuItemBeschrijving, menuItemPrijs, menuItemVoorraad);

                                int aantal = reader.GetInt32(reader.GetOrdinal("Aantal"));

                                OrderItem orderItem = new OrderItem(menuItem, aantal);

                                // Check if the order already exists in the list
                                Order existingOrder = orders.FirstOrDefault(o => o.Id == orderId);
                                if (existingOrder != null)
                                {
                                    existingOrder.Items.Add(orderItem);
                                }
                                else
                                {
                                    List<OrderItem> orderItems = new List<OrderItem> { orderItem };
                                    Order newOrder = new Order(orderId, customerId, orderItems, orderDate, orderBetaling);
                                    orders.Add(newOrder);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new DataException("OrderRepo-GetAllOrders", ex);
                    }
                }
            }

            return orders;
        }

        public Order GetOrderById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT o.Id AS OrderId, o.CustomerId, o.OrderDate, o.OrderBetaling, oi.MenuItemId, oi.Aantal, m.Id, m.Naam, m.Beschrijving, m.Prijs, m.Voorraad " +
                                                        "FROM Orders o " +
                                                        "JOIN OrderItem oi ON o.Id = oi.OrderId " +
                                                        "JOIN MenuItems m ON oi.MenuItemId = m.Id " +
                                                        "WHERE o.Id = @OrderId;", conn))
                {
                    try
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@OrderId", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Order order = null;

                            while (reader.Read())
                            {
                                if (order == null)
                                {
                                    int customerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
                                    DateTime orderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"));
                                    DateTime orderBetaling = reader.GetDateTime(reader.GetOrdinal("OrderBetaling"));

                                    order = new Order(id, customerId, new List<OrderItem>(), orderDate, orderBetaling);
                                }

                                int menuItemId = reader.GetInt32(reader.GetOrdinal("Id"));
                                string menuItemNaam = reader.GetString(reader.GetOrdinal("Naam"));
                                string menuItemBeschrijving = reader.GetString(reader.GetOrdinal("Beschrijving"));
                                decimal menuItemPrijs = reader.GetDecimal(reader.GetOrdinal("Prijs"));
                                int menuItemVoorraad = reader.GetInt32(reader.GetOrdinal("Voorraad"));
                                MenuItem menuItem = new MenuItem(menuItemId, menuItemNaam, menuItemBeschrijving, menuItemPrijs, menuItemVoorraad);

                                int aantal = reader.GetInt32(reader.GetOrdinal("Aantal"));

                                OrderItem orderItem = new OrderItem(menuItem, aantal);

                                order.Items.Add(orderItem);
                            }

                            return order;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new DataException("OrderRepo-GetOrderById", ex);
                    }
                }
            }
        }
        #endregion

        #region PUT
        public void UpdateOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Update the Orders table
                        using (SqlCommand updateOrderCmd = new SqlCommand("UPDATE Orders SET CustomerId = @CustomerId, OrderDate = @OrderDate, OrderBetaling = @OrderBetaling WHERE Id = @OrderId;", conn, transaction))
                        {
                            updateOrderCmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                            updateOrderCmd.Parameters.AddWithValue("@OrderDate", order.OrderPlaatsing);
                            updateOrderCmd.Parameters.AddWithValue("@OrderBetaling", order.OrderBetaling);
                            updateOrderCmd.Parameters.AddWithValue("@OrderId", order.Id);

                            updateOrderCmd.ExecuteNonQuery();
                        }

                        // Delete existing order items for the order
                        using (SqlCommand deleteOrderItemsCmd = new SqlCommand("DELETE FROM OrderItem WHERE OrderId = @OrderId;", conn, transaction))
                        {
                            deleteOrderItemsCmd.Parameters.AddWithValue("@OrderId", order.Id);

                            deleteOrderItemsCmd.ExecuteNonQuery();
                        }

                        // Insert new order items
                        foreach (OrderItem orderItem in order.Items)
                        {
                            using (SqlCommand insertOrderItemCmd = new SqlCommand("INSERT INTO OrderItem (OrderId, MenuItemId, Aantal) VALUES (@OrderId, @MenuItemId, @Aantal);", conn, transaction))
                            {
                                insertOrderItemCmd.Parameters.AddWithValue("@OrderId", order.Id);
                                insertOrderItemCmd.Parameters.AddWithValue("@MenuItemId", orderItem.MenuItem.Id);
                                insertOrderItemCmd.Parameters.AddWithValue("@Aantal", orderItem.Aantal);

                                insertOrderItemCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new DataException("OrderRepo-UpdateOrder", ex);
                    }
                }
            }
        }

        #endregion
    }
}
