using System;
using MySql.Data.MySqlClient;
using NUnit.Framework;

[TestFixture]
public class EmployeeDALTests
{
    private MySqlConnection connection;
    private EmployeeDAL dal;

    [SetUp]
    public void Setup()
    {
        // Set up the connection to the test database
        string connectionString = "your_test_mysql_connection_string";
        connection = new MySqlConnection(connectionString);
        connection.Open();

        // Initialize the data access layer
        dal = new EmployeeDAL(connection);
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up the test database
        connection.Close();
    }

    [Test]
    public void TestUpdateEmployeeSalary()
    {
        // Arrange
        int employeeId = 1;
        int newSalary = 50000;
        int oldSalary;

        // Act
        oldSalary = dal.UpdateEmployeeSalary(employeeId, newSalary);

        // Assert
        Assert.AreEqual(40000, oldSalary);
    }
}
