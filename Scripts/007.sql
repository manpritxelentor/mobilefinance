IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[tbl_Customer]') 
         AND name = 'CustomerPhotoPath'
)
BEGIN
	ALTER table tbl_Customer add CustomerPhotoPath nvarchar(max) NULL
END
GO
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[tbl_Customer]') 
         AND name = 'CityId'
)
BEGIN
	ALTER table tbl_Customer add CityId int NULL
END
GO

IF NOT EXISTS(
select top 1 1 from tbl_CodeMaintain where Module = 'Customer'
)
BEGIN
	INSERT INTO tbl_CodeMaintain 
	(Module
		,LastNumber
		,TenantId
		,Prefix
		,Separator
		,Padding)
	values
	('Customer', 0, 2, 'RAJ', '-', 5)
END
GO

IF NOT EXISTS(
select top 1 1 from tbl_GroupCode where Name = 'City'
)
BEGIN
	INSERT INTO tbl_GroupCode 
	(Code
,Name
,DisplayName
,TenantId)
	values
	('AHM', 'City', 'Ahmedabad', 2)
END
GO