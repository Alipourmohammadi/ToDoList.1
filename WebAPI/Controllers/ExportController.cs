using Microsoft.AspNetCore.Mvc;
using ToDoList.Applications.Interfaces;

namespace ToDoList.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ExportController : ControllerBase
  {
    private readonly IExportService _exportService;
    public ExportController(IExportService exportService)
    {
      _exportService = exportService;
    }
    [HttpGet("export-csv")]
    public async Task<IActionResult> ExportCsv()
    {
      var csvData = await _exportService.Export2Csv();
      return File(csvData, "text/csv", "todoItems.csv");
    }

    [HttpGet("export-pdf")]
    public async Task<IActionResult> ExportPdf()
    {
      try
      {

        var pdfData = await _exportService.Export2Pdf();
        return File(pdfData, "application/pdf", "todoItems.pdf");
      }
      catch (Exception ex)
      {
        return BadRequest($"Error generating PDF: {ex.Message}");
      }
    }
  }
}
