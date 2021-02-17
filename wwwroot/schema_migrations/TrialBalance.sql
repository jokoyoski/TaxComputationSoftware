PRINT('================================================Trial Balance Script Started==============================================')


PRINT('========================================Creating Track Trial Balance Table=======================================================')

---------------------------------------CREATE TRACK TRIAL BALANCE TABLE-----------------------------------------


IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'TrackTrialBalance')
BEGIN
CREATE TABLE [dbo].[TrackTrialBalance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[YearId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TrackTrialBalance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

PRINT('========================================Creating Trial Balance Mapping Table=======================================================')

---------------------------------------CREATE TRIAL BALANCE TABLE-----------------------------------------

IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'TrialBalance')
BEGIN
CREATE TABLE [dbo].[TrialBalance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [nvarchar](max) NULL,
	[Item] [nvarchar](max) NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[MappedTo] [nvarchar](max) NULL,
	[IsCheck] [bit] NOT NULL,
	[IsRemoved] [bit] NOT NULL,
	[TrackId] [int] NOT NULL,
 CONSTRAINT [PK_TrialBalance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO


PRINT('========================================Creating Trial Balance Mapping Table=======================================================')

---------------------------------------CREATE TRIAL BALANCE MAPPING TABLE-----------------------------------------


IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'TrialBalanceMapping')
BEGIN
CREATE TABLE [dbo].[TrialBalanceMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrialBalanceId] [int] NOT NULL,
	[ModuleId] [int] NOT NULL,
	[ModuleCode] [varchar](max) NULL,
	[AdditionalInfo] [varchar](max) NULL,
 CONSTRAINT [PK_TrialBalanceMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO


PRINT('========================================Creating Insert stored procedure into trial balance table===================================================')

--------------------------------------- STORED PROCEDURE TO  INSERT INTO TTRACK TRIAL BALANCE TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_Track_Trial_Balance]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Track_Trial_Balance]
PRINT('OK')
END
GO
CREATE PROCEDURE [usp_Insert_Track_Trial_Balance](
@CompanyId INT,
@YearId   INT,
@DateCreated  DATETIME2(7),
@Id int OUTPUT
)
AS

INSERT [dbo].[TrackTrialBalance]
(
 CompanyId,
 YearId,
 DateCreated
)
VALUES
(
 @CompanyId,
 @YearId,
 @DateCreated
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO



PRINT('========================================Creating Insert stored procedure into trial balance table===================================================')

--------------------------------------- STORED PROCEDURE TO  INSERT INTO TRIAL BALANCE TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_Trial_Balance]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Trial_Balance]
PRINT('OK')
END
GO
CREATE PROCEDURE [usp_Insert_Trial_Balance](
@Item NVARCHAR(max),
@Debit   DECIMAL(18, 2),
@Credit  DECIMAL(18, 2),
@MappedTo   NVARCHAR (max),
@IsCheck   BIT,
@AccountId  NVARCHAR (max),
@IsRemoved BIT,
@TrackId    INT,
@Id int OUTPUT
)
AS

