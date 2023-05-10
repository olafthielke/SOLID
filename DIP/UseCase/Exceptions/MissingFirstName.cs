﻿using System;

namespace SOLID.DIP.UseCase.Exceptions
{
    public class MissingFirstName : Exception
    {
        public MissingFirstName()
            : base("Missing first name.")
        { }
    }
}
