﻿namespace SOLID.OCP.SwitchToo.Compliant
{
    public class NewZealandGst : ISalesTax
    {
        public string Country => "New Zealand";

        public string TaxName => "GST";

        public decimal TaxRate => 0.15m;
    }
}
