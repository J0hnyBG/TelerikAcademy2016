---------------1--------------
USE [master]
GO

IF DB_ID('BankSystem') IS NOT NULL
BEGIN
	DROP DATABASE [BankSystem]
END
GO

CREATE DATABASE [BankSystem]
GO

USE [BankSystem]
GO

CREATE TABLE dbo.Persons (
	Id INT IDENTITY
	,CONSTRAINT PK_Persons_Id PRIMARY KEY (Id)
	,FirstName NVARCHAR(50) NOT NULL
	,LastName NVARCHAR(50) NOT NULL
	,SSN BIGINT NOT NULL UNIQUE
)
GO

CREATE TABLE dbo.Accounts (
	Id INT IDENTITY
	,CONSTRAINT PK_Accounts_Id PRIMARY KEY (Id)
	,PersonId INT
	,CONSTRAINT FK_Accounts_Persons FOREIGN KEY (PersonId) REFERENCES Persons (Id)
	,Balance MONEY
)
GO

INSERT INTO Persons (FirstName, LastName, SSN)
	VALUES (N'Petar', N'Petrov', 99081821);
INSERT INTO Persons (FirstName, LastName, SSN)
	VALUES (N'Petar', N'Ivanov', 99081421);
INSERT INTO Persons (FirstName, LastName, SSN)
	VALUES (N'Ivan', N'Petrov', 123546597);
INSERT INTO Persons (FirstName, LastName, SSN)
	VALUES (N'Georgi', N'Ivanov', 546546523);
INSERT INTO Persons (FirstName, LastName, SSN)
	VALUES (N'Petar', N'Georgiev', 990121821);

INSERT INTO Accounts (PersonId, Balance)
	VALUES (1, 1000)
INSERT INTO Accounts (PersonId, Balance)
	VALUES (1, 2000)
INSERT INTO Accounts (PersonId, Balance)
	VALUES (2, 2000);
INSERT INTO Accounts (PersonId, Balance)
	VALUES (3, 3000);
INSERT INTO Accounts (PersonId, Balance)
	VALUES (4, 4000);
INSERT INTO Accounts (PersonId, Balance)
	VALUES (5, 5000);
GO

CREATE PROC dbo.usp_SelectFullNameOfAllPeople
AS
	SELECT
		p.FirstName + ' ' + p.LastName AS [FullName]
	FROM Persons p
GO

EXEC dbo.usp_SelectFullNameOfAllPeople
GO

---------------2--------------
CREATE PROC dbo.usp_SelectPeopleWithMoreMoneyThan (@money MONEY)
AS
	SELECT
		p.FirstName + ' ' + p.LastName AS [FullName]
		,SUM(a.Balance) AS [TotalMoney]
	FROM Accounts a
	JOIN Persons p
		ON a.PersonId = p.Id
	GROUP BY	a.PersonId
				,p.Id
				,p.FirstName
				,p.LastName
				,p.SSN
	HAVING @money <= SUM(a.Balance)
GO

EXEC dbo.usp_SelectPeopleWithMoreMoneyThan @money = '3500'
GO
---------------3--------------
CREATE FUNCTION dbo.udf_GetBalanceAfter (@sum MONEY,
@interest FLOAT,
@months FLOAT)
RETURNS MONEY
AS
BEGIN
	RETURN (
	(@months / 12) * @interest * @sum / 100 + @sum
	)
END
GO

SELECT
	dbo.udf_GetBalanceAfter(100, 5, 12)
SELECT
	dbo.udf_GetBalanceAfter(100, 5, 18)
SELECT
	dbo.udf_GetBalanceAfter(100, 5, 24)
GO

---------------4--------------

IF OBJECT_ID('dbo.usp_ApplyMonthOfInterestTo') IS NOT NULL
	SET NOEXEC ON
GO
CREATE PROCEDURE dbo.usp_ApplyMonthOfInterestTo
AS
	RETURN;
GO
SET NOEXEC OFF
GO
ALTER PROCEDURE dbo.usp_ApplyMonthOfInterestTo (@interest FLOAT, @accountId INT)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @accountBalance MONEY;
	SET @accountBalance = (SELECT
			a.Balance
		FROM Accounts a
		WHERE @accountId = a.Id)
	DECLARE @newBalance MONEY;
	SET @newBalance = dbo.udf_GetBalanceAfter(@accountBalance, @interest, 1);

	UPDATE Accounts
	SET Balance = @newBalance
	WHERE Id = @accountId

	RETURN;
