using System;

namespace SOLID.DIP.UseCase
{
    public class MissingFirstName : Exception
    {
        public MissingFirstName()
            : base("Missing first name.")
        { }
    }
}
