
using Application.Repository;
using CsvHelper;
using System.Globalization;
using ToDoList.Applications.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ToDoList.Applications.Services
{
  public class ExportService : IExportService
  {
    private readonly IToDoRepository _todoRepository;

    public ExportService(IToDoRepository repository)
    {
      _todoRepository = repository;
    }
    public async Task<byte[]> Export2Csv()
    {
      var todoItems = await _todoRepository.GetCurrentToDosAsync();

      using (var memoryStream = new MemoryStream())
      using (var writer = new StreamWriter(memoryStream))
      using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
      {
        csv.WriteRecords(todoItems);
        writer.Flush();
        return memoryStream.ToArray();
      }
    }

    public async Task<byte[]> Export2Pdf()
    {
      var todoItems = await _todoRepository.GetCurrentToDosAsync();

      using (var memoryStream = new MemoryStream())
      {
        Document document = new Document();
        PdfWriter.GetInstance(document, memoryStream);
        document.Open();

        document.Add(new Paragraph("ToDo List"));
        document.Add(new Paragraph(" "));

        PdfPTable table = new PdfPTable(3);

        //headers
        table.AddCell("Title");
        table.AddCell("Date Created");
        table.AddCell("Is Done");

        // Add rows
        foreach (var item in todoItems)
        {
          table.AddCell(item.title);
          table.AddCell(item.dateCreated.ToString());
          table.AddCell(item.isDone ? "Yes" : "No");
        }

        document.Add(table);
        document.Close();

        return memoryStream.ToArray();
      }
    }
  }
}
