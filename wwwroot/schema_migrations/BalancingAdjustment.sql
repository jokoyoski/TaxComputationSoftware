PRINT('================================================Balance Adjustment Script Started==============================================')


PRINT('========================================Creating Balancing Adjustment Table=======================================================')

--------------------------------------------------------CREATE BALANCING ADJUSTMENT TABLE-----------------------------------------

IF NOT EXISTS(SELECT 1
FROM sysobjects
WHERE type = 'U' and name = 'BalancingAdjustment')
BEGIN
    CREATE TABLE [dbo].[BalancingAdjustment]
    (
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [AssetId] [int] NOT NULL,
        [CompanyId] [int] NOT NULL,
        [Year] [nvarchar](max) NULL,
        [DateCreated] [datetime2](7) NOT NULL,
        CONSTRAINT [PK_BalancingAdjustment] PRIMARY KEY CLUSTERED
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

PRINT('========================================Creating Balancing Adjustment Year Bought Table=======================================================')

--------------------------------------------------------CREATE BALANCING ADJUSTMENT YEAR BOUGHT TABLE-----------------------------------------

IF NOT EXISTS(SELECT 1
FROM sysobjects
WHERE type = 'U' and name = 'BalancingAdjustmentYearBought')
BEGIN
    CREATE TABLE [dbo].[BalancingAdjustmentYearBought]
    (
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [AssestId] [int] NOT NULL,
        [Cost] [decimal](18, 2) NOT NULL,
        [InitialAllowance] [decimal](18, 2) NOT NULL,
        [AnnualAllowance] [decimal](18, 2) NOT NULL,
        [SalesProceed] [decimal](18, 2) NOT NULL,
        [Residue] [decimal](18, 2) NOT NULL,
        [BalancingAllowance] [decimal](18, 2) NOT NULL,
        [BalancingCharge] [decimal](18, 2) NOT NULL,
        [DateCreated] [datetime2](7) NOT NULL,
        [YearBought] [nvarchar](max) NULL,
        [BalancingAdjustmentId] [int] NOT NULL,
        CONSTRAINT [PK_BalancingAdjustmentYearBought] PRIMARY KEY CLUSTERED
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

PRINT('============================================Creating balancing adjustment by companyId and year=====================================================')

------------------------------------------------STORED PROCEDURE TO  GET TRACK TRIAL BALANCE BY COMPANYID AND YEARID---------------------------------------------

IF OBJECT_ID('[dbo].[usp_GetBalancingAdjustment_By_CompanyId_And_YearId]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_GetBalancingAdjustment_By_CompanyId_And_YearId]
END
GO
CREATE PROCEDURE [dbo].[usp_GetBalancingAdjustment_By_CompanyId_And_YearId](
    @Year nvarchar(max),
    @CompanyId int
)
AS
SELECT *
FROM [dbo].[BalancingAdjustment]
WHERE CompanyId=@CompanyId AND Year=@Year
GO


PRINT('============================================Creating balancing adjustment by companyId and year=====================================================')

------------------------------------------------STORED PROCEDURE TO  GET TRACK TRIAL BALANCE BY COMPANYID AND YEARID---------------------------------------------

IF OBJECT_ID('[dbo].[usp_GetBalancingAdjustment_BalancingAdjustmentId_AssetId]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_GetBalancingAdjustment_BalancingAdjustmentId_AssetId]
END
GO
CREATE PROCEDURE [dbo].[usp_GetBalancingAdjustment_BalancingAdjustmentId_AssetId](
    @AssetId nvarchar(max),
    @BalancingAdjustmentId int
)
AS
SELECT *
FROM [dbo].[BalancingAdjustmentYearBought]
WHERE AssestId=@AssetId AND BalancingAdjustmentId=@BalancingAdjustmentId
GO


PRINT('============================================Creating balancing adjustment by yearbought and assetId=====================================================')

------------------------------------------------STORED PROCEDURE TO  GET TRACK TRIAL BALANCE BY COMPANYID AND YEARID---------------------------------------------

IF OBJECT_ID('[dbo].[usp_GetBalancingAdjustment_YearBought_AssetId]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_GetBalancingAdjustment_YearBought_AssetId]
END
GO
CREATE PROCEDURE [dbo].[usp_GetBalancingAdjustment_YearBought_AssetId](
    @AssetId nvarchar(max),
    @YearBought int
)
AS
SELECT *
FROM [dbo].[BalancingAdjustmentYearBought]
WHERE AssestId=@AssetId AND YearBought=@YearBought
GO


PRINT('========================================Creating Insert stored procedure into balancing Adjustment table===================================================')

--------------------------------------- STORED PROCEDURE TO  INSERT INTO TRIAL BALANCE TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_Balance_Adjustment]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Balance_Adjustment]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_Balance_Adjustment](
    @Id int OUTPUT,
    @AssetId int,
    @CompanyId int,
    @Year nvarchar (max),
    @DateCreated datetime2 (7)
)
AS

INSERT [dbo].[BalancingAdjustment]
(
    AssetId,
    CompanyId,
    Year,
    DateCreated
)
VALUES
(
        @AssetId,
        @CompanyId,
        @Year,
        @DateCreated
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO


PRINT('========================================Creating Insert stored procedure into balancing Adjustment Yearbought table===================================================')

--------------------------------------- STORED PROCEDURE TO  INSERT INTO TRIAL BALANCE TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_Balance_Adjustment_YearBought]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Balance_Adjustment_YearBought]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_Balance_Adjustment_YearBought](
    @AssestId int,
    @Cost decimal(18, 2),
    @InitialAllowance decimal(18, 2),
    @AnnualAllowance decimal(18, 2),
    @SalesProceed decimal(18, 2),
    @Residue decimal(18, 2),
    @BalancingAllowance decimal(18, 2),
    @BalancingCharge decimal(18, 2),
    @DateCreated datetime2(7),
    @YearBought nvarchar(max),
    @BalancingAdjustmentId int,
    @Id int OUTPUT
)
AS

