IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'CapitalAllowance')
BEGIN
   create table CapitalAllowance(

 Id   int identity(1,1) NOT NULL ,
 TaxYear   varchar(10),
 NumberOfYearsAvailable int,
 OpeningResidue  varchar(20),
 Addition   varchar(20),
 Disposal   varchar(30),
 Initial  varchar (30),
 Annual    varchar(20),
 Channel      varchar(10),
 Total    varchar(20),
 ClosingResidue varchar(20),
 YearsToGo varchar(20),
 CompanyId int,
 AssetId  int,
 CompanyCode varchar(20)
 )
END
GO



     --------------------------------------- STORED PROCEDURE TO  INSERT CAPITAL ALLOWANCE-----------------------------------------



IF OBJECT_ID('[dbo].[usp_Insert_Capital_Allowance]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_Capital_Allowance]
PRINT('OK')
END
GO

CREATE procedure [usp_Insert_Capital_Allowance](
@AssetId int,
@CompanyId int,
@TaxYear   varchar(10),
@NumberOfYearsAvailable int,
@OpeningResidue  varchar(20),
@Channel      varchar(10),
@Addition   varchar(20),
@Disposal   varchar(30),
@Initial  varchar (30),
@Annual    varchar(20),
@Total    varchar(20),
@ClosingResidue varchar(20),
@YearsToGo varchar(20),
@CompanyCode varchar(20)
)
AS

IF   exists (select * from [dbo].[CapitalAllowance] where CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear )
BEGIN
update [dbo].[CapitalAllowance] set TaxYear=@TaxYear,OpeningResidue=@OpeningResidue,Addition=@Addition,Disposal=@Disposal,Initial=@Initial,
Annual=@Annual,NumberOfYearsAvailable=@NumberOfYearsAvailable,Total=@Total,ClosingResidue=@ClosingResidue,YearsToGo=@YearsToGo,CompanyId=@CompanyId,
AssetId=@AssetId , CompanyCode=@CompanyCode, Channel=@Channel
where CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear
END
ELSE
BEGIN
INSERT [dbo].[CapitalAllowance](
 TaxYear,
 OpeningResidue,
 Addition,
 Disposal,
 Initial,
 Annual,
 Total,
 ClosingResidue,
 YearsToGo,
 CompanyId,
 AssetId,
 CompanyCode,
 NumberOfYearsAvailable,
 Channel
)
VALUES(
 @TaxYear,
 @OpeningResidue,
 @Addition,
 @Disposal,
 @Initial,
 @Annual,
 @Total,
 @ClosingResidue,
 @YearsToGo,
 @CompanyId,
 @AssetId,
 @CompanyCode,
 @NumberOfYearsAvailable,
 @Channel
)
END
GO

--------------------------------------- STORED PROCEDURE TO  GET CAPITAL ALLOWANCE-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId]
END
GO
CREATE procedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId](
@AssetId int,
@CompanyId int

)
AS

select  [dbo].[CapitalAllowance].Id,[dbo].[FinancialYear].Name As TaxYear,[dbo].[FinancialYear].Id As YearId,OpeningResidue,Addition,Disposal,Initial,Annual,Total,ClosingResidue,YearsToGo,NumberOfYearsAvailable,CompanyCode,Channel,[dbo].[CapitalAllowance].CompanyId,AssetId from [dbo].[CapitalAllowance] inner join [dbo].[FinancialYear]on [dbo].[CapitalAllowance].TaxYear=[FinancialYear].Id  where [dbo].[CapitalAllowance].CompanyId=@CompanyId AND AssetId=@AssetId
GO


--------------------------------------- STORED PROCEDURE TO  GET CAPITAL aALLOWANCE BY ASSET ,COMPANY AND YEAR-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]
END
GO
CREATE procedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId_And_Year](
@AssetId int,
@CompanyId int,
@Year varchar(20)
)
AS

select  Id,TaxYear,OpeningResidue,Addition,Disposal,Initial,Annual,Total,ClosingResidue,YearsToGo,NumberOfYearsAvailable,CompanyCode,Channel,CompanyId,AssetId from [dbo].[CapitalAllowance] where CompanyId=@CompanyId AND AssetId=@AssetId AND TaxYear=@Year
GO




