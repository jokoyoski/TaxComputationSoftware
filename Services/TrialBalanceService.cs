using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Aspose.Cells;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationAPI.Dtos;

namespace TaxComputationAPI.Services
{
    public class TrialBalanceService : ITrialBalanceService
    {
        private readonly ITrialBalanceRepository _trialBalancerepository;
        private readonly ILogger<TrialBalanceService> _logger;

        public TrialBalanceService(ITrialBalanceRepository trialBalanceRepository, ILogger<TrialBalanceService> logger)
        {
            _trialBalancerepository = trialBalanceRepository;
            _logger = logger;
        }
        public async Task UpdateTrialBalance(int trialBalanceId, string mappedTo)
        {
            _trialBalancerepository.UpdateTrialBalance(trialBalanceId, mappedTo);
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
                    DateCreated = DateTime.UtcNow
                };


                var saveTrack = await _trialBalancerepository.AddTrackTrialBalance(track);

                trackId = (saveTrack.Id <= 0) ? 0 : track.Id;

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
            }

            return dataTable;
        }

    }
}