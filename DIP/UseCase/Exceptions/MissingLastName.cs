﻿using System;

namespace SOLID.DIP.UseCase.Exceptions
{
    public class MissingLastName : Exception
    {
        public MissingLastName()
            : base("Missing last name.")
        { }
    }
}
