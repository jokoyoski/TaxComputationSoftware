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


PRINT('========================================Creating Insert stored procedure into PreNotification table===================================================')

--------------------------------------- STORED PROCEDURE TO  INSERT INTO PreNotification TABLE-----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_PreNotification]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_Insert_PreNotification]
PRINT('OK')
END
GO
CREATE PROCEDURE [dbo].[usp_Insert_PreNotification](
    @Id int out, 
    @CompanyId int,
    @OpeningDate datetime2 (7)

)
AS

INSERT [dbo].[PreNotification]
(
    CompanyId,
    OpeningDate
)
VALUES
(
    @CompanyId,
    @OpeningDate
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO


PRINT('====================================================Update PreNotification table===========================================================')

------------------------------------------------ STORED PROCEDURE TO GET PreNotification BY ID--------------------------------------------

IF OBJECT_ID('[dbo].[usp_UpdatePreNotification]') IS NOT NULL
BEGIN
DROP PROCEDURE [dbo].[usp_UpdatePreNotification]
END
GO
CREATE PROCEDURE [dbo].[usp_UpdatePreNotification](
    @Id INT,
    @OpeningDate datetime2 (7)
)
AS
BEGIN
UPDATE [dbo].[PreNotification]
SET  OpeningDate = @OpeningDate
WHERE Id=@Id
END
GO

