using System.Collections.Generic;

namespace SOLID.SRP.Cart.Violation
{
    public class ShoppingCartDto
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();
        public decimal Total { get; set; }
        public int ItemsCount { get; set; }
    }
}