INSERT [dbo].[TrialBalance]
(
 Item,
 Debit,
 Credit,
 MappedTo,
 IsCheck,
 AccountId,
 IsRemoved,
 TrackId
)
VALUES
(
 @Item,
 @Debit,
 @Credit,
 @MappedTo,
 @IsCheck,
 @AccountId,
 @IsRemoved,
 @TrackId
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO


PRINT('========================================Creating select all stored procedure from track trial balance table===================================================')

------------------------------------------------STORED PROCEDURE TO  GET TRACK TRIAL BALANCE BY COMPANYID AND YEARID---------------------------------------------

IF OBJECT_ID('[dbo].[usp_GetTrackTrialBalance_By_CompanyId_And_YearId]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_GetTrackTrialBalance_By_CompanyId_And_YearId]
END
GO
CREATE PROCEDURE [dbo].[usp_GetTrackTrialBalance_By_CompanyId_And_YearId](
@YearId int,
@CompanyId int
)
AS
SELECT * FROM [dbo].[TrackTrialBalance] WHERE CompanyId=@CompanyId AND YearId=@YearId
GO

PRINT('========================Creating get trial balance by trackId stored procedure from trial balance table===========================================')

------------------------------------------------ STORED PROCEDURE TO  GET TRIAL BALANCE BY TRIAL BALANCE TABLE--------------------------------------------

IF OBJECT_ID('[dbo].[usp_GetTrialBalance_By_TrackingId]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_GetTrialBalance_By_TrackingId]
END
GO
CREATE PROCEDURE [dbo].[usp_GetTrialBalance_By_TrackingId](
@TrackId int
)
AS
SELECT * FROM [dbo].[TrialBalance] WHERE TrackId=@TrackId
GO

PRINT('=====================================Delete from trial balance by trailId stored procedure from trial balance table=====================================')

------------------------------------------------ STORED PROCEDURE TO DELETE TRIAL BALANCE BY TRIALID BALANCE TABLE--------------------------------------------

IF OBJECT_ID('[dbo].[usp_DeleteTrialBalance_By_Id]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_DeleteTrialBalance_By_Id]
END
GO
CREATE PROCEDURE [dbo].[usp_DeleteTrialBalance_By_Id](
@TrailId int
)
AS
DELETE FROM [dbo].[TrialBalance] WHERE Id=@TrailId
GO


PRINT('===================================Get from trial balance by Id stored procedure from trial balance table==========================================')

------------------------------------------------ STORED PROCEDURE TO GET TRIAL BALANCE BY TRIALID BALANCE TABLE--------------------------------------------

IF OBJECT_ID('[dbo].[usp_GetTrialBalance_By_Id]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_GetTrialBalance_By_Id]
END
GO
CREATE PROCEDURE [dbo].[usp_GetTrialBalance_By_Id](
@TrailId int
)
AS
SELECT * FROM [dbo].[TrialBalance] WHERE Id=@TrailId
GO

PRINT('====================================================Update trial balance table===========================================================')

------------------------------------------------ STORED PROCEDURE TO GET TRIAL BALANCE BY TRIALID BALANCE TABLE--------------------------------------------

IF OBJECT_ID('[dbo].[usp_UpdateTrialBalance]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_UpdateTrialBalance]
END
GO
CREATE PROCEDURE [dbo].[usp_UpdateTrialBalance](
@TrailId INT,
@mappedTo NVARCHAR(max),
@IsDelete BIT
)
AS
IF (@IsDelete = 1) 
BEGIN
UPDATE [dbo].[TrialBalance]
SET IsCheck = 0, IsRemoved = 0, MappedTo=@mappedTo
WHERE Id=@TrailId
END
ELSE 
BEGIN
UPDATE [dbo].[TrialBalance]
SET IsCheck = 1, IsRemoved = 1, MappedTo=@mappedTo
WHERE Id=@TrailId
END
GO


PRINT('========================================Creating Insert stored procedure into trial balance mapping table===================================================')

---------------------------------------------STORED PROCEDURE TO  INSERT INTO TRIAL BALANCE MAPPING TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_Trial_Balance_Mapping]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_Trial_Balance_Mapping]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_Trial_Balance_Mapping](
	@TrialBalanceId INT,
	@ModuleId INT,
	@ModuleCode NVARCHAR(max),
	@AdditionalInfo NVARCHAR(max)
)
AS

INSERT [dbo].[TrialBalanceMapping]
(
    TrialBalanceId,
    ModuleId,
    ModuleCode,
    AdditionalInfo
)
VALUES
(
    @TrialBalanceId,
	@ModuleId,
	@ModuleCode,
	@AdditionalInfo
)
GO


PRINT('========================================Creating delete stored procedure from trial balance mapping table===============================================')

---------------------------------------------------- STORED PROCEDURE TO  DELETE FORM TRIAL BALANCE MAPPING TABLE----------------------------------------------

IF OBJECT_ID('[dbo].[usp_Delete_Trial_Balance_Mapping]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Delete_Trial_Balance_Mapping]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Delete_Trial_Balance_Mapping](
	@Id INT
)
AS
DELETE FROM [dbo].[TrialBalanceMapping] WHERE TrialBalanceId = @Id
GO


PRINT('===============================================Creating get amount debit stored procedure===================================================')

------------------------------------------------------- STORED PROCEDURE TO  GET AMOUNT DEBIT---------------------------------------------------


IF OBJECT_ID('[dbo].[usp_Get_Amount_Debit]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Amount_Debit]
END
GO
CREATE procedure [dbo].[usp_Get_Amount_Debit](
@ModuleId int,
@AdditionalInfo varchar(20)
)
AS

select [dbo].[TrialBalance].Debit  from [dbo].[TrialBalanceMapping]
inner join [dbo].[TrialBalance] on [dbo].[TrialBalanceMapping].TrialBalanceId = [dbo].[TrialBalance].Id
where [dbo].[TrialBalanceMapping].ModuleId=@ModuleId and [dbo].[TrialBalanceMapping].AdditionalInfo=@AdditionalInfo
order by [dbo].[TrialBalance].Debit DESC
GO


PRINT('========================================Creating get amount credit stored procedure===================================================')

------------------------------------------------------- STORED PROCEDURE TO  GET AMOUNT CREDIT---------------------------------------------------


IF OBJECT_ID('[dbo].[usp_Get_Amount_Credit]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Amount_Credit]
END
GO
CREATE procedure [dbo].[usp_Get_Amount_Credit](
@ModuleId int,
@AdditionalInfo varchar(20)
)
AS

select [dbo].[TrialBalance].Credit  from [dbo].[TrialBalanceMapping]
inner join [dbo].[TrialBalance] on [dbo].[TrialBalanceMapping].TrialBalanceId = [dbo].[TrialBalance].Id
where [dbo].[TrialBalanceMapping].ModuleId=@ModuleId and [dbo].[TrialBalanceMapping].AdditionalInfo=@AdditionalInfo
order by [dbo].[TrialBalance].Credit DESC
GO




--------------------------------------- STORED PROCEDURE TO  GET ASSET MAPPING BY ASSETNAME -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_From_TrialBalanceMapping_With_TrialBalanceId]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Get_From_TrialBalanceMapping_With_TrialBalanceId]
END
GO
CREATE procedure [dbo].[usp_Get_From_TrialBalanceMapping_With_TrialBalanceId](
  @TrialBalanceId int
)
AS

select *
from [dbo].[TrialBalanceMapping]
where TrialBalanceId = @TrialBalanceId
GO





--------------------------------------- STORED PROCEDURE TO  GET ASSET MAPPING BY ASSETNAME -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_From_TrialBalance_With_TrialBalanceId]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Get_From_TrialBalance_With_TrialBalanceId]
END
GO
CREATE procedure [dbo].[usp_Get_From_TrialBalance_With_TrialBalanceId](
  @TrialBalanceId int
)
AS

select *
from [dbo].[TrialBalance]
where Id = @TrialBalanceId
GO