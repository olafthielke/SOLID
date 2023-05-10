﻿using System;

namespace SOLID.DIP.UseCase.Exceptions
{
    public class MissingEmailAddress : Exception
    {
        public MissingEmailAddress()
            : base("Missing email address.")
        { }
    }
}
