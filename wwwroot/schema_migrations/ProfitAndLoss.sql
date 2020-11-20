IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'ProfitAndLoss')
BEGIN
   create table ProfitAndLoss(

 Id   int identity(1,1) NOT NULL ,
 Revenue   int,
 OtherIncome  int,
 CostOfSales   int,
 OtherOperatingIncome   int,
 OperatingExpense  int,
 YearId int,
 CompanyId int,
 GrossProfit int,
 GrossLoss int,
 OtherOperatingGain int,
 OtherOperatingLoss int,
 LossBeforeTaxation int,
 ProfitBeforeTaxation int
 )
END
GO
--------------------------------------- STORED PROCEDURE TO  GET PROFIT AND LOSS -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Profit_And_Loss]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Profit_And_Loss]
END
GO
CREATE procedure [dbo].[usp_Get_Profit_And_Loss]
AS

select * from [dbo].[ProfitAndLoss] 
GO

-------------------------------------- STORED PROCEDURE TO  INSERT PROFIT AND LOSS -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Insert_Profit_And_Loss]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_Profit_And_Loss]
END
GO
CREATE procedure usp_Insert_Profit_And_Loss(
@Revenue   int,
 @OtherIncome  int,
 @CostOfSales   int,
 @OtherOperatingIncome   int,
 @OperatingExpense  int,
 @YearId int,
 @CompanyId int,
 @GrossProfit int,
 @GrossLoss int,
 @OtherOperatingGain int,
 @OtherOperatingLoss int,
 @LossBeforeTaxation int,
 @ProfitBeforeTaxation int
)
AS

INSERT [dbo].[ProfitAndLoss](
 Revenue,
 OtherIncome,
 CostOfSales,
 OtherOperatingIncome,
 OperatingExpense,
 YearId,
 CompanyId,
 GrossProfit,
 GrossLoss,
 OtherOperatingGain,
 OtherOperatingLoss,
 LossBeforeTaxation,
 ProfitBeforeTaxation
)
VALUES(
 @Revenue,
 @OtherIncome,
 @CostOfSales,
 @OtherOperatingIncome,
 @OperatingExpense,
 @YearId,
 @CompanyId,
 @GrossProfit,
 @GrossLoss,
 @OtherOperatingGain,
 @OtherOperatingLoss,
 @LossBeforeTaxation,
 @ProfitBeforeTaxation
)
GO