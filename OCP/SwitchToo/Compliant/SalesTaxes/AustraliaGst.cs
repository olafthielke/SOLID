namespace SOLID.OCP.SwitchToo.Compliant.SalesTaxes
{
    public class AustaliaGst : ISalesTax
    {
        public string Country => "Australia";
        public string TaxName => "GST";
        public decimal TaxRate => 0.10m;
    }
}
