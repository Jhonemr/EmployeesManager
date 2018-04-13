using System.Collections.Generic;
using EmployeesManager.Domain.Models;

namespace EmployeesManager.DataAccess.Contracts
{
    public interface IEmployeesRepository
    {
        /// <summary>
        /// Gets all stored employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        IList<EmployeeModel> GetAll();

        /// <summary>
        /// Gets an stored employee by id.
        /// </summary>
        /// <returns>An employee.</returns>
        EmployeeModel GetById(int id);
    }
}
