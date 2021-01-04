PRINT('================================================PreNotification Script Started==============================================')


PRINT('========================================Creating PreNotification Table=======================================================')

--------------------------------------------------------CREATE PreNotification TABLE-----------------------------------------

IF NOT EXISTS(SELECT 1
FROM sysobjects
WHERE type = 'U' and name = 'PreNotification')
BEGIN
    CREATE TABLE [dbo].[PreNotification]
    (
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [CompanyId] [int] NOT NULL,
        [OpeningDate] [datetime2](7) NOT NULL,
        [ClosingingDate] [datetime2](7) NOT NULL,
        [JobDate] [datetime2](7) NULL,
        [IsLocked] BIT NOT NULL,
        CONSTRAINT [PK_PreNotification] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO


--------------------------------------- STORED PROCEDURE TO  GET BPreNotification-----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_All_PreNotification]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Get_All_PreNotification]
END
GO
CREATE PROCEDURE [dbo].[usp_Get_All_PreNotification]
AS
SELECT *
FROM [dbo].[PreNotification]
GO


-------------------------------------- STORED PROCEDURE TO  INSERT INTO PreNotification TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_PreNotification]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_PreNotification]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_PreNotification](
    @Id int out,
    @CompanyId int,
    @OpeningDate datetime2 (7),
    @ClosingingDate datetime2 (7),
    @IsLocked bit

)
AS

INSERT [dbo].[PreNotification]
(
    CompanyId,
    OpeningDate,
    ClosingingDate,
    IsLocked
)
VALUES
(
    @CompanyId,
    @OpeningDate,
    @ClosingingDate,
    @IsLocked
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO



PRINT('====================================================Update PreNotification table===========================================================')

------------------------------------------------ STORED PROCEDURE TO Update PreNotification table--------------------------------------------

IF OBJECT_ID('[dbo].[usp_UpdatePreNotification]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_UpdatePreNotification]
END
GO
CREATE PROCEDURE [dbo].[usp_UpdatePreNotification](
    @Id INT,
    @OpeningDate datetime2 (7),
    @JobDate datetime2 (7)
)
AS
BEGIN
UPDATE [dbo].[PreNotification]
SET  OpeningDate = @OpeningDate,
     ClosingingDate = @ClosingingDate,
     JobDate = @JobDate
WHERE Id=@Id
END
GO



PRINT('====================================================Update Job Date PreNotification to Null table===========================================================')

------------------------------------------------ STORED PROCEDURE TO Update Job Date PreNotification to Null table--------------------------------------------

IF OBJECT_ID('[dbo].[usp_Update_Jobdate_To_Null]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Update_Jobdate_To_Null]
END
GO
CREATE PROCEDURE [dbo].[usp_Update_Jobdate_To_Null](
    @Id INT
)
AS
BEGIN
UPDATE [dbo].[PreNotification]
SET  JobDate = Null
WHERE Id=@Id
END
GO


PRINT('====================================================Lock PreNotification table===========================================================')

------------------------------------------------ STORED PROCEDURE To Lock PreNotification table--------------------------------------------

IF OBJECT_ID('[dbo].[usp_Lock]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Lock]
END
GO
CREATE PROCEDURE [dbo].[usp_Lock](
    @Id INT,
    @IsLocked BIT
)
AS
BEGIN
UPDATE [dbo].[PreNotification]
SET  IsLocked = @IsLocked
WHERE Id=@Id
END
GO

