using System;

namespace SOLID.SRP.UseCase.Exceptions
{
    public class MissingEmailAddress : Exception
    {
        public MissingEmailAddress()
            : base("Missing email address.")
        { }
    }
}
