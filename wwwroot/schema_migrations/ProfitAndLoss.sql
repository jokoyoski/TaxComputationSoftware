--------------------------------------- STORED PROCEDURE TO  CRAETE PROFITS AND LOSS-----------------------------------------


IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'ProfitsAndLoss')
BEGIN
   create table ProfitsAndLoss(

 Id   int identity(1,1) NOT NULL ,
 Pick   varchar(20),
 CompanyId   varchar(20),
 TrialBalanceId  varchar(20),
 YearId varchar(20),
 TypeValue varchar(20)
)
END
GO



--------------------------------------- STORED PROCEDURE TO  INSERT INTO PROFITS AND LOSS-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Insert_Profits_And_Loss]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Profits_And_Loss]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_Profits_And_Loss](
    @Id int OUTPUT,
    @Pick varchar(10),
    @TrialBalanceId int,
    @YearId varchar(20),
    @CompanyId varchar(20),
    @TypeValue varchar(20)

)
AS

INSERT [dbo].[ProfitsAndLoss]
(
    Pick,
    TrialBalanceId,
    YearId,
    CompanyId,
    TypeValue
   
)
VALUES
(
    @Pick,
    @TrialBalanceId,
    @CompanyId,
    @YearId,
    @TypeValue
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO


--------------------------------------- STORED PROCEDURE TO  GET PROFITS AND LOSS BY TYPE-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Profits_And_Loss_By_Type]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Profits_And_Loss_By_Type]
END
GO
CREATE procedure [dbo].[usp_Get_Profits_And_Loss_By_Type](
@TypeValue varchar(20),
@CompanyId int,
@YearId int
)
AS
SELECT  Debit,Credit,Pick FROM [dbo].[ProfitsAndLoss] inner join [dbo].[TrialBalance]  
on [dbo].[ProfitsAndLoss].TrialBalanceId =[dbo].[TrialBalance].Id  
where YearId=@YearId and CompanyId=@CompanyId and TypeValue=@TypeValue
GO





--------------------------------------- STORED PROCEDURE TO  DELETE PROFITS AND LOSS BY TRIALBALANCEID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Delete_Profits_And_Loss_By_TrialBalanceId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Delete_Profits_And_Loss_By_TrialBalanceId]
END
GO
CREATE procedure [dbo].[usp_Delete_Profits_And_Loss_By_TrialBalanceId](
@TrialBalanceId varchar(20)
)
AS
delete  from [dbo].[ProfitsAndLoss] where TrialBalanceId=@TrialBalanceId
GO

