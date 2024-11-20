using System;

namespace SOLID.SRP.Cart.Exceptions
{
    public class MissingProduct : Exception
    {
        public MissingProduct()
            : base("Must have a product.")
        { }
    }
}
