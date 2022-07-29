namespace SOLID.LSP.Invoices.Compliant
{
    public class NzInvoice : Invoice
    {
        public override decimal GstRate => 0.15m;
    }
}
