using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID.OCP.SwitchToo.Compliant
{
    public class SalesTaxSelector
    {
        private List<ISalesTax> Taxes { get; } = new List<ISalesTax>();

        public SalesTaxSelector(params ISalesTax[] taxes)
        {
            Taxes.AddRange(taxes);
        }

        public ISalesTax Select(string country)
        {
            var tax = Taxes.SingleOrDefault(t => t.Country == country);
            if (tax == null)
                throw new InvalidOperationException($"{country} does not have a sales tax.");
            return tax;
        }
    }
}
