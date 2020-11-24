﻿IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'ProfitAndLoss')
BEGIN
   create table ProfitAndLoss(

 Id   int identity(1,1) NOT NULL ,
 Revenue   varchar(20),
 CostOfSales   varchar(20),
 OtherOperatingIncome   varchar(20),
 OperatingExpenses  varchar(20),
 YearId varchar(20),
 CompanyId int,
 OtherOperatingGainOrLoss varchar(20)
 )
END
GO



--------------------------------------- STORED PROCEDURE TO  GET PROFIT AND LOSS BY COMPANYiD AND YEARID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Profit_And_Loss_By_YearId_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Profit_And_Loss_By_YearId_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Get_Profit_And_Loss_By_YearId_CompanyId](
@YearId varchar(20),
@CompanyId int
)
AS
select * from [dbo].[ProfitAndLoss] where CompanyId=@CompanyId AND YearId=@YearId
GO




--------------------------------------- STORED PROCEDURE TO  UPDATE PROFIT AND LOSS BY COMPANYiD AND YEARID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Update_Profit_And_Loss_By_YearId_CompanyId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Update_Profit_And_Loss_By_YearId_CompanyId]
END
GO
CREATE procedure [dbo].[usp_Update_Profit_And_Loss_By_YearId_CompanyId](
@YearId varchar(20),
@CompanyId int,
@Type varchar(30),
@Amount varchar (20)
)
AS

IF not EXISTS (SELECT * FROM [dbo].[ProfitAndLoss] where YearId=@YearId and CompanyId=@CompanyId)
begin

if @Type='Revenue'
begin

INSERT [dbo].[ProfitAndLoss](
 Revenue,
 CostOfSales,
 OtherOperatingIncome,
 OperatingExpenses,
 YearId,
 CompanyId,
 OtherOperatingGainOrLoss
)
VALUES(
 @Amount,
 '0',
 '0',
 '0',
 @YearId,
 @CompanyId,
 '0'
)
end


if @Type='CostOfSales'
begin

INSERT [dbo].[ProfitAndLoss](
 Revenue,
 CostOfSales,
 OtherOperatingIncome,
 OperatingExpenses,
 YearId,
 CompanyId,
 OtherOperatingGainOrLoss
)
VALUES(
 '0',
 @Amount,
 '0',
 '0',
 @YearId,
 @CompanyId,
 '0'
)
end




if @Type='OtherOperatingIncome'
begin

INSERT [dbo].[ProfitAndLoss](
 Revenue,
 CostOfSales,
 OtherOperatingIncome,
 OperatingExpenses,
 YearId,
 CompanyId,
 OtherOperatingGainOrLoss
)
VALUES(
 '0',
 '0',
 @Amount,
 '0',
 @YearId,
 @CompanyId,
 '0'
)
end



if @Type='OperatingExpenses'
begin

INSERT [dbo].[ProfitAndLoss](
 Revenue,
 CostOfSales,
 OtherOperatingIncome,
 OperatingExpenses,
 YearId,
 CompanyId,
 OtherOperatingGainOrLoss
)
VALUES(
 '0',
 '0',
 '0',
 @Amount,
 @YearId,
 @CompanyId,
 '0'
)
end



if @Type='OtherOperatingGainOrLoss'
begin

INSERT [dbo].[ProfitAndLoss](
 Revenue,
 CostOfSales,
 OtherOperatingIncome,
 OperatingExpenses,
 YearId,
 CompanyId,
 OtherOperatingGainOrLoss
)
VALUES(
 '0',
 '0',
 '0',
 '0',
 @YearId,
 @CompanyId,
 @Amount
)
end
end
else
begin
IF @type='Revenue'
begin
UPDATE [dbo].[ProfitAndLoss]
SET Revenue=@Amount
WHERE CompanyId=@CompanyId and YearId=@YearId
end

IF @type='CostOfSales'
begin
UPDATE [dbo].[ProfitAndLoss]
SET CostOfSales=@Amount
WHERE CompanyId=@CompanyId and YearId=@YearId
end

IF @type='OtherOperatingIncome'
begin
UPDATE [dbo].[ProfitAndLoss]
SET OtherOperatingIncome=@Amount
WHERE CompanyId=@CompanyId and YearId=@YearId
end

IF @type='OperatingExpenses'
begin
UPDATE [dbo].[ProfitAndLoss]
SET OperatingExpenses=@Amount
WHERE CompanyId=@CompanyId and YearId=@YearId
end

IF @type='OtherOperatingGainOrLoss'
begin
UPDATE [dbo].[ProfitAndLoss]
SET OtherOperatingGainOrLoss=@Amount
WHERE CompanyId=@CompanyId and YearId=@YearId
end
end
GO