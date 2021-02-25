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
    @CompanyId varchar(20),
    @TrialBalanceId int,
    @YearId varchar(20),
    @TypeValue varchar(20)

)
AS

INSERT [dbo].[ProfitsAndLoss]
(
   Pick,
    CompanyId ,
    TrialBalanceId,
    YearId ,
    TypeValue
   
)
VALUES
(    @Pick,
    @CompanyId,
    @TrialBalanceId,
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












--------------------------------------- STORED PROCEDURE TO  CREATE PROFIT AND LOSS RECORD -----------------------------------------


if NOT EXISTS(SELECT 1 FROM sysobjects where type='U' and name ='ProfitAndLossRecord')
BEGIN
create table ProfitAndLossRecord(

 Id   int identity(1,1) NOT NULL ,
 CompanyId int ,
 ProfitAndLoss decimal,
 YearId int

 )

END
GO


-------------------------------------- STORED PROCEDURE TO  GET PROFIT AND LOS LOSS BY COMPANY ID AND YEAR ID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Profit_And_Loss_By_CompanyId_YearId]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].usp_Get_Profit_And_Loss_By_CompanyId_YearId
END
GO
CREATE PROCEDURE [dbo].usp_Get_Profit_And_Loss_By_CompanyId_YearId(
    @CompanyId int,@YearId int)
   
AS
SELECT *
FROM [dbo].[ProfitAndLossRecord]
WHERE CompanyId=@CompanyId AND YearId=@YearId
GO








-------------------------------------- STORED PROCEDURE TO  INSERT INTO Profit and loss record  TAX TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_Profit_And_Loss_Record_Table]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Profit_And_Loss_Record_Table]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_Profit_And_Loss_Record_Table](
    @Id int,
    @CompanyId int,
    @YearId int,
    @ProfitAndLoss varchar(50)
)
AS
if exists (select * from ProfitAndLossRecord where CompanyId=@CompanyId  and YearId =@YearId)
begin
 update [dbo].[ProfitAndLossRecord] set ProfitAndLoss=@ProfitAndLoss
end
else
INSERT [dbo].[ProfitAndLossRecord]
(
    CompanyId,
    YearId,
    ProfitAndLoss
)
VALUES
(
    @CompanyId,
    @YearId,
    @ProfitAndLoss
   
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO