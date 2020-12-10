IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'InvestmentAllowance')
BEGIN
   create table InvestmentAllowance(
 Id   int identity(1,1) NOT NULL ,
 YearId int,
 AssetId int
 )
END
GO

--------------------------------------- STORED PROCEDURE TO  INSERT INVESTMENT ALLOWANCE -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Insert_Investment_Allowance]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Insert_Investment_Allowance]
END
GO
CREATE procedure [dbo].[usp_Insert_Investment_Allowance](
  @YearId   INT,
  @AssetId  INT
)
AS

INSERT [dbo].[InvestmentAllowance]
(
    YearId,
    AssetId
)
VALUES
(
    @YearId,
    @AssetId
)
GO

--------------------------------------- STORED PROCEDURE TO  DELETE INVESTMENT ALLOWANCE -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Delete_Investment_Allowance]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Delete_Investment_Allowance]
END
GO
CREATE procedure [dbo].[usp_Delete_Investment_Allowance](
  @Id INT
)
AS
DELETE [dbo].[AssetMapping] WHERE  Id = @Id  
GO
