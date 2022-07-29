using System;

namespace SOLID.OCP.Structure.Compliant
{
    public class Customer
    {
        public PersonalDetails Details { get; }

        public Address Address { get; }
        public CustomerLoyalty Loyalty { get; }

        public Customer(PersonalDetails details, Address address, CustomerLoyalty loyalty)
        {
            Details = details;
            Address = address;
            Loyalty = loyalty;
        }
    }

    public class PersonalDetails
    {
        public string CustomerNumber { get; set; }
        public Salutation Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }

        // ctor?
    }

    public class Address
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string TownOrCity { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
    }

    public class CustomerLoyalty
    {
        public decimal LoyaltyPoints { get; set; }
        public decimal LoyaltyRating { get; set; }
        public DateTime LastPurchaseDate { get; set; }
    }

    public enum Salutation
    {
        None,
        Mr,
        Mrs,
        Miss,
        Prof,
    }
}
