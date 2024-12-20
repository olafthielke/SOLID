﻿using System;
using FluentAssertions;
using Xunit;

namespace SOLID.OCP.SwitchToo.Compliant
{
    public class SalesTaxServiceTests
    {
        [Theory]
        //[InlineData("Australia", "GST", 0.1, 10)]
        [InlineData("New Zealand", "GST", 0.15, 15)]
        [InlineData("United Kingdom", "VAT", 0.20, 20)]
        public void Countries_With_SalesTax_Tests(string country, string taxName, decimal taxRate, decimal taxAmount)
        {
            var salesTaxService = new SalesTaxService();
            salesTaxService.GetSalesTaxName(country).Should().Be(taxName);
            salesTaxService.GetSalesTaxRate(country).Should().Be(taxRate);
            salesTaxService.CalcSalesTaxAmount(100, country).Should().Be(taxAmount);
            salesTaxService.DoesCountryHaveSalesTax(country).Should().BeTrue();
        }

        [Theory]
        [InlineData("USA")]
        [InlineData("Malta")]
        [InlineData("Vietnam")]
        public void Countries_Without_SalesTax_Tests(string country)
        {
            var salesTaxService = new SalesTaxService();
            VerifyThrowsException(() => salesTaxService.GetSalesTaxName(country), country);
            VerifyThrowsException(() => salesTaxService.GetSalesTaxRate(country), country);
            VerifyThrowsException(() => salesTaxService.CalcSalesTaxAmount(100, country), country);
            salesTaxService.DoesCountryHaveSalesTax(country).Should().BeFalse();
        }

        [Fact]
        public void Given_Uninitialised_SalesTaxSelector_When_Call_Select_For_NZ_Then_Throws_InvalidOperationException()
        {
            var selector = new SalesTaxSelector();
            Action select = () => selector.Select("New Zealand");
            select.Should().ThrowExactly<InvalidOperationException>()
                .WithMessage("New Zealand does not have a sales tax.");
        }


        private static void VerifyThrowsException(Action action, string country)
        {
            action.Should().ThrowExactly<InvalidOperationException>()
                .WithMessage($"{country} does not have a sales tax.");
        }
    }
}
