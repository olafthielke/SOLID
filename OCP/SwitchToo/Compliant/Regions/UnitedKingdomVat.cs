namespace SOLID.OCP.SwitchToo.Compliant.Regions
{
    public class UnitedKingdomVat : ISalesTax
    {
        public string Country => "United Kingdom";

        public string TaxName => "VAT";

        public decimal TaxRate => 0.2m;
    }
}
