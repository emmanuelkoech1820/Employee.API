using System;
using System.Data.SqlClient;
using Employee.Infrastructure;
using MySql.Data.MySqlClient;
using NUnit.Framework;

[TestFixture]
public class EmployeeDALTests
{
    private MySqlConnection connection;
    private EmployeeRepository _dal;
    public EmployeeDALTests(string connectionString, EmployeeRepository dal, EmployeeRepository _dal)
    {
        // Set up the connection to the test database
        connection = new MySqlConnection(connectionString);
    }

    [SetUp]
    public void Setup()
    {

        connection.Open();
    }

    [TearDown]
    // used to cleanup
    public void TearDown()
    {
        connection.Close();
    }

    [Test]
    //I have passed multiple data to the test to test failure and happy paths
    [TestCase(1, 50000)]
    [TestCase(2, 60000)]
    [TestCase(3, 70000)]
    public void TestUpdateEmployeeSalary([Values(1, 2, 3)] int employeeId, [Values(50000, 60000, 70000)] int newSalary)
    {
        // Arrange
        int oldSalary;

        // Act
        oldSalary =  _dal.UpdateSalary(new SalaryUpdateDto {EmpId = employeeId, NewSalary= newSalary }).Result.OldSalary;

        // Assert
        Assert.AreEqual(40000, oldSalary);
    }
}
