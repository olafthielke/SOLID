using System;

namespace SOLID.DIP.UseCase
{
    public class MissingLastName : Exception
    {
        public MissingLastName()
            : base("Missing last name.")
        { }
    }
}
