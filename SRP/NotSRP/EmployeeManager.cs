using System.Collections.Generic;
using System.Linq;

namespace SOLID.SRP.NotSRP
{
    public class EmployeeManager
    {
        public ISalaryLookup SalaryLookup { get; }

        public EmployeeManager(ISalaryLookup salaryLookup)
        {
            SalaryLookup = salaryLookup;
        }

        public int CalcPayroll(IEnumerable<Employee> employees)
        {
            PopulateSalaries(employees);
            return GetPayroll(employees);
        }



        private void PopulateSalaries(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
                employee.Salary = SalaryLookup.LookupSalary(employee.Id);
        }

        private int GetPayroll(IEnumerable<Employee> employees)
        {
            var payroll = 0;
            foreach (var employee in employees)
                payroll += employee.Salary;
            return payroll;
        }
    }
}
