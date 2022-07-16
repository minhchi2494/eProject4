using WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.IO;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ExportService
    {
        private readonly Project4Context _context;

        public ExportService(Project4Context context)
        {
            _context = context;
        }

        private byte[] ConvertToByte(XLWorkbook workbook)
        {
            var stream = new MemoryStream();
            workbook.SaveAs(stream);

            var content = stream.ToArray();
            return content;
        }

        public byte[] CreateFullExport()
        {
            var workbook = new XLWorkbook();
            workbook.Properties.Title = "Daily Sales";
            workbook.Properties.Author = "Chi Author";
            workbook.Properties.Subject = "Report";
            workbook.Properties.Keywords = "Export, Chi, Blazor";

            CreateAuthorWorksheet(workbook);
            return ConvertToByte(workbook);
        }

        public void CreateAuthorWorksheet(XLWorkbook package)
        {
            var worksheet = package.Worksheets.Add("Report");

            worksheet.Cell(1, 1).Value = "OrderId";
            worksheet.Cell(1, 2).Value = "Salesman";
            worksheet.Cell(1, 3).Value = "StoreName";
            worksheet.Cell(1, 4).Value = "ProductName";
            worksheet.Cell(1, 5).Value = "ActualQuantity";
            worksheet.Cell(1, 6).Value = "CreatedOn";


            var a = _context.Reports.ToList();
            for (int i = 1; i <= a.Count; i++)
            {
                worksheet.Cell(i + 1, 1).Value = a[i - 1].OrderId;
                worksheet.Cell(i + 1, 2).Value = a[i - 1].Salesman;
                worksheet.Cell(i + 1, 3).Value = a[i - 1].StoreName;
                worksheet.Cell(i + 1, 4).Value = a[i - 1].ProductName;
                worksheet.Cell(i + 1, 5).Value = a[i - 1].ActualQuantity;
                worksheet.Cell(i + 1, 6).Value = a[i - 1].CreatedOn;
            }
        }
    }
}
