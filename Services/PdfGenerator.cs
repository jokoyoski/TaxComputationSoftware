

using System;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationSoftware.Services
{
    public class PdfGenerator
    {
        private readonly IEmailService _emailService;
        public PdfGenerator(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public void GeneratePdf()
        {
            MemoryStream ms = new MemoryStream();
            Document document = new Document(PageSize.A4, 67, 62, 40, 130);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, ms);
            PdfPCell cell = null;
            Action<PdfPTable, string, iTextSharp.text.Font> addTableCell = (table, value, font) =>
            {
                cell = new PdfPCell(new Phrase(value, font));
                cell.VerticalAlignment = Element.ALIGN_LEFT;
                cell.BorderColorBottom = BaseColor.DARK_GRAY;
                cell.Border = 0;
                cell.MinimumHeight = 10f;
                cell.NoWrap = false;
                cell.HorizontalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cell);
            };


            Chunk companyName = new Chunk("BEST MOBILE LIMITED\n2020 INCOME TAX COMPUTATION\nACCOUNTS FOR THE YEAR ENDED DECEMBER 31ST, 2019\n\n\n\nINCOME TAX\n");
            var para = new Phrase();
            para.Add(companyName);
            document.Open();
            document.Add(para);
            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = 500f;
            table.LockedWidth=true;
            table.SpacingBefore=20f;
            table.SpacingAfter=30f;
            table.SetWidthPercentage(new float[] { 250f, 125f, 125f }, PageSize.A4);
            //table.AddCell(cell);
            table.AddCell(" ");
            table.AddCell("₦");
            table.AddCell("₦");
            #region profit and loss per account
            table.AddCell("Profit/Loss per accounts");
            table.AddCell(" ");
            table.AddCell("₦300,000");
            #endregion
            table.AddCell(" ");
            table.AddCell(" ");
            table.AddCell(" ");
            #region DisAllowable Expenses
             table.AddCell( new Phrase("Add: DisAllowable Expenses", FontFactory.GetFont("verdana",15, iTextSharp.text.Font.BOLD)));
            table.AddCell(" ");
            table.AddCell(" ");

            table.AddCell("Depreciation");
            table.AddCell("3256,89");
            table.AddCell(" ");

            table.AddCell("Second Value");
            table.AddCell("7256,89");
            table.AddCell("2333,12");
            #endregion


            #region Allowable Income
            table.AddCell( new Phrase("Add: Allowable Income", FontFactory.GetFont("verdana",13, iTextSharp.text.Font.BOLD)));
            table.AddCell(" ");
            table.AddCell(" ");

            table.AddCell("Depreciation");
            table.AddCell("3256,89");
            table.AddCell(" ");

            table.AddCell("Second Value");
            table.AddCell("7256,89");
            table.AddCell("2333,12");
            #endregion

            table.AddCell(" ");
            table.AddCell(" ");
            table.AddCell(" ");


            #region Assessable Gain and Loss
            table.AddCell("Assessable Loss");
            table.AddCell(" ");
            table.AddCell("2333,12");
            #endregion

            #region Balancing Charge
            table.AddCell("Balancing Charge");
            table.AddCell(" ");
            table.AddCell("2333,12");

            table.AddCell(" ");
            table.AddCell(" ");
            table.AddCell("9333,12");
            #endregion


            document.Add(table);
            document.Add(new Chunk(" "));
            document.Close();
            byte[] values = ms.ToArray();
            _emailService.SendPdf(values);

        }
    }
}