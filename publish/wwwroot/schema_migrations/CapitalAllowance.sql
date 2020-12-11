IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'CapitalAllowance')
BEGIN
   create table CapitalAllowance(

 Id   int identity(1,1) NOT NULL ,
 TaxYear   varchar(10),
 OpeningResidue  varchar(20),
 Addition   varchar(20),
 Disposal   varchar(30),
 Initial  varchar (30),
 Annual    varchar(20),
 Total    varchar(20),
 ClosingResidue varchar(20),
 YearsToGo varchar(20),
 CompanyId int,
 AssetId  int
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
@OpeningResidue  varchar(20),
@Addition   varchar(20),
@Disposal   varchar(30),
@Initial  varchar (30),
@Annual    varchar(20),
@Total    varchar(20),
@ClosingResidue varchar(20),
@YearsToGo varchar(20)
)
AS

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
 AssetId
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
 @AssetId
)
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

select TaxYear,OpeningResidue,Addition,Disposal,Initial,Annual,Total,ClosingResidue,YearsToGo from [dbo].[CapitalAllowance] where CompanyId=@CompanyId AND AssetId=@AssetId
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

select TaxYear,OpeningResidue,Addition,Disposal,Initial,Annual,Total,ClosingResidue,YearsToGo from [dbo].[CapitalAllowance] where CompanyId=@CompanyId AND AssetId=@AssetId AND TaxYear=@Year
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
@Addition varchar(20),
@Annual varchar(20),
@Initial varchar(20),
@Total  varchar(20),
@YearsToGo varchar(20),
@CompanyId int,
@AssetId int

)
AS

UPDATE [dbo].[CapitalAllowance]
set OpeningResidue=@OpeningResidue, ClosingResidue=@ClosingResidue ,Addition=@Addition,Annual=@Annual, Initial=@Initial,Total=@Total,YearsToGo=@YearsToGo   WHERE CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear

GO