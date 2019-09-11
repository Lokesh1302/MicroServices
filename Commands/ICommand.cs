using OrderSystem.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Commands
{
    public interface ICommand
    {

    }

    public class CreateOrder : ICommand
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderItems[] OrderItems { get; set; }
    }
}
