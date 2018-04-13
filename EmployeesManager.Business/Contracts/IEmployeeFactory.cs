using EmployeesManager.Domain.Models;

namespace EmployeesManager.Business.Contracts
{
    public interface IEmployeeFactory
    {
        /// <summary>
        /// Gets the employee data according to an employee model.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns>The employee information.</returns>
        IEmployee GetEmployee(EmployeeModel employeeModel);
    }
}
