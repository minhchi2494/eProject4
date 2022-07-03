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
            workbook.Properties.Subject = "Store Sales Detail";
            workbook.Properties.Keywords = "Export, Chi, Blazor";

            CreateAuthorWorksheet(workbook);
            return ConvertToByte(workbook);
        }

        public void CreateAuthorWorksheet(XLWorkbook package)
        {
            var worksheet = package.Worksheets.Add("StoreSalesDetail");

            worksheet.Cell(1, 1).Value = "ProductId";
            worksheet.Cell(1, 2).Value = "OrderId";
            //worksheet.Cell(1, 3).Value = "UserId";
            worksheet.Cell(1, 3).Value = "ActualQuantity";
            //worksheet.Cell(1, 4).Value = "Date";


            var a = _context.OrderDetails.ToList();
            for (int i = 1; i <= a.Count; i++)
            {
                worksheet.Cell(i + 1, 1).Value = a[i - 1].ProductId;
                worksheet.Cell(i + 1, 2).Value = a[i - 1].OrderId;
                //worksheet.Cell(i + 1, 3).Value = a[i - 1].UserId;
                worksheet.Cell(i + 1, 3).Value = a[i - 1].ActualQuantity;
                //worksheet.Cell(i + 1, 4).Value = a[i - 1].Date;
            }
        }
    }
}
