using EmployeesManager.Business.Contracts;
using EmployeesManager.Domain.Models;

namespace EmployeesManager.Business.Dtos
{
    /// <summary>
    /// Class that represents the Hourly Salary Employees.
    /// </summary>
    public class HourlyEmployee : EmployeeModel, IEmployee
    {
        public HourlyEmployee()
        {
        }

        /// <summary>
        /// Sets the model data to the business object.
        /// </summary>
        /// <param name="employee">The employee model.</param>
        public HourlyEmployee(EmployeeModel employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleId = employee.RoleId;
            RoleName = employee.RoleName;
            RoleDescription = employee.RoleDescription;
            HourlySalary = employee.HourlySalary;
            MonthlySalary = employee.MonthlySalary;
        }

        /// <summary>
        /// Sets the annual salary property for Hourly Salary Employees.
        /// </summary>
        public void SetAnnualSalary()
        {
             AnnualSalary = 120 * HourlySalary * 12;
        }
    }
}
