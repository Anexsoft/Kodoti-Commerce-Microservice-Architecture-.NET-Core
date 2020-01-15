using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Order.Persistence.Database.Configuration
{
    public class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ClientId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            var clients = new List<Client>();

            for (var i = 1; i <= 10; i++)
            {
                clients.Add(new Client
                {
                    ClientId = i,
                    Name = $"Client {i}"
                });
            }

            entityBuilder.HasData(clients);
        }
    }
}
