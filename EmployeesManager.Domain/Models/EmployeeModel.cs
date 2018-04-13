using EmployeesManager.Domain.Enums;

namespace EmployeesManager.Domain.Models
{
    /// <summary>
    /// Represents the model for employee data.
    /// </summary>
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContractType ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }
        public double AnnualSalary { get; set; }
    }
}
