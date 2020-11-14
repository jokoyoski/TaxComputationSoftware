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



IF OBJECT_ID('N[dbo].[usp_Insert_Capital_Allowance]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_Capital_Allowance]
END
GO
CREATE procedure usp_Insert_Capital_Allowance(
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

IF OBJECT_ID('N[dbo].[usp_Get_Capital_Allowance_By_CompanyId_Year]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_Year]
END
GO
CREATE procedure usp_Get_Capital_Allowance_By_CompanyId_Year(
@AssetId int,
@CompanyId int

)
AS

select TaxYear,OpeningResidue,Addition,Disposal,Initial,Annual,Total,ClosingResidue,YearsToGo from [dbo].[CapitalAllowance] where CompanyId=@CompanyId AND AssetId=@AssetId