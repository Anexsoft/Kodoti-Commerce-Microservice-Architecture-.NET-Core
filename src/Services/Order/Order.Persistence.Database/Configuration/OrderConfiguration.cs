using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Persistence.Database.Configuration
{
    public class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<Domain.Order> entityBuilder)
        {
            entityBuilder.HasKey(x => x.OrderId);
        }
    }
}
