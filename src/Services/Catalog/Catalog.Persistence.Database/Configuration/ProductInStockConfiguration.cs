using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductInStockConfiguration
    {
        public ProductInStockConfiguration(EntityTypeBuilder<ProductInStock> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ProductInStockId);

            var random = new Random();
            var products = new List<ProductInStock>();

            for (var i = 1; i <= 100; i++) 
            {
                products.Add(new ProductInStock{
                    ProductInStockId = i,
                    ProductId = i,
                    Stock = random.Next(0, 20)
                });
            }

            entityBuilder.HasData(products);
        }
    }
}
