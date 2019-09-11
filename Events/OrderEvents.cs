using OrderSystem.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Events
{
    public class OrderEvents
    {
        public class OrderPlaced : IEvents
        {
            public int OrderID { get; set; }
            public OrderDateTime OrderDateTime { get; set; }
            public OrderItems [] OrderItems { get; set; }

            //public OrderPlaced(int _orderId, OrderDateTime _dateTime, OrderItems[] _orderItems)
            //{
            //    OrderID = _orderId;
            //    OrderDateTime = _dateTime;
            //    OrderItems = _orderItems;
            //}
        }
    }
}
