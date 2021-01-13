IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'Users')
BEGIN
CREATE TABLE Users(
Id int identity(1,1) NOT NULL,
Email varchar(50),
PasswordHash varchar(max),
PhoneNumber varchar(25),
FirstName varchar(50),
LastName varchar(50),
DateCreated datetime,
IsActive bit
)
END
GO

--------------------------------------- STORED PROCEDURE TO  INSERT USER -----------------------------------------

IF OBJECT_ID('[dbo].[usp_Insert_User]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Insert_User]
PRINT('OK')
END
GO
CREATE procedure [usp_Insert_User](
@Email varchar(50),
@PasswordHash varchar(max),
@PhoneNumber varchar(25),
@FirstName varchar(50),
@LastName varchar(50),
@DateCreated datetime,
@IsActive bit
)
AS

INSERT [dbo].[Users](
Email,
PasswordHash,
PhoneNumber,
FirstName,
LastName,
DateCreated,
IsActive
)
VALUES(
@Email,
@PasswordHash,
@PhoneNumber,
@FirstName,
@LastName,
getdate(),
@IsActive
)
GO




--------------------------------------- STORED PROCEDURE TO  GET ALL USERS -----------------------------------------

IF OBJECT_ID('[dbo].[usp_Get_Users') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_User_By_Email]
END
GO
CREATE procedure [dbo].[usp_Get_User_By_Email]
AS

SELECT Email,PasswordHash,PhoneNumber,FirstName,LastName,DateCreated,IsActive from [dbo].[Users]
GO

--------------------------------------- STORED PROCEDURE TO  GET USER BY EMAIL -----------------------------------------

IF OBJECT_ID('[dbo].[usp_Get_User_By_Email]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_User_By_Email]
END
GO
CREATE procedure [dbo].[usp_Get_User_By_Email](
@Email varchar(50)
)
AS

SELECT Email,PasswordHash,PhoneNumber,FirstName,LastName,DateCreated,IsActive from [dbo].[Users] WHERE Email = @Email
GO

--------------------------------------- STORED PROCEDURE TO  CREATE USERCODES TABLE -----------------------------------------

IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE type = 'U' and name = 'UserCodes')
BEGIN
CREATE TABLE UserCodes(
Id int identity(1,1) NOT NULL,
Email varchar(50),
Code varchar(4),
DateCreated datetime,
)
END
GO

--------------------------------------- STORED PROCEDURE TO  GET USER BY CODE -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_User_By_Code]') IS NOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_User_By_Code]
END
GO
CREATE procedure [dbo].[usp_Get_User_By_Code](
@Code varchar(4)
)
AS

SELECT Email,Code,DateCreated from [dbo].[UserCodes] WHERE Code = @Code
GO

--------------------------------------- STORED PROCEDURE TO  UPDATE PASSWORD -----------------------------------------

IF OBJECT_ID('[dbo].[Update_Password]') IS NOT NULL
BEGIN
DROP procedure [dbo].[Update_Password]
END
GO
CREATE PROCEDURE [dbo].[Update_Password](
@Email VARCHAR(50),
@PasswordHash varchar(MAX)
)
AS
IF EXISTS(SELECT * FROM [dbo].[Users] where Email=@Email)
BEGIN
    UPDATE [dbo].[Users]
    SET PasswordHash = @PasswordHash
    WHERE Email=@Email
END
