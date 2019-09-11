using System;

namespace OrderSystem.Model.Core
{
    public class OrderDateTime : IEquatable<OrderDateTime>
    {
        private OrderDateTime orderDate;

        public DateTime OrderDate { get; private set; }

        private OrderDateTime()
        {

        }

        public OrderDateTime(DateTime _dateTime)
        {
            OrderDate = _dateTime;
            Validate();
        }

        private void Validate()
        {
            if(OrderDate > DateTime.Now.AddDays(15))
            {
                throw new InvalidOperationException(string.Concat(nameof(OrderDate), " cannot be more than 15 Days from Today."));
            }
        }

        public bool Equals(OrderDateTime other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if(ReferenceEquals(this, other))
            {
                return true;
            }
            return (other.OrderDate == this.OrderDate);
        }

        public override bool Equals(object obj)
        {

            if (ReferenceEquals(obj, null))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Equals((OrderDateTime)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(OrderDateTime right, OrderDateTime left)
        {
            return (right.OrderDate == left.OrderDate);
        }

        public static bool operator !=(OrderDateTime right, OrderDateTime left)
        {
            return !(right.OrderDate == left.OrderDate);
        }
    }
}
