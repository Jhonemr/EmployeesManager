using System;
using EmployeesManager.Business.Contracts;
using EmployeesManager.Business.Dtos;
using EmployeesManager.Domain.Enums;
using EmployeesManager.Domain.Models;

namespace EmployeesManager.Business.Factories
{
    /// <summary>
    /// Factory object for the employee object.
    /// </summary>
    public class EmployeeFactory : IEmployeeFactory
    {
        /// <summary>
        /// Creates an instance of the IEmployee object according to the contract type.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns>The employee business object.</returns>
        public IEmployee GetEmployee(EmployeeModel employeeModel)
        {
            IEmployee employee;
            switch (employeeModel.ContractTypeName)
            {
                case ContractType.HourlySalaryEmployee:
                    employee = new HourlyEmployee(employeeModel);
                    employee.SetAnnualSalary();
                    break;
                case ContractType.MonthlySalaryEmployee:
                    employee = new MonthlyEmployee(employeeModel);
                    employee.SetAnnualSalary();
                    break;
                default:
                    throw new NotSupportedException();
            }

            employee.SetAnnualSalary();
            return employee;
        }
    }
}
