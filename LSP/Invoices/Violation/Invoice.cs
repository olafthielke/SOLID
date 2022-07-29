namespace SOLID.LSP.Invoices.Violation
{
    public abstract class Invoice
    {
        public decimal GstRate { get; private set; }

        public void SetGst()
        {
            if (this is NzInvoice)
                GstRate = 0.15m;

            else if (this is AussieInvoice)
                GstRate = 0.10m;
            
            else if (this is UkInvoice)
                GstRate = 0.20m;
            // ...
        }
    }
}
