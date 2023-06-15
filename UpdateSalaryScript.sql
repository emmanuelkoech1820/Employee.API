

CREATE PROCEDURE UpdateEmployeeSalary(
    IN employeeId INT,
    IN newSalary INT,
    OUT oldSalary INT
)
BEGIN
    -- Store the old salary
    SELECT salary INTO oldSalary FROM employees WHERE id = employeeId;

    -- Update the salary
    UPDATE employees SET salary = newSalary WHERE id = employeeId;
END 
