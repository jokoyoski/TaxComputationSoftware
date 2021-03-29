------------------------------------CREATE COMPANYCODE TABLE--------------------------------------

IF NOT EXISTS(SELECT 1
FROM sysobjects
WHERE type = 'U' and name = 'CompanyCode')
BEGIN
  create table CompanyCode
  (

    Id int identity(1,1) NOT NULL ,
    CompanyId int,
    Code varchar(20),
    NextExecution DateTime
  )
END
GO


-------------------------------------- STORED PROCEDURE TO  GET  COMPANYCODE BY ID -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_CompanyCode_By_Id]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Get_CompanyCode_By_Id]
END
GO
CREATE procedure [dbo].[usp_Get_CompanyCode_By_Id](
  @CompanyId int
)
AS

select *
from [dbo].[CompanyCode]
where CompanyId = @CompanyId
GO




-------------------------------------- STORED PROCEDURE TO  INSERT INTO COMPANY CODE  TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_Into_Company_Code_Table]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Into_Company_Code_Table]
PRINT('OK')
END
GO
CREATE PROCEDURE [usp_Insert_Into_Company_Code_Table](
@CompanyId INT,
@NextExecution   DateTime,
@Code  varchar(20)
)
AS
if  exists(select * from [dbo].[CompanyCode] where CompanyId=@CompanyId)
BEGIN
UPDATE [dbo].[CompanyCode] SET Code=@Code , NextExecution=@NextExecution where CompanyId=@CompanyId
END
ELSE
BEGIN
INSERT [dbo].CompanyCode
(
 CompanyId,
 NextExecution,
 Code
)
VALUES
(
 @CompanyId,
 @NextExecution,
 @Code
)
END
GO




-------------------------------------CREATE ASSETMAPPING TABLE--------------------------------------

IF NOT EXISTS(SELECT 1
FROM sysobjects
WHERE type = 'U' and name = 'AssetMapping')
BEGIN
  create table AssetMapping
  (

    Id int identity(1,1) NOT NULL ,
    AssetName varchar(50),
    Initial int,
    Annual int
  )
END
GO

--------------------------------------- STORED PROCEDURE TO  INSERT ASSET MAPPING -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Insert_Asset_Mapping]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Insert_Asset_Mapping]
END
GO
CREATE procedure [dbo].[usp_Insert_Asset_Mapping](
  @AssetName VARCHAR(50),
  @Initial   INT,
  @Annual  INT
)
AS

INSERT [dbo].[AssetMapping]
(
    AssetName,
    Initial,
    Annual
)
VALUES
(
    @AssetName,
    @Initial,
    @Annual
)
GO

--------------------------------------- STORED PROCEDURE TO  UPDATE ASSET MAPPING -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Update_Asset_Mapping]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Update_Asset_Mapping]
END
GO
CREATE procedure [dbo].[usp_Update_Asset_Mapping](
  @Id INT,
  @AssetName varchar(50),
  @Initial   int,
  @Annual  int
)
AS
UPDATE [dbo].[AssetMapping]  
  SET 
    AssetName = @AssetName,  
    Initial = @Initial,  
    Annual = @Annual
  WHERE  Id = @Id  
GO

--------------------------------------- STORED PROCEDURE TO  DELETE ASSET MAPPING -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Delete_Asset_Mapping]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Delete_Asset_Mapping]
END
GO
CREATE procedure [dbo].[usp_Delete_Asset_Mapping](
  @Id INT
)
AS
DELETE [dbo].[AssetMapping] WHERE  Id = @Id  
GO

--------------------------------------- STORED PROCEDURE TO  GET ASSET MAPPING -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Asset_Mapping]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Get_Asset_Mapping]
END
GO
CREATE procedure [dbo].[usp_Get_Asset_Mapping]
AS

select *
from [dbo].[AssetMapping] 
GO
--------------------------------------- STORED PROCEDURE TO  GET ASSET ASSETMAPPING BY ID -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Asset_Mapping_By_Id]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Get_Asset_Mapping_By_Id]
END
GO
CREATE procedure [dbo].[usp_Get_Asset_Mapping_By_Id](
  @Id int
)
AS

