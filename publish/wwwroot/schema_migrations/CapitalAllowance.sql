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
<<<<<<< HEAD
GO
<<<<<<< HEAD
=======
GO
>>>>>>> 2860c1f490c9ea7bbea7c9b73660e82b40328612
=======
>>>>>>> 1426fd094a857e6b88a91df7198e2e70c47629fb
