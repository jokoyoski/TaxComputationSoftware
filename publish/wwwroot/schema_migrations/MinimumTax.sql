PRINT('================================================Minimum Tax Script Started==============================================')


PRINT('========================================Creating Minimum Tax Table=======================================================')

--------------------------------------------------------CREATE BALANCING ADJUSTMENT TABLE-----------------------------------------

IF NOT EXISTS(SELECT 1
FROM sysobjects
WHERE type = 'U' and name = 'MinimumTax')
BEGIN
    CREATE TABLE [dbo].[MinimumTax]
    (
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [CompanyId] [int] NOT NULL,
        [FinancialYearId] [int] NOT NULL,
        [GrossProfit] [varchar(50)] NOT NULL,
        [NetAsset] [varchar(50)] NOT NULL,
        [ShareCapital] [varchar(50)] NOT NULL,
        [TurnOver] [varchar(50)] NOT NULL,
        [MinimumTaxPayable] [varchar(50)] NOT NULL,
        [DateCreated] [datetime2](7) NOT NULL,
        CONSTRAINT [PK_MinimumTax] PRIMARY KEY CLUSTERED
    (
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

PRINT('============================================Creating Minimum Tax by companyId and year=====================================================')

------------------------------------------------STORED PROCEDURE TO  GET MINIMUM TAX BY COMPANYID AND YEARID---------------------------------------------

IF OBJECT_ID('[dbo].[usp_GetMinimum_By_CompanyId_And_YearId]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_GetMinimum_By_CompanyId_And_YearId]
END
GO
CREATE PROCEDURE [dbo].[usp_GetMinimum_By_CompanyId_And_YearId](
    @Year int,
    @CompanyId int
)
AS
SELECT *
FROM [dbo].[MinimumTax]
WHERE CompanyId=@CompanyId AND FinancialYearId=@Year
GO


PRINT('========================================Creating Insert stored procedure into MINIMUM TAX table===================================================')

--------------------------------------- STORED PROCEDURE TO  INSERT INTO MINIMUM TAX TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_Minimum_Tax]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Minimum_Tax]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_Minimum_Tax](
    @Id int,
    @CompanyId int,
    @FinancialYearId int,
    @GrossProfit varchar(50),
    @NetAsset varchar(50),
    @ShareCapital varchar(50),
    @TurnOver varchar(50),
    @MinimumTaxPayable varchar(50),
    @DateCreated datetime2(7)
)
AS

INSERT [dbo].[MinimumTax]
(
    CompanyId,
    FinancialYearId,
    GrossProfit,
    NetAsset,
    ShareCapital,
    TurnOver,
    MinimumTaxPayable,
    DateCreated
)
VALUES
(
    @CompanyId,
    @FinancialYearId,
    @GrossProfit,
    @NetAsset,
    @ShareCapital,
    @TurnOver,
    @MinimumTaxPayable,
    @DateCreated
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO


--------------------------------------- STORED PROCEDURE TO  GET BALANCING ADJUSTMENT BY ID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_MinimumTax_By_Id]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].usp_MinimumTax_By_Id
END
GO
CREATE PROCEDURE [dbo].usp_MinimumTax_By_Id(
    @Id int)
   
AS
SELECT *
FROM [dbo].[MinimumTax]
WHERE Id=@Id
GO


PRINT('====================================================Update Minimum tax table===========================================================')

------------------------------------------------ STORED PROCEDURE TO UPDATE MINIMUM TAX TABLE--------------------------------------------

IF OBJECT_ID('[dbo].[usp_Update_MinimumTax]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Update_MinimumTax]
END
GO
CREATE PROCEDURE [dbo].[usp_Update_MinimumTax](
    @Id int,
    @GrossProfit varchar(50),
    @NetAsset varchar(50),
    @ShareCapital varchar(50),
    @TurnOver varchar(50),
    @MinimumTaxPayable varchar(50)
)
AS

UPDATE [dbo].[MinimumTax]
SET GrossProfit = @GrossProfit, 
    NetAsset = @NetAsset, 
    ShareCapital=@ShareCapital,
    TurnOver=@TurnOver,
    MinimumTaxPayable=@MinimumTaxPayable
WHERE Id=@Id
GO


--------------------------------------- STORED PROCEDURE TO  DELETE BALANCINGADJUSTMENTYEARBOUGHT BY ID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Delete_MinimumTax]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Delete_MinimumTax]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Delete_MinimumTax](
    @Id INT
)
AS
DELETE FROM [dbo].[BalancingAdjustmentYearBought]
WHERE Id = @Id

GO



--------------------------------------- STORED PROCEDURE TO  CREAYE MINIMUM TAX PERCENTAGE AND ASEESIBLE L0SS-----------------------------------------


if NOT EXISTS(SELECT 1 FROM sysobjects where type='U' and name ='MinimumTaxPercentage')
BEGIN
create table MinimumTaxPercentage(

 Id   int identity(1,1) NOT NULL ,
 CompanyId int ,
 MinimumTaxPercentage decimal,
 YearId int

 )

END
GO


-------------------------------------- STORED PROCEDURE TO  GET MINIMUM TAX AND ASESSABLE LOSS BY COMPANY ID AND YEAR ID-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_Minimum_Tax_Percentage_By_CompanyId_YearId]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].usp_Get_Minimum_Tax_Percentage_By_CompanyId_YearId
END
GO
CREATE PROCEDURE [dbo].usp_Get_Minimum_Tax_Percentage_By_CompanyId_YearId(
    @CompanyId int,@YearId int)
   
AS
SELECT *
FROM [dbo].[MinimumTaxPercentage]
WHERE CompanyId=@CompanyId AND YearId=@YearId
GO








-------------------------------------- STORED PROCEDURE TO  INSERT INTO MINIMUM TAX TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_Minimum_Tax_Percentage_Table]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Minimum_Tax_Percentage_Table]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_Minimum_Tax_Percentage_Table](
    @Id int,
    @CompanyId int,
    @YearId int,
    @MinimumTaxPercentage varchar(50)
)
AS
if exists (select * from MinimumTaxPercentage where CompanyId=@CompanyId  and YearId =@YearId)
begin
 update [dbo].[MinimumTaxPercentage] set MinimumTaxPercentage=@MinimumTaxPercentage
end
else
INSERT [dbo].[MinimumTaxPercentage]
(
    CompanyId,
    YearId,
    MinimumTaxPercentage
)
VALUES
(
    @CompanyId,
    @YearId,
    @MinimumTaxPercentage
   
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO

