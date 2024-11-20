using System.Linq;
using FluentAssertions;
using SOLID.SRP.Cart.Exceptions;
using Xunit;

namespace SOLID.SRP.Cart.Violation
{
    public class ShoppingCartManagerTests
    {
        [Fact]
        public void When_Create_Cart_Then_Cart_Is_Empty()
        {
            var cart = new ShoppingCartDto();

            cart.Items.Should().BeEmpty();
            cart.ItemsCount.Should().Be(0);
        }

        [Fact]
        public void When_Create_Cart_Then_Total_Is_Zero()
        {
            var cart = new ShoppingCartDto();
            var mgr = new ShoppingCartManager();

            mgr.CalcTotal(cart);

            cart.Total.Should().Be(0);
        }

        [Fact]
        public void Given_No_Product_When_Call_Add_Then_Throw_MissingProduct_Exception()
        {
            var cart = new ShoppingCartDto();
            var mgr = new ShoppingCartManager();

            var add = () => mgr.Add(cart, null, 3);

            add.Should().ThrowExactly<MissingProduct>().WithMessage("Must have a product.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-3)]
        [InlineData(-20)]
        public void Given_Quantity_Is_Invalid_When_Call_Add_Then_Throw_InvalidQuantity_Exception(int quantity)
        {
            var cart = new ShoppingCartDto();
            var mgr = new ShoppingCartManager();

            var add = () => mgr.Add(cart, new Product("Apple", 0.35m), quantity);

            add.Should().ThrowExactly<InvalidQuantity>().WithMessage($"{quantity} is an invalid quantity.");
        }

        [Theory]
        [InlineData("Apple")]
        [InlineData("Banana")]
        [InlineData("Cantaloupe")]
        public void Given_Have_Product_In_Cart_When_Call_Add_With_More_Same_Product_Then_Merge_Product_Quantities(string productName)
        {
            var cart = new ShoppingCartDto();
            var mgr = new ShoppingCartManager();

            var product = new Product(productName, 1);
            mgr.Add(cart, product, 3);
            mgr.Add(cart, product, 7);

            VerifyCart(cart, 1, 10 * product.UnitPrice);
            VerifyCartItem(cart.Items[0], product, 10);
        }

        [Theory]
        [InlineData("Apple", 2, 3)]
        [InlineData("Banana", 0.75, 5)]
        [InlineData("Cantaloupe", 2.5, 11)]
        public void Given_Have_Quantity_Of_A_Product_When_Call_Add_Then_Have_Product_In_Cart(string productName,
            decimal unitPrice, int quantity)
        {
            var cart = new ShoppingCartDto();
            var mgr = new ShoppingCartManager();

            mgr.Add(cart, new Product(productName, unitPrice), quantity);

            VerifyCart(cart, 1, quantity * unitPrice);
            VerifyCartItem(cart.Items.First(), productName, unitPrice, quantity);
        }

        [Fact]
        public void Given_Have_Two_Products_When_Call_Add_Then_Have_Two_Products_In_Cart()
        {
            var cart = new ShoppingCartDto();
            var mgr = new ShoppingCartManager();

            mgr.Add(cart, Apple, 5);
            mgr.Add(cart, Banana, 8);

            VerifyCart(cart, 2, 5 * Apple.UnitPrice + 8 * Banana.UnitPrice);
            VerifyCartItem(cart.Items[0], Apple, 5);
            VerifyCartItem(cart.Items[1], Banana, 8);
        }

        [Fact]
        public void Given_Have_Three_Products_When_Call_Add_Then_Have_Three_Products_In_Cart()
        {
            var cart = new ShoppingCartDto();
            var mgr = new ShoppingCartManager();

            mgr.Add(cart, Cantaloupe, 10);
            mgr.Add(cart, Banana, 20);
            mgr.Add(cart, Apple, 30);

            VerifyCart(cart, 3, 10 * Cantaloupe.UnitPrice + 20 * Banana.UnitPrice + 30 * Apple.UnitPrice);
            VerifyCartItem(cart.Items[0], Cantaloupe, 10);
            VerifyCartItem(cart.Items[1], Banana, 20);
            VerifyCartItem(cart.Items[2], Apple, 30);
        }

        [Fact]
        public void Given_Empty_Cart_When_Call_Clear_Then_Have_Empty_Cart()
        {
            var cart = new ShoppingCartDto();
            var mgr = new ShoppingCartManager();

            mgr.Clear(cart);

            VerifyCartIsEmpty(cart);
        }

        [Fact]
        public void Given_Have_One_Item_In_Cart_When_Call_Clear_Then_Have_Empty_Cart()
        {
            var cart = new ShoppingCartDto();
            var mgr = new ShoppingCartManager();

            mgr.Add(cart, Apple, 7);
            mgr.Clear(cart);

            VerifyCartIsEmpty(cart);
        }

        [Fact]
        public void Given_Have_Many_Items_In_Cart_When_Call_Clear_Then_Have_Empty_Cart()
        {
            var cart = new ShoppingCartDto();
            var mgr = new ShoppingCartManager();

            mgr.Add(cart, Apple, 7);
            mgr.Add(cart, Banana, 13);
            mgr.Add(cart, Cantaloupe, 29);

            mgr.Clear(cart);

            VerifyCartIsEmpty(cart);
        }

        //[Fact]
        //public void Given_Empty_Cart_When_Call_Remove_On_Apple_Then_Have_Empty_Cart()
        //{
        //    var cart = new ShoppingCart();
        //    cart.Remove("Apple");
        //    VerifyCartIsEmpty(cart);
        //}

        //[Fact]
        //public void Given_Apples_In_Cart_When_Call_Remove_On_Bananas_Then_Have_Apples_In_Cart()
        //{
        //    var cart = new ShoppingCart();
        //    cart.Add(Apple, 3);
        //    cart.Remove("Banana");
        //    VerifyCart(cart, 1, 3 * Apple.UnitPrice);
        //    VerifyCartItem(cart.Items[0], Apple, 3);
        //}

        //[Fact]
        //public void Given_Apples_In_Cart_When_Call_Remove_On_Apples_Then_Have_Empty_Cart()
        //{
        //    var cart = new ShoppingCart();
        //    cart.Add(Apple, 2);
        //    cart.Remove("Apple");
        //    VerifyCartIsEmpty(cart);
        //}

        //[Fact]
        //public void Given_Have_Apples_Bananas_And_Cantaloupes_In_Cart_When_Call_Remove_Bananas_Then_Have_Apples_and_Cantaloupes_In_Cart()
        //{
        //    // Arrange
        //    var cart = new ShoppingCart();
        //    cart.Add(Apple, 1);
        //    cart.Add(Banana, 2);
        //    cart.Add(Cantaloupe, 3);

        //    // Act
        //    cart.Remove(Banana.Name);

        //    // Assert
        //    VerifyCart(cart, 2, 1 * Apple.UnitPrice + 3 * Cantaloupe.UnitPrice);
        //    VerifyCartItem(cart.Items[0], Apple, 1);
        //    VerifyCartItem(cart.Items[1], Cantaloupe, 3);
        //}


        private static readonly Product Apple = new Product("Apple", 0.35m);
        private static readonly Product Banana = new Product("Banana", 0.75m);
        private static readonly Product Cantaloupe = new Product("Cantaloupe", 2.5m);


        private static void VerifyCartIsEmpty(ShoppingCartDto cart)
        {
            cart.Items.Should().BeEmpty();
            cart.ItemsCount.Should().Be(0);
            cart.Total.Should().Be(0);
        }

        private static void VerifyCart(ShoppingCartDto cart, int itemsCount, decimal total)
        {
            cart.ItemsCount.Should().Be(itemsCount);
            cart.Total.Should().Be(total);
        }

        private static void VerifyCartItem(ShoppingCartItem item,
            Product product, int quantity)
        {
            item.Product.Should().BeEquivalentTo(product);
            item.Quantity.Should().Be(quantity);
        }

        private static void VerifyCartItem(ShoppingCartItem item,
            string productName, decimal unitPrice, int quantity)
        {
            item.ProductName.Should().Be(productName);
            item.UnitPrice.Should().Be(unitPrice);
            item.Quantity.Should().Be(quantity);
        }
    }
}
