using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderSystem.Model.Core;

namespace OrderSystem.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private OrdersDBContext _context;
    
        public OrdersRepository(OrdersDBContext context)
        {
            _context = context;
        }

        public async Task AddOrder(Orders o)
        {
            _context.Add(o);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Orders> GetOrders()
        {
            var ordersCollection = _context.Orders.ToList();
            return ordersCollection;
        }
    }
}
