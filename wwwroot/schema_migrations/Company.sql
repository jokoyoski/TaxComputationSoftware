IF OBJECT_ID('[dbo].[usp_Get_Company_By_Id]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Company_By_Id]
END
GO
CREATE procedure usp_Get_Company_By_Id(
@Id int

)
AS

select * from  [dbo].[Company] where  [dbo].[Company].Id=@Id

GO



IF OBJECT_ID('[dbo].[usp_Get_All_Company]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_All_Company]
END
GO
CREATE procedure usp_Get_All_Company
AS

select * from  [dbo].[Company]
GO


IF OBJECT_ID('[dbo].[usp_Get_Company_By_Tin]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Company_By_Tin]
END
GO
CREATE procedure usp_Get_Company_By_Tin(
@TinNumber varchar(20)

)
AS

select * from  [dbo].[Company] where  [dbo].[Company].TinNumber=@TinNumber

GO


if NOT EXISTS(SELECT 1 FROM sysobjects where type='U' and name ='Company')
BEGIN
create table Company(

 Id   int identity(1,1) NOT NULL ,
 CompanyName varchar(200),
CompanyDescription varchar(200),
CacNumber nvarchar(max) null,
TinNumber nvarchar(max)null,
DateCreated datetime null,
IsActive bit null,

 )

END
GO


if object_id('[dbo].[usp_Insert_Company]') IS NOT NULL
BEGIN
drop procedure [dbo].[usp_Insert_Company]
end
go
create procedure usp_Insert_Company(
@CompanyName varchar(200),
@CompanyDescription varchar(200),
@CacNumber nvarchar(max) null,
@TinNumber nvarchar(max)null,
@DateCreated datetime  null,
@IsActive bit null
)
AS

INSERT [dbo].[Company](

CompanyName,
CompanyDescription,
CacNumber,
TinNumber,
DateCreated,
IsActive
)
values(

@CompanyName,
@CompanyDescription,
@CacNumber,
@TinNumber,
@DateCreated,
@IsActive
)