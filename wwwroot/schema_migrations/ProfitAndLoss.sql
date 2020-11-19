IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'ProfitAndLoss')
BEGIN
   create table ProfitAndLoss(

 Id   int identity(1,1) NOT NULL ,
 Revenue   int,
 OtherIncome  int,
 CostOfSales   int,
 OtherOperatingIncome   int,
 OperatingExpense  int
 )
END
GO
--------------------------------------- STORED PROCEDURE TO  GET ASSET MAPPING -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Profit_And_Loss]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Profit_And_Loss]
END
GO
CREATE procedure [dbo].[usp_Get_Profit_And_Loss]
AS

select * from [dbo].[ProfitAndLoss] 
GO