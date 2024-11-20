using System.Collections.Generic;
using System.Linq;
using SOLID.SRP.Cart.Exceptions;

namespace SOLID.SRP.Cart.Compliant
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();
        public decimal Total => Items.Sum(i => i.Subtotal);
        public int ItemsCount => Items.Count;

        public void Add(Product product, int quantity)
        {
            ValidateAdd(product);
            var item = GetItem(product.Name);
            if (item != null)
                item.Quantity += quantity;
            else
                Items.Add(new ShoppingCartItem(product, quantity));
        }

        public void Remove(string productName)
        {
            var item = GetItem(productName);
            if (item != null)
                Items.Remove(item);
        }

        public void Clear()
        {
            Items.Clear();
        }


        private static void ValidateAdd(Product product)
        {
            if (product == null)
                throw new MissingProduct();
        }

        private ShoppingCartItem? GetItem(string productName)
        {
            return Items.SingleOrDefault(i => i.ProductName == productName);
        }
    }
}