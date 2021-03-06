USE Computers
GO

----------------1---------------
--Returning all computers (vendor, model, id) with memory (RAM) between provided range
CREATE PROCEDURE dbo.usp_GetComputersWithRamBetween @low FLOAT, @high FLOAT
AS
	SELECT
		c.Model
		,c.Id
		,v.Name AS [VendorName]
		,c.Memory
	FROM Computers c
	INNER JOIN Vendors v
		ON c.VendorId = v.Id
	WHERE c.Memory BETWEEN @low AND @high
GO

EXEC dbo.usp_GetComputersWithRamBetween	@low = 1
										,@high = 2
GO
----------------2---------------
--Returning all computers with a specific GPU (by id) and range of memory (as the above)

CREATE PROCEDURE dbo.usp_GetComputersWithGpuAndRamBetween @GpuId INT, @low FLOAT, @high FLOAT
AS
	SELECT
		c.Memory AS [ComputerMemory]
		,c.Id AS [ComputerId]
		,c.Model AS [ComputerModel]
		,g.Memory AS [GpuMemory]
		,g.Id AS [GpuId]
		,g.Model AS [GpuModel]
	FROM Computers c
	INNER JOIN ComputersGpus cg
		ON c.Id = cg.ComputerId
	INNER JOIN Gpus g
		ON cg.GpuId = g.Id
	WHERE g.Id = @GpuId
	AND c.Memory BETWEEN @low AND @high
GO

EXEC dbo.usp_GetComputersWithGpuAndRamBetween	@GpuId = 1
												,@low = 1
												,@high = 2
GO
------------3-----------
--Return all GPUs that can be paired with a concrete computer type (dekstop, ultrabook or notebook)

CREATE PROCEDURE dbo.usp_GetGpusForComputerType @ComputerType NVARCHAR(50)
AS
DECLARE @gpuTypeName NVARCHAR(50);

IF LOWER(@ComputerType) = 'desktop' 
BEGIN  
	SET @gpuTypeName = 'Internal';
END
ELSE 
BEGIN  
	SET @gpuTypeName = 'External';
END

SELECT g.Memory AS[GpuMemory],
	g.Model as [GpuModel],
	gt.Name AS [GpuType]
FROM Gpus g
INNER JOIN GpuTypes gt ON g.TypeId = gt.Id
WHERE LOWER(gt.Name) = LOWER(@gpuTypeName)
GO

EXEC dbo.usp_GetGpusForComputerType @ComputerType = 'ultrabook';
EXEC dbo.usp_GetGpusForComputerType @ComputerType = 'desktop';
GO