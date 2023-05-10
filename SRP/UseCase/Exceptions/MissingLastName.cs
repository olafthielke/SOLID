using System;

namespace SOLID.SRP.UseCase.Exceptions
{
    public class MissingLastName : Exception
    {
        public MissingLastName()
            : base("Missing last name.")
        { }
    }
}
