using System.Collections.Generic;
using System.Linq;
using Moq;
using EmployeesManager.Business.Contracts;
using EmployeesManager.Business.Dtos;
using EmployeesManager.Business.Services;
using EmployeesManager.DataAccess.Contracts;
using EmployeesManager.Domain.Enums;
using EmployeesManager.Domain.Models;
using Xunit;

namespace EmployeesManager.Tests.Services
{
    public class EmployeeServiceTest
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeServiceTest()
        {
            var hourlyEmployModel = new EmployeeModel
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = ContractType.HourlySalaryEmployee,
                RoleId = 1,
                RoleName = "Administrator",
                RoleDescription = "Admin",
                HourlySalary = 60000,
                MonthlySalary = 80000
            };
            var monthlyEmployModel = new EmployeeModel
            {
                Id = 2,
                Name = "Sebastian",
                ContractTypeName = ContractType.MonthlySalaryEmployee,
                RoleId = 2,
                RoleName = "Contractor",
                RoleDescription = "Contractor",
                HourlySalary = 60000,
                MonthlySalary = 80000
            };

            // Setting up the methods for the employeesRepository mock
            var employeesRepository = new Mock<IEmployeesRepository>();
            employeesRepository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(hourlyEmployModel);
            employeesRepository.Setup(_ => _.GetAll()).Returns(new List<EmployeeModel> {hourlyEmployModel, monthlyEmployModel});

            // Setting up the methods for the employeeFactory mock
            var employeeFactory = new Mock<IEmployeeFactory>();
            employeeFactory.Setup(_ => _.GetEmployee(It.IsAny<EmployeeModel>()))
                .Returns(new HourlyEmployee(hourlyEmployModel));

            _employeeService = new EmployeeService(employeesRepository.Object, employeeFactory.Object);
        }

        [Fact(DisplayName = "GetAllEmployeesValidTest")]
        public void GetAllEmployeesValidTest()
        {
            const int expectedResult = 2;
            var actualResult = _employeeService.GetAll();
            Assert.Equal(actualResult.Count(), expectedResult);
        }

        [Fact(DisplayName = "GetEmployeeByIdValidTest")]
        public void GetEmployeeByIdValidTest()
        {
            const string expectedResult = "Juan";
            var actualResult = (HourlyEmployee)_employeeService.GetById(1);
            Assert.Equal(actualResult.Name, expectedResult);
        }
    }
}
