using MediatR;

namespace Customer.Service.EventHandlers.Commands
{
    public class ClientCreateCommand : INotification
    {
        public string Name { get; set; }
    }
}