--------------------------------------- STORED PROCEDURE TO  GET UPDATE CAPITAL ALLOWANCE BY FIXED ASSET OR BALANCING ADJUSTMENT-----------------------------------------

IF OBJECT_ID('[dbo].[Update_Capital_Allowance_From_Fixed_Asset_Or_Balancing_Adjustment]') IS nOT NULL
BEGIN
DROP procedure [dbo].[Update_Capital_Allowance_From_Fixed_Asset_Or_Balancing_Adjustment]
END
GO
CREATE procedure [dbo].[Update_Capital_Allowance_From_Fixed_Asset_Or_Balancing_Adjustment](
@TaxYear int,
@OpeningResidue varchar(20),
@ClosingResidue varchar(20),
@Channel varchar(10),
@Addition varchar(20),
@Disposal varchar(30),
@Annual varchar(20),
@NumberOfYearsAvailable int,
@Initial varchar(20),
@Total  varchar(20),
@YearsToGo varchar(20),
@CompanyId int,
@AssetId int,
@CompanyCode varchar(20)

)
AS

UPDATE [dbo].[CapitalAllowance]
set OpeningResidue=@OpeningResidue, Disposal=@Disposal,CompanyCode=@CompanyCode,ClosingResidue=@ClosingResidue ,NumberOfYearsAvailable=@NumberOfYearsAvailable,Addition=@Addition,Annual=@Annual, Initial=@Initial,Total=@Total,YearsToGo=@YearsToGo ,Channel=@Channel  WHERE CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear

GO






--------------------------------------- STORED PROCEDURE TO  CREATE ARCHIVED CAPITAL ALLOWANCE-----------------------------------------



IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'ArchivedCapitalAllowance')
BEGIN
   create table ArchivedCapitalAllowance(

 Id   int identity(1,1) NOT NULL ,
 TaxYear   varchar(10),
 NumberOfYearsAvailable int,
 OpeningResidue  varchar(20),
 Addition   varchar(20),
 Disposal   varchar(30),
 Initial  varchar (30),
 Annual    varchar(20),
 Channel      varchar(10),
 Total    varchar(20),
 ClosingResidue varchar(20),
 YearsToGo varchar(20),
 CompanyId int,
 AssetId  int,
 CompanyCode varchar(20)
 )
END
GO






     --------------------------------------- STORED PROCEDURE TO  INSERT  INTO ARCHIVED CAPITAL ALLOWANCE-----------------------------------------



IF OBJECT_ID('[dbo].[usp_Insert_Archived_Capital_Allowance]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_Archived_Capital_Allowance]
PRINT('OK')
END
GO

CREATE procedure [usp_Insert_Archived_Capital_Allowance](
@AssetId int,
@CompanyId int,
@TaxYear   varchar(10),
@NumberOfYearsAvailable int,
@OpeningResidue  varchar(20),
@Channel      varchar(10),
@Addition   varchar(20),
@Disposal   varchar(30),
@Initial  varchar (30),
@Annual    varchar(20),
@Total    varchar(20),
@ClosingResidue varchar(20),
@YearsToGo varchar(20),
@CompanyCode varchar(20)
)
AS

IF   exists (select * from [dbo].[ArchivedCapitalAllowance] where CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear )
BEGIN
update [dbo].[ArchivedCapitalAllowance] set TaxYear=@TaxYear,OpeningResidue=@OpeningResidue,Addition=@Addition,Disposal=@Disposal,Initial=@Initial,
Annual=@Annual,NumberOfYearsAvailable=@NumberOfYearsAvailable,Total=@Total,ClosingResidue=@ClosingResidue,YearsToGo=@YearsToGo,CompanyId=@CompanyId,
AssetId=@AssetId , CompanyCode=@CompanyCode, Channel=@Channel
where CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear
END
ELSE
BEGIN
INSERT [dbo].[ArchivedCapitalAllowance](
 TaxYear,
 OpeningResidue,
 Addition,
 Disposal,
 Initial,
 Annual,
 Total,
 ClosingResidue,
 YearsToGo,
 CompanyId,
 AssetId,
 CompanyCode,
 NumberOfYearsAvailable,
 Channel
)
VALUES(
 @TaxYear,
 @OpeningResidue,
 @Addition,
 @Disposal,
 @Initial,
 @Annual,
 @Total,
 @ClosingResidue,
 @YearsToGo,
 @CompanyId,
 @AssetId,
 @CompanyCode,
 @NumberOfYearsAvailable,
 @Channel
)
END
GO



--------------------------------------- STORED PROCEDURE TO  GET FROM ARCHIVED  CAPITAL aALLOWANCE BY ASSET ,COMPANY AND YEAR-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]
END
GO
CREATE procedure [dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId_And_AssetId_And_Year](
@AssetId int,
@CompanyId int,
@Year varchar(20)
)
AS

