using System.Data;
using System.Data.SqlClient;

namespace Employee.Infrastructure
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly string connectionString;
        public EmployeeRepository()
        {
            // This should got to Appsettings/or cloud config to be fetched dynamically based on environment
            //should be on startup incase its used by other services
            connectionString = "your_connection_string_here";
        }

        public async Task<Response> UpdateSalary(SalaryUpdateDto salaryUpdateDto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateEmployeeSalary";

                    command.Parameters.AddWithValue("@empID", salaryUpdateDto.EmpId);
                    command.Parameters.AddWithValue("@newSalary", salaryUpdateDto.NewSalary);

                    SqlParameter oldSalaryParameter = new SqlParameter("@oldSalary", SqlDbType.Int);
                    oldSalaryParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(oldSalaryParameter);

                    command.ExecuteNonQuery();

                    int oldSalary = Convert.ToInt32(command.Parameters["@oldSalary"].Value);
                    return new Response { OldSalary = oldSalary, Success = true };
                }
            }
        }
    }        

    
}