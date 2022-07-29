using SOLID.OCP.SwitchToo.Compliant.SalesTaxes;
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


        private static ISalesTax GetSalesTax(string country)
        {
            // TODO: Add Australian GST.
            var taxSelector = new SalesTaxSelector(new NewZealandGst(), 
                                                   new UnitedKingdomVat(),
                                                   new AustaliaGst());
            var tax = taxSelector.Select(country);
            return tax;
        }
    }
}
