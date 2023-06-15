using System.Data;

namespace Employee.Infrastructure
{
    public interface IEmployeeRepository
    {
        Task<Response> UpdateSalary(SalaryUpdateDto salaryUpdateDto); 
    }
}