select  TaxYear,OpeningResidue,Addition,Disposal,Initial,Annual,Total,ClosingResidue,YearsToGo,NumberOfYearsAvailable,CompanyCode,Channel,CompanyId,AssetId from [dbo].[ArchivedCapitalAllowance] where CompanyId=@CompanyId AND AssetId=@AssetId AND TaxYear=@Year
GO

--------------------------------------- STORED PROCEDURE TO  DELETE CAPITALALLOWANCE BY ASSETID YEARID COMPANYID-----------------------------------------
--------------------------------------- STORED PROCEDURE TO  DELETE CAPITALALLOWANCE BY ASSETID YEARID COMPANYID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Delete_Capital_Allowance_By_Company_Id_YearId_Asset_Id]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Delete_Capital_Allowance_By_Company_Id_YearId_Asset_Id]
END
GO
CREATE procedure [dbo].[usp_Delete_Capital_Allowance_By_Company_Id_YearId_Asset_Id](
@AssetId int,
@Year int,
@CompanyId int
)
AS
declare @FixedAssetId as int
select @FixedAssetId=Id from [dbo].[FixedAsset] where AssetId=@AssetId and YearId=@Year and CompanyId=@CompanyId
UPDATE [dbo].[TrialBalance] SET MappedTo = null,IsCheck=0,IsRemoved=0 WHERE Id IN (SELECT TrialBalanceId FROM [dbo].[TrialBalanceMapping] where ModuleId=@FixedAssetId);
delete from [dbo].[TrialBalanceMapping] where ModuleId=@FixedAssetId
Delete from [dbo].[BalancingAdjustmentYearBought] where AssestId=@AssetId and YearBought=@Year and CompanyId=@CompanyId
Delete from [dbo].[ArchivedCapitalAllowance] where AssetId=@AssetId and TaxYear=@Year and CompanyId=@CompanyId
Delete from [dbo].[CapitalAllowance] where AssetId=@AssetId and TaxYear=@Year and CompanyId=@CompanyId
Delete from [dbo].[FixedAsset] where AssetId=@AssetId and YearId=@Year and CompanyId=@CompanyId
GO

--------------------------------------- STORED PROCEDURE TO  CREATE CAPITAL ALLOWANCE SUMMARY-----------------------------------------


IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'CapitalAllowanceSummary')
BEGIN
   create table CapitalAllowanceSummary(
 Id   int identity(1,1) NOT NULL ,
 OpeningResidue  varchar(20),
 Addition   varchar(20),
 Disposal   varchar(30),
 Initial  varchar (30),
 Annual    varchar(20),
 Total    varchar(20),
 ClosingResidue varchar(20),
 CompanyId int,
 AssetId  int
 )
END
GO


--------------------------------------- STORED PROCEDURE TO  UPDATE CAPITAL ALLOWANCE SUMMARY-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_Capital_Allowance_Summary]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_Capital_Allowance_Summary]
PRINT('OK')
END
GO
CREATE procedure [usp_Insert_Capital_Allowance_Summary](
 @OpeningResidue  varchar(20),
 @Addition   varchar(20),
 @Disposal   varchar(30),
 @Initial  varchar (30),
 @Annual    varchar(20),
 @Total    varchar(20),
 @ClosingResidue varchar(20),
 @CompanyId int,
 @AssetId  int
)
AS

