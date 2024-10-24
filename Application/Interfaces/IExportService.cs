

namespace ToDoList.Applications.Interfaces
{
  public interface IExportService
  {
    Task<byte[]> Export2Pdf();
    Task<byte[]> Export2Csv();
  }
}
