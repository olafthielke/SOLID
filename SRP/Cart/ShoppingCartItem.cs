using SOLID.SRP.Cart.Exceptions;

namespace SOLID.SRP.Cart
{
    public class ShoppingCartItem
    {
        public Product Product { get; }
        public int Quantity { get; set; }
        public string ProductName => Product.Name;
        public decimal UnitPrice => Product.UnitPrice;
        public decimal Subtotal => Quantity * UnitPrice;

        public ShoppingCartItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new InvalidQuantity(quantity);

            Product = product;
            Quantity = quantity;
        }
    }
}
