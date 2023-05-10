namespace SOLID.SRP.NotSRP
{
    public class Employee
    {
        public int Id { get; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        public int Salary { get; set; }

        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
