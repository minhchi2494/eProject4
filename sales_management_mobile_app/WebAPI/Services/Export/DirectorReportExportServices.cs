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
    public class DirectorReportExportServices
    {
        private readonly Project4Context _context;

        public DirectorReportExportServices(Project4Context context)
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
            workbook.Properties.Subject = "DirectorReport";
            workbook.Properties.Keywords = "Export, Chi, Blazor";

            CreateAuthorWorksheet(workbook);
            return ConvertToByte(workbook);
        }

        public void CreateAuthorWorksheet(XLWorkbook package)
        {
            var worksheet = package.Worksheets.Add("DirectorReport");

            worksheet.Cell(1, 1).Value = "DirectorId";
            worksheet.Cell(1, 2).Value = "Director";
            worksheet.Cell(1, 3).Value = "Store";
            worksheet.Cell(1, 4).Value = "Product";
            worksheet.Cell(1, 5).Value = "ActualQuantity";
            worksheet.Cell(1, 6).Value = "CreatedOn";


            var a = _context.vDirectorReports.ToList();
            for (int i = 1; i <= a.Count; i++)
            {
                worksheet.Cell(i + 1, 1).Value = a[i - 1].DirectorId;
                worksheet.Cell(i + 1, 2).Value = a[i - 1].Director;
                worksheet.Cell(i + 1, 3).Value = a[i - 1].Store;
                worksheet.Cell(i + 1, 4).Value = a[i - 1].Product;
                worksheet.Cell(i + 1, 5).Value = a[i - 1].ActualQuantity;
                worksheet.Cell(i + 1, 6).Value = a[i - 1].CreatedOn;
            }
        }
    }
}
