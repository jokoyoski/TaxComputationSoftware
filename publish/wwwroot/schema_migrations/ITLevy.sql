-------------------------------------CREATE IT LEVY TABLE--------------------------------------

IF NOT EXISTS(SELECT 1
FROM sysobjects
WHERE type = 'U' and name = 'ITLevy')
BEGIN
  create table ITLevy
  (

    Id int identity(1,1) NOT NULL ,
    Item varchar(50)
  )
END
GO


--------------------------------------- STORED PROCEDURE TO  GET IT Levy -----------------------------------------
IF OBJECT_ID('[dbo].[usp_Get_IT_Levy]') IS nOT NULL
BEGIN
  DROP procedure [dbo].[usp_Get_IT_Levy]
END
GO
CREATE procedure [dbo].[usp_Get_IT_Levy]
AS

select *
from [dbo].[ITLevy] 
GO