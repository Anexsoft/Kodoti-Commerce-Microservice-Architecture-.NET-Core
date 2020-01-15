namespace Order.Service.Queries.DTOs
{
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}
