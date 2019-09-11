using OrderSystem.Model.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderSystem.Repository
{
    public interface IOrdersRepository
    {
        Task AddOrder(Orders o);
        IEnumerable<Orders> GetOrders();
    }
}
