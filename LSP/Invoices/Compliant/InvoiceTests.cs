using FluentAssertions;
using Xunit;

namespace SOLID.LSP.Invoices.Compliant
{
    public class InvoiceTests
    {
        [Fact]
        public void NzInvoice_GstRate_Is_15_Percent()
        {
            var invoice = new NzInvoice();
            invoice.GstRate.Should().Be(0.15m);
        }

        [Fact]
        public void UkInvoice_GstRate_Is_20_Percent()
        {
            var invoice = new UkInvoice();
            invoice.GstRate.Should().Be(0.20m);
        }

        [Fact]
        public void AussieInvoice_GstRate_Is_10_Percent()
        {
            var invoice = new AussieInvoice();
            invoice.GstRate.Should().Be(0.10m);
        }
    }
}
