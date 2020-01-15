using System;
using System.Collections.Generic;
using static Order.Common.Enums;

namespace Order.Service.Queries.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string OrderNumber
        {
            get
            {
                return CreatedAt.Year + "-" + OrderId.ToString().PadLeft(6, '0');
            }
        }
        public OrderStatus Status { get; set; }
        public OrderPayment PaymentType { get; set; }
        public int ClientId { get; set; }
        public IEnumerable<OrderDetailDto> Items { get; set; } = new List<OrderDetailDto>();
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }
    }
}
