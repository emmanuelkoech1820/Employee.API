

CREATE PROCEDURE UpdateEmployeeSalary (
    IN empID INT, 
    IN newSalary INT, 
    OUT oldSalary INT
)
BEGIN
   -- This is used to store retreive the existing record
    SELECT salary INTO oldSalary FROM employees WHERE id = empID;
    
   -- update the record to the current one
    UPDATE employees SET salary = newSalary WHERE id = empID;
    
    -- return the old recod to the user
    SELECT oldSalary;
END; 


