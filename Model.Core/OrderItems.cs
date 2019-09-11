using System;

namespace OrderSystem.Model.Core
{
    /// <summary>
    /// This class is called as value object because it doesn't have a unique ID 
    /// </summary>
    public class OrderItems : IEquatable<OrderItems>
    {
        //public int OrderLineItemId {get; private set;}
        public int ProductID {get; private set;}
        public int ProductQuantity {get; private set;}
        public int ProductPrice {get; private set;}

        private OrderItems()
        {

        }

        public OrderItems(int ProductID, int ProductQuantity, int ProductPrice)
        {
            this.ProductID = ProductID;
            this.ProductQuantity = ProductQuantity;
            this.ProductPrice = ProductPrice;
            Validate();
        }
        private void Validate()
        {
            if (ProductPrice < 0)
            {
                throw new InvalidOperationException(string.Concat(nameof(ProductPrice), " cannot be less than Zero."));
            }
            else if (ProductQuantity < 0)
            {
                throw new InvalidOperationException(string.Concat(nameof(ProductQuantity), " cannot be less than Zero."));
            }
        }

        public bool Equals(OrderItems other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return  (other.ProductID == this.ProductID) &&
                    (other.ProductQuantity == this.ProductQuantity) &&
                    (other.ProductPrice == this.ProductPrice);
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
            return this.ProductID.GetHashCode() + this.ProductPrice.GetHashCode() + this.ProductQuantity.GetHashCode();
        }

        public static bool operator ==(OrderItems right, OrderItems left)
        {
            return (right.ProductID == left.ProductID) &&
                    (right.ProductQuantity == left.ProductQuantity) &&
                    (right.ProductPrice == left.ProductPrice);
        }

        public static bool operator !=(OrderItems right, OrderItems left)
        {
            return (right.ProductID == left.ProductID) &&
                   (right.ProductQuantity == left.ProductQuantity) &&
                   (right.ProductPrice == left.ProductPrice);
        }
    }
}
