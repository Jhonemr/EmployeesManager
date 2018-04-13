using System.Collections.Generic;
using System.Linq;
using EmployeesManager.Business.Contracts;
using EmployeesManager.DataAccess.Contracts;

namespace EmployeesManager.Business.Services
{
    /// <summary>
    /// Handles the business logic for employees.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeService(IEmployeesRepository employeesRepository, IEmployeeFactory employeeFactory)
        {
            _employeesRepository = employeesRepository;
            _employeeFactory = employeeFactory;
        }

        /// <summary>
        /// Gets all employees data.
        /// </summary>
        /// <returns>The list with all employees data.</returns>
        public IEnumerable<IEmployee> GetAll()
        {
            return _employeesRepository.GetAll()
                .Select(employee => _employeeFactory.GetEmployee(employee));
        }

        /// <summary>
        /// Gets the data for one employee by id.
        /// </summary>
        /// <param name="id">The employee id.</param>
        /// <returns>The employee data.</returns>
        public IEmployee GetById(int id)
        {
            var employee = _employeesRepository.GetById(id);
            return employee == null ? null : _employeeFactory.GetEmployee(employee);
        }
    }
}
