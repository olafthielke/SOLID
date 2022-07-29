using System;

namespace SOLID.OCP.GetById
{
    public class Customer : HttpResponse
    {
        public int Id { get; }
        public Guid Guid { get; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }

        // more properties
    }
}