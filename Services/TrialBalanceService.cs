using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;
using TrialBalance = TaxComputationAPI.Models.TrialBalance;
//using TaxComputationAPI.Dtos;

namespace TaxComputationAPI.Services
{
    public class TrialBalanceService : ITrialBalanceService
    {
        private readonly ITrialBalanceRepository _trialBalancerepository;
        private readonly ILogger<TrialBalanceService> _logger;
        private readonly IMinimumTaxService _minimumTaxService;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly IEmailService _emailService;

        public TrialBalanceService(ITrialBalanceRepository trialBalanceRepository, 
        IUtilitiesRepository utilitiesRepository, IEmailService emailService, 
        ILogger<TrialBalanceService> logger, IMinimumTaxService minimumTaxService,
        ICompaniesRepository companiesRepository)
        {
            _trialBalancerepository = trialBalanceRepository;
            _logger = logger;
            _minimumTaxService = minimumTaxService;
            _companiesRepository = companiesRepository;
            _utilitiesRepository = utilitiesRepository;
            _emailService = emailService;
        }
        public async Task UpdateTrialBalance(int trialBalanceId, string mappedTo, bool isDelete)
        {
            _trialBalancerepository.UpdateTrialBalance(trialBalanceId, mappedTo, isDelete);
        }

        public async Task<List<TrialBalance>> GetTrialBalance(int companyId, int yearId)
        {
            if (companyId <= 0 && yearId <= 0) return null;


            var trialBalance = new List<TrialBalance>();

            try
            {
                var track = await _trialBalancerepository.GetTrackTrialBalance(companyId, yearId);

                if (track == null) return null;

                trialBalance = await _trialBalancerepository.GetTrialBalance(track.Id);

                if (trialBalance == null) return null;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }


            return trialBalance;

        }

        public async Task<TrialBalance> GetTrialBalanceById(int trialBalanceId)
        {
            return await _trialBalancerepository.GetTrialBalanceById(trialBalanceId);
        }

