
-- SQL Script to create CustomerProduct table
CREATE TABLE CustomerProduct (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Rate DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL,
    Price AS (Rate * Quantity) PERSISTED,
    MobileNo NVARCHAR(15) NOT NULL
);
