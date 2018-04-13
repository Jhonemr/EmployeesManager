using System;
using System.Net;
using EmployeesManager.Business.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Api.Controllers
{
    /// <summary>
    /// Controller to handle employees-related calls.
    /// </summary>
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// Initializes a new instance of the EmployeesController class.
        /// </summary>
        /// <param name="employeeService">The employee Service.</param>
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET api/employees
        /// <summary>
        /// Gets all employees data.
        /// </summary>
        /// <returns>Tha action result with the employees list.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_employeeService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/employees/5
        /// <summary>
        /// Gets the data for one employee by id.
        /// </summary>
        /// <param name="id">The employee id.</param>
        /// <returns>The action result with the employee data.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_employeeService.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