INSERT [dbo].[BalancingAdjustmentYearBought]
(
    AssestId,
    Cost,
    InitialAllowance,
    AnnualAllowance,
    SalesProceed,
    Residue,
    BalancingAllowance,
    BalancingCharge,
    DateCreated,
    YearBought,
    BalancingAdjustmentId
)
VALUES
(
    @AssestId,
    @Cost,
    @InitialAllowance,
    @AnnualAllowance,
    @SalesProceed,
    @Residue,
    @BalancingAllowance,
    @BalancingCharge,
    @DateCreated,
    @YearBought,
    @BalancingAdjustmentId
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO



--------------------------------------- STORED PROCEDURE TO  GET BALANCING ADJUSTMENT BY ID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_GetBalancingAdjustment_By_Id]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].usp_GetBalancingAdjustment_By_Id
END
GO
CREATE PROCEDURE [dbo].usp_GetBalancingAdjustment_By_Id(
    @Id int)
   
AS
SELECT *
FROM [dbo].[BalancingAdjustment]
WHERE Id=@Id
GO



--------------------------------------- STORED PROCEDURE TO  DELETE BALANCINGADJUSTMENTYEARBOUGHT BY ID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Delete_BalancingAdjustmentYearBought]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].usp_Delete_BalancingAdjustmentYearBought
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Delete_BalancingAdjustmentYearBought](
    @Id INT
)
AS
DELETE FROM [dbo].[BalancingAdjustmentYearBought]
WHERE Id = @Id

GO

--------------------------------------- STORED PROCEDURE TO  GET BALANCINGADJUSTMENTYEARBOUGHT BY ID -----------------------------------------

IF OBJECT_ID('[dbo].[usp_Get_BalancingAdjustmentYearBought]') IS NOT NULL
BEGIN
DROP procedure [dbo].usp_Get_BalancingAdjustmentYearBought
END
GO
CREATE procedure [dbo].[usp_Get_BalancingAdjustmentYearBought](
@Id INT
)
AS

SELECT Id,AssestId,Cost,InitialAllowance,AnnualAllowance,SalesProceed,Residue,BalancingAllowance,BalancingCharge,DateCreated,YearBought,BalancingAdjustmentId from [dbo].[BalancingAdjustmentYearBought] WHERE Id = @Id
GO