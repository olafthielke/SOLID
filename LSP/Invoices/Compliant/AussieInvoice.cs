namespace SOLID.LSP.Invoices.Compliant
{
    public class AussieInvoice : Invoice
    {
        public override decimal GstRate => 0.10m;
    }
}
