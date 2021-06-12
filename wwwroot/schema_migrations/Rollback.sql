




IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'OldCapitalAllowanceSummary')
BEGIN
   create table OldCapitalAllowanceSummary(
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







IF OBJECT_ID('[dbo].[usp_Insert_Old_Capital_Allowance_Summary]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_Old_Capital_Allowance_Summary]
PRINT('OK')
END
GO
CREATE procedure [usp_Insert_Old_Capital_Allowance_Summary](
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

BEGIN
INSERT [dbo].[OldCapitalAllowanceSummary](
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


IF OBJECT_ID('[dbo].[usp_Get_Old_Capital_Allowance_Summary_By_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Old_Capital_Allowance_Summary_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_Old_Capital_Allowance_Summary_By_CompanyId](
@CompanyId int
)
AS

select  * from [dbo].[OldCapitalAllowanceSummary] where CompanyId=@CompanyId 
GO

















IF OBJECT_ID('[dbo].[usp_Get_Last_Financial_Year]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Last_Financial_Year]
END
GO
CREATE procedure [dbo].[usp_Get_Last_Financial_Year](
@CompanyId int
)
AS

select  Top 1 *  from [dbo].[FinancialYear] where CompanyId=@CompanyId  order by Id desc
GO




IF OBJECT_ID('[dbo].[usp_Delete_Last_Financial_Year]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Delete_Last_Financial_Year]
END
GO
CREATE procedure [dbo].[usp_Delete_Last_Financial_Year](
@Id int
)
AS

delete from [dbo].[FinancialYear] where Id=@Id
GO














IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'OldCapitalAllowance')
BEGIN
   create table OldCapitalAllowance(

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






iF OBJECT_ID('[dbo].[usp_Insert_Old_Capital_Allowance]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Old_Capital_Allowance]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_Old_Capital_Allowance](
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

INSERT [dbo].[OldCapitalAllowance](
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
GO



IF OBJECT_ID('[dbo].[usp_Get_Old_Capital_Allowance_By_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Old_Capital_Allowance_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_Old_Capital_Allowance_By_CompanyId](
@CompanyId int
)
AS

select  * from [dbo].[OldCapitalAllowance] where CompanyId=@CompanyId 
GO











IF OBJECT_ID('[dbo].[usp_Delete_IncomeTax_Brought_Foward]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Delete_IncomeTax_Brought_Foward]
END
GO
CREATE procedure [dbo].[usp_Delete_IncomeTax_Brought_Foward](
@Id int
)
AS

delete from [dbo].[IncomeTaxBroughtFoward] where YearId=@Id
GO








IF OBJECT_ID('[dbo].[usp_Delete_Deferred_Tax_Brought_Foward]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Delete_Deferred_Tax_Brought_Foward]
END
GO
CREATE procedure [dbo].[usp_Delete_Deferred_Tax_Brought_Foward](
@Id int
)
AS

delete from [dbo].[DeferredTaxBroughtFoward] where YearId=@Id
GO








IF OBJECT_ID('[dbo].[usp_Delete_Capital_Allowance_Summary]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Delete_Capital_Allowance_Summary]
END
GO
CREATE procedure [dbo].[usp_Delete_Capital_Allowance_Summary](
@Id int
)
AS

delete from [dbo].[CapitalAllowance] where CompanyId=@Id
delete from [dbo].[CapitalAllowanceSummary] where CompanyId=@Id
delete from [dbo].[ArchivedCapitalAllowance] where CompanyId=@Id
GO





IF OBJECT_ID('[dbo].[usp_Delete_Old_Capital_Allowance_Summary]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Delete_Old_Capital_Allowance_Summary]
END
GO
CREATE procedure [dbo].[usp_Delete_Old_Capital_Allowance_Summary](
@Id int
)
AS

delete from [dbo].[OldCapitalAllowance] where CompanyId=@Id
delete from [dbo].[OldCapitalAllowanceSummary] where CompanyId=@Id
delete from [dbo].[OldArchivedCapitalAllowance] where CompanyId=@Id
GO























IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'OldArchivedCapitalAllowance')
BEGIN
   create table OldArchivedCapitalAllowance(

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






iF OBJECT_ID('[dbo].[usp_Insert_Old_Archived_Capital_Allowance]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Old_Archived_Capital_Allowance]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_Old_Archived_Capital_Allowance](
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

INSERT [dbo].[OldArchivedCapitalAllowance](
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
GO



IF OBJECT_ID('[dbo].[usp_Get_Old_Archived_Capital_Allowance_By_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Old_Archived_Capital_Allowance_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_Old_Archived_Capital_Allowance_By_CompanyId](
@CompanyId int
)
AS

select  * from [dbo].[OldArchivedCapitalAllowance] where CompanyId=@CompanyId 
GO







IF OBJECT_ID('[dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId](
@CompanyId int
)
AS

select  * from [dbo].[ArchivedCapitalAllowance] where CompanyId=@CompanyId 
GO





IF OBJECT_ID('[dbo].[usp_Get_Capital_Allowance_By_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId](
@CompanyId int
)
AS

select  * from [dbo].[CapitalAllowance] where CompanyId=@CompanyId 
GO





IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'RollBackYear')
BEGIN
   create table RollBackYear(
 Id   int identity(1,1) NOT NULL ,
 YearId int,
 CompanyId int
 )
END
GO



IF OBJECT_ID('[dbo].[usp_Get_RollBack_Year_By_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_RollBack_Year_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_RollBack_Year_By_CompanyId](
@CompanyId int
)
AS
select  * from [dbo].[RollBackYear] where CompanyId=@CompanyId 
GO


IF OBJECT_ID('[dbo].[usp_Insert_RollBack_Year_By_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_RollBack_Year_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Insert_RollBack_Year_By_CompanyId](
@CompanyId int,
@YearId int
)
AS
if exists (select  * from [dbo].[RollBackYear] where CompanyId=@CompanyId)
begin
update RollBackYear set YearId=@YearId ,CompanyId=@CompanyId
end
else
insert into RollBackYear (CompanyId,YearId) values(@CompanyId,@YearId)
GO
