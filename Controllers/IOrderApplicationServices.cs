using OrderSystem.Commands;
using OrderSystem.EventPublisher;
using OrderSystem.Events;
using OrderSystem.Model.Core;
using OrderSystem.Repository;
using System.Collections;
using System.Collections.Generic;

namespace OrderSystem.Controllers
{
    public interface IOrderApplicationServices
    {
        void handle(ICommand obj);
    }

    public class OrderApplicationServices : IOrderApplicationServices
    {
        private IOrdersRepository _repo;
        private IServiceBusEventPublisher _publisher;
        public OrderApplicationServices(IOrdersRepository repo, IServiceBusEventPublisher publisher)
        {
            this._repo = repo;
            this._publisher = publisher;
        }
        public void handle(ICommand obj)
        {
            switch (obj)
            {
                case CreateOrder co:
                    {
                        var order = new Orders(((CreateOrder)obj).OrderID, new OrderDateTime(((CreateOrder)obj).OrderDate), ((CreateOrder)obj).OrderItems);

                        _repo.AddOrder(order);

                        IEnumerable<IEvents> allEvents = order.GetEvents();
                        foreach(var e in allEvents)
                        {
                            switch (e)
                            {
                                case OrderEvents.OrderPlaced op:
                                    {
                                        _publisher.PublishEvent(e);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
        }
    }
}