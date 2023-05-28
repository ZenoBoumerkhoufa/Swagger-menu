using BusinessLayer.DTOS;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public class OrderMapper
    {
        public static Order MapToEntity(OrderDTO orderDTO)
        {
            return new Order(orderDTO.CustomerId, orderDTO.Items, orderDTO.OrderPlaatsing, orderDTO.OrderBetaling);
        }
    }
}
