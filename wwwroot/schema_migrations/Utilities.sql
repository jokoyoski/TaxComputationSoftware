IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'AssetMapping')
BEGIN
   create table AssetMapping(

 Id   int identity(1,1) NOT NULL ,
 AssetName varchar(50),
 Initial int,
 Annual  int
 )
END
GO

--------------------------------------- STORED PROCEDURE TO  INSERT ASSET ASSETMAPPING -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Insert_Asset_Mapping]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_Asset_Mapping]
END
GO
CREATE procedure usp_Insert_Asset_Mapping(
@AssetName varchar(50),
@Initial   int,
@Annual  int
)
AS

INSERT [dbo].[AssetMapping](
 AssetName,
 Initial,
 Annual
)
VALUES(
 @AssetName,
 @Initial,
 @Annual
)
GO
--------------------------------------- STORED PROCEDURE TO  GET ASSET MAPPING -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Asset_Mapping]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Asset_Mapping]
END
GO
CREATE procedure [dbo].[usp_Get_Asset_Mapping]
AS

select * from [dbo].[AssetMapping] 
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

select AssetName, Initial, Annual from [dbo].[AssetMapping] where Id = @Id
GO
--------------------------------------- STORED PROCEDURE TO  UPDATE ASSET ASSETMAPPING BY ID -----------------------------------------

--------------------------------------- CREATE FINANCIAL YEAR -----------------------------------------
IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'FinancialYear')
BEGIN
   create table FinancialYear(

 Id   int identity(1,1) NOT NULL ,
 Name varchar(50)
 )
END
GO
--------------------------------------- STORED PROCEDURE TO  INSERT FINANCIAL YEAR -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Insert_Financial_Year]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_Financial_Year]
END
GO
CREATE procedure usp_Insert_Financial_Year(
@Name varchar(50)
)
AS

INSERT [dbo].[FinancialYear](
 Name
)
VALUES(
 @Name
)
GO
--------------------------------------- STORED PROCEDURE TO  GET FINANCIAL YEAR -------------------------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Financial_Year]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Financial_Year]
END
GO
CREATE procedure [dbo].[usp_Get_Financial_Year]
AS

select Name from [dbo].[usp_Get_Financial_Year] 
GO
--------------------------------------- STORED PROCEDURE TO  CREATE PROFIT AND LOSS MAPPING -------------------------------------------------------
IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'ProfitAndLossMapping')
BEGIN
   create table ProfitAndLossMapping(

 Id   int identity(1,1) NOT NULL ,
 Revenue   int,
 OtherIncome  int,
 CostOfSales   int,
 OtherOperatingIncome   int,
 OperatingExpense  int
 )
END
GO