        public async Task UploadTrialBalance(UploadTrackTrialBalanceDto upload)
        {
            if (upload == null) return;

            DataTable data = await ExtraDataFromSheet(upload.File);

            if (data == null) return;

            int trackId = 0;

            var exist = await _trialBalancerepository.GetTrackTrialBalance(upload.CompanyId, upload.YearId);

            if (exist != null)
            {

                var trialBalanceRecord = await _trialBalancerepository.GetTrialBalance(exist.Id);

                foreach (var trialBalance in trialBalanceRecord)
                {
                    await _trialBalancerepository.RemoveTrackTrialBalance(trialBalance);
                }

                trackId = (exist.Id <= 0) ? 0 : exist.Id;
            }
            else
            {

                TrackTrialBalance track = new TrackTrialBalance
                {
                    CompanyId = upload.CompanyId,
                    YearId = upload.YearId,
                    DateCreated = DateTime.UtcNow,

                };


                var saveTrack = await _trialBalancerepository.AddTrackTrialBalance(track);

                var saved = await _trialBalancerepository.GetTrackTrialBalance(upload.CompanyId, upload.YearId);

                trackId = saved.Id;

            }


            foreach (DataRow cell in data.Rows)
            {

                TrialBalance trialBalance = new TrialBalance();

                trialBalance.AccountId = cell.ItemArray[0].ToString();

                trialBalance.Item = cell.ItemArray[1].ToString();

                string trialBalanceDebit = cell.ItemArray[2].ToString().Replace(",", "");
                decimal.TryParse(trialBalanceDebit, out decimal debit);
                trialBalance.Debit = debit;

                string trialBalanceCredit = cell.ItemArray[3].ToString().Replace(",", "");
                decimal.TryParse(trialBalanceCredit, out decimal credit);
                trialBalance.Credit = credit;

                trialBalance.IsCheck = false;
                trialBalance.MappedTo = string.Empty;
                trialBalance.TrackId = trackId;
                trialBalance.IsCheck = false;
                trialBalance.IsRemoved = false;

                try
                {
                    await _trialBalancerepository.UploadTrialBalance(trialBalance);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
            }
        }

        private async Task<DataTable> ExtraDataFromSheet(IFormFile excel)
        {
            if (excel == null) return null;

            DataTable dataTable = default(DataTable);

            try
            {
                using (Stream excelFile = excel.OpenReadStream())
                {
                    TxtLoadOptions opts = new TxtLoadOptions();
                    opts.Separator = ',';
                    opts.HasFormula = true;
                    opts.MemorySetting = MemorySetting.MemoryPreference;

                    using (Workbook workbook = new Workbook(excelFile, opts))
                    {
                        Worksheet worksheet = workbook.Worksheets[0];
                        RowCollection row = worksheet.Cells.Rows;

                        if (row == null || row.Count < 1) return null;

                        int rowLength = worksheet.Cells.MaxDataRow + 1;
                        int columnLength = worksheet.Cells.MaxColumn + 1;

                        dataTable = worksheet.Cells.ExportDataTableAsString(1, 0, rowLength, columnLength);

                        if (dataTable == null) return null;
                    }
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);
            }

            return dataTable;
        }


        public async Task<byte[]> DownloadExcel(int companyId, int yearId)
        {
           var comp = await _companiesRepository.GetCompanyAsync(companyId);

           if(comp == null) return null;

           var oldMinimumTax = await _minimumTaxService.GetOldMinimumTax(companyId, yearId);

           if(oldMinimumTax == null) return null;

           string companyName = comp.CompanyName;
           string dateOfDocument = comp.ClosingYear.ToString("dd MMMM yyyy");
           string documentTitle = DocumentTitle.OldMinimumTax;
           string documentDescription = $"ACCOUNTS FOR THE YEAR END {dateOfDocument}";

            //Instantiate a Workbook object that represents Excel file.
            Workbook wb = new Workbook();

            //Note when you create a new workbook, a default worksheet
            //"Sheet1" is added (by default) to the workbook. 
            //Access the first worksheet "Sheet1" in the book.
            Worksheet sheet = wb.Worksheets[0];

            // Adding generic style
            Style style = wb.CreateStyle();
            style.Font.Size = 15;
            style.Font.Name = "Century Gothic";

            //Header style
            Style styleHeader = wb.CreateStyle();
            styleHeader.Font.Size = 15;
            styleHeader.Font.Name = "Century Gothic";
            styleHeader.Font.IsBold = true;
            styleHeader.VerticalAlignment = TextAlignmentType.Center;

            //Double bottom Border style
            Style styleBottomBorder = wb.CreateStyle();
            styleBottomBorder.Font.Size = 15;
            styleBottomBorder.Font.Name = "Century Gothic";
            styleBottomBorder.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Double;

            //Access the "A1" cell in the sheet.
            Cells cells = sheet.Cells;

            //Company Name
            cells.Merge(0, 0, 1, 6);
            //Description
            cells.Merge(2, 0, 1, 6);
            //Document Title
            cells.Merge(4, 0, 1, 6);

            Cell cell1 = sheet.Cells["A1"];
            cell1.PutValue($"{companyName}");
            cell1.SetStyle(styleHeader);

            Cell cell2 = sheet.Cells["A3"];
            cell2.PutValue($"{documentDescription}");
            cell2.SetStyle(styleHeader);


            Cell cell3 = sheet.Cells["A5"];
            cell3.PutValue($"{documentTitle}");
            cell3.SetStyle(styleHeader);
            

            //Weird line of thought
            Style styleHeaderCentered = wb.CreateStyle();
            styleHeaderCentered.Font.Size = 15;
            styleHeaderCentered.Font.Name = "Century Gothic";
            styleHeaderCentered.Font.IsBold = true;
            styleHeaderCentered.VerticalAlignment = TextAlignmentType.Center;
            styleHeaderCentered.HorizontalAlignment = TextAlignmentType.Center;

            Cell cell4 = sheet.Cells["K7"];
            cell4.PutValue($"=N=");
            cell4.SetStyle(styleHeaderCentered);

            Cell cell5 = sheet.Cells["N7"];
            cell5.PutValue($"=N=");
            cell5.SetStyle(styleHeaderCentered);
            
            cells.Merge(7, 0, 1, 6);
            Cell cell6 = sheet.Cells["A8"];
            cell6.SetStyle(style);
            cell6.PutValue("Highest of:");


            int count = 9;
            int num = 1;        


            foreach(var item in oldMinimumTax.Values)
            {

                cells.Merge(count, 1, 1, 6);
                
                //Serial number 
                var number = sheet.Cells[$"A{count}"];
                number.SetStyle(style);
                number.PutValue($"({num})");

                //the cells details for name
                var cellName = sheet.Cells[$"B{count}"];
                cellName.SetStyle(style);
                cellName.PutValue($"{item.Name}");


                //the cells details for value 1
                if(!string.IsNullOrEmpty(item.Value1) && !item.Value1.Equals("0"))
                {
                    var cellValue1 = sheet.Cells[$"K{count}"];
                    cellValue1.SetStyle(styleBottomBorder);
                    cellValue1.PutValue($"{item.Value1.ValueMoneyFormatter("NGN", false)}");
                }
                
                //the cell details for value 2
                if(!string.IsNullOrEmpty(item.Value2) && !item.Value2.Equals("0"))
                {
                    var cellValue2 = sheet.Cells[$"N{count}"];
                    cellValue2.SetStyle(styleBottomBorder);
                    cellValue2.PutValue($"{item.Value2.ValueMoneyFormatter("NGN", false)}");
                }

                num++;
                count++;
            }

            //Save the Excel file.
            return wb.SaveToStream().ToArray();
        } 
    }

    public static class DocumentTitle
    {
        public const string OldMinimumTax = "MINIMUM TAX COMPUTATION";
    }
}