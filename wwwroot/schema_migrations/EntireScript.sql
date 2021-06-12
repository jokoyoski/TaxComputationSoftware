USE [DB_A69507_kkdatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTrialBalance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_UpdateTrialBalance]
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdatePreNotification]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_UpdatePreNotification]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_MinimumTax]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Update_MinimumTax]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Jobdate_To_Null]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Update_Jobdate_To_Null]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Financial_Year]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Update_Financial_Year]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Company_Closing_OpeningDate]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Update_Company_Closing_OpeningDate]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Company]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Update_Company]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Asset_Mapping]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Update_Asset_Mapping]
GO
/****** Object:  StoredProcedure [dbo].[usp_MinimumTax_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_MinimumTax_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Lock]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Lock]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Trial_Balance_Mapping]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Trial_Balance_Mapping]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Trial_Balance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Trial_Balance]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Track_Trial_Balance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Track_Trial_Balance]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Profits_And_Loss]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Profits_And_Loss]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Profit_And_Loss_Record_Table]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Profit_And_Loss_Record_Table]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_PreNotification]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_PreNotification]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_New_Minimum_Tax_Table]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_New_Minimum_Tax_Table]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Minimum_Tax_Percentage_Table]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Minimum_Tax_Percentage_Table]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Minimum_Tax]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Minimum_Tax]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Investment_Allowance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Investment_Allowance]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Into_Income_Tax_Brought_Foward]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Into_Income_Tax_Brought_Foward]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Into_DeferredTax_Brought_Foward]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Into_DeferredTax_Brought_Foward]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Into_Company_Code_Table]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Into_Company_Code_Table]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Fixed_Asset]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Fixed_Asset]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Financial_Year]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Financial_Year]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Company]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Company]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Capital_Allowance_Summary]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Capital_Allowance_Summary]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Capital_Allowance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Capital_Allowance]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Balance_Adjustment_YearBought]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Balance_Adjustment_YearBought]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Balance_Adjustment]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Balance_Adjustment]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Asset_Mapping]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Asset_Mapping]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Asessable_UnRelieved_Table]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Asessable_UnRelieved_Table]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Archived_Capital_Allowance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Insert_Archived_Capital_Allowance]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTrialBalance_By_TrackingId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_GetTrialBalance_By_TrackingId]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTrialBalance_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_GetTrialBalance_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTrackTrialBalance_By_CompanyId_And_YearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_GetTrackTrialBalance_By_CompanyId_And_YearId]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetMinimum_By_CompanyId_And_YearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_GetMinimum_By_CompanyId_And_YearId]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBalancingAdjustmentBought_By_Year_Asset_YearBought]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_GetBalancingAdjustmentBought_By_Year_Asset_YearBought]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBalancingAdjustment_YearBought_AssetId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_GetBalancingAdjustment_YearBought_AssetId]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBalancingAdjustment_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_GetBalancingAdjustment_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBalancingAdjustment_By_CompanyId_And_YearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_GetBalancingAdjustment_By_CompanyId_And_YearId]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBalancingAdjustment_BalancingAdjustmentId_AssetId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_GetBalancingAdjustment_BalancingAdjustmentId_AssetId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Profits_And_Loss_By_Type]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Profits_And_Loss_By_Type]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Profit_And_Loss_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Profit_And_Loss_By_CompanyId_YearId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_New_Minimum_Tax_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_New_Minimum_Tax_By_CompanyId_YearId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Minimum_Tax_Percentage_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Minimum_Tax_Percentage_By_CompanyId_YearId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Investment_Allowance_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Investment_Allowance_By_CompanyId_YearId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Income_Tax_Brought_Foward_By_CompanyId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Income_Tax_Brought_Foward_By_CompanyId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_From_TrialBalanceMapping_With_TrialBalanceId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_From_TrialBalanceMapping_With_TrialBalanceId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_From_TrialBalance_With_TrialBalanceId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_From_TrialBalance_With_TrialBalanceId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Fixed_Asset_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Fixed_Asset_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId_AssetId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId_AssetId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Financial_Year_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Financial_Year_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Financial_Year_By_CompanyId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Financial_Year_By_CompanyId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Financial_Year]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Financial_Year]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Deferred_Tax_Brought_Foward_By_CompanyId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Deferred_Tax_Brought_Foward_By_CompanyId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Deferred_Fair_Value_Gain_By_CompanyId_Year]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Deferred_Fair_Value_Gain_By_CompanyId_Year]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_CompanyCode_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_CompanyCode_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Company_By_Tin]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Company_By_Tin]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Company_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Company_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Company_By_CompanyId_FinancialYearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Company_By_CompanyId_FinancialYearId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Capital_Allowance_Summary_By_CompanyId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Capital_Allowance_Summary_By_CompanyId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Capital_Allowance_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Capital_Allowance_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_BalancingAdjustmentYearBought]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_BalancingAdjustmentYearBought]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_AssetMapping_By_AssetName]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_AssetMapping_By_AssetName]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Asset_Mapping_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Asset_Mapping_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Asset_Mapping]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Asset_Mapping]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Amount_Debit]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Amount_Debit]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Amount_Credit]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Amount_Credit]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Allowable_DisAllowable_By_TrialBalanceId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Allowable_DisAllowable_By_TrialBalanceId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Allowable_DisAllowable_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Allowable_DisAllowable_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId_Allowable]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId_Allowable]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_All_PreNotification]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_All_PreNotification]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_All_Company]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Get_All_Company]
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteTrialBalance_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_DeleteTrialBalance_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Trial_Balance_Mapping]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_Trial_Balance_Mapping]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Profits_And_Loss_By_TrialBalanceId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_Profits_And_Loss_By_TrialBalanceId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_MinimumTax]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_MinimumTax]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Investment_Allowance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_Investment_Allowance]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Fixed_Asset_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_Fixed_Asset_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Financial_Year]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_Financial_Year]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Company]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_Company]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Capital_Allowance_Summary_By_AssetId_Commpany_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_Capital_Allowance_Summary_By_AssetId_Commpany_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Capital_Allowance_By_Company_Id_YearId_Asset_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_Capital_Allowance_By_Company_Id_YearId_Asset_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_BalancingAdjustmentYearBought]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_BalancingAdjustmentYearBought]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Asset_Mapping]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Delete_Asset_Mapping]
GO
/****** Object:  StoredProcedure [dbo].[usp_Assessable_Loss_UnRelieved_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[usp_Assessable_Loss_UnRelieved_By_CompanyId_YearId]
GO
/****** Object:  StoredProcedure [dbo].[Update_Capital_Allowance_From_Fixed_Asset_Or_Balancing_Adjustment]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[Update_Capital_Allowance_From_Fixed_Asset_Or_Balancing_Adjustment]
GO
/****** Object:  StoredProcedure [dbo].[Update_Capital_Allowance_By_Channel]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[Update_Capital_Allowance_By_Channel]
GO
/****** Object:  StoredProcedure [dbo].[Update_Archived_Capital_Allowance_By_Channel]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[Update_Archived_Capital_Allowance_By_Channel]
GO
/****** Object:  StoredProcedure [dbo].[Insert_Into_Deferred_Tax]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[Insert_Into_Deferred_Tax]
GO
/****** Object:  StoredProcedure [dbo].[Insert_Into_Allowable_DisAllowable]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[Insert_Into_Allowable_DisAllowable]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Fair_Gain_By_TrialBalanceId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[Delete_Fair_Gain_By_TrialBalanceId]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Allowable_DisAllowable_By_Id]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP PROCEDURE [dbo].[Delete_Allowable_DisAllowable_By_Id]
GO
ALTER TABLE [dbo].[AspNetUserTokens] DROP CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
/****** Object:  Index [UserNameIndex]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
GO
/****** Object:  Index [EmailIndex]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP INDEX [EmailIndex] ON [dbo].[AspNetUsers]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
GO
/****** Object:  Table [dbo].[UserCodes]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[UserCodes]
GO
/****** Object:  Table [dbo].[TrialBalanceMapping]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[TrialBalanceMapping]
GO
/****** Object:  Table [dbo].[TrialBalance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[TrialBalance]
GO
/****** Object:  Table [dbo].[TrackTrialBalance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[TrackTrialBalance]
GO
/****** Object:  Table [dbo].[ProfitsAndLoss]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[ProfitsAndLoss]
GO
/****** Object:  Table [dbo].[ProfitAndLossRecord]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[ProfitAndLossRecord]
GO
/****** Object:  Table [dbo].[PreNotification]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[PreNotification]
GO
/****** Object:  Table [dbo].[NewMinimumTax]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[NewMinimumTax]
GO
/****** Object:  Table [dbo].[MinimumTaxPercentage]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[MinimumTaxPercentage]
GO
/****** Object:  Table [dbo].[MinimumTax]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[MinimumTax]
GO
/****** Object:  Table [dbo].[InvestmentAllowance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[InvestmentAllowance]
GO
/****** Object:  Table [dbo].[IncomeTaxBroughtFoward]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[IncomeTaxBroughtFoward]
GO
/****** Object:  Table [dbo].[FixedAsset]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[FixedAsset]
GO
/****** Object:  Table [dbo].[FinancialYear]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[FinancialYear]
GO
/****** Object:  Table [dbo].[DeferredTaxBroughtFoward]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[DeferredTaxBroughtFoward]
GO
/****** Object:  Table [dbo].[DeferredFairValueGain]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[DeferredFairValueGain]
GO
/****** Object:  Table [dbo].[CompanyCode]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[CompanyCode]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[Company]
GO
/****** Object:  Table [dbo].[CapitalAllowanceSummary]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[CapitalAllowanceSummary]
GO
/****** Object:  Table [dbo].[CapitalAllowance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[CapitalAllowance]
GO
/****** Object:  Table [dbo].[BalancingAdjustmentYearBought]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[BalancingAdjustmentYearBought]
GO
/****** Object:  Table [dbo].[BalancingAdjustment]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[BalancingAdjustment]
GO
/****** Object:  Table [dbo].[AssetMapping]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[AssetMapping]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[AspNetUserTokens]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[AspNetRoleClaims]
GO
/****** Object:  Table [dbo].[AsessableLossUnRelieved]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[AsessableLossUnRelieved]
GO
/****** Object:  Table [dbo].[ArchivedCapitalAllowance]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[ArchivedCapitalAllowance]
GO
/****** Object:  Table [dbo].[AllowableDisAllowable]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[AllowableDisAllowable]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
USE [master]
GO
/****** Object:  Database [DB_A69507_kkdatabase]    Script Date: 17/05/2021 11:22:57 AM ******/
DROP DATABASE [DB_A69507_kkdatabase]
GO
/****** Object:  Database [DB_A69507_kkdatabase]    Script Date: 17/05/2021 11:22:57 AM ******/
CREATE DATABASE [DB_A69507_kkdatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A69507_kkdatabase_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_A69507_kkdatabase_DATA.mdf' , SIZE = 8192KB , MAXSIZE = 1024000KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'DB_A69507_kkdatabase_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_A69507_kkdatabase_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_A69507_kkdatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET  MULTI_USER 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_A69507_kkdatabase', N'ON'
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET QUERY_STORE = OFF
GO
USE [DB_A69507_kkdatabase]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17/05/2021 11:22:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AllowableDisAllowable]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllowableDisAllowable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[YearId] [int] NULL,
	[TrialBalanceId] [int] NULL,
	[SelectionId] [int] NULL,
	[IsAllowable] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArchivedCapitalAllowance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArchivedCapitalAllowance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaxYear] [varchar](10) NULL,
	[NumberOfYearsAvailable] [int] NULL,
	[OpeningResidue] [varchar](20) NULL,
	[Addition] [varchar](20) NULL,
	[Disposal] [varchar](30) NULL,
	[Initial] [varchar](30) NULL,
	[Annual] [varchar](20) NULL,
	[Channel] [varchar](10) NULL,
	[Total] [varchar](20) NULL,
	[ClosingResidue] [varchar](20) NULL,
	[YearsToGo] [varchar](20) NULL,
	[CompanyId] [int] NULL,
	[AssetId] [int] NULL,
	[CompanyCode] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsessableLossUnRelieved]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsessableLossUnRelieved](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[AssessableLoss] [decimal](18, 0) NULL,
	[UnRelievedCf] [decimal](18, 0) NULL,
	[YearId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetMapping]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AssetName] [varchar](50) NULL,
	[Initial] [int] NULL,
	[Annual] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BalancingAdjustment]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BalancingAdjustment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AssetId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Year] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_BalancingAdjustment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BalancingAdjustmentYearBought]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BalancingAdjustmentYearBought](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AssestId] [int] NOT NULL,
	[Cost] [decimal](18, 2) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[InitialAllowance] [decimal](18, 2) NOT NULL,
	[AnnualAllowance] [decimal](18, 2) NOT NULL,
	[SalesProceed] [decimal](18, 2) NOT NULL,
	[Residue] [decimal](18, 2) NOT NULL,
	[BalancingAllowance] [decimal](18, 2) NOT NULL,
	[BalancingCharge] [decimal](18, 2) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[YearBought] [nvarchar](max) NULL,
	[YearId] [int] NOT NULL,
	[BalancingAdjustmentId] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CapitalAllowance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CapitalAllowance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaxYear] [varchar](10) NULL,
	[NumberOfYearsAvailable] [int] NULL,
	[OpeningResidue] [varchar](20) NULL,
	[Addition] [varchar](20) NULL,
	[Disposal] [varchar](30) NULL,
	[Initial] [varchar](30) NULL,
	[Annual] [varchar](20) NULL,
	[Channel] [varchar](10) NULL,
	[Total] [varchar](20) NULL,
	[ClosingResidue] [varchar](20) NULL,
	[YearsToGo] [varchar](20) NULL,
	[CompanyId] [int] NULL,
	[AssetId] [int] NULL,
	[CompanyCode] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CapitalAllowanceSummary]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CapitalAllowanceSummary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OpeningResidue] [varchar](20) NULL,
	[Addition] [varchar](20) NULL,
	[Disposal] [varchar](30) NULL,
	[Initial] [varchar](30) NULL,
	[Annual] [varchar](20) NULL,
	[Total] [varchar](20) NULL,
	[ClosingResidue] [varchar](20) NULL,
	[CompanyId] [int] NULL,
	[AssetId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](200) NULL,
	[CompanyDescription] [varchar](max) NULL,
	[CacNumber] [nvarchar](max) NULL,
	[TinNumber] [nvarchar](max) NULL,
	[DateCreated] [datetime] NULL,
	[OpeningYear] [datetime] NULL,
	[ClosingYear] [datetime] NULL,
	[IsActive] [bit] NULL,
	[MonthOfOperation] [int] NULL,
	[MinimumTaxTypeId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyCode]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[Code] [varchar](20) NULL,
	[NextExecution] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeferredFairValueGain]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeferredFairValueGain](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[YearId] [int] NULL,
	[TrialBalanceId] [int] NULL,
	[SelectionId] [int] NULL,
	[DeferredFairValueGainId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeferredTaxBroughtFoward]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeferredTaxBroughtFoward](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[DeferredTaxCarriedFoward] [decimal](18, 0) NULL,
	[YearId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinancialYear]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinancialYear](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[OpeningDate] [datetime2](7) NOT NULL,
	[ClosingDate] [datetime2](7) NOT NULL,
	[CompanyId] [int] NULL,
	[FinancialDate] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixedAsset]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixedAsset](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[YearId] [int] NULL,
	[AssetId] [int] NULL,
	[OpeningCost] [varchar](30) NULL,
	[TransferCost] [varchar](30) NULL,
	[CostAddition] [varchar](20) NULL,
	[CostDisposal] [varchar](20) NULL,
	[IsTransferCostRemoved] [bit] NULL,
	[OpeningDepreciation] [varchar](20) NULL,
	[TransferDepreciation] [varchar](20) NULL,
	[DepreciationDisposal] [varchar](200) NULL,
	[DepreciationAddition] [varchar](200) NULL,
	[IsTransferDepreciationRemoved] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IncomeTaxBroughtFoward]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncomeTaxBroughtFoward](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[LossCf] [decimal](18, 0) NULL,
	[UnRelievedCf] [decimal](18, 0) NULL,
	[YearId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvestmentAllowance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestmentAllowance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Companyid] [int] NULL,
	[YearId] [int] NULL,
	[AssetId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MinimumTax]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MinimumTax](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[FinancialYearId] [int] NOT NULL,
	[GrossProfit] [nvarchar](max) NULL,
	[NetAsset] [nvarchar](max) NULL,
	[ShareCapital] [nvarchar](max) NULL,
	[TurnOver] [nvarchar](max) NULL,
	[MinimumTaxPayable] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[Revenue] [varchar](50) NULL,
 CONSTRAINT [PK_MinimumTax] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MinimumTaxPercentage]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MinimumTaxPercentage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[MinimumTaxPercentage] [decimal](10, 10) NULL,
	[YearId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewMinimumTax]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewMinimumTax](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[OtherOperatingGain] [decimal](18, 0) NULL,
	[Revenue] [decimal](18, 0) NULL,
	[OtherOperatingIncome] [decimal](18, 0) NULL,
	[YearId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreNotification]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreNotification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[OpeningDate] [datetime2](7) NOT NULL,
	[ClosingDate] [datetime2](7) NOT NULL,
	[JobDate] [datetime2](7) NULL,
	[IsLocked] [bit] NOT NULL,
 CONSTRAINT [PK_PreNotification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfitAndLossRecord]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfitAndLossRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[ProfitAndLoss] [decimal](18, 0) NULL,
	[YearId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfitsAndLoss]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfitsAndLoss](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pick] [varchar](20) NULL,
	[CompanyId] [varchar](20) NULL,
	[TrialBalanceId] [varchar](20) NULL,
	[YearId] [varchar](20) NULL,
	[TypeValue] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrackTrialBalance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackTrialBalance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[YearId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TrackTrialBalance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrialBalance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrialBalanceMapping]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrialBalanceMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrialBalanceId] [int] NOT NULL,
	[ModuleId] [int] NOT NULL,
	[ModuleCode] [varchar](max) NULL,
	[AdditionalInfo] [varchar](max) NULL,
 CONSTRAINT [PK_TrialBalanceMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCodes]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UserCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 17/05/2021 11:22:58 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 17/05/2021 11:22:58 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 17/05/2021 11:22:58 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 17/05/2021 11:22:58 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 17/05/2021 11:22:58 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 17/05/2021 11:22:58 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 17/05/2021 11:22:58 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Allowable_DisAllowable_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Delete_Allowable_DisAllowable_By_Id](
@Id int
)
AS
delete from [dbo].[AllowableDisAllowable] where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Delete_Fair_Gain_By_TrialBalanceId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Delete_Fair_Gain_By_TrialBalanceId](
@TrialBalanceId int
)
AS
delete from [dbo].[DeferredFairValueGain] where TrialBalanceId=@TrialBalanceId
GO
/****** Object:  StoredProcedure [dbo].[Insert_Into_Allowable_DisAllowable]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insert_Into_Allowable_DisAllowable](
@CompanyId int,
@YearId int,
@TrialBalanceId int,
@SelectionId int,
@IsAllowable bit
)
AS
Insert into [dbo].[AllowableDisAllowable]
(CompanyId,YearId,TrialBalanceId,SelectionId,IsAllowable)
values(@CompanyId,@YearId,@TrialBalanceId,@SelectionId,@IsAllowable)
GO
/****** Object:  StoredProcedure [dbo].[Insert_Into_Deferred_Tax]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Insert_Into_Deferred_Tax](
@CompanyId int,
@YearId int,
@TrialBalanceId int,
@SelectionId int

)
AS
Insert into [dbo].[DeferredFairValueGain] (CompanyId,YearId,TrialBalanceId,SelectionId) values(@CompanyId,@YearId,@TrialBalanceId,@SelectionId)
GO
/****** Object:  StoredProcedure [dbo].[Update_Archived_Capital_Allowance_By_Channel]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Update_Archived_Capital_Allowance_By_Channel](
@CompanyId int,
@AssetId int,
@Channel varchar(10),
@TaxYear varchar (6)
)
AS

UPDATE [dbo].[ArchivedCapitalAllowance]
set Channel=@Channel  WHERE CompanyId=@CompanyId  and AssetId=@AssetId and  TaxYear=@TaxYear
GO
/****** Object:  StoredProcedure [dbo].[Update_Capital_Allowance_By_Channel]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Update_Capital_Allowance_By_Channel](
@Id int,
@Channel varchar(10)
)
AS

UPDATE [dbo].[CapitalAllowance]
set Channel=@Channel  WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Update_Capital_Allowance_From_Fixed_Asset_Or_Balancing_Adjustment]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Update_Capital_Allowance_From_Fixed_Asset_Or_Balancing_Adjustment](
@TaxYear int,
@OpeningResidue varchar(20),
@ClosingResidue varchar(20),
@Channel varchar(10),
@Addition varchar(20),
@Disposal varchar(30),
@Annual varchar(20),
@NumberOfYearsAvailable int,
@Initial varchar(20),
@Total  varchar(20),
@YearsToGo varchar(20),
@CompanyId int,
@AssetId int,
@CompanyCode varchar(20)

)
AS

UPDATE [dbo].[CapitalAllowance]
set OpeningResidue=@OpeningResidue, Disposal=@Disposal,CompanyCode=@CompanyCode,ClosingResidue=@ClosingResidue ,NumberOfYearsAvailable=@NumberOfYearsAvailable,Addition=@Addition,Annual=@Annual, Initial=@Initial,Total=@Total,YearsToGo=@YearsToGo ,Channel=@Channel  WHERE CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear
GO
/****** Object:  StoredProcedure [dbo].[usp_Assessable_Loss_UnRelieved_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Assessable_Loss_UnRelieved_By_CompanyId_YearId](
    @CompanyId int,@YearId int)
   
AS
SELECT *
FROM [dbo].[AsessableLossUnRelieved]
WHERE CompanyId=@CompanyId AND YearId=@YearId
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Asset_Mapping]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Delete_Asset_Mapping](
  @Id INT
)
AS
DELETE [dbo].[AssetMapping] WHERE  Id = @Id  
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_BalancingAdjustmentYearBought]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Delete_BalancingAdjustmentYearBought](
    @Id INT
)
AS
DELETE FROM [dbo].[BalancingAdjustmentYearBought]
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Capital_Allowance_By_Company_Id_YearId_Asset_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Delete_Capital_Allowance_By_Company_Id_YearId_Asset_Id](
@AssetId int,
@Year int,
@CompanyId int
)
AS
declare @FixedAssetId as int
select @FixedAssetId=Id from [dbo].[FixedAsset] where AssetId=@AssetId and YearId=@Year and CompanyId=@CompanyId
UPDATE [dbo].[TrialBalance] SET MappedTo = null,IsCheck=0,IsRemoved=0 WHERE Id IN (SELECT TrialBalanceId FROM [dbo].[TrialBalanceMapping] where ModuleId=@FixedAssetId);
delete from [dbo].[TrialBalanceMapping] where ModuleId=@FixedAssetId
Delete from [dbo].[BalancingAdjustmentYearBought] where AssestId=@AssetId and YearBought=@Year and CompanyId=@CompanyId
Delete from [dbo].[ArchivedCapitalAllowance] where AssetId=@AssetId and TaxYear=@Year and CompanyId=@CompanyId
Delete from [dbo].[CapitalAllowance] where AssetId=@AssetId and TaxYear=@Year and CompanyId=@CompanyId
Delete from [dbo].[FixedAsset] where AssetId=@AssetId and YearId=@Year and CompanyId=@CompanyId
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Capital_Allowance_Summary_By_AssetId_Commpany_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Delete_Capital_Allowance_Summary_By_AssetId_Commpany_Id](
@CompanyId int,
@AssetId int
)
AS

Delete from [dbo].[CapitalAllowanceSummary] where AssetId=@AssetId and CompanyId=@CompanyId
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Company]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Delete_Company](
  @Id INT
)
AS
DELETE [dbo].[Company] WHERE  Id = @Id  
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Financial_Year]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Delete_Financial_Year](
  @CompanyId int
)
AS
-- Update rows in table 'TableName'
DELETE FROM [dbo].[FinancialYear] WHERE 	CompanyId = @CompanyId
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Fixed_Asset_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Delete_Fixed_Asset_By_Id](
@Id int
)
AS
declare @companyId as int
declare @assetId as int
declare @yearId as int
select @yearId=YearId ,@assetId=AssetId ,@companyId=CompanyId from [dbo].[FixedAsset] where Id=@Id
delete from [dbo].[BalancingAdjustmentYearBought] where CompanyId=@companyId and YearBought=@yearId and AssestId=@assetId
delete from [dbo].[CapitalAllowance] where CompanyId=@companyId and TaxYear=@yearId and AssetId=@assetId
delete from [dbo].[CapitalAllowanceSummary] where CompanyId=@companyId  and AssetId=@assetId
delete from [dbo].[ArchivedCapitalAllowance] where CompanyId=@companyId and TaxYear=@yearId and AssetId=@assetId
delete from   [dbo].[FixedAsset] where Id=@Id
UPDATE [dbo].[TrialBalance] SET MappedTo = null,IsCheck=0,IsRemoved=0 WHERE Id IN (SELECT TrialBalanceId FROM [dbo].[TrialBalanceMapping] where ModuleId=@Id);
delete from[dbo].[TrialBalanceMapping] where ModuleId=@Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Investment_Allowance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Delete_Investment_Allowance](
  @Id INT
)
AS
DELETE from  [dbo].[InvestmentAllowance] WHERE  Id = @Id  
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_MinimumTax]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Delete_MinimumTax](
    @Id INT
)
AS
DELETE FROM [dbo].[BalancingAdjustmentYearBought]
WHERE Id = @Id

GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Profits_And_Loss_By_TrialBalanceId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Delete_Profits_And_Loss_By_TrialBalanceId](
@TrialBalanceId varchar(20)
)
AS
delete  from [dbo].[ProfitsAndLoss] where TrialBalanceId=@TrialBalanceId
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Trial_Balance_Mapping]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Delete_Trial_Balance_Mapping](
	@Id INT
)
AS
DELETE FROM [dbo].[TrialBalanceMapping] WHERE TrialBalanceId = @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteTrialBalance_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_DeleteTrialBalance_By_Id](
@TrailId int
)
AS
DELETE FROM [dbo].[TrialBalance] WHERE Id=@TrailId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_All_Company]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_All_Company]
AS

select * from  [dbo].[Company]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_All_PreNotification]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Get_All_PreNotification]
AS
SELECT *
FROM [dbo].[PreNotification]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId](
@YearId int,
@CompanyId int

)
AS
select  [dbo].[AllowableDisAllowable].Id, [dbo].[TrialBalance].Item
,[dbo].[TrialBalance].Debit,[dbo].[TrialBalance].Credit,SelectionId,IsAllowable
from [dbo].[AllowableDisAllowable] inner join [dbo].[TrialBalance] on
[dbo].[AllowableDisAllowable].TrialBalanceId=[dbo].[TrialBalance].Id
where CompanyId=@CompanyId and @YearId=YearId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId_Allowable]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure
[dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId_Allowable](
@CompanyId int,
@YearId int,
@IsAllowable bit


)
AS

select  [dbo].[AllowableDisAllowable].Id, [dbo].[TrialBalance].Item
,[dbo].[TrialBalance].Debit,[dbo].[TrialBalance].Credit,SelectionId,IsAllowable
from [dbo].[AllowableDisAllowable] inner join [dbo].[TrialBalance] on
[dbo].[AllowableDisAllowable].TrialBalanceId=[dbo].[TrialBalance].Id
where CompanyId=@CompanyId and @YearId=YearId and
IsAllowable=@IsAllowable

GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Allowable_DisAllowable_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_Allowable_DisAllowable_By_Id](
@Id int


)
AS
 select * from [dbo].[AllowableDisAllowable] where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Allowable_DisAllowable_By_TrialBalanceId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_Allowable_DisAllowable_By_TrialBalanceId](
@TrialBalanceId int


)
AS
 select * from [dbo].[AllowableDisAllowable] where
TrialBalanceId=@TrialBalanceId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Amount_Credit]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_Get_Amount_Debit]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId_And_AssetId_And_Year](
@AssetId int,
@CompanyId int,
@Year varchar(20)
)
AS

select  TaxYear,OpeningResidue,Addition,Disposal,Initial,Annual,Total,ClosingResidue,YearsToGo,NumberOfYearsAvailable,CompanyCode,Channel,CompanyId,AssetId from [dbo].[ArchivedCapitalAllowance] where CompanyId=@CompanyId AND AssetId=@AssetId AND TaxYear=@Year
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Asset_Mapping]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Asset_Mapping]
AS

select *
from [dbo].[AssetMapping] 
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Asset_Mapping_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Asset_Mapping_By_Id](
  @Id int
)
AS

select *
from [dbo].[AssetMapping]
where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_AssetMapping_By_AssetName]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_AssetMapping_By_AssetName](
  @AssetName varchar(50)
)
AS

select *
from [dbo].[AssetMapping]
where AssetName = @AssetName
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_BalancingAdjustmentYearBought]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_BalancingAdjustmentYearBought](
@Id INT
)
AS

SELECT Id,AssestId,Cost,InitialAllowance,AnnualAllowance,SalesProceed,Residue,BalancingAllowance,BalancingCharge,DateCreated,YearBought,BalancingAdjustmentId,YearId from [dbo].[BalancingAdjustmentYearBought] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId](
@AssetId int,
@CompanyId int

)
AS

select  [dbo].[CapitalAllowance].Id,[dbo].[FinancialYear].Name As TaxYear,[dbo].[FinancialYear].Id As YearId,OpeningResidue,Addition,Disposal,Initial,Annual,Total,ClosingResidue,YearsToGo,NumberOfYearsAvailable,CompanyCode,Channel,[dbo].[CapitalAllowance].CompanyId,AssetId from [dbo].[CapitalAllowance] inner join [dbo].[FinancialYear]on [dbo].[CapitalAllowance].TaxYear=[FinancialYear].Id  where [dbo].[CapitalAllowance].CompanyId=@CompanyId AND AssetId=@AssetId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId_And_Year](
@AssetId int,
@CompanyId int,
@Year varchar(20)
)
AS

select  Id,TaxYear,OpeningResidue,Addition,Disposal,Initial,Annual,Total,ClosingResidue,YearsToGo,NumberOfYearsAvailable,CompanyCode,Channel,CompanyId,AssetId from [dbo].[CapitalAllowance] where CompanyId=@CompanyId AND AssetId=@AssetId AND TaxYear=@Year
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Capital_Allowance_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Capital_Allowance_By_Id](
@CapitalAllowanceId int
)
AS
select * from [dbo].[CapitalAllowance] where Id=@CapitalAllowanceId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Capital_Allowance_Summary_By_CompanyId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Capital_Allowance_Summary_By_CompanyId](
@CompanyId int
)
AS
select [dbo].[AssetMapping].AssetName as AssetName,OpeningResidue,Addition,Disposal,[dbo].[CapitalAllowanceSummary].Initial,[dbo].[CapitalAllowanceSummary].Annual,Total,ClosingResidue from [dbo].[CapitalAllowanceSummary]  inner join [dbo].[AssetMapping] on [dbo].[CapitalAllowanceSummary].AssetId=[dbo].[AssetMapping].Id where CompanyId=@CompanyId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Company_By_CompanyId_FinancialYearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_Company_By_CompanyId_FinancialYearId](


@CompanyId int,
@FinancialYearId int

)
AS

SELECT
  [dbo].[Company].CompanyName,
  [dbo].[FinancialYear].Name,
  [dbo].[FinancialYear].OpeningDate,
  [dbo].[FinancialYear].ClosingDate,
  [dbo].[FinancialYear].FinancialDate
from [dbo].[Company] inner join [dbo].[FinancialYear] on
[dbo].[FinancialYear].CompanyId = [dbo].[Company].Id
where [FinancialYear].CompanyId = @CompanyId and [FinancialYear].Id=@FinancialYearId

GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Company_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_Company_By_Id](
@Id int

)
AS

select * from  [dbo].[Company] where  [dbo].[Company].Id=@Id

GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Company_By_Tin]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_Company_By_Tin](
@TinNumber varchar(50)

)
AS

select * from  [dbo].[Company] where  [dbo].[Company].TinNumber=@TinNumber

GO
/****** Object:  StoredProcedure [dbo].[usp_Get_CompanyCode_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_CompanyCode_By_Id](
  @CompanyId int
)
AS

select *
from [dbo].[CompanyCode]
where CompanyId = @CompanyId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Deferred_Fair_Value_Gain_By_CompanyId_Year]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Deferred_Fair_Value_Gain_By_CompanyId_Year](
@CompanyId int,
@YearId int
)
AS

select  [dbo].[DeferredFairValueGain].Id, [dbo].[TrialBalance].Item ,[dbo].[TrialBalance].Debit,[dbo].[TrialBalance].Credit,SelectionId from [dbo].[DeferredFairValueGain] inner join [dbo].[TrialBalance] on [dbo].[DeferredFairValueGain].TrialBalanceId=[dbo].[TrialBalance].Id where CompanyId=@CompanyId and @YearId=YearId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Deferred_Tax_Brought_Foward_By_CompanyId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Deferred_Tax_Brought_Foward_By_CompanyId](
@CompanyId int

)
AS
select  * from  [dbo].[DeferredTaxBroughtFoward] where CompanyId=@CompanyId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Financial_Year]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_Financial_Year]
AS
select *
from [dbo].[FinancialYear]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Financial_Year_By_CompanyId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_Financial_Year_By_CompanyId](
  @CompanyId int
)
AS

select *
from [dbo].[FinancialYear]
where CompanyId = @CompanyId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Financial_Year_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_Financial_Year_By_Id](
  @Id int
)
AS

select *
from [dbo].[FinancialYear]
where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId](
@CompanyId int,
@YearId int
)
AS

select [dbo].[FixedAsset].Id,[dbo].[Company].CompanyName AS CompanyName,[dbo].[FinancialYear].Name AS YearName,[dbo].[AssetMapping].AssetName As FixedAssetName,OpeningCost,CostAddition,CostDisposal,OpeningDepreciation,DepreciationAddition,DepreciationDisposal,TransferCost,TransferDepreciation,IsTransferCostRemoved,IsTransferDepreciationRemoved  from [dbo].[FixedAsset] inner join [dbo].[FinancialYear] on [dbo].[FixedAsset].YearId=[dbo].[FinancialYear].Id
inner join [dbo].[AssetMapping] on [dbo].[FixedAsset].AssetId=[dbo].[AssetMapping].Id
inner join [dbo].[Company] on [dbo].[FixedAsset].CompanyId= [dbo].[Company].Id
where [dbo].[FixedAsset].CompanyId=@CompanyId and [dbo].[FixedAsset].YearId=@YearId
order by Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId_AssetId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId_AssetId](
@CompanyId int,
@YearId int,
@AssetId int
)
AS
select * from   [dbo].[FixedAsset] where CompanyId=@CompanyId and AssetId=@AssetId and YearId=@YearId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Fixed_Asset_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Fixed_Asset_By_Id](
@Id int
)
AS

select  * from [dbo].[FixedAsset]
where Id=@Id
order by Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_From_TrialBalance_With_TrialBalanceId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_From_TrialBalance_With_TrialBalanceId](
  @TrialBalanceId int
)
AS

select *
from [dbo].[TrialBalance]
where Id = @TrialBalanceId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_From_TrialBalanceMapping_With_TrialBalanceId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_From_TrialBalanceMapping_With_TrialBalanceId](
  @TrialBalanceId int
)
AS

select *
from [dbo].[TrialBalanceMapping]
where TrialBalanceId = @TrialBalanceId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Income_Tax_Brought_Foward_By_CompanyId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Get_Income_Tax_Brought_Foward_By_CompanyId](
@CompanyId int

)
AS
select  * from  [dbo].[IncomeTaxBroughtFoward] where CompanyId=@CompanyId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Investment_Allowance_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Investment_Allowance_By_CompanyId_YearId](
  @CompanyId INT,
  @YearId  int 
)
AS
select * from  [dbo].[InvestmentAllowance] where CompanyId=@CompanyId and YearId=@YearId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Minimum_Tax_Percentage_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Get_Minimum_Tax_Percentage_By_CompanyId_YearId](
    @CompanyId int,@YearId int)
   
AS
SELECT *
FROM [dbo].[MinimumTaxPercentage]
WHERE CompanyId=@CompanyId AND YearId=@YearId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_New_Minimum_Tax_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Get_New_Minimum_Tax_By_CompanyId_YearId](
    @CompanyId int,@YearId int)
   
AS
SELECT *
FROM [dbo].[NewMinimumTax]
WHERE CompanyId=@CompanyId AND YearId=@YearId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Profit_And_Loss_By_CompanyId_YearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Get_Profit_And_Loss_By_CompanyId_YearId](
    @CompanyId int,@YearId int)
   
AS
SELECT *
FROM [dbo].[ProfitAndLossRecord]
WHERE CompanyId=@CompanyId AND YearId=@YearId
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Profits_And_Loss_By_Type]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Get_Profits_And_Loss_By_Type](
@TypeValue varchar(20),
@CompanyId int,
@YearId int
)
AS
SELECT  Debit,Credit,Pick FROM [dbo].[ProfitsAndLoss] inner join [dbo].[TrialBalance]  
on [dbo].[ProfitsAndLoss].TrialBalanceId =[dbo].[TrialBalance].Id  
where YearId=@YearId and CompanyId=@CompanyId and TypeValue=@TypeValue
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBalancingAdjustment_BalancingAdjustmentId_AssetId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetBalancingAdjustment_BalancingAdjustmentId_AssetId](
    @AssetId nvarchar(max),
    @BalancingAdjustmentId int
)
AS
SELECT [dbo].[BalancingAdjustmentYearBought].Id,AssestId,Cost,InitialAllowance,AnnualAllowance,SalesProceed,Residue,BalancingAllowance,BalancingCharge,DateCreated,[dbo].[FinancialYear].Name As YearBought,BalancingAdjustmentId
FROM [dbo].[BalancingAdjustmentYearBought]
 inner join [dbo].[FinancialYear]on [dbo].[BalancingAdjustmentYearBought].YearBought=[FinancialYear].Id  WHERE AssestId=@AssetId AND BalancingAdjustmentId=@BalancingAdjustmentId
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBalancingAdjustment_By_CompanyId_And_YearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_GetBalancingAdjustment_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetBalancingAdjustment_By_Id](
    @Id int)
   
AS
SELECT *
FROM [dbo].[BalancingAdjustment]
WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBalancingAdjustment_YearBought_AssetId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetBalancingAdjustment_YearBought_AssetId](
    @AssetId nvarchar(max),
    @YearBought int
)
AS
SELECT AssestId,Cost,InitialAllowance,AnnualAllowance,SalesProceed,Residue,BalancingAllowance,BalancingCharge,DateCreated,[dbo].[FinancialYear].Name As YearBought,BalancingAdjustmentId
FROM [dbo].[BalancingAdjustmentYearBought]
inner join [dbo].[FinancialYear] on [dbo].[BalancingAdjustmentYearBought].YearBought=[FinancialYear].Id
WHERE AssestId=@AssetId AND YearBought=@YearBought
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBalancingAdjustmentBought_By_Year_Asset_YearBought]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetBalancingAdjustmentBought_By_Year_Asset_YearBought](
    @YearId int,@YearBought int,@AssetId int)
   
AS
SELECT *
FROM [dbo].[BalancingAdjustmentYearBought]
WHERE YearId=@YearId and AssestId=@AssetId and YearBought=@YearBought
GO
/****** Object:  StoredProcedure [dbo].[usp_GetMinimum_By_CompanyId_And_YearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_GetTrackTrialBalance_By_CompanyId_And_YearId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetTrackTrialBalance_By_CompanyId_And_YearId](
@YearId int,
@CompanyId int
)
AS
SELECT * FROM [dbo].[TrackTrialBalance] WHERE CompanyId=@CompanyId AND YearId=@YearId
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTrialBalance_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetTrialBalance_By_Id](
@TrailId int
)
AS
SELECT * FROM [dbo].[TrialBalance] WHERE Id=@TrailId
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTrialBalance_By_TrackingId]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetTrialBalance_By_TrackingId](
@TrackId int
)
AS
SELECT * FROM [dbo].[TrialBalance] WHERE TrackId=@TrackId
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Archived_Capital_Allowance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Insert_Archived_Capital_Allowance](
@AssetId int,
@CompanyId int,
@TaxYear   varchar(10),
@NumberOfYearsAvailable int,
@OpeningResidue  varchar(20),
@Channel      varchar(10),
@Addition   varchar(20),
@Disposal   varchar(30),
@Initial  varchar (30),
@Annual    varchar(20),
@Total    varchar(20),
@ClosingResidue varchar(20),
@YearsToGo varchar(20),
@CompanyCode varchar(20)
)
AS

IF   exists (select * from [dbo].[ArchivedCapitalAllowance] where CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear )
BEGIN
update [dbo].[ArchivedCapitalAllowance] set TaxYear=@TaxYear,OpeningResidue=@OpeningResidue,Addition=@Addition,Disposal=@Disposal,Initial=@Initial,
Annual=@Annual,NumberOfYearsAvailable=@NumberOfYearsAvailable,Total=@Total,ClosingResidue=@ClosingResidue,YearsToGo=@YearsToGo,CompanyId=@CompanyId,
AssetId=@AssetId , CompanyCode=@CompanyCode, Channel=@Channel
where CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear
END
ELSE
BEGIN
INSERT [dbo].[ArchivedCapitalAllowance](
 TaxYear,
 OpeningResidue,
 Addition,
 Disposal,
 Initial,
 Annual,
 Total,
 ClosingResidue,
 YearsToGo,
 CompanyId,
 AssetId,
 CompanyCode,
 NumberOfYearsAvailable,
 Channel
)
VALUES(
 @TaxYear,
 @OpeningResidue,
 @Addition,
 @Disposal,
 @Initial,
 @Annual,
 @Total,
 @ClosingResidue,
 @YearsToGo,
 @CompanyId,
 @AssetId,
 @CompanyCode,
 @NumberOfYearsAvailable,
 @Channel
)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Asessable_UnRelieved_Table]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Insert_Asessable_UnRelieved_Table](
    @Id int,
    @CompanyId int,
    @YearId int,
    @AssessableLoss decimal,
    @UnRelievedCf decimal 
)
AS
if exists (select * from AsessableLossUnRelieved where CompanyId=@CompanyId  and YearId =@YearId)
begin
 update [dbo].[AsessableLossUnRelieved] set AssessableLoss=@AssessableLoss ,UnRelievedCf=@UnRelievedCf
end
else
INSERT [dbo].[AsessableLossUnRelieved]
(
    CompanyId,
    YearId,
    AssessableLoss,
    UnRelievedCf  
)
VALUES
(
    @CompanyId,
    @YearId,
    @AssessableLoss,
    @UnRelievedCf  
    
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Asset_Mapping]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Insert_Asset_Mapping](
  @AssetName VARCHAR(50),
  @Initial   INT,
  @Annual  INT
)
AS

INSERT [dbo].[AssetMapping]
(
    AssetName,
    Initial,
    Annual
)
VALUES
(
    @AssetName,
    @Initial,
    @Annual
)
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Balance_Adjustment]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_Insert_Balance_Adjustment_YearBought]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Insert_Balance_Adjustment_YearBought](
    @AssestId int,
    @Cost decimal(18, 2),
    @YearId int,
    @CompanyId int,
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
if exists (select * from BalancingAdjustmentYearBought where AssestId=@AssestId and YearBought=@YearBought and YearId=@YearId)
begin
UPDATE  [dbo].[BalancingAdjustmentYearBought] set AssestId=@AssestId,Cost=@Cost , InitialAllowance=@InitialAllowance,SalesProceed=@SalesProceed,YearId=@YearId,
Residue=@Residue,BalancingCharge=@BalancingCharge,BalancingAllowance=@BalancingAllowance,DateCreated=@DateCreated,Yearbought=@Yearbought,BalancingAdjustmentId=@BalancingAdjustmentId
end
else
INSERT [dbo].[BalancingAdjustmentYearBought]
(
    AssestId,
    Cost,
    CompanyId,
    InitialAllowance,
    AnnualAllowance,
    SalesProceed,
    Residue,
    BalancingAllowance,
    BalancingCharge,
    DateCreated,
    YearBought,
    YearId,
    BalancingAdjustmentId
)
VALUES
(
    @AssestId,
    @Cost,
    @CompanyId,
    @InitialAllowance,
    @AnnualAllowance,
    @SalesProceed,
    @Residue,
    @BalancingAllowance,
    @BalancingCharge,
    @DateCreated,
    @YearBought,
    @YearId,
    @BalancingAdjustmentId
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Capital_Allowance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Insert_Capital_Allowance](
@AssetId int,
@CompanyId int,
@TaxYear   varchar(10),
@NumberOfYearsAvailable int,
@OpeningResidue  varchar(20),
@Channel      varchar(10),
@Addition   varchar(20),
@Disposal   varchar(30),
@Initial  varchar (30),
@Annual    varchar(20),
@Total    varchar(20),
@ClosingResidue varchar(20),
@YearsToGo varchar(20),
@CompanyCode varchar(20)
)
AS

IF   exists (select * from [dbo].[CapitalAllowance] where CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear )
BEGIN
update [dbo].[CapitalAllowance] set TaxYear=@TaxYear,OpeningResidue=@OpeningResidue,Addition=@Addition,Disposal=@Disposal,Initial=@Initial,
Annual=@Annual,NumberOfYearsAvailable=@NumberOfYearsAvailable,Total=@Total,ClosingResidue=@ClosingResidue,YearsToGo=@YearsToGo,CompanyId=@CompanyId,
AssetId=@AssetId , CompanyCode=@CompanyCode, Channel=@Channel
where CompanyId=@CompanyId and AssetId=@AssetId and TaxYear=@TaxYear
END
ELSE
BEGIN
INSERT [dbo].[CapitalAllowance](
 TaxYear,
 OpeningResidue,
 Addition,
 Disposal,
 Initial,
 Annual,
 Total,
 ClosingResidue,
 YearsToGo,
 CompanyId,
 AssetId,
 CompanyCode,
 NumberOfYearsAvailable,
 Channel
)
VALUES(
 @TaxYear,
 @OpeningResidue,
 @Addition,
 @Disposal,
 @Initial,
 @Annual,
 @Total,
 @ClosingResidue,
 @YearsToGo,
 @CompanyId,
 @AssetId,
 @CompanyCode,
 @NumberOfYearsAvailable,
 @Channel
)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Capital_Allowance_Summary]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Insert_Capital_Allowance_Summary](
 @OpeningResidue  varchar(20),
 @Addition   varchar(20),
 @Disposal   varchar(30),
 @Initial  varchar (30),
 @Annual    varchar(20),
 @Total    varchar(20),
 @ClosingResidue varchar(20),
 @CompanyId int,
 @AssetId  int
)
AS

IF   exists (select * from [dbo].[CapitalAllowanceSummary] where CompanyId=@CompanyId and AssetId=@AssetId)
BEGIN
update [dbo].[CapitalAllowanceSummary] set OpeningResidue=@OpeningResidue,Addition=@Addition,Disposal=@Disposal,Initial=@Initial,
Annual=@Annual,Total=@Total,ClosingResidue=@ClosingResidue,CompanyId=@CompanyId,
AssetId=@AssetId
where CompanyId=@CompanyId and AssetId=@AssetId
END
ELSE
BEGIN
INSERT [dbo].[CapitalAllowanceSummary](
 OpeningResidue,
 Addition ,
 Disposal,
 Initial,
 Annual,
 Total,
 ClosingResidue,
 CompanyId,
 AssetId
)
VALUES(
 @OpeningResidue,
 @Addition ,
 @Disposal,
 @Initial,
 @Annual,
 @Total,
 @ClosingResidue,
 @CompanyId,
 @AssetId
)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Company]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Insert_Company](
@CompanyName varchar(200),
@CompanyDescription varchar(200),
@CacNumber nvarchar(max) null,
@TinNumber nvarchar(max)null,
@DateCreated datetime  null,
@OpeningYear datetime  null,
@ClosingYear datetime  null,
@MinimumTaxTypeId int null, 
@IsActive bit null,
@MonthOfOperation int  null
)
AS

INSERT [dbo].[Company](

CompanyName,
CompanyDescription,
CacNumber,
TinNumber,
DateCreated,
OpeningYear,
ClosingYear,
MinimumTaxTypeId,
IsActive,
MonthOfOperation
)
values(

@CompanyName,
@CompanyDescription,
@CacNumber,
@TinNumber,
@DateCreated,
@OpeningYear,
@ClosingYear,
@MinimumTaxTypeId,
@IsActive,
@MonthOfOperation
)

GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Financial_Year]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Insert_Financial_Year](
  @Name varchar(50),
  @OpeningDate datetime2,
  @ClosingDate datetime2,
  @FinancialDate varchar(30),
  @CompanyId int
)
AS
INSERT [dbo].[FinancialYear]
  (
  Name,
  OpeningDate,
  ClosingDate,
  FinancialDate,
  CompanyId
  )
VALUES(
    @Name,
    @OpeningDate,
    @ClosingDate,
    @FinancialDate,
    @CompanyId
)
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Fixed_Asset]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_Insert_Fixed_Asset](
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
 @type varchar (20),
 @IsTransferDepreciationRemoved bit
)
AS

if exists(select * from FixedAsset where CompanyId=@CompanyId and YearId=@YearId and  AssetId=@AssetId)
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
TransferDepreciation=@TransferDepreciation,IsTransferDepreciationRemoved=@IsTransferDepreciationRemoved
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
@IsTransferDepreciationRemoved
)
end
end
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Into_Company_Code_Table]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Insert_Into_Company_Code_Table](
@CompanyId INT,
@NextExecution   DateTime,
@Code  varchar(20)
)
AS
if  exists(select * from [dbo].[CompanyCode] where CompanyId=@CompanyId)
BEGIN
UPDATE [dbo].[CompanyCode] SET Code=@Code , NextExecution=@NextExecution where CompanyId=@CompanyId
END
ELSE
BEGIN
INSERT [dbo].CompanyCode
(
 CompanyId,
 NextExecution,
 Code
)
VALUES
(
 @CompanyId,
 @NextExecution,
 @Code
)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Into_DeferredTax_Brought_Foward]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Insert_Into_DeferredTax_Brought_Foward](

@CompanyId int,
@DeferredTaxCarriedFoward decimal,
@YearId int
)
AS


if exists(select * from DeferredTaxBroughtFoward where CompanyId=@CompanyId and YearId=@YearId)
BEGIN
UPDATE [dbo].[DeferredTaxBroughtFoward]
SET CompanyId = @CompanyId, YearId = @YearId,DeferredTaxCarriedFoward=@DeferredTaxCarriedFoward
WHERE CompanyId=@CompanyId and YearId=@YearId
end
else
INSERT [dbo].[DeferredTaxBroughtFoward](
CompanyId,
DeferredTaxCarriedFoward,
YearId 
)
VALUES(
@CompanyId,
@DeferredTaxCarriedFoward,
@YearId 
)
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Into_Income_Tax_Brought_Foward]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Insert_Into_Income_Tax_Brought_Foward](

@CompanyId int,
@LossCf decimal,
@UnRelievedCf decimal,
@YearId int
)
AS

if exists(select * from IncomeTaxBroughtFoward where
CompanyId=@CompanyId and YearId=@YearId)
BEGIN
UPDATE [dbo].[IncomeTaxBroughtFoward]
SET CompanyId = @CompanyId, YearId =
@YearId,LossCf=@LossCf,UnRelievedCf=@UnRelievedCf
WHERE CompanyId=@CompanyId and YearId=@YearId
end
else
INSERT [dbo].[IncomeTaxBroughtFoward](
CompanyId,
LossCf,
UnRelievedCf,
YearId
)
VALUES(
@CompanyId,
@LossCf,
@UnRelievedCf,
@YearId
)
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Investment_Allowance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Insert_Investment_Allowance](
  @CompanyId INT,
  @YearId   INT,
  @AssetId  INT
)
AS

INSERT [dbo].[InvestmentAllowance]
(
    CompanyId,
    YearId,
    AssetId
)
VALUES
(
    @CompanyId,
    @YearId,
    @AssetId
)
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Minimum_Tax]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Insert_Minimum_Tax](
    @Id int,
    @CompanyId int,
    @FinancialYearId int,
    @GrossProfit varchar(50),
    @NetAsset varchar(50),
    @ShareCapital varchar(50),
    @TurnOver varchar(50),
    @Revenue varchar(50),
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
    Revenue,
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
    @Revenue,
    @MinimumTaxPayable,
    @DateCreated
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Minimum_Tax_Percentage_Table]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Insert_Minimum_Tax_Percentage_Table](
    @Id int,
    @CompanyId int,
    @YearId int,
    @MinimumTaxPercentage varchar(30)
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
/****** Object:  StoredProcedure [dbo].[usp_Insert_New_Minimum_Tax_Table]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Insert_New_Minimum_Tax_Table](
 @CompanyId int ,
 @OtherOperatingGain decimal,
 @Revenue decimal,
 @OtherOperatingIncome decimal,
 @YearId int
    
)
AS
if exists (select * from NewMinimumTax where CompanyId=@CompanyId  and YearId =@YearId)
begin
 update [dbo].[NewMinimumTax] set OtherOperatingGain=@OtherOperatingGain ,Revenue=@Revenue,OtherOperatingIncome=@OtherOperatingIncome
end
else
INSERT [dbo].[NewMinimumTax]
(
 CompanyId,
 OtherOperatingGain,
 Revenue,
 OtherOperatingIncome,
 YearId
)
VALUES
(
 @CompanyId,
 @OtherOperatingGain,
 @Revenue,
 @OtherOperatingIncome,
 @YearId
)
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_PreNotification]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Insert_PreNotification](
    @Id int out,
    @CompanyId int,
    @OpeningDate datetime2 (7),
    @ClosingDate datetime2 (7),
    @IsLocked bit

)
AS

INSERT [dbo].[PreNotification]
(
    CompanyId,
    OpeningDate,
    ClosingDate,
    IsLocked
)
VALUES
(
    @CompanyId,
    @OpeningDate,
    @ClosingDate,
    @IsLocked
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Profit_And_Loss_Record_Table]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Insert_Profit_And_Loss_Record_Table](
    @Id int,
    @CompanyId int,
    @YearId int,
    @ProfitAndLoss varchar(50)
)
AS
if exists (select * from ProfitAndLossRecord where CompanyId=@CompanyId  and YearId =@YearId)
begin
 update [dbo].[ProfitAndLossRecord] set ProfitAndLoss=@ProfitAndLoss
end
else
INSERT [dbo].[ProfitAndLossRecord]
(
    CompanyId,
    YearId,
    ProfitAndLoss
)
VALUES
(
    @CompanyId,
    @YearId,
    @ProfitAndLoss
   
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Profits_And_Loss]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Insert_Profits_And_Loss](
    @Id int OUTPUT,
    @Pick varchar(10),
    @CompanyId varchar(20),
    @TrialBalanceId int,
    @YearId varchar(20),
    @TypeValue varchar(20)

)
AS

INSERT [dbo].[ProfitsAndLoss]
(
   Pick,
    CompanyId ,
    TrialBalanceId,
    YearId ,
    TypeValue
   
)
VALUES
(    @Pick,
    @CompanyId,
    @TrialBalanceId,
    @YearId,
    @TypeValue
)
SET @Id = SCOPE_IDENTITY()
SELECT @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_Track_Trial_Balance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Insert_Track_Trial_Balance](
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
/****** Object:  StoredProcedure [dbo].[usp_Insert_Trial_Balance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Insert_Trial_Balance](
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
/****** Object:  StoredProcedure [dbo].[usp_Insert_Trial_Balance_Mapping]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_Lock]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_MinimumTax_By_Id]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MinimumTax_By_Id](
    @Id int)
   
AS
SELECT *
FROM [dbo].[MinimumTax]
WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Asset_Mapping]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Update_Asset_Mapping](
  @Id INT,
  @AssetName varchar(50),
  @Initial   int,
  @Annual  int
)
AS
UPDATE [dbo].[AssetMapping]  
  SET 
    AssetName = @AssetName,  
    Initial = @Initial,  
    Annual = @Annual
  WHERE  Id = @Id  
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Company]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Update_Company](
@Id int,
@CompanyName varchar(200),
@CompanyDescription varchar(200),
@CacNumber nvarchar(max) null,
@TinNumber nvarchar(max)null,
@MinimumTaxTypeId int null
)
AS
Update [dbo].[Company]
set CompanyName = @CompanyName,
CompanyDescription = @CompanyDescription,
CacNumber = @CacNumber,
TinNumber = @TinNumber,
MinimumTaxTypeId = @MinimumTaxTypeId
where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Company_Closing_OpeningDate]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Update_Company_Closing_OpeningDate](
@Id int,
@OpeningDate datetime,
@ClosingDate datetime

)
AS
Update [dbo].[Company]
set OpeningYear = @OpeningDate,
ClosingYear = @ClosingDate
where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Financial_Year]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Update_Financial_Year](
  @Id int,
  @Name varchar(50),
  @OpeningDate datetime2,
  @ClosingDate datetime2,
  @FinancialDate varchar(30),
  @CompanyId int
)
AS
-- Update rows in table 'TableName'
UPDATE [dbo].[FinancialYear]
SET
    Name = @Name,
    OpeningDate = @OpeningDate,
    ClosingDate = @ClosingDate,
    FinancialDate = @FinancialDate,
    CompanyId = @CompanyId
  -- add more columns and values here
WHERE 	Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Jobdate_To_Null]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_Update_MinimumTax]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Update_MinimumTax](
    @Id int,
    @GrossProfit varchar(50),
    @NetAsset varchar(50),
    @ShareCapital varchar(50),
    @TurnOver varchar(50),
    @Revenue varchar(50),
    @MinimumTaxPayable varchar(50)
)
AS

UPDATE [dbo].[MinimumTax]
SET GrossProfit = @GrossProfit,
    NetAsset = @NetAsset,
    ShareCapital=@ShareCapital,
    TurnOver=@TurnOver,
    Revenue = @Revenue,
    MinimumTaxPayable = @MinimumTaxPayable
WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdatePreNotification]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_UpdatePreNotification](
    @Id INT,
    @OpeningDate datetime2 (7),
    @ClosingDate datetime2 (7),
    @JobDate datetime2 (7)
)
AS
BEGIN
UPDATE [dbo].[PreNotification]
SET  OpeningDate = @OpeningDate,
     ClosingDate = @ClosingDate,
     JobDate = @JobDate
WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTrialBalance]    Script Date: 17/05/2021 11:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
USE [master]
GO
ALTER DATABASE [DB_A69507_kkdatabase] SET  READ_WRITE 
GO


DELETE FROM [dbo].[AssetMapping]
GO
DELETE FROM [dbo].[__EFMigrationsHistory]
GO
DELETE FROM [dbo].[AspNetUserTokens]
GO
DELETE FROM [dbo].[AspNetUserLogins]
GO
DELETE FROM [dbo].[AspNetUserClaims]
GO
DELETE FROM [dbo].[AspNetUserRoles]
GO
DELETE FROM [dbo].[AspNetUsers]
GO
DELETE FROM [dbo].[AspNetRoleClaims]
GO
DELETE FROM [dbo].[AspNetRoles]
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'SystemAdmin', N'SYSTEMADMIN', N'449300eb-750c-49d6-8880-57075defa892')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'User', N'USER', N'99251510-2bcc-4d8f-a03c-eff878edae0e')
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [DateCreated], [IsActive]) VALUES (8, N'jookoyoski@gmail.com', N'JOOKOYOSKI@GMAIL.COM', N'jookoyoski@gmail.com', N'JOOKOYOSKI@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEJu66oQbjuLd17bvWZ/9XQvmsKg0rXYKDarIsy8uqPl+JT7yYjvsfHBOY6yd6oePXA==', N'3HQSJ3Z3CFSXHK5LNAEMXVWLAOYF7SQ5', N'580d09c5-58c5-4762-a87c-bb4b5d4faead', N'07039260209', 0, 0, NULL, 1, 0, N'adeola', N'oladeinde', CAST(N'2021-01-18T22:58:31.5658080' AS DateTime2), 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [DateCreated], [IsActive]) VALUES (9, N'afolasayokazeem@kkc-ps.com', N'AFOLASAYOKAZEEM@KKC-PS.COM', N'afolasayokazeem@kkc-ps.com', N'AFOLASAYOKAZEEM@KKC-PS.COM', 1, N'AQAAAAEAACcQAAAAEFFUt57QhbzDSm3itrv8ooPFnD9FpqoraNPwSiJKGQoguJagUjruYJWAPkCcPsYm6A==', N'LMZCCXG5ANR45YRHGMMETEJ4EQ4Y7UFY', N'df90e9ed-2811-4827-b24e-4336b77d7fe3', N'08023222482', 0, 0, NULL, 1, 0, N'Afolasayo', N'Kazeem', CAST(N'2021-01-22T11:18:25.4987348' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (8, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (9, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (8, 2)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (9, 2)
SET IDENTITY_INSERT [dbo].[AssetMapping] ON 

INSERT [dbo].[AssetMapping] ([Id], [AssetName], [Initial], [Annual]) VALUES (1, N'Leasehold Improvements', 15, 10)
INSERT [dbo].[AssetMapping] ([Id], [AssetName], [Initial], [Annual]) VALUES (2, N'Plant & Machinery', 50, 25)
INSERT [dbo].[AssetMapping] ([Id], [AssetName], [Initial], [Annual]) VALUES (3, N'Furniture & Fittings', 25, 20)
INSERT [dbo].[AssetMapping] ([Id], [AssetName], [Initial], [Annual]) VALUES (4, N'Motor Vehicles', 50, 25)
INSERT [dbo].[AssetMapping] ([Id], [AssetName], [Initial], [Annual]) VALUES (5, N'Office Equipment', 50, 25)
INSERT [dbo].[AssetMapping] ([Id], [AssetName], [Initial], [Annual]) VALUES (6, N'IT Equipment', 50, 25)
INSERT [dbo].[AssetMapping] ([Id], [AssetName], [Initial], [Annual]) VALUES (7, N'Building', 15, 10)
INSERT [dbo].[AssetMapping] ([Id], [AssetName], [Initial], [Annual]) VALUES (8, N'Network Operating Communication', 50, 25)
INSERT [dbo].[AssetMapping] ([Id], [AssetName], [Initial], [Annual]) VALUES (9, N'Network Radios', 50, 25)
INSERT [dbo].[AssetMapping] ([Id], [AssetName], [Initial], [Annual]) VALUES (10, N'Communication Equipment', 50, 25)
SET IDENTITY_INSERT [dbo].[AssetMapping] OFF
