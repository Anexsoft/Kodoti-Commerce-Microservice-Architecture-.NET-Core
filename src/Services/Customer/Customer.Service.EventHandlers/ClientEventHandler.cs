using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers
{
    public class ClientEventHandler :
        INotificationHandler<ClientCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public ClientEventHandler(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClientCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Client {
                Name = notification.Name
            });

            await _context.SaveChangesAsync();
        }
    }
}
