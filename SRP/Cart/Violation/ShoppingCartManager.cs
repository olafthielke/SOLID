using SOLID.SRP.Cart.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SOLID.SRP.Cart.Violation
{
    public class ShoppingCartManager
    {

        public void CalcTotal(ShoppingCartDto cart)
        {
            cart.Total = cart.Items.Sum(i => i.Subtotal);
        }

        public void Add(ShoppingCartDto cart, Product product, int quantity)
        {
            ValidateAdd(product);
            var item = GetItem(cart, product.Name);
            if (item != null)
            {
                item.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new ShoppingCartItem(product, quantity));
                cart.ItemsCount++;
            }
            CalcTotal(cart);
        }

        public void Remove(ShoppingCartDto cart, string productName)
        {
            var item = GetItem(cart, productName);
            if (item != null)
                cart.Items.Remove(item);
        }

        public void Clear(ShoppingCartDto cart)
        {
            cart.Items.Clear();

            cart.ItemsCount = 0;
            cart.Total = 0;
        }


        private static void ValidateAdd(Product product)
        {
            if (product == null)
                throw new MissingProduct();
        }

        private ShoppingCartItem? GetItem(ShoppingCartDto cart, string productName)
        {
            return cart.Items.SingleOrDefault(i => i.ProductName == productName);
        }

    }
}