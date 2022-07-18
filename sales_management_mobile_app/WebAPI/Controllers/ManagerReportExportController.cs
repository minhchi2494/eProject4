using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerReportExportController : ControllerBase
    {
        private ManagerReportExportServices _service;
        private string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private string fileName = "ManagerReport.xlsx";

        public ManagerReportExportController(ManagerReportExportServices service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult DownloadExport()
        {
            return File(_service.CreateFullExport(), contentType, fileName);
        }
    }
}
