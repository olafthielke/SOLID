using System;

namespace SOLID.DIP.UseCase
{
    public class MissingEmailAddress : Exception
    {
        public MissingEmailAddress()
            : base("Missing email address.")
        { }
    }
}
