using System.Collections.Generic;

namespace EmployeesManager.Business.Contracts
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets all employees data.
        /// </summary>
        /// <returns>The list with all employees data.</returns>
        IEnumerable<IEmployee> GetAll();

        /// <summary>
        /// Gets the data for one employee by id.
        /// </summary>
        /// <param name="id">The employee id.</param>
        /// <returns>The employee data.</returns>
        IEmployee GetById(int id);
    }
}
