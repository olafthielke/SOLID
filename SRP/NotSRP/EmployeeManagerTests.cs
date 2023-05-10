using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace SOLID.SRP.NotSRP
{
    public class EmployeeManagerTests
    {
        [Fact]
        public void Given_No_Employees_When_Call_CalcPayroll_Then_Payroll_Is_Zero()
        {
            var mgr = new EmployeeManager(null);
            var no_employees = new List<Employee>();
            var payroll = mgr.CalcPayroll(no_employees);
            payroll.Should().Be(0);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(71)]
        [InlineData(443)]
        public void Given_One_Employee_When_Call_CalcPayroll_Then_Lookup_Salary_By_EmployeeId(int employeeId)
        {
            var mockSalaryLookup = new MockSalaryLookup();
            var mgr = new EmployeeManager(mockSalaryLookup);
            var fred = new Employee(employeeId, "Fred", "Flintstone");
            var one_employee = new List<Employee>() { fred };
            mgr.CalcPayroll(one_employee);
            VerifyLookupSalary(employeeId, mgr);
        }

        [Theory]
        [InlineData(67500)]
        [InlineData(98700)]
        [InlineData(123400)]
        public void Given_One_Employee_When_Call_CalcPayroll_Then_Salary_Lookup_Sets_Salary_On_Employee(int salary)
        {
            var mockSalaryLookup = new MockSalaryLookup(salary);
            var mgr = new EmployeeManager(mockSalaryLookup);
            var fred = new Employee(3, "Fred", "Flintstone");
            var one_employee = new List<Employee>() { fred };
            var payroll = mgr.CalcPayroll(one_employee);
            fred.Salary.Should().Be(salary);
            payroll.Should().Be(salary);
        }

        [Fact]
        public void Given_Two_Employees_When_Call_CalcPayroll_Then_Looks_Up_And_Sets_Salaries_And_Calculates_Payroll()
        {
            var fredSalary = 123400;
            var barneySalary = 234500;
            var fred = new Employee(3, "Fred", "Flintstone");
            var barney = new Employee(79, "Barney", "Rubble");

            var mockSalaryLookup = new MockSalaryLookup(fredSalary, barneySalary);
            var mgr = new EmployeeManager(mockSalaryLookup);
            var employees = new List<Employee>() { fred, barney };
            var payroll = mgr.CalcPayroll(employees);
            fred.Salary.Should().Be(fredSalary);
            barney.Salary.Should().Be(barneySalary);
            payroll.Should().Be(fred.Salary + barney.Salary);
        }




        private void VerifyLookupSalary(int employeeId, EmployeeManager mgr)
        {
            var mockSalaryLookup = (MockSalaryLookup)mgr.SalaryLookup;

            mockSalaryLookup.CalledWithEmployeeIds[0].Should().Be(employeeId);
        }
    }


    public class MockSalaryLookup : ISalaryLookup
    {
        public List<int> CalledWithEmployeeIds = new List<int>();
        private int currentIndex = 0;

        private int[] SalariesToReturn;

        public MockSalaryLookup(params int[] salariesToReturn)
        {
            SalariesToReturn = salariesToReturn;
        }

        public int LookupSalary(int employeeId)
        {
            CalledWithEmployeeIds.Add(employeeId);

            return SalariesToReturn.Any() ? SalariesToReturn[currentIndex++] : 0;
        }
    }
}
