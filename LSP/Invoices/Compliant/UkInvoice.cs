namespace SOLID.LSP.Invoices.Compliant
{
    public class UkInvoice : Invoice
    {
        public override decimal GstRate => 0.20m;
    }
}
