CREATE TABLE [dbo].[PaymentMethods]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Cash] BIT NOT NULL DEFAULT 1, 
    [MasterCard] BIT NOT NULL DEFAULT 1, 
    [Visa] BIT NOT NULL DEFAULT 1, 
    [Сashless ] BIT NOT NULL DEFAULT 1, 
    [Сredit] BIT NOT NULL DEFAULT 1
)
