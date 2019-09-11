using Microsoft.IdentityModel.Xml;
using OrderSystem.Events;
using System;
using System.Collections;
using System.Collections.Generic;

namespace OrderSystem.Model.Core
{
    /// <summary>
    /// This class is called as Root Aggregate object because it is main class which holds all the other Value Objects.
    /// </summary>
    public class Orders : Entity
    {

        public int OrderId { get; private set; }
        public OrderDateTime OrderDate { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public List<OrderItems> OrderItems { get; private set; }

        public Orders(int _orderId, OrderDateTime _dateTime, OrderItems[] _orderItems)
        {
            Apply(
            new OrderEvents.OrderPlaced { 
                OrderID = _orderId,
                OrderDateTime = _dateTime,
                OrderItems = _orderItems
            });
        }

        public Orders()
        {

        }

        public void UpdateOrderDate()
        {
        }

        public void UpdateOrder()
        {
        }

        public void DeleteOrder()
        {
        }

        public override void Validate()
        {
            if (OrderStatus == OrderStatus.OrderPlaced)
            {
                //Do
            }
        }

        public override void When(IEvents @event)
        {
            switch (@event)
            {
                case OrderEvents.OrderPlaced e:
                    {
                        this.OrderId = e.OrderID;
                        this.OrderItems = new List<OrderItems>(e.OrderItems);
                        this.OrderDate = e.OrderDateTime;
                    }
                    break;
            }
        }
    }

    public enum OrderStatus
    {
        OrderPlaced,
        OrderCancelled,
        OrderInReview
    }
}
