using MediatR;

namespace Catalog.Service.EventHandlers.Commands
{
    public class ProductCreateCommand : INotification
    {
        public string Name { get; set; }
    }
}
