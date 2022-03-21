using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using OfficeOpenXml;
using WebAPI.Services;

namespace practice_codefirst2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {

        private readonly IStoreSalesDetailServices _service;

        public ImportController(IStoreSalesDetailServices service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {

            var stream = file.OpenReadStream();
            List<StoreSalesDetail> list = new List<StoreSalesDetail>();
            try
            {
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.First();//package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (var row = 1; row <= rowCount; row++)
                    {
                        try
                        {

                            var ProductId = worksheet.Cells[row + 1, 1].Value?.ToString();
                            var StoreId = worksheet.Cells[row + 1, 2].Value?.ToString();
                            var UserId = worksheet.Cells[row + 1, 3].Value?.ToString();
                            var StoreActualQuantity = worksheet.Cells[row + 1, 4].Value?.ToString();
                            var Date = worksheet.Cells[row + 1, 5].Value?.ToString();

                            var ssd = new StoreSalesDetail()
                            {
                                ProductId = ProductId,
                                StoreId = StoreId,
                                UserId = int.Parse(UserId),
                                StoreActualQuantity = int.Parse(StoreActualQuantity),
                                Date = DateTime.Parse(Date),
                            };
                            _service.createStoreSalesDetail(ssd);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            };

            return Ok();
        }

    }
}