END
GO

SELECT
	*
FROM Accounts a
WHERE a.Id = 1;

EXEC usp_ApplyMonthOfInterestTo	@interest = 5
								,@accountId = 1;
SELECT
	*
FROM Accounts a
WHERE a.Id = 1;

---------------5--------------

IF OBJECT_ID('dbo.usp_WithdrawMoney') IS NOT NULL
	SET NOEXEC ON
GO
CREATE PROCEDURE dbo.usp_WithdrawMoney
AS
	RETURN;
GO
SET NOEXEC OFF
GO
ALTER PROCEDURE dbo.usp_WithdrawMoney (@accountId INT,
@money MONEY)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRAN;
	SET XACT_ABORT ON;
	DECLARE @currentBalance MONEY;
	SET @currentBalance = (SELECT
			a.Balance
		FROM Accounts a
		WHERE @accountId = a.Id)
	DECLARE @newBalance MONEY;
	SET @newBalance = @currentBalance - @money;

	UPDATE Accounts
	SET Balance = @newBalance
	WHERE @accountId = Id

	COMMIT;
	RETURN;
END
GO

SELECT
	*
FROM Accounts a
WHERE a.Id = 3;

EXEC dbo.usp_WithdrawMoney	@money = 1000
							,@accountId = 3
SELECT
	*
FROM Accounts a
WHERE a.Id = 3;

IF OBJECT_ID('dbo.usp_DepositMoney') IS NOT NULL
	SET NOEXEC ON
GO
CREATE PROCEDURE dbo.usp_DepositMoney
AS
	RETURN;
GO
SET NOEXEC OFF
GO
ALTER PROCEDURE dbo.usp_DepositMoney (@accountId INT,
@money MONEY)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRAN;
	SET XACT_ABORT ON;
	DECLARE @currentBalance MONEY;
	SET @currentBalance = (SELECT
			a.Balance
		FROM Accounts a
		WHERE @accountId = a.Id)
	DECLARE @newBalance MONEY;
	SET @newBalance = @currentBalance + @money;

	UPDATE Accounts
	SET Balance = @newBalance
	WHERE @accountId = Id

	COMMIT;
	RETURN;
END
GO

SELECT
	*
FROM Accounts a
WHERE a.Id = 3;

EXEC dbo.usp_DepositMoney	@money = 1000
							,@accountId = 3
SELECT
	*
FROM Accounts a
WHERE a.Id = 3;

---------------6--------------

CREATE TABLE dbo.Logs (
	Id INT IDENTITY
	,CONSTRAINT PK_Logs_ID PRIMARY KEY (Id)
	,AccountId INT
	,CONSTRAINT FK_Logs_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts (Id)
	,OldSum MONEY
	,NewSum MONEY
)
GO

CREATE TRIGGER dbo.trg_AccountBalanceUpdate
ON dbo.Accounts
FOR UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @oldBalance MONEY;
	DECLARE @newBalance MONEY;
	DECLARE @accountId INT;

	SET @newBalance = (SELECT
			Balance
		FROM INSERTED);
	SET @oldBalance = (SELECT
			Balance
		FROM DELETED);
	SET @accountId = (SELECT
			Id
		FROM DELETED);

	INSERT INTO Logs (AccountId, OldSum, NewSum)
		VALUES (@accountId, @oldBalance, @newBalance);

END
GO

SELECT
	*
FROM Logs l
EXEC dbo.usp_DepositMoney	@money = 10000
							,@accountId = 3
EXEC dbo.usp_WithdrawMoney	@money = 1000
							,@accountId = 5
SELECT
	*
FROM Logs l
GO
---------------7--------------
USE [TelerikAcademy]
GO
CREATE FUNCTION dbo.udf_GetAllNamesConsistingOfSetOfLetters (@letters NVARCHAR(MAX))
RETURNS TABLE
AS
	RETURN (SELECT DISTINCT e.FirstName FROM Employees e);
GO

--DROP FUNCTION dbo.udf_GetAllNamesConsistingOfSetOfLetters

SELECT 
	*
FROM dbo.udf_GetAllNamesConsistingOfSetOfLetters('oistmiahf');
GO
---------------2--------------
---------------2--------------
---------------2--------------
---------------2--------------
---------------2--------------
---------------2--------------