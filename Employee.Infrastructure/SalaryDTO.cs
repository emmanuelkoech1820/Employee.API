namespace Employee.Infrastructure
{
    public class SalaryUpdateDto
    {
        public int NewSalary { get; set; }
        public int EmpId { get; set; }
    }
    public class Response
    {
        public bool Success { get; set; }
        public int OldSalary  { get; set; }
    }
}