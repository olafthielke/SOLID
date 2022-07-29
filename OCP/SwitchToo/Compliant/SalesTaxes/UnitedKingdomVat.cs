namespace SOLID.OCP.SwitchToo.Compliant.SalesTaxes
{
    public class UnitedKingdomVat : ISalesTax
    {
        public string Country => "United Kingdom";
        public string TaxName => "VAT";
        public decimal TaxRate => 0.20m;
    }
}
