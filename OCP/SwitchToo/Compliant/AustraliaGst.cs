namespace SOLID.OCP.SwitchToo.Compliant
{
    public class AustraliaGst : ISalesTax
    {
        public string Country => "Australia";

        public string TaxName => "GST";

        public decimal TaxRate => 0.10m;
    }
}
