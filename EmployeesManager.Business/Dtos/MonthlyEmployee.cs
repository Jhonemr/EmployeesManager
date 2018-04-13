using EmployeesManager.Business.Contracts;
using EmployeesManager.Domain.Models;

namespace EmployeesManager.Business.Dtos
{
    /// <summary>
    /// Class that represents the Monthly Salary Employees.
    /// </summary>
    public class MonthlyEmployee : EmployeeModel, IEmployee
    {
        public MonthlyEmployee()
        {
        }

        /// <summary>
        /// Sets the model data to the business object.
        /// </summary>
        /// <param name="employee">The employee model.</param>
        public MonthlyEmployee(EmployeeModel employee)
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
        /// Sets the annual salary property for Monthly Salary Employees.
        /// </summary>
        public void SetAnnualSalary()
        {
            AnnualSalary = MonthlySalary * 12;
        }
    }
}
