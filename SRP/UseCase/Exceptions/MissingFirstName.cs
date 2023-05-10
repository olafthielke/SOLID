using System;

namespace SOLID.SRP.UseCase.Exceptions
{
    public class MissingFirstName : Exception
    {
        public MissingFirstName()
            : base("Missing first name.")
        { }
    }
}
