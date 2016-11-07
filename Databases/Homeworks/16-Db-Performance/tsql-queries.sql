CREATE TABLE PerformanceLogs (
	LogId INT NOT NULL IDENTITY
	,Content NVARCHAR(100)
	,Date DATETIME
	,CONSTRAINT PK_Logs_LogId PRIMARY KEY (LogId)
)

DECLARE @Counter INT = 0
WHILE @Counter < 1000000
BEGIN
INSERT INTO PerformanceLogs (Content, Date)
	VALUES ('Log' + CAST(@Counter AS NVARCHAR), DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01'))
SET @Counter = @Counter + 1
END

SELECT
	COUNT(*)
FROM PerformanceLogs

-------------------1------------------
CHECKPOINT;
DBCC DROPCLEANBUFFERS;

SELECT
	*
FROM PerformanceLogs pl
WHERE pl.Date > '2005-01-01'
AND pl.Date < '2010-01-01';
--Result 00:00:02
-------------------2------------------
CHECKPOINT;
DBCC DROPCLEANBUFFERS;

CREATE INDEX IDX_PerformanceLogs_Date
ON PerformanceLogs (Date)

SELECT
	*
FROM PerformanceLogs pl
WHERE pl.Date > '2005-01-01'
AND pl.Date < '2010-01-01';
--Result 00:00:01
-------------3-------------
CHECKPOINT;
DBCC DROPCLEANBUFFERS;

SELECT * FROM PerformanceLogs pl
WHERE pl.Content LIKE '%123%'
--Result 00:00:00

CHECKPOINT;
DBCC DROPCLEANBUFFERS;

CREATE FULLTEXT CATALOG PerformanceLogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON PerformanceLogs(Content LANGUAGE 1033)
KEY INDEX PK_Logs_LogId
ON PerformanceLogsFullTextCatalog
WITH CHANGE_TRACKING AUTO

SELECT * FROM PerformanceLogs pl
WHERE CONTAINS(pl.Content, '123')
