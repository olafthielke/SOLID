using System;

namespace SOLID.OCP.SwitchToo.Compliant
{
    public class SalesTaxService
    {
        public string GetSalesTaxName(string country)
        {
            var tax = GetSalesTax(country);
            return tax.TaxName;
        }

        public decimal GetSalesTaxRate(string country)
        {
            var tax = GetSalesTax(country);
            return tax.TaxRate;
        }

        public decimal CalcSalesTaxAmount(decimal amount, string country)
        {
            return amount * GetSalesTaxRate(country);
        }

        public bool DoesCountryHaveSalesTax(string country)
        {
            try
            {
                var tax = GetSalesTax(country);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private ISalesTax GetSalesTax(string country)
        {
            var selector = new SalesTaxSelector(new NewZealandGst(),
                new UnitedKingdomVat(), new AustraliaGst());

            return selector.Select(country);
        }
    }
}
