﻿IF OBJECT_ID('[dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId]') IS nOT NULL
BEGIN
DROP procedure [dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId]
END
GO
CREATE procedure usp_Get_Fixed_Asset_By_CompanyId_And_YearId(
@CompanyId int,
@YearId int
)
AS

select [dbo].[FixedAsset].Id,[dbo].[Company].CompanyName AS CompanyName,[dbo].[FinancialYear].Name AS Year,[dbo].[AssetMapping].AssetName As FixedAssetName,OpeningCost,CostAddition,CostDisposal,OpeningDepreciation,DepreciationAddition,DepreciationDisposal,TransferCost,TransferDepreciation,IsTransferCostRemoved,IsTransferDepreciationRemoved  from [dbo].[FixedAsset] inner join [dbo].[FinancialYear] on [dbo].[FixedAsset].YearId=Name
inner join [dbo].[AssetMapping] on [dbo].[FixedAsset].AssetId=[dbo].[AssetMapping].Id
inner join [dbo].[Company] on [dbo].[FixedAsset].CompanyId= [dbo].[Company].Id
where [dbo].[FixedAsset].CompanyId=@CompanyId and [dbo].[FixedAsset].YearId=@YearId
order by Id
GO






--------------------------------------- STORED PROCEDURE TO  CREATE FIXED ASSET TABLE-----------------------------------------


If NOT EXISTS(SELECT 1 FROM sysobjects where type='U' and name ='FixedAsset')
BEGIN
create table FixedAsset(

 Id   int identity(1,1) NOT NULL ,
 CompanyId   int,
 YearId  int,
 AssetId  int,
 OpeningCost   varchar(30) NULL,
 TransferCost  varchar (30) null,
 CostAddition    varchar(20)null,
 CostDisposal    varchar(20) null,
 IsTransferCostRemoved bit,
 OpeningDepreciation varchar(20) null,
 TransferDepreciation varchar(20) null,
 DepreciationDisposal varchar(200),
<<<<<<< HEAD
<<<<<<< HEAD
=======
 DepreciationClosing varchar(200),
>>>>>>> 2860c1f490c9ea7bbea7c9b73660e82b40328612
=======
 DepreciationClosing varchar(200),
>>>>>>> 1426fd094a857e6b88a91df7198e2e70c47629fb
 DepreciationAddition varchar(200),
 IsTransferDepreciationRemoved bit,
 )

END
GO




--------------------------------------- STORED PROCEDURE TO  insert into FIXED ASSET TABLE-----------------------------------------


if object_id('[dbo].[usp_Insert_Fixed_Asset]') IS NOT NULL
BEGIN
drop procedure [dbo].[usp_Insert_Fixed_Asset]
end
go
create procedure usp_Insert_Fixed_Asset(
 @CompanyId   int,
 @YearId  int,
 @AssetId  int,
 @OpeningCost   varchar(30),
 @TransferCost  varchar (30),
 @CostAddition    varchar(20),
 @CostDisposal    varchar(20),
 @IsTransferCostRemoved bit,
 @OpeningDepreciation varchar(20),
 @TransferDepreciation varchar(20),
 @DepreciationAddition varchar(20),
 @DepreciationDisposal varchar(20),
<<<<<<< HEAD
<<<<<<< HEAD
=======
 @DepreciationClosing varchar(200),
>>>>>>> 2860c1f490c9ea7bbea7c9b73660e82b40328612
=======
 @DepreciationClosing varchar(200),
>>>>>>> 1426fd094a857e6b88a91df7198e2e70c47629fb
 @type varchar (20),
 @IsTransferDepreciationRemoved bit
)
AS

if exists(select * from FixedAsset where CompanyId=@CompanyId and YearId=@YearId)
BEGIN
 IF @type='Cost'
begin
UPDATE [dbo].[FixedAsset]
SET CompanyId = @CompanyId, YearId = @YearId, AssetId=@AssetId ,OpeningCost=@OpeningCost,CostAddition=@CostAddition,CostDisposal=@CostDisposal,
TransferCost=@TransferCost,IsTransferCostRemoved=@IsTransferCostRemoved
WHERE CompanyId=@CompanyId and YearId=@YearId and AssetId=@AssetId
end
else
begin
begin
UPDATE [dbo].[FixedAsset]
SET CompanyId = @CompanyId, YearId = @YearId, AssetId=@AssetId ,OpeningDepreciation=@OpeningDepreciation,DepreciationAddition=@DepreciationAddition,DepreciationDisposal=@DepreciationDisposal,
<<<<<<< HEAD
<<<<<<< HEAD
TransferDepreciation=@TransferDepreciation,IsTransferDepreciationRemoved=@IsTransferDepreciationRemoved
=======
TransferDepreciation=@TransferDepreciation,IsTransferDepreciationRemoved=@IsTransferDepreciationRemoved,DepreciationClosing=@DepreciationClosing
>>>>>>> 2860c1f490c9ea7bbea7c9b73660e82b40328612
=======
TransferDepreciation=@TransferDepreciation,IsTransferDepreciationRemoved=@IsTransferDepreciationRemoved,DepreciationClosing=@DepreciationClosing
>>>>>>> 1426fd094a857e6b88a91df7198e2e70c47629fb
WHERE CompanyId=@CompanyId and YearId=@YearId and AssetId=@AssetId
END
end
end
else
begin
IF @type='Cost'
begin
INSERT [dbo].[FixedAsset](
 CompanyId,
 YearId,
 AssetId,
 OpeningCost,
 TransferCost,
 CostAddition,
 CostDisposal,
 IsTransferCostRemoved
 )
values(

 @CompanyId,
 @YearId,
 @AssetId,
 @OpeningCost,
 @TransferCost,
 @CostAddition,
 @CostDisposal,
 @IsTransferCostRemoved
)
end
else
begin
INSERT [dbo].[FixedAsset](
 CompanyId,
 YearId,
 AssetId,
 OpeningDepreciation,
 TransferDepreciation,
 DepreciationAddition,
 DepreciationDisposal,
<<<<<<< HEAD
<<<<<<< HEAD
=======
 DepreciationClosing,
>>>>>>> 2860c1f490c9ea7bbea7c9b73660e82b40328612
=======
 DepreciationClosing,
>>>>>>> 1426fd094a857e6b88a91df7198e2e70c47629fb
 IsTransferDepreciationRemoved
)
values(

@CompanyId,
@YearId,
@AssetId,
@OpeningDepreciation,
@TransferDepreciation,
@DepreciationAddition,
@DepreciationDisposal,
<<<<<<< HEAD
<<<<<<< HEAD
=======
@DepreciationClosing,
>>>>>>> 2860c1f490c9ea7bbea7c9b73660e82b40328612
=======
@DepreciationClosing,
>>>>>>> 1426fd094a857e6b88a91df7198e2e70c47629fb
@IsTransferDepreciationRemoved
)
end
end