IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'AllowableDisAllowable')
BEGIN
   create table AllowableDisAllowable(

 Id   int identity(1,1) NOT NULL ,
 CompanyId int,
 YearId int,
 TrialBalanceId int,
 SelectionId int,
 IsAllowable bit
 )
END
GO




--------------------------------------- STORED PROCEDURE TO  GET ALLOWABLE AND DISALLOWABLE BY COMPANY ID, YEAR, ALLOWABLE-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId_Allowable]') IS nOT NULL
BEGIN
DROP procedure [dbo].usp_Get_Allowable_DisAllowable_By_CompanyId_YearId_Allowable
END
GO
CREATE procedure [dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId_Allowable](
@CompanyId int,
@YearId int,
@IsAllowable bit


)
AS

select  [dbo].[AllowableDisAllowable].Id, [dbo].[TrialBalance].Item ,[dbo].[TrialBalance].Debit,[dbo].[TrialBalance].Credit,SelectionId,IsAllowable from [dbo].[AllowableDisAllowable] inner join [dbo].[TrialBalance] on [dbo].[AllowableDisAllowable].TrialBalanceId=[dbo].[TrialBalance].Id where CompanyId=@CompanyId and @YearId=YearId and IsAllowable=@IsAllowable

GO


--------------------------------------- STORED PROCEDURE TO  GET ALLOWABLE AND DISALLOWABLE BY ID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Allowable_DisAllowable_By_Id]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Allowable_DisAllowable_By_Id]
END
GO
CREATE procedure [dbo].[usp_Get_Allowable_DisAllowable_By_Id](
@Id int


)
AS
 select * from [dbo].[AllowableDisAllowable] where Id=@Id
GO




--------------------------------------- STORED PROCEDURE TO  GET ALLOWABLE AND DISALLOWABLE BY TRIALBALANCEID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Allowable_DisAllowable_By_TrialBalanceId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Allowable_DisAllowable_By_TrialBalanceId]
END
GO
CREATE procedure [dbo].[usp_Get_Allowable_DisAllowable_By_TrialBalanceId](
@TrialBalanceId int


)
AS
 select * from [dbo].[AllowableDisAllowable] where TrialBalanceId=@TrialBalanceId
GO



--------------------------------------- STORED PROCEDURE TO  GET ALLOWABLE AND DISALLOWABLE BY COMPANYID AND YEARID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId]
END
GO
CREATE procedure [dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId](
@YearId int,
@CompanyId int

)
AS
select  [dbo].[AllowableDisAllowable].Id, [dbo].[TrialBalance].Item ,[dbo].[TrialBalance].Debit,[dbo].[TrialBalance].Credit,SelectionId,IsAllowable from [dbo].[AllowableDisAllowable] inner join [dbo].[TrialBalance] on [dbo].[AllowableDisAllowable].TrialBalanceId=[dbo].[TrialBalance].Id where CompanyId=@CompanyId and @YearId=YearId
GO




--------------------------------------- STORED PROCEDURE TO  DELETE ALLOWABLE DISALLOWABLE BY ID-----------------------------------------
IF OBJECT_ID('[dbo].[Delete_Allowable_DisAllowable_By_Id]') IS nOT NULL
BEGIN
DROP procedure [dbo].[Delete_Allowable_DisAllowable_By_Id]
END
GO
CREATE procedure [dbo].[Delete_Allowable_DisAllowable_By_Id](
@Id int
)
AS
delete from [dbo].[AllowableDisAllowable] where Id=@Id
GO








--------------------------------------- STORED PROCEDURE TO  INSERT INTO ALLOWABLE DISALLOWABLE-----------------------------------------
IF OBJECT_ID('[dbo].[Insert_Into_Allowable_DisAllowable]') IS nOT NULL
BEGIN
DROP procedure [dbo].[Insert_Into_Allowable_DisAllowable]
END
GO
CREATE procedure [dbo].[Insert_Into_Allowable_DisAllowable](
@CompanyId int,
@YearId int,
@TrialBalanceId int,
@SelectionId int,
@IsAllowable bit
)
AS
Insert into [dbo].[AllowableDisAllowable] (CompanyId,YearId,TrialBalanceId,SelectionId,IsAllowable) values(@CompanyId,@YearId,@TrialBalanceId,@SelectionId,@IsAllowable)
GO





IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'BroughtFoward')
BEGIN
   create table BroughtFoward(

 Id   int identity(1,1) NOT NULL ,
 CompanyId int,
 IsStarted bit,
 LossBf decimal,
 LossCf decimal,
 Accessible decimal,
 UnRelievedCf decimal,
 UnRelievedBf decimal
 )
END
GO




--------------------------------------- STORED PROCEDURE TO  GET BROUGHT FOWARD BY COMPANYID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Brought_Foward_By_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Brought_Foward_By_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_Brought_Foward_By_CompanyId](
@CompanyId int

)
AS
select  * from  [dbo].[BroughtFoward] where CompanyId=@CompanyId
GO









--------------------------------------- STORED PROCEDURE TO  INSERT INTO BROUGHT FOWARD TABLE-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Insert_Into_Brought_Foward]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_Into_Brought_Foward]
PRINT('OK')
END
GO

CREATE procedure [usp_Insert_Into_Brought_Foward](

@CompanyId int,
@IsStarted bit,
@LossBf decimal,
@LossCf decimal,
@Accessible decimal,
@UnRelievedCf decimal,
@UnRelievedBf decimal
)
AS


INSERT [dbo].[BroughtFoward](
CompanyId,
IsStarted,
LossBf,
LossCf,
Accessible,
UnRelievedCf,
UnRelievedBf
)
VALUES(
@CompanyId,
@IsStarted,
@LossBf,
@LossCf,
@Accessible,
@UnRelievedCf,
@UnRelievedBf
)
GO



--------------------------------------- STORED PROCEDURE TO  UPDATE ACCESSIBLE AND UNRELIEVED CF FROM INCOME TAX-----------------------------------------


IF OBJECT_ID('[dbo].[usp_Accessible_Cf_By_Income_Tax]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Accessible_Cf_By_Income_Tax]
PRINT('OK')
END
GO

CREATE procedure [usp_Accessible_Cf_By_Income_Tax](
@CompanyId int,
@LossCf decimal,
@UnRelievedCf decimal,
@Accessible decimal
)
AS
Update [dbo].[BroughtFoward] set LossCf=@LossCf, UnRelievedCf=@UnRelievedCf ,Accessible=@Accessible where CompanyId=@CompanyId
GO









--------------------------------------- STORED PROCEDURE TO  UPDATE BR and UNRELEIEVD BF FROM BACKGROUND JOB-----------------------------------------


IF OBJECT_ID('[dbo].[usp_Update_lossBf_Background]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Update_lossBf_Background]
PRINT('OK')
END
GO

CREATE procedure [usp_Update_lossBf_Background](

@CompanyId int

)
AS
declare @lossCfValue decimal
declare @UnRelievedCf decimal
select @lossCfValue=LossCf, @UnRelievedCf=UnRelievedCf from [dbo].[BroughtFoward] where CompanyId=@CompanyId
Update [dbo].[BroughtFoward] set LossBf=@lossCfValue ,LossCf=null, UnRelievedBf=@UnRelievedCf,UnRelievedCf=null ,Accessible=null where CompanyId=@CompanyId
GO
