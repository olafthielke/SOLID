namespace SOLID.OCP.SwitchToo.Compliant
{
    public interface ISalesTax
    {
        string Country { get; }
        string TaxName { get; }
        decimal TaxRate { get; }
    }
}
