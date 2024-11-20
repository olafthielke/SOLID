namespace SOLID.SRP.Cart
{
    public class Product
    {
        public string Name { get; }
        public decimal UnitPrice { get; }

        public Product(string name, decimal unitPrice)
        {
            Name = name;
            UnitPrice = unitPrice;
        }
    }
}
