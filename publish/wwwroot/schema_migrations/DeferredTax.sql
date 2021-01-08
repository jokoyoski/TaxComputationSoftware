IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'DeferredFairValueGain')
BEGIN
   create table DeferredFairValueGain(

 Id   int identity(1,1) NOT NULL ,
 CompanyId int,
 YearId int,
 TrialBalanceId int,
 SelectionId int,
 DeferredFairValueGainId int
 )
END
GO



--------------------------------------- STORED PROCEDURE TO  GET DEFERRED FAIR VALUE GAIN  BY COMPANY ID, YEAR-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Deferred_Fair_Value_Gain_By_CompanyId_Year]') IS nOT NULL
BEGIN
DROP procedure [dbo].usp_Get_Deferred_Fair_Value_Gain_By_CompanyId_Year
END
GO
CREATE procedure [dbo].[usp_Get_Deferred_Fair_Value_Gain_By_CompanyId_Year](
@CompanyId int,
@YearId int
)
AS

select  [dbo].[DeferredFairValueGain].Id, [dbo].[TrialBalance].Item ,[dbo].[TrialBalance].Debit,[dbo].[TrialBalance].Credit,SelectionId from [dbo].[DeferredFairValueGain] inner join [dbo].[TrialBalance] on [dbo].[DeferredFairValueGain].TrialBalanceId=[dbo].[TrialBalance].Id where CompanyId=@CompanyId and @YearId=YearId

GO







--------------------------------------- STORED PROCEDURE TO  INSERT INTO DEFERRED TAX TABLE-----------------------------------------
IF OBJECT_ID('[dbo].[Insert_Into_Deferred_Tax]') IS nOT NULL
BEGIN
DROP procedure [dbo].[Insert_Into_Deferred_Tax]
END
GO
CREATE procedure [dbo].[Insert_Into_Deferred_Tax](
@CompanyId int,
@YearId int,
@TrialBalanceId int,
@SelectionId int

)
AS
Insert into [dbo].[DeferredFairValueGain] (CompanyId,YearId,TrialBalanceId,SelectionId) values(@CompanyId,@YearId,@TrialBalanceId,@SelectionId)
GO






--------------------------------------- STORED PROCEDURE TO  DELETE FAIR VALUE GAIN BY TRIALBALANCEID-----------------------------------------
IF OBJECT_ID('[dbo].[Delete_Fair_Gain_By_TrialBalanceId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[Delete_Fair_Gain_By_TrialBalanceId]
END
GO
CREATE procedure [dbo].[Delete_Fair_Gain_By_TrialBalanceId](
@TrialBalanceId int
)
AS
delete from [dbo].[DeferredFairValueGain] where TrialBalanceId=@TrialBalanceId
GO







IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'DeferredTaxBroughtFoward')
BEGIN
   create table DeferredTaxBroughtFoward(

 Id   int identity(1,1) NOT NULL ,
 CompanyId int,
 DeferredTaxCarriedFoward decimal,
 YearId int
 )
END
GO




--------------------------------------- STORED PROCEDURE TO  GET  DEFRRED TAX BROUGHT FOWARD BY COMPANYID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Deferred_Tax_Brought_Foward_By_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Deferred_Tax_Brought_Foward_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_Deferred_Tax_Brought_Foward_By_CompanyId](
@CompanyId int

)
AS
select  * from  [dbo].[DeferredTaxBroughtFoward] where CompanyId=@CompanyId
GO












--------------------------------------- STORED PROCEDURE TO  INSERT INTO DEFERRED TAX BROUGHT FOWARD TABLE-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Insert_Into_DeferredTax_Brought_Foward]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_Into_DeferredTax_Brought_Foward]
PRINT('OK')
END
GO

CREATE procedure [usp_Insert_Into_DeferredTax_Brought_Foward](

@CompanyId int,
@DeferredTaxCarriedFoward decimal,
@YearId int
)
AS


INSERT [dbo].[DeferredTaxBroughtFoward](
CompanyId,
DeferredTaxCarriedFoward,
YearId 
)
VALUES(
@CompanyId,
@DeferredTaxCarriedFoward,
@YearId 
)
GO
