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

--------------------------------------- STORED PROCEDURE TO  GET USER -----------------------------------------
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