select *
from [dbo].[AssetMapping]
where Id = @Id
GO

--------------------------------------- CREATE FINANCIAL YEAR -----------------------------------------
IF NOT EXISTS(SELECT 1
FROM sysobjects
WHERE type = 'U' and name = 'FinancialYear')
BEGIN
  create table FinancialYear
  (

    Id int identity(1,1) NOT NULL ,
    Name varchar(50),
    OpeningDate DATETIME2 NOT NULL,
    ClosingDate DATETIME2 NOT NULL,
    FinancialDate VARCHAR(50) NOT NULL,
    CompanyId int
  )
END
GO
--------------------------------------- STORED PROCEDURE TO  INSERT FINANCIAL YEAR -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Insert_Financial_Year]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Insert_Financial_Year]
END
GO
CREATE procedure [dbo].[usp_Insert_Financial_Year](
  @Name varchar(50),
  @OpeningDate datetime2,
  @ClosingDate datetime2,
  @FinancialDate varchar(30),
  @CompanyId int
)
AS
INSERT [dbo].[FinancialYear]
  (
  Name,
  OpeningDate,
  ClosingDate,
  FinancialDate,
  CompanyId
  )
VALUES(
    @Name,
    @OpeningDate,
    @ClosingDate,
    @FinancialDate,
    @CompanyId
)
GO

--------------------------------------- STORED PROCEDURE TO  Update FINANCIAL YEAR -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Update_Financial_Year]') IS NOT NULL
BEGIN
  DROP procedure [dbo].[usp_Update_Financial_Year]
END
GO
CREATE procedure [dbo].[usp_Update_Financial_Year](
  @Id int,
  @Name varchar(50),
  @OpeningDate datetime2,
  @ClosingDate datetime2,
  @FinancialDate varchar(30),
  @CompanyId int
)
AS
-- Update rows in table 'TableName'
UPDATE [dbo].[FinancialYear]
SET
    Name = @Name,
    OpeningDate = @OpeningDate,
    ClosingDate = @ClosingDate,
    FinancialDate = @FinancialDate,
    CompanyId = @CompanyId
  -- add more columns and values here
WHERE 	Id = @Id
GO 


--------------------------------------- STORED PROCEDURE TO  DELETE FINANCIAL YEAR -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Delete_Financial_Year]') IS NOT NULL
BEGIN
  DROP procedure [dbo].[usp_Delete_Financial_Year]
END
GO
CREATE procedure [dbo].[usp_Delete_Financial_Year](
  @CompanyId int
)
AS
-- Update rows in table 'TableName'
DELETE FROM [dbo].[FinancialYear] WHERE 	CompanyId = @CompanyId
GO 



--------------------------------------- STORED PROCEDURE TO  GET FINANCIAL YEAR -------------------------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Financial_Year]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Get_Financial_Year]
END
GO
CREATE procedure [dbo].[usp_Get_Financial_Year]
AS
select *
from [dbo].[FinancialYear]
GO

--------------------------------------- STORED PROCEDURE TO  GET ASSET FINANCIALYEAR BY ID -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Financial_Year_By_Id]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Get_Financial_Year_By_Id]
END
GO
CREATE procedure [dbo].[usp_Get_Financial_Year_By_Id](
  @Id int
)
AS

select *
from [dbo].[FinancialYear]
where Id = @Id
GO


--------------------------------------- STORED PROCEDURE TO  GET ASSET FINANCIALYEAR BY COMPANYID -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Financial_Year_By_CompanyId]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Get_Financial_Year_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_Financial_Year_By_CompanyId](
  @CompanyId int
)
AS

select *
from [dbo].[FinancialYear]
where CompanyId = @CompanyId
GO


--------------------------------------- STORED PROCEDURE TO  GET ASSET MAPPING BY ASSETNAME -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_AssetMapping_By_AssetName]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Get_AssetMapping_By_AssetName]
END
GO
CREATE procedure [dbo].[usp_Get_AssetMapping_By_AssetName](
  @AssetName varchar(50)
)
AS

select *
from [dbo].[AssetMapping]
where AssetName = @AssetName
GO