IF   exists (select * from [dbo].[CapitalAllowanceSummary] where CompanyId=@CompanyId and AssetId=@AssetId)
BEGIN
update [dbo].[CapitalAllowanceSummary] set OpeningResidue=@OpeningResidue,Addition=@Addition,Disposal=@Disposal,Initial=@Initial,
Annual=@Annual,Total=@Total,ClosingResidue=@ClosingResidue,CompanyId=@CompanyId,
AssetId=@AssetId
where CompanyId=@CompanyId and AssetId=@AssetId
END
ELSE
BEGIN
INSERT [dbo].[CapitalAllowanceSummary](
 OpeningResidue,
 Addition ,
 Disposal,
 Initial,
 Annual,
 Total,
 ClosingResidue,
 CompanyId,
 AssetId
)
VALUES(
 @OpeningResidue,
 @Addition ,
 @Disposal,
 @Initial,
 @Annual,
 @Total,
 @ClosingResidue,
 @CompanyId,
 @AssetId
)
END
GO





--------------------------------------- STORED PROCEDURE TO  GET CAPITAL ALLOWANCE BY ID-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Get_Capital_Allowance_By_Id]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Capital_Allowance_By_Id]
END
GO
CREATE procedure [dbo].[usp_Get_Capital_Allowance_By_Id](
@CapitalAllowanceId int
)
AS
select * from [dbo].[CapitalAllowance] where Id=@CapitalAllowanceId
GO


-------------------------------------- STORED PROCEDURE TO  GET CAPITAL ALLOWANCE SUMMARY BY COMPANYID-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Get_Capital_Allowance_Summary_By_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Capital_Allowance_Summary_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_Capital_Allowance_Summary_By_CompanyId](
@CompanyId int
)
AS
select [dbo].[AssetMapping].AssetName as AssetName,OpeningResidue,Addition,Disposal,[dbo].[CapitalAllowanceSummary].Initial,[dbo].[CapitalAllowanceSummary].Annual,Total,ClosingResidue from [dbo].[CapitalAllowanceSummary]  inner join [dbo].[AssetMapping] on [dbo].[CapitalAllowanceSummary].AssetId=[dbo].[AssetMapping].Id where CompanyId=@CompanyId
GO

-------------------------------------- STORED PROCEDURE TO  DELETE CAPITALALLOWANCE BY ID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Delete_Capital_Allowance_Summary_By_AssetId_Commpany_Id]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Delete_Capital_Allowance_Summary_By_AssetId_Commpany_Id]
END
GO
CREATE procedure [dbo].[usp_Delete_Capital_Allowance_Summary_By_AssetId_Commpany_Id](
@CompanyId int,
@AssetId int
)
AS

Delete from [dbo].[CapitalAllowanceSummary] where AssetId=@AssetId and CompanyId=@CompanyId
GO





--------------------------------------- STORED PROCEDURE TO  GET UPDATE CAPITAL ALLOWANCE BY CHANNEL-----------------------------------------

IF OBJECT_ID('[dbo].[Update_Capital_Allowance_By_Channel]') IS nOT NULL
BEGIN
DROP procedure [dbo].[Update_Capital_Allowance_By_Channel]
END
GO
CREATE procedure [dbo].[Update_Capital_Allowance_By_Channel](
@Id int,
@Channel varchar(10)
)
AS

UPDATE [dbo].[CapitalAllowance]
set Channel=@Channel  WHERE Id=@Id

GO







--------------------------------------- STORED PROCEDURE TO  GET UPDATE  ARCHIVED CAPITAL ALLOWANCE BY COMPANYID, ASSETID,TAXYEAR  FRO CHANNEL-----------------------------------------

IF OBJECT_ID('[dbo].[Update_Archived_Capital_Allowance_By_Channel]') IS nOT NULL
BEGIN
DROP procedure [dbo].[Update_Archived_Capital_Allowance_By_Channel]
END
GO
CREATE procedure [dbo].[Update_Archived_Capital_Allowance_By_Channel](
@CompanyId int,
@AssetId int,
@Channel varchar(10),
@TaxYear varchar (6)
)
AS

UPDATE [dbo].[ArchivedCapitalAllowance]
set Channel=@Channel  WHERE CompanyId=@CompanyId  and AssetId=@AssetId and  TaxYear=@TaxYear
GO




